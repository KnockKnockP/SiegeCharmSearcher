using SiegeCharmSearcher.Shared;

namespace SiegeCharmSearcher.Forms {
    public partial class MainForm : Form {
        const string fileDialogFilter = "JavaScript Object Notation|*.json";

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

        private bool detectPosition = true;

        private Task? analyzationTask = null, navigationTask = null;
        private CancellationTokenSource analyzationCancelTokenSource = new(),
                                        navigationCancelTokenSource = new();

        public MainForm() {
            InitializeComponent();

            try {
                siegeCharmSearcher = new Shared.SiegeCharmSearcher();
            } catch (ProcessNotFoundException) {
                MessageBox.Show(Messages.R6NotFoundContent,
                                Messages.R6NotFoundTitle,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                Environment.Exit(0);
            } catch (VulkanNotSupportedException) {
                MessageBox.Show(Messages.VulkanUnsupportedContent,
                                Messages.VulkanUnsupportedTitle,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            if (!siegeCharmSearcher.settings.hasSeenHelp) {
                DisplayHelp();
            }

            charmsLists[0] = charmsList0;
            charmsLists[1] = charmsList1;
            charmsLists[2] = charmsList2;
        }

        private void DisplayHelp() {
            siegeCharmSearcher.settings.hasSeenHelp = true;
            siegeCharmSearcher.SaveSettings();

            HelpForm helpForm = new();
            helpForm.ShowDialog();
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
            if (analyzationTask == null) {
                analyzeButton.Text = Messages.Stop;
                analyzingProgressBar.Style = ProgressBarStyle.Marquee;
                statusLabel.Text = Messages.StartingAnalyzation;
                ClearCharms();

                IProgress<Bitmap> analyzingNameImage = new Progress<Bitmap>(bitmap => screenshotDisplay.Image = bitmap),
                                  analyzingOwnedImage = new Progress<Bitmap>(bitmap => ownedImageDisplay.Image = bitmap);
                IProgress<Color> analyzingPresentColor = new Progress<Color>(color => presentImageDisplay.BackColor = color);
                IProgress<string> status = new Progress<string>(s => statusLabel.Text = s);
                IProgress<Charm> analyzedCharm = new Progress<Charm>(AddCharm);

                analyzationTask = Task.Factory.StartNew(() => {
                    siegeCharmSearcher.StartAnalyzing(analyzingNameImage,
                                                      analyzingOwnedImage,
                                                      analyzingPresentColor,
                                                      status,
                                                      analyzedCharm,
                                                      analyzationCancelTokenSource.Token);
                }, analyzationCancelTokenSource.Token);

                try {
                    await analyzationTask;
                } catch (OperationCanceledException) {}

                analyzationTask = null;
                analyzationCancelTokenSource = new();
                analyzeButton.Text = Messages.Scan;
                analyzingProgressBar.Style = ProgressBarStyle.Continuous;
            } else {
                analyzationCancelTokenSource.Cancel();
            }
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
                statusLabel.Text = Messages.NavigateNoCharmSelected;
                return;
            }

            if (navigationTask == null) {
                navigateButton.Text = Messages.Stop;
                analyzingProgressBar.Style = ProgressBarStyle.Marquee;

                Vector2Int? specifiedPosition = null;
                if (!detectPosition) {
                    specifiedPosition = new(int.Parse(navigationXInput.Text), int.Parse(navigationYInput.Text));
                }

                IProgress<string> status = new Progress<string>(s => statusLabel.Text = s);
                navigationTask = Task.Factory.StartNew(() => {
                    siegeCharmSearcher.NavigateTo(SelectedCharm,
                                                  specifiedPosition,
                                                  status,
                                                  navigationCancelTokenSource.Token);
                }, navigationCancelTokenSource.Token);

                try { 
                    await navigationTask;
                } catch (OperationCanceledException) {}

                navigationTask = null;
                navigationCancelTokenSource = new();
                navigateButton.Text = Messages.Navigate;
                analyzingProgressBar.Style = ProgressBarStyle.Continuous;
            } else {
                navigationCancelTokenSource.Cancel();
            }
        }

        private void SaveButtonClick(object sender, EventArgs eventArgs) {
            SaveFileDialog saveFileDialog = new() {
                Filter = fileDialogFilter,
                Title = Messages.SaveCharms,
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
                Title = Messages.LoadCharms,
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

        private void ShowHelpButtonClicked(object sender, EventArgs eventArgs) => DisplayHelp();

        private void DetectPositionChecked(object sender, EventArgs eventArgs) {
            detectPosition = true;
        }

        private void SpecifyPositionChecked(object sender, EventArgs eventArgs) {
            detectPosition = false;
        }

        private void ExitButtonClick(object sender, EventArgs eventArgs) {
            Application.Exit();
        }

        private void FormClosingPrompt(object sender, FormClosingEventArgs formClosingEventArgs) {
            if (!siegeCharmSearcher.charms.IsDirty) {
                return;
            }

            DialogResult dialogResult = MessageBox.Show(Messages.ExitSavePrompt,
                                                        Messages.ExitSaveTitle,
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning,
                                                        MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.Yes) {
                SaveButtonClick(sender, formClosingEventArgs);
            }
        }
    }
}