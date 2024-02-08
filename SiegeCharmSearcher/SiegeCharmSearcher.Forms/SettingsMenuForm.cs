using SiegeCharmSearcher.Shared;

namespace SiegeCharmSearcher.Forms {
    public partial class SettingsMenuForm : Form {
        private readonly Shared.SiegeCharmSearcher siegeCharmSearcher;

        public SettingsMenuForm(Shared.SiegeCharmSearcher siegeCharmSearcher) {
            InitializeComponent();
            this.siegeCharmSearcher = siegeCharmSearcher;

            Settings settings = siegeCharmSearcher.settings;
            Vector2Int size = settings.resolution.size;
            resolutionXInputBox.Text = size.x.ToString();
            resolutionYInputBox.Text = size.y.ToString();
            aspectRatioComboBox.SelectedIndex = (int)(settings.resolution.aspectRatio);
            delayInputBox.Text = settings.delay.ToString();
        }

        private void Save(object sender, FormClosingEventArgs formClosingEventArgs) {
            Settings settings = siegeCharmSearcher.settings;
            settings.resolution.size = new Vector2Int(int.Parse(resolutionXInputBox.Text), int.Parse(resolutionYInputBox.Text));
            settings.resolution.aspectRatio = (AspectRatio)(aspectRatioComboBox.SelectedIndex);
            settings.delay = int.Parse(delayInputBox.Text);
            siegeCharmSearcher.SaveSettings();
        }
    }
}