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
            aspectRatioComboBox.Items.AddRange(new object[] { "5:4", "4:3", "3:2", "16:10", "5:3", "16:9", "19:10", "21:9" });
            aspectRatioComboBox.Location = new Point(12, 71);
            aspectRatioComboBox.Name = "aspectRatioComboBox";
            aspectRatioComboBox.Size = new Size(121, 23);
            aspectRatioComboBox.TabIndex = 0;
            // 
            // resolutionXInputBox
            // 
            resolutionXInputBox.Location = new Point(12, 27);
            resolutionXInputBox.Name = "resolutionXInputBox";
            resolutionXInputBox.Size = new Size(100, 23);
            resolutionXInputBox.TabIndex = 1;
            // 
            // resolutionLabel
            // 
            resolutionLabel.AutoSize = true;
            resolutionLabel.Location = new Point(12, 9);
            resolutionLabel.Name = "resolutionLabel";
            resolutionLabel.Size = new Size(63, 15);
            resolutionLabel.TabIndex = 2;
            resolutionLabel.Text = "Resolution";
            // 
            // resolutionYInputBox
            // 
            resolutionYInputBox.Location = new Point(118, 27);
            resolutionYInputBox.Name = "resolutionYInputBox";
            resolutionYInputBox.Size = new Size(100, 23);
            resolutionYInputBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 4;
            label2.Text = "Aspect Ratio";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // delayLable
            // 
            delayLable.AutoSize = true;
            delayLable.Location = new Point(12, 97);
            delayLable.Name = "delayLable";
            delayLable.Size = new Size(36, 15);
            delayLable.TabIndex = 5;
            delayLable.Text = "Delay";
            delayLable.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // delayInputBox
            // 
            delayInputBox.Location = new Point(12, 115);
            delayInputBox.Name = "delayInputBox";
            delayInputBox.Size = new Size(100, 23);
            delayInputBox.TabIndex = 6;
            // 
            // SettingsMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(264, 241);
            Controls.Add(delayInputBox);
            Controls.Add(delayLable);
            Controls.Add(label2);
            Controls.Add(resolutionYInputBox);
            Controls.Add(resolutionLabel);
            Controls.Add(resolutionXInputBox);
            Controls.Add(aspectRatioComboBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(280, 280);
            MinimumSize = new Size(280, 280);
            Name = "SettingsMenuForm";
            Text = "Settings";
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