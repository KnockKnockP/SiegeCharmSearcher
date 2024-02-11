using System.Diagnostics;
using System.Drawing;
using Tesseract;

namespace SiegeCharmSearcher.Shared {
    public class SiegeCharmSearcher {
        private readonly Process process;
        public Settings settings = new();
        
        private const string blacklisted = "=[]\\;,./~!@#$%^&*()_+{}|:\"<>?[\n";
        private readonly TesseractEngine tesseractEngine = new("./tessdata-4.1.0", "eng", EngineMode.TesseractAndLstm);

        public MarkableObservableCollection<Charm> charms = [];

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
                                   IProgress<Charm> analyzedCharm,
                                   CancellationToken cancellationToken) {
            Vector2Int position = new(0, 0);

            void AddCharm(Charm charm) {
                charms.Add(charm);
                analyzedCharm.Report(charm);
                status.Report(string.Format(Messages.AddedCharm, charm.name, charm.position));
                if (++position.x > 2) {
                    position.x = 0;
                    ++position.y;
                }

                SendKeyAndSleep(Direction.Right);
            }

            charms.Clear();
            WindowsWrapper.BringWindowUpFront(process.MainWindowHandle);
            while (!cancellationToken.IsCancellationRequested) {
                status.Report(string.Empty);

                if (position == new Vector2Int(0, 0)) {
                    AddCharm(new Charm() {
                        name = Messages.NoneCharm,
                        position = position
                    });
                    continue;
                }

                Screenshot screenshot = new(settings.resolution);
                screenshot.charm.position = position;

                screenshot.Capture();
                analyzingNameImage.Report(screenshot.nameImage);
                if (!AnalyzeCharmName(screenshot, status, cancellationToken)) {
                    status.Report(Messages.Skipping);

                    AddCharm(new Charm() {
                        name = Messages.SkippedCharm,
                        position = position
                    });
                    continue;
                }

                analyzingOwnedImage.Report(screenshot.ownedImage);
                AnalyzeOwned(screenshot);

                analyzingPresentColor.Report(screenshot.presentColor);
                bool isPresent = AnalyzePresent(screenshot);

                if ((!screenshot.owned.Contains("OW", StringComparison.InvariantCultureIgnoreCase)) &&
                    (!isPresent)) {
                    break;
                }

                AddCharm(screenshot.charm);
            }

            status.Report(Messages.StoppedAnalyzing);
        }

        private bool AnalyzeCharmName(Screenshot screenshot,
                                      IProgress<string> status,
                                      CancellationToken cancellationToken) {
            for (int i = 0; (i < 10 && (!cancellationToken.IsCancellationRequested)); ++i) {
                screenshot.Capture();
                using Page page = tesseractEngine.Process(screenshot.nameImage);

                string charmName = page.GetText().RemoveAllCharactersInString(blacklisted);
                screenshot.charm.name = charmName;

                page.Dispose();

                if ((charmName.Length != 0) &&
                    (!charmName.OnlyContains(' ')) &&
                    ((charms.Count == 0) || (charmName != charms[^1].name))) {
                    return true;
                }

                status.Report(string.Format(Messages.RetryCount, i));
                Thread.Sleep(settings.delay);
            }

            return false;
        }

        private void AnalyzeOwned(Screenshot screenshot) {
            using Page page = tesseractEngine.Process(screenshot.ownedImage);

            screenshot.owned = page.GetText().RemoveAllCharactersInString(blacklisted);
            page.Dispose();
        }

        public void NavigateTo(Charm charm,
                               Vector2Int? specifiedPosition,
                               IProgress<string> status,
                               CancellationToken cancellationToken) {
            Charm? foundCharm = null;

            status.Report(string.Format(Messages.NavigatingTo, charm.position));
            WindowsWrapper.BringWindowUpFront(process.MainWindowHandle);
            Screenshot screenshot = new(settings.resolution);

            if (specifiedPosition != null) {
                foundCharm = new Charm() {
                    position = specifiedPosition.Value
                };
                
                status.Report(string.Format(Messages.NavigatingFrom, specifiedPosition));
            }

            while ((foundCharm == null) && (!cancellationToken.IsCancellationRequested)) {
                bool foundName = AnalyzeCharmName(screenshot, status, cancellationToken);

                string[] names = charms.Select(c => c.name).ToArray(),
                         searched = SearchStrategies.LiteralSearchIgnoreSpaceWithoutSpaces(screenshot.charm.name, names);
                if ((!foundName) || (searched == null) || (searched.Length == 0)) {
                    status.Report(Messages.FailedToDetectPosition);
                    return;
                }
                foreach (Charm _charm in charms) {
                    if (_charm.name == searched[0]) {
                        foundCharm = _charm;
                        break;
                    }
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