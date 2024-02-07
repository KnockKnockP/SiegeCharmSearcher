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
            screenshotDisplay = new PictureBox();
            analyzeButton = new Button();
            charmName = new Label();
            stopAnalyzingButton = new Button();
            wButton = new Button();
            ((System.ComponentModel.ISupportInitialize)screenshotDisplay).BeginInit();
            SuspendLayout();
            // 
            // screenshotDisplay
            // 
            screenshotDisplay.Location = new Point(18, 12);
            screenshotDisplay.Name = "screenshotDisplay";
            screenshotDisplay.Size = new Size(810, 60);
            screenshotDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
            screenshotDisplay.TabIndex = 1;
            screenshotDisplay.TabStop = false;
            // 
            // analyzeButton
            // 
            analyzeButton.Location = new Point(18, 415);
            analyzeButton.Name = "analyzeButton";
            analyzeButton.Size = new Size(75, 23);
            analyzeButton.TabIndex = 2;
            analyzeButton.Text = "Analyze";
            analyzeButton.UseVisualStyleBackColor = true;
            analyzeButton.Click += AnalyzeButtonClick;
            // 
            // charmName
            // 
            charmName.AutoSize = true;
            charmName.Location = new Point(18, 75);
            charmName.Name = "charmName";
            charmName.Size = new Size(78, 15);
            charmName.TabIndex = 4;
            charmName.Text = "Charm Name";
            // 
            // stopAnalyzingButton
            // 
            stopAnalyzingButton.Location = new Point(99, 415);
            stopAnalyzingButton.Name = "stopAnalyzingButton";
            stopAnalyzingButton.Size = new Size(75, 23);
            stopAnalyzingButton.TabIndex = 5;
            stopAnalyzingButton.Text = "Stop";
            stopAnalyzingButton.UseVisualStyleBackColor = true;
            stopAnalyzingButton.Click += StopAnalyzingButtonClick;
            // 
            // wButton
            // 
            wButton.Location = new Point(180, 415);
            wButton.Name = "wButton";
            wButton.Size = new Size(75, 23);
            wButton.TabIndex = 6;
            wButton.Text = "W";
            wButton.UseVisualStyleBackColor = true;
            wButton.Click += WButtonClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(847, 450);
            Controls.Add(wButton);
            Controls.Add(stopAnalyzingButton);
            Controls.Add(charmName);
            Controls.Add(analyzeButton);
            Controls.Add(screenshotDisplay);
            Name = "MainForm";
            Text = "Siege Charm Searcher";
            ((System.ComponentModel.ISupportInitialize)screenshotDisplay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox screenshotDisplay;
        private Button analyzeButton;
        private Label charmName;
        private Button stopAnalyzingButton;
        private Button wButton;
    }
}
