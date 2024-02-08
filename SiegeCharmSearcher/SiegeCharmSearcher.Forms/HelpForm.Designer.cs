namespace SiegeCharmSearcher.Forms {
    partial class HelpForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            helpLabel = new Label();
            okButton = new Button();
            exitButton = new Button();
            SuspendLayout();
            // 
            // helpLabel
            // 
            resources.ApplyResources(helpLabel, "helpLabel");
            helpLabel.Name = "helpLabel";
            // 
            // okButton
            // 
            resources.ApplyResources(okButton, "okButton");
            okButton.Name = "okButton";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += OkButtonClick;
            // 
            // exitButton
            // 
            resources.ApplyResources(exitButton, "exitButton");
            exitButton.Name = "exitButton";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += ExitButtonClick;
            // 
            // HelpForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            ControlBox = false;
            Controls.Add(exitButton);
            Controls.Add(okButton);
            Controls.Add(helpLabel);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "HelpForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label helpLabel;
        private Button okButton;
        private Button exitButton;
    }
}