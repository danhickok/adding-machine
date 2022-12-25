namespace AddingMachine
{
    partial class OptionsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsDialog));
            this.AppOptionsOKButton = new System.Windows.Forms.Button();
            this.AppOptionsCancelButton = new System.Windows.Forms.Button();
            this.TapeLinesOptionContainer = new System.Windows.Forms.Panel();
            this.TapeLinesKeepOption = new System.Windows.Forms.RadioButton();
            this.TapeLinesNewOption = new System.Windows.Forms.RadioButton();
            this.TapeLinesOptionContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // AppOptionsOKButton
            // 
            this.AppOptionsOKButton.Location = new System.Drawing.Point(249, 168);
            this.AppOptionsOKButton.Name = "AppOptionsOKButton";
            this.AppOptionsOKButton.Size = new System.Drawing.Size(75, 23);
            this.AppOptionsOKButton.TabIndex = 0;
            this.AppOptionsOKButton.Text = "OK";
            this.AppOptionsOKButton.UseVisualStyleBackColor = true;
            // 
            // AppOptionsCancelButton
            // 
            this.AppOptionsCancelButton.Location = new System.Drawing.Point(330, 168);
            this.AppOptionsCancelButton.Name = "AppOptionsCancelButton";
            this.AppOptionsCancelButton.Size = new System.Drawing.Size(75, 23);
            this.AppOptionsCancelButton.TabIndex = 1;
            this.AppOptionsCancelButton.Text = "Cancel";
            this.AppOptionsCancelButton.UseVisualStyleBackColor = true;
            // 
            // TapeLinesOptionContainer
            // 
            this.TapeLinesOptionContainer.Controls.Add(this.TapeLinesNewOption);
            this.TapeLinesOptionContainer.Controls.Add(this.TapeLinesKeepOption);
            this.TapeLinesOptionContainer.Location = new System.Drawing.Point(12, 34);
            this.TapeLinesOptionContainer.Name = "TapeLinesOptionContainer";
            this.TapeLinesOptionContainer.Size = new System.Drawing.Size(379, 102);
            this.TapeLinesOptionContainer.TabIndex = 3;
            // 
            // TapeLinesKeepOption
            // 
            this.TapeLinesKeepOption.AutoSize = true;
            this.TapeLinesKeepOption.Location = new System.Drawing.Point(3, 18);
            this.TapeLinesKeepOption.Name = "TapeLinesKeepOption";
            this.TapeLinesKeepOption.Size = new System.Drawing.Size(104, 19);
            this.TapeLinesKeepOption.TabIndex = 3;
            this.TapeLinesKeepOption.TabStop = true;
            this.TapeLinesKeepOption.Text = "Remember last";
            this.TapeLinesKeepOption.UseVisualStyleBackColor = true;
            // 
            // TapeLinesNewOption
            // 
            this.TapeLinesNewOption.AutoSize = true;
            this.TapeLinesNewOption.Location = new System.Drawing.Point(3, 56);
            this.TapeLinesNewOption.Name = "TapeLinesNewOption";
            this.TapeLinesNewOption.Size = new System.Drawing.Size(193, 19);
            this.TapeLinesNewOption.TabIndex = 4;
            this.TapeLinesNewOption.TabStop = true;
            this.TapeLinesNewOption.Text = "Start with a new tape every time";
            this.TapeLinesNewOption.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 203);
            this.Controls.Add(this.TapeLinesOptionContainer);
            this.Controls.Add(this.AppOptionsCancelButton);
            this.Controls.Add(this.AppOptionsOKButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.Text = "Adding Machine - Options";
            this.TapeLinesOptionContainer.ResumeLayout(false);
            this.TapeLinesOptionContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button AppOptionsOKButton;
        private Button AppOptionsCancelButton;
        private Panel TapeLinesOptionContainer;
        private RadioButton TapeLinesNewOption;
        private RadioButton TapeLinesKeepOption;
    }
}