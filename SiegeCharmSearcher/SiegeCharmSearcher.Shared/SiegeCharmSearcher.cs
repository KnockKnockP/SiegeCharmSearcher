using System.Diagnostics;
using System.Drawing;
using Tesseract;

namespace SiegeCharmSearcher.Shared {
    public class SiegeCharmSearcher {
        private readonly Process process;
        internal Resolution Resolution { get; private set; }

        private bool stopAnalyzing;
        private readonly TesseractEngine tesseractEngine = new("./tessdata-4.1.0", "eng", EngineMode.TesseractAndLstm);

        public readonly List<Charm> charms = [];

        public SiegeCharmSearcher() {
            process = WindowsWrapper.FindProcessOfNames([
                "RainbowSix"
            ]);
            Resolution = WindowsWrapper.GetResolution();
        }

        public void StartAnalyzing(IProgress<Bitmap> analyzingImage,
                                   IProgress<string> warning,
                                   IProgress<Charm> analyzedCharm) {
            stopAnalyzing = false;
            charms.Clear();
            
            Vector2Int position = new(0, 0);
            int retryCount = 0;

            void SelectNext() {
                SendD();
                Thread.Sleep(500);
            }

            void IncrementPosition() {
                if (++position.x > 2) {
                    position.x = 0;
                    ++position.y;
                }

                SelectNext();
            }

            void AddCharm(Charm charm) {
                charms.Add(charm);
                analyzedCharm.Report(charm);
            }

            WindowsWrapper.BringWindowUpFront(process.MainWindowHandle);
            while (true) {
                if (stopAnalyzing) {
                    warning.Report("Stopped anal.");
                    break;
                }

                warning.Report("");

                if (retryCount >= 5) {
                    warning.Report("Skipping.");
                    retryCount = 0;

                    AddCharm(new Charm() {
                        name = "(SKIPPED)",
                        position = position
                    });

                    IncrementPosition();
                    continue;
                }

                Screenshot screenshot = new(Resolution);
                screenshot.charm.position = position;
                bool success = AnalyzeCharmName(screenshot);
                analyzingImage.Report(screenshot.image);

                if (!success) {
                    warning.Report($"Retry count: {retryCount++}");
                    Thread.Sleep(250);
                    continue;
                }

                if (screenshot.charm.name.Equals("view more", StringComparison.CurrentCultureIgnoreCase)) {
                    warning.Report("END OF IN GAME LIST");
                    break;
                }

                retryCount = 0;
                AddCharm(screenshot.charm);

                IncrementPosition();
            }
        }

        private bool AnalyzeCharmName(Screenshot screenshot) {
            screenshot.Capture();
            using Page page = tesseractEngine.Process(screenshot.image);

            string charmName = page.GetText().RemoveAllCharactersInString("=[]\\;,./~!@#$%^&*()_+{}|:\"<>?[\n");
            screenshot.charm.name = charmName;

            page.Dispose();

            return ((charmName.Length != 0) &&
                    (!charmName.OnlyContains(' ')) &&
                    ((charms.Count == 0) || (charmName != charms[^1].name)));
        }

        public void StopAnalyzing() {
            stopAnalyzing = true;
        }

        //This is probably replacable with WH_JOURNALPLAYBACK but this will do for now.
        internal void SendW() {
            WindowsWrapper.BringWindowUpFront(process.MainWindowHandle);
            Process.Start("./Scripts/W.exe").WaitForExit();
        }

        internal void SendA() {
            WindowsWrapper.BringWindowUpFront(process.MainWindowHandle);
            Process.Start("./Scripts/A.exe").WaitForExit();
        }

        internal void SendS() {
            WindowsWrapper.BringWindowUpFront(process.MainWindowHandle);
            Process.Start("./Scripts/S.exe").WaitForExit();
        }

        internal void SendD() {
            WindowsWrapper.BringWindowUpFront(process.MainWindowHandle);
            Process.Start("./Scripts/D.exe").WaitForExit();
        }
    }
}