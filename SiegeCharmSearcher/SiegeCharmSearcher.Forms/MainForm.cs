using SiegeCharmSearcher.Shared;

namespace SiegeCharmSearcher.Forms {
    public partial class MainForm : Form {
        private readonly Shared.SiegeCharmSearcher siegeCharmSearcher;

        public MainForm() {
            InitializeComponent();

            siegeCharmSearcher = new Shared.SiegeCharmSearcher();
        }

        private async void AnalyzeButtonClick(object sender, EventArgs eventArgs) {
            charmName.Text = string.Empty;
            IProgress<Screenshot> progress = new Progress<Screenshot>(screenshot => {
                charmName.Text += $"{screenshot.charmName}: {screenshot.position}{Environment.NewLine}";
                screenshotDisplay.Image = screenshot.image;
            });
            await Task.Factory.StartNew(() => {
                siegeCharmSearcher.StartAnalyzing(progress);
            });
        }

        private void StopAnalyzingButtonClick(object sender, EventArgs eventArgs) {
            siegeCharmSearcher.StopAnalyzing();
        }

        private void WButtonClick(object sender, EventArgs eventArgs) => siegeCharmSearcher.SendW();
    }
}

//TODO:
//add settings menu.
//add custom resolution setting.
//add custom aspect ratio setting.