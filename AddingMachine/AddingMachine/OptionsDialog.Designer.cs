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
            AppOptionsOKButton = new Button();
            AppOptionsCancelButton = new Button();
            TapeLinesOptionContainer = new Panel();
            TapeLinesKeepNumber = new NumericUpDown();
            TapeLinesKeepLabel = new Label();
            TapeLinesNewOption = new RadioButton();
            TapeLinesKeepOption = new RadioButton();
            TapeLinesOptionLabel = new Label();
            IncludesValuesLabel = new Label();
            TapeLinesOptionContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TapeLinesKeepNumber).BeginInit();
            SuspendLayout();
            // 
            // AppOptionsOKButton
            // 
            AppOptionsOKButton.Location = new Point(235, 170);
            AppOptionsOKButton.Name = "AppOptionsOKButton";
            AppOptionsOKButton.Size = new Size(75, 23);
            AppOptionsOKButton.TabIndex = 2;
            AppOptionsOKButton.Text = "OK";
            AppOptionsOKButton.UseVisualStyleBackColor = true;
            AppOptionsOKButton.Click += AppOptionsOKButton_Click;
            // 
            // AppOptionsCancelButton
            // 
            AppOptionsCancelButton.Location = new Point(316, 170);
            AppOptionsCancelButton.Name = "AppOptionsCancelButton";
            AppOptionsCancelButton.Size = new Size(75, 23);
            AppOptionsCancelButton.TabIndex = 3;
            AppOptionsCancelButton.Text = "Cancel";
            AppOptionsCancelButton.UseVisualStyleBackColor = true;
            AppOptionsCancelButton.Click += AppOptionsCancelButton_Click;
            // 
            // TapeLinesOptionContainer
            // 
            TapeLinesOptionContainer.Controls.Add(IncludesValuesLabel);
            TapeLinesOptionContainer.Controls.Add(TapeLinesKeepNumber);
            TapeLinesOptionContainer.Controls.Add(TapeLinesKeepLabel);
            TapeLinesOptionContainer.Controls.Add(TapeLinesNewOption);
            TapeLinesOptionContainer.Controls.Add(TapeLinesKeepOption);
            TapeLinesOptionContainer.Location = new Point(12, 34);
            TapeLinesOptionContainer.Name = "TapeLinesOptionContainer";
            TapeLinesOptionContainer.Size = new Size(379, 130);
            TapeLinesOptionContainer.TabIndex = 1;
            // 
            // TapeLinesKeepNumber
            // 
            TapeLinesKeepNumber.Increment = new decimal(new int[] { 500, 0, 0, 0 });
            TapeLinesKeepNumber.Location = new Point(133, 18);
            TapeLinesKeepNumber.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            TapeLinesKeepNumber.Minimum = new decimal(new int[] { 500, 0, 0, 0 });
            TapeLinesKeepNumber.Name = "TapeLinesKeepNumber";
            TapeLinesKeepNumber.Size = new Size(85, 23);
            TapeLinesKeepNumber.TabIndex = 1;
            TapeLinesKeepNumber.TextAlign = HorizontalAlignment.Right;
            TapeLinesKeepNumber.Value = new decimal(new int[] { 500, 0, 0, 0 });
            // 
            // TapeLinesKeepLabel
            // 
            TapeLinesKeepLabel.Location = new Point(224, 20);
            TapeLinesKeepLabel.Name = "TapeLinesKeepLabel";
            TapeLinesKeepLabel.Size = new Size(146, 36);
            TapeLinesKeepLabel.TabIndex = 2;
            TapeLinesKeepLabel.Text = "lines of the tape (including blank lines)";
            // 
            // TapeLinesNewOption
            // 
            TapeLinesNewOption.AutoSize = true;
            TapeLinesNewOption.Location = new Point(3, 97);
            TapeLinesNewOption.Name = "TapeLinesNewOption";
            TapeLinesNewOption.Size = new Size(135, 19);
            TapeLinesNewOption.TabIndex = 3;
            TapeLinesNewOption.TabStop = true;
            TapeLinesNewOption.Text = "Start with a new tape";
            TapeLinesNewOption.UseVisualStyleBackColor = true;
            TapeLinesNewOption.CheckedChanged += TapeLinesNewOption_CheckedChanged;
            // 
            // TapeLinesKeepOption
            // 
            TapeLinesKeepOption.AutoSize = true;
            TapeLinesKeepOption.Location = new Point(3, 18);
            TapeLinesKeepOption.Name = "TapeLinesKeepOption";
            TapeLinesKeepOption.Size = new Size(124, 19);
            TapeLinesKeepOption.TabIndex = 0;
            TapeLinesKeepOption.TabStop = true;
            TapeLinesKeepOption.Text = "Remember the last";
            TapeLinesKeepOption.UseVisualStyleBackColor = true;
            TapeLinesKeepOption.CheckedChanged += TapeLinesKeepOption_CheckedChanged;
            // 
            // TapeLinesOptionLabel
            // 
            TapeLinesOptionLabel.AutoSize = true;
            TapeLinesOptionLabel.Location = new Point(15, 16);
            TapeLinesOptionLabel.Name = "TapeLinesOptionLabel";
            TapeLinesOptionLabel.Size = new Size(163, 15);
            TapeLinesOptionLabel.TabIndex = 0;
            TapeLinesOptionLabel.Text = "When Adding Machine starts:";
            // 
            // IncludesValuesLabel
            // 
            IncludesValuesLabel.AutoSize = true;
            IncludesValuesLabel.Location = new Point(133, 56);
            IncludesValuesLabel.Name = "IncludesValuesLabel";
            IncludesValuesLabel.Size = new Size(184, 15);
            IncludesValuesLabel.TabIndex = 4;
            IncludesValuesLabel.Text = "Also remembers calculator values";
            // 
            // OptionsDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 203);
            Controls.Add(TapeLinesOptionLabel);
            Controls.Add(TapeLinesOptionContainer);
            Controls.Add(AppOptionsCancelButton);
            Controls.Add(AppOptionsOKButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OptionsDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Adding Machine - Options";
            Load += OptionsDialog_Load;
            TapeLinesOptionContainer.ResumeLayout(false);
            TapeLinesOptionContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TapeLinesKeepNumber).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private Label IncludesValuesLabel;
    }
}