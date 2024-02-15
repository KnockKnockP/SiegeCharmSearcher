using SiegeCharmSearcher.Shared;

namespace SiegeCharmSearcher.Forms {
    internal sealed partial class SettingsMenuForm : Form {
        private readonly Shared.SiegeCharmSearcher siegeCharmSearcher;

        internal SettingsMenuForm(Shared.SiegeCharmSearcher siegeCharmSearcher) {
            InitializeComponent();
            this.siegeCharmSearcher = siegeCharmSearcher;

            Settings settings = siegeCharmSearcher.Settings;
            Vector2Int size = settings.Resolution.Size;
            resolutionXInputBox.Text = size.x.ToString();
            resolutionYInputBox.Text = size.y.ToString();
            aspectRatioComboBox.SelectedIndex = (int)(settings.Resolution.AspectRatio);
            delayInputBox.Text = settings.Delay.ToString();
        }

        private void Save(object sender, FormClosingEventArgs formClosingEventArgs) {
            Settings settings = siegeCharmSearcher.Settings;
            settings.Resolution.Size = new Vector2Int(int.Parse(resolutionXInputBox.Text), int.Parse(resolutionYInputBox.Text));
            settings.Resolution.AspectRatio = (AspectRatio)(aspectRatioComboBox.SelectedIndex);
            settings.Delay = int.Parse(delayInputBox.Text);
            siegeCharmSearcher.SaveSettings();
        }
    }
}