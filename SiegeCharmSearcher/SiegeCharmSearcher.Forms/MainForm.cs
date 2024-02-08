using SiegeCharmSearcher.Shared;

namespace SiegeCharmSearcher.Forms {
    public partial class MainForm : Form {
        private readonly Shared.SiegeCharmSearcher siegeCharmSearcher;
        private readonly ListBox[] charmsLists = new ListBox[3];
        private Charm? SelectedCharm { get; set; } = null;

        public MainForm() {
            InitializeComponent();

            siegeCharmSearcher = new Shared.SiegeCharmSearcher();

            charmsLists[0] = charmsList0;
            charmsLists[1] = charmsList1;
            charmsLists[2] = charmsList2;
        }

        private async void AnalyzeButtonClick(object sender, EventArgs eventArgs) {
            IProgress<Bitmap> analyzingImage = new Progress<Bitmap>(bitmap => {
                screenshotDisplay.Image = bitmap;
            });
            IProgress<string> warning = new Progress<string>(s => warningLabel.Text = s);
            IProgress<Charm> analyzedCharm = new Progress<Charm>(charm => {
                charmNameLabel.Text = $"{charm.name}: {charm.position}";
                charmsLists[charm.position.x].Items.Add(charm.name);
            });

            warningLabel.Text = "Starting analyzation.";
            await Task.Factory.StartNew(() => {
                siegeCharmSearcher.StartAnalyzing(analyzingImage, warning, analyzedCharm);
            });
        }

        private void StopAnalyzingButtonClick(object sender, EventArgs eventArgs) {
            siegeCharmSearcher.StopAnalyzing();
        }

        private void CharmsListSelect(object sender, EventArgs eventArgs) {
            object? selected = ((ListBox)(sender)).SelectedItem;
            if (selected == null) {
                return;
            }

            Charm? charm = siegeCharmSearcher.charms.Find(c => c.name == selected.ToString());
            if (charm == null) {
                return;
            }

            SelectedCharm = charm;
        }

        private void SearchBoxChanged(object sender, EventArgs eventArgs) {
            string query = searchBox.Text;
            resultsList.Items.Clear();
            List<string> charmNames = siegeCharmSearcher.charms.Select(c => c.name).ToList();

            void AddAndRemove(string result) {
                resultsList.Items.Add(result);
                charmNames.Remove(result);
            }

            foreach (string result in SearchStrategies.LiteralSearchIgnoreCase(query, [.. charmNames])) {
                AddAndRemove(result);
            }

            foreach (string result in SearchStrategies.LiteralSearchIgnoreSpaceWithoutSpaces(query, [.. charmNames])) {
                AddAndRemove(result);
            }

            foreach(string result in SearchStrategies.IncludesOneOfTheKeywords(query, [.. charmNames])) {
                AddAndRemove(result);
            }
        }
    }
}

//TODO:
//add settings menu.
//add custom resolution setting.
//add custom aspect ratio setting.
//check ownership of skins.
//disable battleeye
//remove vulkan support