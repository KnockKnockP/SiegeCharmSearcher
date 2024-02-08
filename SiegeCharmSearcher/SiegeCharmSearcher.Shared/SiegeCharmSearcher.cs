using System.Diagnostics;
using System.Drawing;
using Tesseract;

namespace SiegeCharmSearcher.Shared {
    public class SiegeCharmSearcher {
        private readonly Process process;
        public Settings settings = new();
        
        public volatile bool analyzing = false;
        private const string blacklisted = "=[]\\;,./~!@#$%^&*()_+{}|:\"<>?[\n";
        private readonly TesseractEngine tesseractEngine = new("./tessdata-4.1.0", "eng", EngineMode.TesseractAndLstm);

        public MarkableObservableCollection<Charm> charms = [];

        public volatile bool navigating = false;

        public SiegeCharmSearcher() {
            try {
                WindowsWrapper.FindProcessOfNames(["RainbowSix_Vulkan"]);
                throw new VulkanNotSupportedException();
            } catch (ProcessNotFoundException) {}

            process = WindowsWrapper.FindProcessOfNames(["RainbowSix"]);

            Settings? loaded = LoadSettings();
            if (loaded == null) {
                settings = new Settings {
                    resolution = WindowsWrapper.GetResolution()
                };
            } else {
                settings = loaded;
            }
        }

        public void SaveSettings() {
            if (settings == null) {
                return;
            }

            FileManager.SaveAsJson(settings.SerializeAsJson(), FileManager.SettingsFilePath);
        }

        private static Settings? LoadSettings() {
            Settings loaded = new();
            try {
                loaded.LoadFromJson(FileManager.ReadJson(FileManager.SettingsFilePath));
            } catch (Exception) {
                return null;
            }
            return loaded;
        }

        private static bool AnalyzePresent(Screenshot screenshot) {
            Color color = screenshot.presentImage.GetPixel(0, 0);
            screenshot.presentColor = color;

            byte maximum = 35;
            return (MathHelper.InBetweenInclusive(color.R, 0, maximum) &&
                    MathHelper.InBetweenInclusive(color.G, 0, maximum) &&
                    MathHelper.InBetweenInclusive(color.B, 0, maximum));
        }

        public void StartAnalyzing(IProgress<Bitmap> analyzingNameImage,
                                   IProgress<Bitmap> analyzingOwnedImage,
                                   IProgress<Color> analyzingPresentColor,
                                   IProgress<string> status,
                                   IProgress<Charm> analyzedCharm) {
            analyzing = true;
            navigating = false;
            charms.Clear();
            WindowsWrapper.BringWindowUpFront(process.MainWindowHandle);

            Vector2Int position = new(0, 0);
            int retryCount = 0;

            void IncrementPosition() {
                if (++position.x > 2) {
                    position.x = 0;
                    ++position.y;
                }

                SendKeyAndSleep(Direction.Right);
            }

            void AddCharm(Charm charm) {
                charms.Add(charm);
                analyzedCharm.Report(charm);
            }

            while (true) {
                if (!analyzing) {
                    break;
                }

                status.Report(string.Empty);

                if (retryCount >= 10) {
                    status.Report(Messages.Skipping);
                    retryCount = 0;

                    AddCharm(new Charm() {
                        name = Messages.SkippedCharm,
                        position = position
                    });

                    IncrementPosition();
                    continue;
                }

                Screenshot screenshot = new(settings.resolution);
                screenshot.charm.position = position;
                bool success = AnalyzeCharmName(screenshot);
                analyzingNameImage.Report(screenshot.nameImage);

                if (!success) {
                    status.Report(string.Format(Messages.RetryCount, retryCount++));
                    Thread.Sleep(settings.delay);
                    continue;
                }

                AnalyzeOwned(screenshot);
                analyzingOwnedImage.Report(screenshot.ownedImage);

                bool isPresent = AnalyzePresent(screenshot);
                analyzingPresentColor.Report(screenshot.presentColor);

                if ((position != new Vector2Int(0, 0)) &&
                    (!screenshot.owned.Contains("OW", StringComparison.InvariantCultureIgnoreCase)) &&
                    (!isPresent)) {
                    break;
                }

                retryCount = 0;
                AddCharm(screenshot.charm);

                IncrementPosition();
            }

            status.Report(Messages.StoppedAnalyzing);
            analyzing = false;
        }

        private bool AnalyzeCharmName(Screenshot screenshot) {
            screenshot.Capture();
            using Page page = tesseractEngine.Process(screenshot.nameImage);

            string charmName = page.GetText().RemoveAllCharactersInString(blacklisted);
            screenshot.charm.name = charmName;

            page.Dispose();

            return ((charmName.Length != 0) &&
                    (!charmName.OnlyContains(' ')) &&
                    ((charms.Count == 0) || (charmName != charms[^1].name)));
        }

        private void AnalyzeOwned(Screenshot screenshot) {
            using Page page = tesseractEngine.Process(screenshot.ownedImage);

            screenshot.owned = page.GetText().RemoveAllCharactersInString(blacklisted);
            page.Dispose();
        }

        public void NavigateTo(Charm charm, IProgress<string> status) {
            analyzing = false;
            navigating = true;
            status.Report(string.Format(Messages.NavigatingTo, charm.position));

            WindowsWrapper.BringWindowUpFront(process.MainWindowHandle);
            Screenshot screenshot = new(settings.resolution);

            int retryCount = 0;
            Charm? foundCharm = null;
            while (true) {
                if (!navigating) {
                    break;
                }

                foreach (Charm _charm in charms) {
                    if (_charm.name == screenshot.charm.name) {
                        foundCharm = _charm;
                        break;
                    }
                }

                if (!AnalyzeCharmName(screenshot) || (foundCharm == null)) {
                    status.Report(string.Format(Messages.RetryCount, retryCount++));
                    Thread.Sleep(settings.delay);
                    continue;
                }

                status.Report(string.Format(Messages.StandingOn, foundCharm.name, foundCharm.position));
                break;
            }

            Vector2Int target = charm.position, current = foundCharm.position;
            if (target == current) {
                status.Report(Messages.AlreadySamePlace);
                return;
            }

            if (target.x < current.x) {
                while (target.x < current.x--) {
                    SendKeyAndSleep(Direction.Left);
                }
            } else {
                while (target.x > current.x++) {
                    SendKeyAndSleep(Direction.Right);
                }
            }

            if (target.y < current.y) {
                while (target.y < current.y--) {
                    SendKeyAndSleep(Direction.Up);
                }
            } else {
                while (target.y > current.y++) {
                    SendKeyAndSleep(Direction.Down);
                }
            }

            navigating = false;
            status.Report(Messages.NavigationDone);
        }

        //This is probably replacable with WH_JOURNALPLAYBACK but this will do for now.
        private void SendKeyAndSleep(Direction direction) {
            switch (direction) {
                case Direction.Up:
                    Process.Start("./Scripts/W.exe").WaitForExit();
                    break;
                case Direction.Left:
                    Process.Start("./Scripts/A.exe").WaitForExit();
                    break;
                case Direction.Down:
                    Process.Start("./Scripts/S.exe").WaitForExit();
                    break;
                case Direction.Right:
                    Process.Start("./Scripts/D.exe").WaitForExit();
                    break;
            }

            Thread.Sleep(settings.delay);
        }

        public void Save(string path) {
            FileManager.SaveAsJson(charms.SerializeAsJson(), path);
        }

        public void Load(string path) {
            charms.LoadFromJson(path);
        }
    }
}