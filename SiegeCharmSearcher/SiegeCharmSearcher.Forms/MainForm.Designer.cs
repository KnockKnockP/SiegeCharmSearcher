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
            screenshotDisplay.Anchor = AnchorStyles.Top;
            screenshotDisplay.Location = new Point(18, 27);
            screenshotDisplay.Name = "screenshotDisplay";
            screenshotDisplay.Size = new Size(810, 60);
            screenshotDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
            screenshotDisplay.TabIndex = 1;
            screenshotDisplay.TabStop = false;
            // 
            // analyzeButton
            // 
            analyzeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            analyzeButton.Location = new Point(666, 373);
            analyzeButton.Name = "analyzeButton";
            analyzeButton.Size = new Size(75, 23);
            analyzeButton.TabIndex = 2;
            analyzeButton.Text = "Scan";
            analyzeButton.UseVisualStyleBackColor = true;
            analyzeButton.Click += AnalyzeButtonClick;
            // 
            // stopAnalyzingButton
            // 
            stopAnalyzingButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            stopAnalyzingButton.Location = new Point(666, 344);
            stopAnalyzingButton.Name = "stopAnalyzingButton";
            stopAnalyzingButton.Size = new Size(75, 23);
            stopAnalyzingButton.TabIndex = 5;
            stopAnalyzingButton.Text = "Stop";
            stopAnalyzingButton.UseVisualStyleBackColor = true;
            stopAnalyzingButton.Click += StopAnalyzingButtonClick;
            // 
            // charmsList0
            // 
            charmsList0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            charmsList0.FormattingEnabled = true;
            charmsList0.HorizontalScrollbar = true;
            charmsList0.ItemHeight = 15;
            charmsList0.Location = new Point(18, 93);
            charmsList0.Name = "charmsList0";
            charmsList0.Size = new Size(156, 304);
            charmsList0.TabIndex = 16;
            charmsList0.SelectedIndexChanged += CharmsListSelect;
            // 
            // charmsList1
            // 
            charmsList1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            charmsList1.FormattingEnabled = true;
            charmsList1.HorizontalScrollbar = true;
            charmsList1.ItemHeight = 15;
            charmsList1.Location = new Point(180, 93);
            charmsList1.Name = "charmsList1";
            charmsList1.Size = new Size(156, 304);
            charmsList1.TabIndex = 17;
            charmsList1.SelectedIndexChanged += CharmsListSelect;
            // 
            // charmsList2
            // 
            charmsList2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            charmsList2.FormattingEnabled = true;
            charmsList2.HorizontalScrollbar = true;
            charmsList2.ItemHeight = 15;
            charmsList2.Location = new Point(342, 93);
            charmsList2.Name = "charmsList2";
            charmsList2.Size = new Size(156, 304);
            charmsList2.TabIndex = 18;
            charmsList2.SelectedIndexChanged += CharmsListSelect;
            // 
            // searchBox
            // 
            searchBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            searchBox.Location = new Point(504, 111);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(156, 23);
            searchBox.TabIndex = 19;
            searchBox.TextChanged += SearchBoxChanged;
            // 
            // resultsList
            // 
            resultsList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            resultsList.FormattingEnabled = true;
            resultsList.HorizontalScrollbar = true;
            resultsList.ItemHeight = 15;
            resultsList.Location = new Point(504, 137);
            resultsList.Name = "resultsList";
            resultsList.Size = new Size(156, 259);
            resultsList.TabIndex = 20;
            resultsList.SelectedIndexChanged += CharmsListSelect;
            // 
            // navigateButton
            // 
            navigateButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            navigateButton.Location = new Point(747, 373);
            navigateButton.Name = "navigateButton";
            navigateButton.Size = new Size(75, 23);
            navigateButton.TabIndex = 22;
            navigateButton.Text = "Navigate";
            navigateButton.UseVisualStyleBackColor = true;
            navigateButton.Click += NavigateButtonClick;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { analyzingProgressBar, statusLabel, r6Text });
            statusStrip.Location = new Point(0, 399);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(844, 22);
            statusStrip.TabIndex = 24;
            statusStrip.Text = "statusStrip";
            // 
            // analyzingProgressBar
            // 
            analyzingProgressBar.Name = "analyzingProgressBar";
            analyzingProgressBar.Size = new Size(100, 16);
            analyzingProgressBar.Style = ProgressBarStyle.Continuous;
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(363, 17);
            statusLabel.Spring = true;
            statusLabel.Text = "Status";
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // r6Text
            // 
            r6Text.Name = "r6Text";
            r6Text.Size = new Size(363, 17);
            r6Text.Spring = true;
            r6Text.Text = "Made with love and hatred of R6.";
            r6Text.TextAlign = ContentAlignment.MiddleRight;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(844, 24);
            menuStrip.TabIndex = 25;
            menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, loadToolStripMenuItem, exitToolStripMenuItem, exitToolStripMenuItem1 });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += SaveButtonClick;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(180, 22);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += LoadButtonClick;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Settings";
            exitToolStripMenuItem.Click += SettingsMenuButtonClick;
            // 
            // exitToolStripMenuItem1
            // 
            exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            exitToolStripMenuItem1.Size = new Size(180, 22);
            exitToolStripMenuItem1.Text = "Exit";
            exitToolStripMenuItem1.Click += ExitButtonClick;
            // 
            // charmNameInputBox
            // 
            charmNameInputBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            charmNameInputBox.Location = new Point(666, 111);
            charmNameInputBox.Name = "charmNameInputBox";
            charmNameInputBox.Size = new Size(162, 23);
            charmNameInputBox.TabIndex = 26;
            // 
            // xLabel
            // 
            xLabel.AutoSize = true;
            xLabel.Location = new Point(693, 140);
            xLabel.Name = "xLabel";
            xLabel.Size = new Size(14, 15);
            xLabel.TabIndex = 27;
            xLabel.Text = "X";
            xLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // yLabel
            // 
            yLabel.AutoSize = true;
            yLabel.Location = new Point(780, 140);
            yLabel.Name = "yLabel";
            yLabel.Size = new Size(14, 15);
            yLabel.TabIndex = 28;
            yLabel.Text = "Y";
            yLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // xInputBox
            // 
            xInputBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            xInputBox.Location = new Point(666, 158);
            xInputBox.Name = "xInputBox";
            xInputBox.Size = new Size(75, 23);
            xInputBox.TabIndex = 29;
            // 
            // yInputBox
            // 
            yInputBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            yInputBox.Location = new Point(753, 158);
            yInputBox.Name = "yInputBox";
            yInputBox.Size = new Size(75, 23);
            yInputBox.TabIndex = 30;
            // 
            // searchLabel
            // 
            searchLabel.AutoSize = true;
            searchLabel.Location = new Point(558, 93);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(42, 15);
            searchLabel.TabIndex = 31;
            searchLabel.Text = "Search";
            searchLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // selectedCharmLabel
            // 
            selectedCharmLabel.AutoSize = true;
            selectedCharmLabel.Location = new Point(703, 93);
            selectedCharmLabel.Name = "selectedCharmLabel";
            selectedCharmLabel.Size = new Size(90, 15);
            selectedCharmLabel.TabIndex = 32;
            selectedCharmLabel.Text = "Selected Charm";
            selectedCharmLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // applyButton
            // 
            applyButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            applyButton.Location = new Point(747, 344);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(75, 23);
            applyButton.TabIndex = 34;
            applyButton.Text = "Apply";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += ApplyButtonClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(844, 421);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(860, 460);
            Name = "MainForm";
            Text = "Siege Charm Searcher";
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
