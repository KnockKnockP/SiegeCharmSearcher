using System.Diagnostics;
using Tesseract;

namespace SiegeCharmSearcher.Shared {
    public class SiegeCharmSearcher {
        private readonly Process process;
        public Resolution Resolution { get; private set; }

        private bool stopAnalyzing;
        private readonly TesseractEngine tesseractEngine = new("./tessdata-4.1.0", "eng", EngineMode.TesseractAndLstm);

        public readonly List<Screenshot> screenshots = [];

        public SiegeCharmSearcher() {
            process = WindowsWrapper.FindProcessOfNames([
                "RainbowSix",
                "RainbowSix_Vulkan"
            ]);
            Resolution = WindowsWrapper.GetResolution();
        }

        public void StartAnalyzing(IProgress<Screenshot> progress) {
            screenshots.Clear();
            WindowsWrapper.BringWindowUpFront(process.MainWindowHandle);

            Vector2Int position = new(0, 0);
            while (!stopAnalyzing) {
                Screenshot screenshot = new(Resolution);

                screenshot.Capture();
                using Page page = tesseractEngine.Process(screenshot.image);
                screenshot.charmName = page.GetText().TrimEnd('\n');
                page.Dispose();
                if (screenshot.charmName.Length == 0) {
                    Thread.Sleep(250);
                    continue;
                }

                if (screenshot.charmName.Equals("view more", StringComparison.CurrentCultureIgnoreCase)) {
                    //remove past 5 entries.
                    //break;
                }

                screenshot.position = position;

                screenshots.Add(screenshot);
                progress.Report(screenshot);

                if (position.x++ > 2) {
                    position.x = 0;
                    ++position.y;
                }
                SendD();
                Thread.Sleep(200);
            }
        }

        public void StopAnalyzing() {
            stopAnalyzing = true;
        }

        //This is probably replacable with WH_JOURNALPLAYBACK but this will do for now.
        public void SendW() {
            WindowsWrapper.BringWindowUpFront(process.MainWindowHandle);
            Process.Start("./Scripts/W.exe").WaitForExit();
        }

        public void SendA() {
            WindowsWrapper.BringWindowUpFront(process.MainWindowHandle);
            Process.Start("./Scripts/A.exe").WaitForExit();
        }

        public void SendS() {
            WindowsWrapper.BringWindowUpFront(process.MainWindowHandle);
            Process.Start("./Scripts/S.exe").WaitForExit();
        }

        public void SendD() {
            WindowsWrapper.BringWindowUpFront(process.MainWindowHandle);
            Process.Start("./Scripts/D.exe").WaitForExit();
        }
    }
}