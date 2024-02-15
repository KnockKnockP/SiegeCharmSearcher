using System.Diagnostics;
using System.Drawing;

namespace SiegeCharmSearcher.Shared {
    public sealed class SiegeCharmSearcher {
        private readonly Process process;
        public Settings Settings { get; private set; } = new();

        public MarkableObservableCollection<Charm> charms = [];

        public SiegeCharmSearcher() {
            process = FindProcess();
            Settings = LoadOrCreateSettings();
        }

        private static Process FindProcess() {
            try {
                WindowsWrapper.FindProcessOfNames(["RainbowSix_Vulkan"]);
                throw new VulkanNotSupportedException();
            } catch (ProcessNotFoundException) { }

            return WindowsWrapper.FindProcessOfNames(["RainbowSix"]);
        }

        private static Settings LoadOrCreateSettings() {
            Settings? loaded = LoadSettings();
            loaded ??= new Settings {
                           Resolution = WindowsWrapper.GetResolution()
                       };
            return loaded;
        }

        public void StartAnalyzing(IProgress<AProgress> progress,
                                   IProgress<Charm> analyzedCharm,
                                   CancellationToken cancellationToken) {
            Vector2Int position = new(0, 0);

            void AddCharm(Charm charm) {
                charms.Add(charm);
                analyzedCharm.Report(charm);
                progress.Report(new ProgressMessage(string.Format(Messages.AddedCharm, charm.Name, charm.Position)));
                if (++position.x > 2) {
                    position.x = 0;
                    ++position.y;
                }

                SendKeyAndSleep(Direction.Right);
            }

            charms.Clear();
            WindowsWrapper.BringWindowUpFront(process.MainWindowHandle);
            while (!cancellationToken.IsCancellationRequested) {
                Charm charm = new(position);
                if (position == new Vector2Int(0, 0)) {
                    charm.Name = Messages.NoneCharm;
                    AddCharm(charm);
                    continue;
                }

                Screenshot screenshot = new(Settings.Resolution);
                if (!AnalyzeCharmName(charm, screenshot, progress, cancellationToken)) {
                    progress.Report(new ProgressMessage(Messages.Skipping));

                    charm.Name = Messages.SkippedCharm;
                    AddCharm(charm);
                    continue;
                }

                bool owned = screenshot.AnalyzeOwned();
                progress.Report(new ProgressImage(screenshot.OwnedImage, AnalyzingImage.Owned));

                (bool, Color) present = screenshot.AnalyzePresent();
                progress.Report(new ProgressPresent(present.Item2));

                if ((!owned) && (!present.Item1)) {
                    break;
                }

                AddCharm(charm);
            }

            progress.Report(new ProgressMessage(Messages.StoppedAnalyzing));
        }

        private bool AnalyzeCharmName(Charm charm,
                                      Screenshot screenshot,
                                      IProgress<AProgress> progress,
                                      CancellationToken cancellationToken) {
            for (int i = 0; ((i < 10) && (!cancellationToken.IsCancellationRequested)); ++i) {
                charm.Name = screenshot.AnalyzeName();
                progress.Report(new ProgressImage(screenshot.NameImage, AnalyzingImage.Name));

                if ((charm.Name.Length != 0) &&
                    (!charm.Name.OnlyContains(' ')) &&
                    ((charms.Count == 0) || (charm.Name != charms[^1].Name))) {
                    return true;
                }

                progress.Report(new ProgressMessage(string.Format(Messages.RetryCount, i)));
                Thread.Sleep(Settings.Delay);
            }

            return false;
        }

        public void NavigateTo(Charm charm,
                               Vector2Int? specifiedPosition,
                               IProgress<AProgress> progress,
                               CancellationToken cancellationToken) {
            progress.Report(new ProgressMessage(string.Format(Messages.NavigatingTo, charm.Position)));
            WindowsWrapper.BringWindowUpFront(process.MainWindowHandle);

            Charm? standingOnCharm = null;
            Screenshot screenshot = new(Settings.Resolution);
            if (specifiedPosition != null) {
                standingOnCharm = new Charm() {
                    Position = specifiedPosition.Value
                };
                
                progress.Report(new ProgressMessage(string.Format(Messages.NavigatingFrom, specifiedPosition)));
            }

            if (standingOnCharm == null) {
                standingOnCharm = new();
                bool foundName = AnalyzeCharmName(standingOnCharm, screenshot, progress, cancellationToken);

                string[] names = charms.Select(c => c.Name).ToArray(),
                         searched = SearchStrategies.LiteralSearchIgnoreSpaceWithoutSpaces(standingOnCharm.Name, names);
                if ((!foundName) || (searched == null) || (searched.Length == 0)) {
                    progress.Report(new ProgressMessage(Messages.FailedToDetectPosition));
                    return;
                }
                foreach (Charm _charm in charms) {
                    if (_charm.Name == searched[0]) {
                        standingOnCharm = _charm;
                        break;
                    }
                }

                progress.Report(new ProgressMessage(string.Format(Messages.StandingOn, standingOnCharm.Name, standingOnCharm.Position)));
            }

            Vector2Int target = charm.Position, current = standingOnCharm.Position;
            if (target == current) {
                progress.Report(new ProgressMessage(Messages.AlreadySamePlace));
                return;
            }

            while ((target.x < current.x) && (!cancellationToken.IsCancellationRequested)) {
                SendKeyAndSleep(Direction.Left);
                --current.x;
            }
            while ((target.x > current.x) && (!cancellationToken.IsCancellationRequested)) {
                SendKeyAndSleep(Direction.Right);
                ++current.x;
            }

            while ((target.y < current.y) && (!cancellationToken.IsCancellationRequested)) {
                SendKeyAndSleep(Direction.Up);
                --current.y;
            }
            while ((target.y > current.y) && (!cancellationToken.IsCancellationRequested)) {
                SendKeyAndSleep(Direction.Down);
                ++current.y;
            }

            progress.Report(new ProgressMessage(Messages.NavigationDone));
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

            Thread.Sleep(Settings.Delay);
        }

        public void Save(string path) =>
            FileManager.SaveAsJson(charms.SerializeAsJson(), path);

        public void Load(string path) => charms.LoadFromJson(path);

        public void SaveSettings() {
            if (Settings == null) {
                return;
            }

            FileManager.SaveAsJson(Settings.SerializeAsJson(), FileManager.SettingsFilePath);
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
    }
}