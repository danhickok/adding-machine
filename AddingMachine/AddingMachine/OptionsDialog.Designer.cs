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
            this.TapeLinesNewOption = new System.Windows.Forms.RadioButton();
            this.TapeLinesKeepOption = new System.Windows.Forms.RadioButton();
            this.TapeLinesKeepLabel = new System.Windows.Forms.Label();
            this.TapeLinesOptionLabel = new System.Windows.Forms.Label();
            this.TapeLinesKeepNumber = new System.Windows.Forms.NumericUpDown();
            this.TapeLinesOptionContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TapeLinesKeepNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // AppOptionsOKButton
            // 
            this.AppOptionsOKButton.Location = new System.Drawing.Point(235, 142);
            this.AppOptionsOKButton.Name = "AppOptionsOKButton";
            this.AppOptionsOKButton.Size = new System.Drawing.Size(75, 23);
            this.AppOptionsOKButton.TabIndex = 2;
            this.AppOptionsOKButton.Text = "OK";
            this.AppOptionsOKButton.UseVisualStyleBackColor = true;
            // 
            // AppOptionsCancelButton
            // 
            this.AppOptionsCancelButton.Location = new System.Drawing.Point(316, 142);
            this.AppOptionsCancelButton.Name = "AppOptionsCancelButton";
            this.AppOptionsCancelButton.Size = new System.Drawing.Size(75, 23);
            this.AppOptionsCancelButton.TabIndex = 3;
            this.AppOptionsCancelButton.Text = "Cancel";
            this.AppOptionsCancelButton.UseVisualStyleBackColor = true;
            // 
            // TapeLinesOptionContainer
            // 
            this.TapeLinesOptionContainer.Controls.Add(this.TapeLinesKeepNumber);
            this.TapeLinesOptionContainer.Controls.Add(this.TapeLinesKeepLabel);
            this.TapeLinesOptionContainer.Controls.Add(this.TapeLinesNewOption);
            this.TapeLinesOptionContainer.Controls.Add(this.TapeLinesKeepOption);
            this.TapeLinesOptionContainer.Location = new System.Drawing.Point(12, 34);
            this.TapeLinesOptionContainer.Name = "TapeLinesOptionContainer";
            this.TapeLinesOptionContainer.Size = new System.Drawing.Size(379, 102);
            this.TapeLinesOptionContainer.TabIndex = 1;
            // 
            // TapeLinesNewOption
            // 
            this.TapeLinesNewOption.AutoSize = true;
            this.TapeLinesNewOption.Location = new System.Drawing.Point(3, 63);
            this.TapeLinesNewOption.Name = "TapeLinesNewOption";
            this.TapeLinesNewOption.Size = new System.Drawing.Size(135, 19);
            this.TapeLinesNewOption.TabIndex = 3;
            this.TapeLinesNewOption.TabStop = true;
            this.TapeLinesNewOption.Text = "Start with a new tape";
            this.TapeLinesNewOption.UseVisualStyleBackColor = true;
            // 
            // TapeLinesKeepOption
            // 
            this.TapeLinesKeepOption.AutoSize = true;
            this.TapeLinesKeepOption.Location = new System.Drawing.Point(3, 18);
            this.TapeLinesKeepOption.Name = "TapeLinesKeepOption";
            this.TapeLinesKeepOption.Size = new System.Drawing.Size(124, 19);
            this.TapeLinesKeepOption.TabIndex = 0;
            this.TapeLinesKeepOption.TabStop = true;
            this.TapeLinesKeepOption.Text = "Remember the last";
            this.TapeLinesKeepOption.UseVisualStyleBackColor = true;
            // 
            // TapeLinesKeepLabel
            // 
            this.TapeLinesKeepLabel.Location = new System.Drawing.Point(224, 20);
            this.TapeLinesKeepLabel.Name = "TapeLinesKeepLabel";
            this.TapeLinesKeepLabel.Size = new System.Drawing.Size(146, 36);
            this.TapeLinesKeepLabel.TabIndex = 2;
            this.TapeLinesKeepLabel.Text = "lines of the tape (including blank lines)";
            // 
            // TapeLinesOptionLabel
            // 
            this.TapeLinesOptionLabel.AutoSize = true;
            this.TapeLinesOptionLabel.Location = new System.Drawing.Point(15, 16);
            this.TapeLinesOptionLabel.Name = "TapeLinesOptionLabel";
            this.TapeLinesOptionLabel.Size = new System.Drawing.Size(163, 15);
            this.TapeLinesOptionLabel.TabIndex = 0;
            this.TapeLinesOptionLabel.Text = "When Adding Machine starts:";
            // 
            // TapeLinesKeepNumber
            // 
            this.TapeLinesKeepNumber.Location = new System.Drawing.Point(133, 17);
            this.TapeLinesKeepNumber.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.TapeLinesKeepNumber.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.TapeLinesKeepNumber.Name = "TapeLinesKeepNumber";
            this.TapeLinesKeepNumber.Size = new System.Drawing.Size(85, 23);
            this.TapeLinesKeepNumber.TabIndex = 1;
            this.TapeLinesKeepNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TapeLinesKeepNumber.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // OptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 177);
            this.Controls.Add(this.TapeLinesOptionLabel);
            this.Controls.Add(this.TapeLinesOptionContainer);
            this.Controls.Add(this.AppOptionsCancelButton);
            this.Controls.Add(this.AppOptionsOKButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsDialog";
            this.Text = "Adding Machine - Options";
            this.TapeLinesOptionContainer.ResumeLayout(false);
            this.TapeLinesOptionContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TapeLinesKeepNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button AppOptionsOKButton;
        private Button AppOptionsCancelButton;
        private Panel TapeLinesOptionContainer;
        private RadioButton TapeLinesNewOption;
        private RadioButton TapeLinesKeepOption;
        private NumericUpDown TapeLinesKeepNumber;
        private Label TapeLinesKeepLabel;
        private Label TapeLinesOptionLabel;
    }
}