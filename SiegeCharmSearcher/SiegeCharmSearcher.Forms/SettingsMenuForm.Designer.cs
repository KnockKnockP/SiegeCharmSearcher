namespace SiegeCharmSearcher.Forms {
    partial class SettingsMenuForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsMenuForm));
            aspectRatioComboBox = new ComboBox();
            resolutionXInputBox = new TextBox();
            resolutionLabel = new Label();
            resolutionYInputBox = new TextBox();
            label2 = new Label();
            delayLable = new Label();
            delayInputBox = new TextBox();
            SuspendLayout();
            // 
            // aspectRatioComboBox
            // 
            aspectRatioComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            aspectRatioComboBox.FormattingEnabled = true;
            aspectRatioComboBox.Items.AddRange(new object[] { resources.GetString("aspectRatioComboBox.Items"), resources.GetString("aspectRatioComboBox.Items1"), resources.GetString("aspectRatioComboBox.Items2"), resources.GetString("aspectRatioComboBox.Items3"), resources.GetString("aspectRatioComboBox.Items4"), resources.GetString("aspectRatioComboBox.Items5"), resources.GetString("aspectRatioComboBox.Items6"), resources.GetString("aspectRatioComboBox.Items7") });
            resources.ApplyResources(aspectRatioComboBox, "aspectRatioComboBox");
            aspectRatioComboBox.Name = "aspectRatioComboBox";
            // 
            // resolutionXInputBox
            // 
            resources.ApplyResources(resolutionXInputBox, "resolutionXInputBox");
            resolutionXInputBox.Name = "resolutionXInputBox";
            // 
            // resolutionLabel
            // 
            resources.ApplyResources(resolutionLabel, "resolutionLabel");
            resolutionLabel.Name = "resolutionLabel";
            // 
            // resolutionYInputBox
            // 
            resources.ApplyResources(resolutionYInputBox, "resolutionYInputBox");
            resolutionYInputBox.Name = "resolutionYInputBox";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // delayLable
            // 
            resources.ApplyResources(delayLable, "delayLable");
            delayLable.Name = "delayLable";
            // 
            // delayInputBox
            // 
            resources.ApplyResources(delayInputBox, "delayInputBox");
            delayInputBox.Name = "delayInputBox";
            // 
            // SettingsMenuForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(delayInputBox);
            Controls.Add(delayLable);
            Controls.Add(label2);
            Controls.Add(resolutionYInputBox);
            Controls.Add(resolutionLabel);
            Controls.Add(resolutionXInputBox);
            Controls.Add(aspectRatioComboBox);
            MaximizeBox = false;
            Name = "SettingsMenuForm";
            FormClosing += Save;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox aspectRatioComboBox;
        private TextBox resolutionXInputBox;
        private Label resolutionLabel;
        private TextBox resolutionYInputBox;
        private Label label2;
        private Label delayLable;
        private TextBox delayInputBox;
    }
}