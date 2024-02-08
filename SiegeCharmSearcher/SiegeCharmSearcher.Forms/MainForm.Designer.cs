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
            warningLabel = new Label();
            charmNameLabel = new Label();
            charmsList0 = new ListBox();
            charmsList1 = new ListBox();
            charmsList2 = new ListBox();
            searchBox = new TextBox();
            resultsList = new ListBox();
            label = new Label();
            ((System.ComponentModel.ISupportInitialize)screenshotDisplay).BeginInit();
            SuspendLayout();
            // 
            // screenshotDisplay
            // 
            screenshotDisplay.Anchor = AnchorStyles.Top;
            screenshotDisplay.Location = new Point(18, 12);
            screenshotDisplay.Name = "screenshotDisplay";
            screenshotDisplay.Size = new Size(810, 60);
            screenshotDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
            screenshotDisplay.TabIndex = 1;
            screenshotDisplay.TabStop = false;
            // 
            // analyzeButton
            // 
            analyzeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            analyzeButton.Location = new Point(18, 415);
            analyzeButton.Name = "analyzeButton";
            analyzeButton.Size = new Size(75, 23);
            analyzeButton.TabIndex = 2;
            analyzeButton.Text = "Analyze";
            analyzeButton.UseVisualStyleBackColor = true;
            analyzeButton.Click += AnalyzeButtonClick;
            // 
            // stopAnalyzingButton
            // 
            stopAnalyzingButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            stopAnalyzingButton.Location = new Point(99, 415);
            stopAnalyzingButton.Name = "stopAnalyzingButton";
            stopAnalyzingButton.Size = new Size(75, 23);
            stopAnalyzingButton.TabIndex = 5;
            stopAnalyzingButton.Text = "Stop";
            stopAnalyzingButton.UseVisualStyleBackColor = true;
            stopAnalyzingButton.Click += StopAnalyzingButtonClick;
            // 
            // warningLabel
            // 
            warningLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            warningLabel.AutoSize = true;
            warningLabel.Location = new Point(180, 432);
            warningLabel.Name = "warningLabel";
            warningLabel.Size = new Size(52, 15);
            warningLabel.TabIndex = 7;
            warningLabel.Text = "Warning";
            warningLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // charmNameLabel
            // 
            charmNameLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            charmNameLabel.AutoSize = true;
            charmNameLabel.Location = new Point(180, 412);
            charmNameLabel.Name = "charmNameLabel";
            charmNameLabel.Size = new Size(78, 15);
            charmNameLabel.TabIndex = 12;
            charmNameLabel.Text = "Charm Name";
            charmNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // charmsList0
            // 
            charmsList0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            charmsList0.FormattingEnabled = true;
            charmsList0.ItemHeight = 15;
            charmsList0.Location = new Point(18, 78);
            charmsList0.Name = "charmsList0";
            charmsList0.Size = new Size(156, 334);
            charmsList0.TabIndex = 16;
            charmsList0.SelectedIndexChanged += CharmsListSelect;
            // 
            // charmsList1
            // 
            charmsList1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            charmsList1.FormattingEnabled = true;
            charmsList1.ItemHeight = 15;
            charmsList1.Location = new Point(180, 78);
            charmsList1.Name = "charmsList1";
            charmsList1.Size = new Size(156, 334);
            charmsList1.TabIndex = 17;
            charmsList1.SelectedIndexChanged += CharmsListSelect;
            // 
            // charmsList2
            // 
            charmsList2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            charmsList2.FormattingEnabled = true;
            charmsList2.ItemHeight = 15;
            charmsList2.Location = new Point(342, 78);
            charmsList2.Name = "charmsList2";
            charmsList2.Size = new Size(156, 334);
            charmsList2.TabIndex = 18;
            charmsList2.SelectedIndexChanged += CharmsListSelect;
            // 
            // searchBox
            // 
            searchBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            searchBox.Location = new Point(504, 78);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(324, 23);
            searchBox.TabIndex = 19;
            searchBox.Text = "Search";
            searchBox.TextChanged += SearchBoxChanged;
            // 
            // resultsList
            // 
            resultsList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            resultsList.FormattingEnabled = true;
            resultsList.ItemHeight = 15;
            resultsList.Location = new Point(504, 107);
            resultsList.Name = "resultsList";
            resultsList.Size = new Size(156, 304);
            resultsList.TabIndex = 20;
            // 
            // label
            // 
            label.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label.AutoSize = true;
            label.Location = new Point(654, 426);
            label.Name = "label";
            label.Size = new Size(181, 15);
            label.TabIndex = 21;
            label.Text = "Made with love and hatred of R6.";
            label.TextAlign = ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(847, 450);
            Controls.Add(label);
            Controls.Add(resultsList);
            Controls.Add(searchBox);
            Controls.Add(charmsList2);
            Controls.Add(charmsList1);
            Controls.Add(charmsList0);
            Controls.Add(charmNameLabel);
            Controls.Add(warningLabel);
            Controls.Add(stopAnalyzingButton);
            Controls.Add(analyzeButton);
            Controls.Add(screenshotDisplay);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Siege Charm Searcher";
            ((System.ComponentModel.ISupportInitialize)screenshotDisplay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox screenshotDisplay;
        private Button analyzeButton;
        private Button stopAnalyzingButton;
        private Label warningLabel;
        private Label charmNameLabel;
        private ListBox charmsList0;
        private ListBox charmsList1;
        private ListBox charmsList2;
        private TextBox searchBox;
        private ListBox resultsList;
        private Label label;
    }
}
