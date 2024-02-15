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
            nameImage = new PictureBox();
            analyzeButton = new Button();
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
            helpToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem1 = new ToolStripMenuItem();
            charmNameInputBox = new TextBox();
            xLabel = new Label();
            yLabel = new Label();
            xInputBox = new TextBox();
            yInputBox = new TextBox();
            searchLabel = new Label();
            selectedCharmLabel = new Label();
            applyButton = new Button();
            ownedImage = new PictureBox();
            presentColor = new PictureBox();
            detectPositionButton = new RadioButton();
            navigationLabel = new Label();
            specifyPositionButton = new RadioButton();
            navigationYInput = new TextBox();
            navigationXInput = new TextBox();
            navigationYLabel = new Label();
            navigationXLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)nameImage).BeginInit();
            statusStrip.SuspendLayout();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ownedImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)presentColor).BeginInit();
            SuspendLayout();
            // 
            // nameImage
            // 
            resources.ApplyResources(nameImage, "nameImage");
            nameImage.Name = "nameImage";
            nameImage.TabStop = false;
            // 
            // analyzeButton
            // 
            resources.ApplyResources(analyzeButton, "analyzeButton");
            analyzeButton.Name = "analyzeButton";
            analyzeButton.UseVisualStyleBackColor = true;
            analyzeButton.Click += AnalyzeButtonClick;
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
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, loadToolStripMenuItem, exitToolStripMenuItem, helpToolStripMenuItem, exitToolStripMenuItem1 });
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
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(helpToolStripMenuItem, "helpToolStripMenuItem");
            helpToolStripMenuItem.Click += ShowHelpButtonClicked;
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
            // ownedImage
            // 
            resources.ApplyResources(ownedImage, "ownedImage");
            ownedImage.Name = "ownedImage";
            ownedImage.TabStop = false;
            // 
            // presentColor
            // 
            resources.ApplyResources(presentColor, "presentColor");
            presentColor.Name = "presentColor";
            presentColor.TabStop = false;
            // 
            // detectPositionButton
            // 
            resources.ApplyResources(detectPositionButton, "detectPositionButton");
            detectPositionButton.Checked = true;
            detectPositionButton.Name = "detectPositionButton";
            detectPositionButton.TabStop = true;
            detectPositionButton.UseVisualStyleBackColor = true;
            detectPositionButton.CheckedChanged += DetectPositionChecked;
            // 
            // navigationLabel
            // 
            resources.ApplyResources(navigationLabel, "navigationLabel");
            navigationLabel.Name = "navigationLabel";
            // 
            // specifyPositionButton
            // 
            resources.ApplyResources(specifyPositionButton, "specifyPositionButton");
            specifyPositionButton.Name = "specifyPositionButton";
            specifyPositionButton.UseVisualStyleBackColor = true;
            specifyPositionButton.CheckedChanged += SpecifyPositionChecked;
            // 
            // navigationYInput
            // 
            resources.ApplyResources(navigationYInput, "navigationYInput");
            navigationYInput.Name = "navigationYInput";
            // 
            // navigationXInput
            // 
            resources.ApplyResources(navigationXInput, "navigationXInput");
            navigationXInput.Name = "navigationXInput";
            // 
            // navigationYLabel
            // 
            resources.ApplyResources(navigationYLabel, "navigationYLabel");
            navigationYLabel.Name = "navigationYLabel";
            // 
            // navigationXLabel
            // 
            resources.ApplyResources(navigationXLabel, "navigationXLabel");
            navigationXLabel.Name = "navigationXLabel";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(navigationYInput);
            Controls.Add(navigationXInput);
            Controls.Add(navigationYLabel);
            Controls.Add(navigationXLabel);
            Controls.Add(specifyPositionButton);
            Controls.Add(navigationLabel);
            Controls.Add(detectPositionButton);
            Controls.Add(presentColor);
            Controls.Add(ownedImage);
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
            Controls.Add(analyzeButton);
            Controls.Add(nameImage);
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            FormClosing += FormClosingPrompt;
            ((System.ComponentModel.ISupportInitialize)nameImage).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ownedImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)presentColor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox nameImage;
        private Button analyzeButton;
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
        private ToolStripMenuItem helpToolStripMenuItem;
        private PictureBox ownedImage;
        private PictureBox presentColor;
        private RadioButton detectPositionButton;
        private Label navigationLabel;
        private RadioButton specifyPositionButton;
        private TextBox navigationYInput;
        private TextBox navigationXInput;
        private Label navigationYLabel;
        private Label navigationXLabel;
    }
}
