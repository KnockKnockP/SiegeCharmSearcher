namespace SiegeCharmSearcher.Forms {
    partial class MainForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            screenshotDisplay = new PictureBox();
            analyzeButton = new Button();
            stopAnalyzingButton = new Button();
            charmsList0 = new ListBox();
            charmsList1 = new ListBox();
            charmsList2 = new ListBox();
            searchBox = new TextBox();
            resultsList = new ListBox();
            navigateButton = new Button();
            statusStrip = new StatusStrip();
            analyzingProgressBar = new ToolStripProgressBar();
            statusLabel = new ToolStripStatusLabel();
            r6Text = new ToolStripStatusLabel();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem1 = new ToolStripMenuItem();
            charmNameInputBox = new TextBox();
            xLabel = new Label();
            yLabel = new Label();
            xInputBox = new TextBox();
            yInputBox = new TextBox();
            searchLabel = new Label();
            selectedCharmLabel = new Label();
            applyButton = new Button();
            ((System.ComponentModel.ISupportInitialize)screenshotDisplay).BeginInit();
            statusStrip.SuspendLayout();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // screenshotDisplay
            // 
            resources.ApplyResources(screenshotDisplay, "screenshotDisplay");
            screenshotDisplay.Name = "screenshotDisplay";
            screenshotDisplay.TabStop = false;
            // 
            // analyzeButton
            // 
            resources.ApplyResources(analyzeButton, "analyzeButton");
            analyzeButton.Name = "analyzeButton";
            analyzeButton.UseVisualStyleBackColor = true;
            analyzeButton.Click += AnalyzeButtonClick;
            // 
            // stopAnalyzingButton
            // 
            resources.ApplyResources(stopAnalyzingButton, "stopAnalyzingButton");
            stopAnalyzingButton.Name = "stopAnalyzingButton";
            stopAnalyzingButton.UseVisualStyleBackColor = true;
            stopAnalyzingButton.Click += StopAnalyzingButtonClick;
            // 
            // charmsList0
            // 
            resources.ApplyResources(charmsList0, "charmsList0");
            charmsList0.FormattingEnabled = true;
            charmsList0.Name = "charmsList0";
            charmsList0.SelectedIndexChanged += CharmsListSelect;
            // 
            // charmsList1
            // 
            resources.ApplyResources(charmsList1, "charmsList1");
            charmsList1.FormattingEnabled = true;
            charmsList1.Name = "charmsList1";
            charmsList1.SelectedIndexChanged += CharmsListSelect;
            // 
            // charmsList2
            // 
            resources.ApplyResources(charmsList2, "charmsList2");
            charmsList2.FormattingEnabled = true;
            charmsList2.Name = "charmsList2";
            charmsList2.SelectedIndexChanged += CharmsListSelect;
            // 
            // searchBox
            // 
            resources.ApplyResources(searchBox, "searchBox");
            searchBox.Name = "searchBox";
            searchBox.TextChanged += SearchBoxChanged;
            // 
            // resultsList
            // 
            resources.ApplyResources(resultsList, "resultsList");
            resultsList.FormattingEnabled = true;
            resultsList.Name = "resultsList";
            resultsList.SelectedIndexChanged += CharmsListSelect;
            // 
            // navigateButton
            // 
            resources.ApplyResources(navigateButton, "navigateButton");
            navigateButton.Name = "navigateButton";
            navigateButton.UseVisualStyleBackColor = true;
            navigateButton.Click += NavigateButtonClick;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { analyzingProgressBar, statusLabel, r6Text });
            resources.ApplyResources(statusStrip, "statusStrip");
            statusStrip.Name = "statusStrip";
            // 
            // analyzingProgressBar
            // 
            analyzingProgressBar.Name = "analyzingProgressBar";
            resources.ApplyResources(analyzingProgressBar, "analyzingProgressBar");
            analyzingProgressBar.Style = ProgressBarStyle.Continuous;
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            resources.ApplyResources(statusLabel, "statusLabel");
            statusLabel.Spring = true;
            // 
            // r6Text
            // 
            r6Text.Name = "r6Text";
            resources.ApplyResources(r6Text, "r6Text");
            r6Text.Spring = true;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            resources.ApplyResources(menuStrip, "menuStrip");
            menuStrip.Name = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, loadToolStripMenuItem, exitToolStripMenuItem, exitToolStripMenuItem1 });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(saveToolStripMenuItem, "saveToolStripMenuItem");
            saveToolStripMenuItem.Click += SaveButtonClick;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            resources.ApplyResources(loadToolStripMenuItem, "loadToolStripMenuItem");
            loadToolStripMenuItem.Click += LoadButtonClick;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(exitToolStripMenuItem, "exitToolStripMenuItem");
            exitToolStripMenuItem.Click += SettingsMenuButtonClick;
            // 
            // exitToolStripMenuItem1
            // 
            exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            resources.ApplyResources(exitToolStripMenuItem1, "exitToolStripMenuItem1");
            exitToolStripMenuItem1.Click += ExitButtonClick;
            // 
            // charmNameInputBox
            // 
            resources.ApplyResources(charmNameInputBox, "charmNameInputBox");
            charmNameInputBox.Name = "charmNameInputBox";
            // 
            // xLabel
            // 
            resources.ApplyResources(xLabel, "xLabel");
            xLabel.Name = "xLabel";
            // 
            // yLabel
            // 
            resources.ApplyResources(yLabel, "yLabel");
            yLabel.Name = "yLabel";
            // 
            // xInputBox
            // 
            resources.ApplyResources(xInputBox, "xInputBox");
            xInputBox.Name = "xInputBox";
            // 
            // yInputBox
            // 
            resources.ApplyResources(yInputBox, "yInputBox");
            yInputBox.Name = "yInputBox";
            // 
            // searchLabel
            // 
            resources.ApplyResources(searchLabel, "searchLabel");
            searchLabel.Name = "searchLabel";
            // 
            // selectedCharmLabel
            // 
            resources.ApplyResources(selectedCharmLabel, "selectedCharmLabel");
            selectedCharmLabel.Name = "selectedCharmLabel";
            // 
            // applyButton
            // 
            resources.ApplyResources(applyButton, "applyButton");
            applyButton.Name = "applyButton";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += ApplyButtonClick;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(applyButton);
            Controls.Add(selectedCharmLabel);
            Controls.Add(searchLabel);
            Controls.Add(yInputBox);
            Controls.Add(xInputBox);
            Controls.Add(yLabel);
            Controls.Add(xLabel);
            Controls.Add(charmNameInputBox);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            Controls.Add(navigateButton);
            Controls.Add(resultsList);
            Controls.Add(searchBox);
            Controls.Add(charmsList2);
            Controls.Add(charmsList1);
            Controls.Add(charmsList0);
            Controls.Add(stopAnalyzingButton);
            Controls.Add(analyzeButton);
            Controls.Add(screenshotDisplay);
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            FormClosing += FormClosingPrompt;
            ((System.ComponentModel.ISupportInitialize)screenshotDisplay).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox screenshotDisplay;
        private Button analyzeButton;
        private Button stopAnalyzingButton;
        private ListBox charmsList0;
        private ListBox charmsList1;
        private ListBox charmsList2;
        private TextBox searchBox;
        private ListBox resultsList;
        private Button navigateButton;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLabel;
        private ToolStripProgressBar analyzingProgressBar;
        private ToolStripStatusLabel r6Text;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem1;
        private TextBox charmNameInputBox;
        private Label xLabel;
        private Label yLabel;
        private TextBox xInputBox;
        private TextBox yInputBox;
        private Label searchLabel;
        private Label selectedCharmLabel;
        private Button applyButton;
    }
}
