using SiegeCharmSearcher.Shared;

namespace SiegeCharmSearcher.Forms {
    public partial class MainForm : Form {
        private readonly Shared.SiegeCharmSearcher siegeCharmSearcher;
        private readonly ListBox[] charmsLists = new ListBox[3];

        private Charm? selectedCharm = null;
        private Charm? SelectedCharm {
            get => selectedCharm;
            set {
                selectedCharm = value;

                if (selectedCharm != null) {
                    charmNameInputBox.Text = selectedCharm.name;
                    xInputBox.Text = selectedCharm.position.x.ToString();
                    yInputBox.Text = selectedCharm.position.y.ToString();
                } else {
                    charmNameInputBox.Text = string.Empty;
                }
            }
        }

        const string fileDialogFilter = "JavaScript Object Notation|*.json";

        public MainForm() {
            InitializeComponent();

            siegeCharmSearcher = new Shared.SiegeCharmSearcher();

            charmsLists[0] = charmsList0;
            charmsLists[1] = charmsList1;
            charmsLists[2] = charmsList2;
        }

        private void AddCharm(Charm charm) {
            charmsLists[charm.position.x].Items.Add(charm.name);
        }

        private void ModifyCharm(Charm charm) {
            charmsLists[charm.position.x].Items[charm.position.y] = charm.name;
        }

        private void ClearCharms() {
            foreach (ListBox listBox in charmsLists) {
                listBox.Items.Clear();
            }
            resultsList.Items.Clear();
            SelectedCharm = null;
        }

        private async void AnalyzeButtonClick(object sender, EventArgs eventArgs) {
            IProgress<Bitmap> analyzingImage = new Progress<Bitmap>(bitmap => screenshotDisplay.Image = bitmap);
            IProgress<string> status = new Progress<string>(s => statusLabel.Text = s);
            IProgress<Charm> analyzedCharm = new Progress<Charm>(AddCharm);
            IProgress<bool> enableProgressBar = new Progress<bool>(enable => {
                analyzingProgressBar.Style = (enable ? ProgressBarStyle.Marquee : ProgressBarStyle.Continuous);
            });

            ClearCharms();

            statusLabel.Text = "Starting analyzation.";
            await Task.Factory.StartNew(() => {
                siegeCharmSearcher.StartAnalyzing(analyzingImage,
                                                  status,
                                                  analyzedCharm,
                                                  enableProgressBar);
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

            Charm? foundCharm = null;
            foreach (Charm charm in siegeCharmSearcher.charms) {
                if (charm.name == selected.ToString()) {
                    foundCharm = charm;
                    break;
                }
            }
            if (foundCharm == null) {
                return;
            }

            SelectedCharm = foundCharm;
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

            foreach (string result in SearchStrategies.IncludesOneOfTheKeywords(query, [.. charmNames])) {
                AddAndRemove(result);
            }
        }

        private async void NavigateButtonClick(object sender, EventArgs eventArgs) {
            if (SelectedCharm == null) {
                statusLabel.Text = "No charm has been selected.";
                return;
            }

            IProgress<string> status = new Progress<string>(s => statusLabel.Text = s);
            await Task.Factory.StartNew(() => {
                siegeCharmSearcher.NavigateTo(SelectedCharm, status);
            });
        }

        private void SaveButtonClick(object sender, EventArgs eventArgs) {
            SaveFileDialog saveFileDialog = new() {
                Filter = fileDialogFilter,
                Title = "Save Charms",
                RestoreDirectory = true
            };
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName == string.Empty) {
                return;
            }

            siegeCharmSearcher.Save(saveFileDialog.FileName);
        }

        private void LoadButtonClick(object sender, EventArgs eventArgs) {
            OpenFileDialog openFileDialog = new() {
                Filter = fileDialogFilter,
                Title = "Load Charms",
                RestoreDirectory = true
            };
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName == string.Empty) {
                return;
            }

            siegeCharmSearcher.Load(openFileDialog.FileName);

            ClearCharms();
            foreach (Charm charm in siegeCharmSearcher.charms) {
                AddCharm(charm);
            }
        }

        private void ApplyButtonClick(object sender, EventArgs eventArgs) {
            if (SelectedCharm == null) {
                return;
            }

            for (int i = 0; i < siegeCharmSearcher.charms.Count; ++i) {
                if (siegeCharmSearcher.charms[i] == SelectedCharm) {
                    Charm charm = siegeCharmSearcher.charms[i];
                    charm.name = charmNameInputBox.Text;
                    charm.position = new Vector2Int(int.Parse(xInputBox.Text), int.Parse(yInputBox.Text));
                    ModifyCharm(charm);
                    siegeCharmSearcher.charms.MarkDirty();
                }
            }
        }

        private void SettingsMenuButtonClick(object sender, EventArgs eventArgs) {
            SettingsMenuForm settingsMenuForm = new(siegeCharmSearcher);
            settingsMenuForm.ShowDialog();
        }

        private void ExitButtonClick(object sender, EventArgs eventArgs) {
            Application.Exit();
        }

        private void FormClosingPrompt(object sender, FormClosingEventArgs formClosingEventArgs) {
            if (!siegeCharmSearcher.charms.IsDirty) {
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Would you like to save before exiting?",
                                                        "Unsaved Work",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning,
                                                        MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.Yes) {
                SaveButtonClick(sender, formClosingEventArgs);
            }
        }
    }
}

//TODO:
//add settings menu.
//add custom resolution setting.
//add custom aspect ratio setting.
//add readme

//localization
//check ownership of skins.
//disable battleeye
//remove vulkan support