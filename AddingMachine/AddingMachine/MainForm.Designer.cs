namespace AddingMachine
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainFormMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewTapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenTapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveTapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutAddingMachineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NumericDisplay = new System.Windows.Forms.Panel();
            this.DigitBox0 = new System.Windows.Forms.PictureBox();
            this.DecimalOptionsPanel = new System.Windows.Forms.Panel();
            this.DecimalOptionF = new System.Windows.Forms.RadioButton();
            this.DecimalOption0 = new System.Windows.Forms.RadioButton();
            this.DecimalOption2 = new System.Windows.Forms.RadioButton();
            this.DecimalOption4 = new System.Windows.Forms.RadioButton();
            this.DecimalOption6 = new System.Windows.Forms.RadioButton();
            this.KeyPanel = new System.Windows.Forms.Panel();
            this.KeyDecimal = new System.Windows.Forms.Button();
            this.Key0 = new System.Windows.Forms.Button();
            this.KeySTGT = new System.Windows.Forms.Button();
            this.Key3 = new System.Windows.Forms.Button();
            this.Key2 = new System.Windows.Forms.Button();
            this.Key1 = new System.Windows.Forms.Button();
            this.Key6 = new System.Windows.Forms.Button();
            this.Key5 = new System.Windows.Forms.Button();
            this.Key4 = new System.Windows.Forms.Button();
            this.KeyPlusEquals = new System.Windows.Forms.Button();
            this.Key9 = new System.Windows.Forms.Button();
            this.Key8 = new System.Windows.Forms.Button();
            this.Key7 = new System.Windows.Forms.Button();
            this.KeyMinus = new System.Windows.Forms.Button();
            this.KeyMultiply = new System.Windows.Forms.Button();
            this.KeyDivide = new System.Windows.Forms.Button();
            this.KeyCCE = new System.Windows.Forms.Button();
            this.TapeContainer = new System.Windows.Forms.Panel();
            this.TapeScrollBar = new System.Windows.Forms.VScrollBar();
            this.TapeText0 = new System.Windows.Forms.Label();
            this.DigitImages19 = new System.Windows.Forms.ImageList(this.components);
            this.KeyFocusTimer = new System.Windows.Forms.Timer(this.components);
            this.DigitImages38 = new System.Windows.Forms.ImageList(this.components);
            this.MainFormMenuStrip.SuspendLayout();
            this.NumericDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DigitBox0)).BeginInit();
            this.DecimalOptionsPanel.SuspendLayout();
            this.KeyPanel.SuspendLayout();
            this.TapeContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainFormMenuStrip
            // 
            this.MainFormMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainFormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainFormMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainFormMenuStrip.Name = "MainFormMenuStrip";
            this.MainFormMenuStrip.Size = new System.Drawing.Size(262, 24);
            this.MainFormMenuStrip.TabIndex = 1;
            this.MainFormMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewTapeToolStripMenuItem,
            this.OpenTapeToolStripMenuItem,
            this.SaveTapeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.ExitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // NewTapeToolStripMenuItem
            // 
            this.NewTapeToolStripMenuItem.Name = "NewTapeToolStripMenuItem";
            this.NewTapeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewTapeToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.NewTapeToolStripMenuItem.Text = "&New tape";
            this.NewTapeToolStripMenuItem.Click += new System.EventHandler(this.NewTapeToolStripMenuItem_Click);
            // 
            // OpenTapeToolStripMenuItem
            // 
            this.OpenTapeToolStripMenuItem.Name = "OpenTapeToolStripMenuItem";
            this.OpenTapeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenTapeToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.OpenTapeToolStripMenuItem.Text = "&Open tape...";
            this.OpenTapeToolStripMenuItem.Click += new System.EventHandler(this.OpenTapeToolStripMenuItem_Click);
            // 
            // SaveTapeToolStripMenuItem
            // 
            this.SaveTapeToolStripMenuItem.Name = "SaveTapeToolStripMenuItem";
            this.SaveTapeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveTapeToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.SaveTapeToolStripMenuItem.Text = "&Save tape";
            this.SaveTapeToolStripMenuItem.Click += new System.EventHandler(this.SaveTapeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(178, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.ExitToolStripMenuItem.Text = "E&xit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyToolStripMenuItem,
            this.PasteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.CopyToolStripMenuItem.Text = "&Copy";
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // PasteToolStripMenuItem
            // 
            this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            this.PasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.PasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.PasteToolStripMenuItem.Text = "&Paste";
            this.PasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutAddingMachineToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // AboutAddingMachineToolStripMenuItem
            // 
            this.AboutAddingMachineToolStripMenuItem.Name = "AboutAddingMachineToolStripMenuItem";
            this.AboutAddingMachineToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.AboutAddingMachineToolStripMenuItem.Text = "&About Adding Machine...";
            this.AboutAddingMachineToolStripMenuItem.Click += new System.EventHandler(this.AboutAddingMachineToolStripMenuItem_Click);
            // 
            // NumericDisplay
            // 
            this.NumericDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NumericDisplay.BackColor = System.Drawing.Color.Black;
            this.NumericDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NumericDisplay.Controls.Add(this.DigitBox0);
            this.NumericDisplay.Location = new System.Drawing.Point(4, 220);
            this.NumericDisplay.Name = "NumericDisplay";
            this.NumericDisplay.Size = new System.Drawing.Size(255, 40);
            this.NumericDisplay.TabIndex = 2;
            // 
            // DigitBox0
            // 
            this.DigitBox0.BackColor = System.Drawing.Color.Black;
            this.DigitBox0.InitialImage = ((System.Drawing.Image)(resources.GetObject("DigitBox0.InitialImage")));
            this.DigitBox0.Location = new System.Drawing.Point(10, 2);
            this.DigitBox0.Name = "DigitBox0";
            this.DigitBox0.Size = new System.Drawing.Size(19, 33);
            this.DigitBox0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DigitBox0.TabIndex = 0;
            this.DigitBox0.TabStop = false;
            // 
            // DecimalOptionsPanel
            // 
            this.DecimalOptionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DecimalOptionsPanel.Controls.Add(this.DecimalOptionF);
            this.DecimalOptionsPanel.Controls.Add(this.DecimalOption0);
            this.DecimalOptionsPanel.Controls.Add(this.DecimalOption2);
            this.DecimalOptionsPanel.Controls.Add(this.DecimalOption4);
            this.DecimalOptionsPanel.Controls.Add(this.DecimalOption6);
            this.DecimalOptionsPanel.Location = new System.Drawing.Point(4, 266);
            this.DecimalOptionsPanel.Name = "DecimalOptionsPanel";
            this.DecimalOptionsPanel.Size = new System.Drawing.Size(119, 29);
            this.DecimalOptionsPanel.TabIndex = 3;
            // 
            // DecimalOptionF
            // 
            this.DecimalOptionF.Appearance = System.Windows.Forms.Appearance.Button;
            this.DecimalOptionF.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.DecimalOptionF.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDark;
            this.DecimalOptionF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DecimalOptionF.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DecimalOptionF.Location = new System.Drawing.Point(95, 0);
            this.DecimalOptionF.Name = "DecimalOptionF";
            this.DecimalOptionF.Size = new System.Drawing.Size(18, 23);
            this.DecimalOptionF.TabIndex = 4;
            this.DecimalOptionF.Text = "F";
            this.DecimalOptionF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DecimalOptionF.UseVisualStyleBackColor = true;
            this.DecimalOptionF.Click += new System.EventHandler(this.DecimalOptionF_Click);
            // 
            // DecimalOption0
            // 
            this.DecimalOption0.Appearance = System.Windows.Forms.Appearance.Button;
            this.DecimalOption0.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.DecimalOption0.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDark;
            this.DecimalOption0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DecimalOption0.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DecimalOption0.Location = new System.Drawing.Point(72, 0);
            this.DecimalOption0.Name = "DecimalOption0";
            this.DecimalOption0.Size = new System.Drawing.Size(18, 23);
            this.DecimalOption0.TabIndex = 3;
            this.DecimalOption0.Text = "0";
            this.DecimalOption0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DecimalOption0.UseVisualStyleBackColor = true;
            this.DecimalOption0.Click += new System.EventHandler(this.DecimalOption0_Click);
            // 
            // DecimalOption2
            // 
            this.DecimalOption2.Appearance = System.Windows.Forms.Appearance.Button;
            this.DecimalOption2.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.DecimalOption2.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDark;
            this.DecimalOption2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DecimalOption2.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DecimalOption2.Location = new System.Drawing.Point(49, 0);
            this.DecimalOption2.Name = "DecimalOption2";
            this.DecimalOption2.Size = new System.Drawing.Size(18, 23);
            this.DecimalOption2.TabIndex = 2;
            this.DecimalOption2.Text = "2";
            this.DecimalOption2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DecimalOption2.UseVisualStyleBackColor = true;
            this.DecimalOption2.Click += new System.EventHandler(this.DecimalOption2_Click);
            // 
            // DecimalOption4
            // 
            this.DecimalOption4.Appearance = System.Windows.Forms.Appearance.Button;
            this.DecimalOption4.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.DecimalOption4.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDark;
            this.DecimalOption4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DecimalOption4.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DecimalOption4.Location = new System.Drawing.Point(26, 0);
            this.DecimalOption4.Name = "DecimalOption4";
            this.DecimalOption4.Size = new System.Drawing.Size(18, 23);
            this.DecimalOption4.TabIndex = 1;
            this.DecimalOption4.Text = "4";
            this.DecimalOption4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DecimalOption4.UseVisualStyleBackColor = true;
            this.DecimalOption4.Click += new System.EventHandler(this.DecimalOption4_Click);
            // 
            // DecimalOption6
            // 
            this.DecimalOption6.Appearance = System.Windows.Forms.Appearance.Button;
            this.DecimalOption6.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.DecimalOption6.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDark;
            this.DecimalOption6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DecimalOption6.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DecimalOption6.Location = new System.Drawing.Point(3, 0);
            this.DecimalOption6.Name = "DecimalOption6";
            this.DecimalOption6.Size = new System.Drawing.Size(18, 23);
            this.DecimalOption6.TabIndex = 0;
            this.DecimalOption6.Text = "6";
            this.DecimalOption6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DecimalOption6.UseVisualStyleBackColor = true;
            this.DecimalOption6.Click += new System.EventHandler(this.DecimalOption6_Click);
            // 
            // KeyPanel
            // 
            this.KeyPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.KeyPanel.Controls.Add(this.KeyDecimal);
            this.KeyPanel.Controls.Add(this.Key0);
            this.KeyPanel.Controls.Add(this.KeySTGT);
            this.KeyPanel.Controls.Add(this.Key3);
            this.KeyPanel.Controls.Add(this.Key2);
            this.KeyPanel.Controls.Add(this.Key1);
            this.KeyPanel.Controls.Add(this.Key6);
            this.KeyPanel.Controls.Add(this.Key5);
            this.KeyPanel.Controls.Add(this.Key4);
            this.KeyPanel.Controls.Add(this.KeyPlusEquals);
            this.KeyPanel.Controls.Add(this.Key9);
            this.KeyPanel.Controls.Add(this.Key8);
            this.KeyPanel.Controls.Add(this.Key7);
            this.KeyPanel.Controls.Add(this.KeyMinus);
            this.KeyPanel.Controls.Add(this.KeyMultiply);
            this.KeyPanel.Controls.Add(this.KeyDivide);
            this.KeyPanel.Controls.Add(this.KeyCCE);
            this.KeyPanel.Location = new System.Drawing.Point(0, 298);
            this.KeyPanel.Name = "KeyPanel";
            this.KeyPanel.Size = new System.Drawing.Size(260, 208);
            this.KeyPanel.TabIndex = 4;
            // 
            // KeyDecimal
            // 
            this.KeyDecimal.Location = new System.Drawing.Point(131, 163);
            this.KeyDecimal.Name = "KeyDecimal";
            this.KeyDecimal.Size = new System.Drawing.Size(64, 40);
            this.KeyDecimal.TabIndex = 37;
            this.KeyDecimal.TabStop = false;
            this.KeyDecimal.Text = "·";
            this.KeyDecimal.UseVisualStyleBackColor = true;
            this.KeyDecimal.Click += new System.EventHandler(this.KeyDecimal_Click);
            // 
            // Key0
            // 
            this.Key0.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Key0.Location = new System.Drawing.Point(3, 163);
            this.Key0.Name = "Key0";
            this.Key0.Size = new System.Drawing.Size(128, 40);
            this.Key0.TabIndex = 36;
            this.Key0.TabStop = false;
            this.Key0.Text = "0";
            this.Key0.UseVisualStyleBackColor = true;
            this.Key0.Click += new System.EventHandler(this.Key0_Click);
            // 
            // KeySTGT
            // 
            this.KeySTGT.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.KeySTGT.Location = new System.Drawing.Point(195, 123);
            this.KeySTGT.Name = "KeySTGT";
            this.KeySTGT.Size = new System.Drawing.Size(64, 80);
            this.KeySTGT.TabIndex = 35;
            this.KeySTGT.TabStop = false;
            this.KeySTGT.Text = "ST\r\nGT";
            this.KeySTGT.UseVisualStyleBackColor = true;
            this.KeySTGT.Click += new System.EventHandler(this.KeySTGT_Click);
            // 
            // Key3
            // 
            this.Key3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Key3.Location = new System.Drawing.Point(131, 123);
            this.Key3.Name = "Key3";
            this.Key3.Size = new System.Drawing.Size(64, 40);
            this.Key3.TabIndex = 34;
            this.Key3.TabStop = false;
            this.Key3.Text = "3";
            this.Key3.UseVisualStyleBackColor = true;
            this.Key3.Click += new System.EventHandler(this.Key3_Click);
            // 
            // Key2
            // 
            this.Key2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Key2.Location = new System.Drawing.Point(67, 123);
            this.Key2.Name = "Key2";
            this.Key2.Size = new System.Drawing.Size(64, 40);
            this.Key2.TabIndex = 33;
            this.Key2.TabStop = false;
            this.Key2.Text = "2";
            this.Key2.UseVisualStyleBackColor = true;
            this.Key2.Click += new System.EventHandler(this.Key2_Click);
            // 
            // Key1
            // 
            this.Key1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Key1.Location = new System.Drawing.Point(3, 123);
            this.Key1.Name = "Key1";
            this.Key1.Size = new System.Drawing.Size(64, 40);
            this.Key1.TabIndex = 32;
            this.Key1.TabStop = false;
            this.Key1.Text = "1";
            this.Key1.UseVisualStyleBackColor = true;
            this.Key1.Click += new System.EventHandler(this.Key1_Click);
            // 
            // Key6
            // 
            this.Key6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Key6.Location = new System.Drawing.Point(131, 83);
            this.Key6.Name = "Key6";
            this.Key6.Size = new System.Drawing.Size(64, 40);
            this.Key6.TabIndex = 31;
            this.Key6.TabStop = false;
            this.Key6.Text = "6";
            this.Key6.UseVisualStyleBackColor = true;
            this.Key6.Click += new System.EventHandler(this.Key6_Click);
            // 
            // Key5
            // 
            this.Key5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Key5.Location = new System.Drawing.Point(67, 83);
            this.Key5.Name = "Key5";
            this.Key5.Size = new System.Drawing.Size(64, 40);
            this.Key5.TabIndex = 30;
            this.Key5.TabStop = false;
            this.Key5.Text = "5";
            this.Key5.UseVisualStyleBackColor = true;
            this.Key5.Click += new System.EventHandler(this.Key5_Click);
            // 
            // Key4
            // 
            this.Key4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Key4.Location = new System.Drawing.Point(3, 83);
            this.Key4.Name = "Key4";
            this.Key4.Size = new System.Drawing.Size(64, 40);
            this.Key4.TabIndex = 29;
            this.Key4.TabStop = false;
            this.Key4.Text = "4";
            this.Key4.UseVisualStyleBackColor = true;
            this.Key4.Click += new System.EventHandler(this.Key4_Click);
            // 
            // KeyPlusEquals
            // 
            this.KeyPlusEquals.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.KeyPlusEquals.Location = new System.Drawing.Point(195, 43);
            this.KeyPlusEquals.Name = "KeyPlusEquals";
            this.KeyPlusEquals.Size = new System.Drawing.Size(64, 80);
            this.KeyPlusEquals.TabIndex = 28;
            this.KeyPlusEquals.TabStop = false;
            this.KeyPlusEquals.Text = "+\r\n=";
            this.KeyPlusEquals.UseVisualStyleBackColor = true;
            this.KeyPlusEquals.Click += new System.EventHandler(this.KeyPlusEquals_Click);
            // 
            // Key9
            // 
            this.Key9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Key9.Location = new System.Drawing.Point(131, 43);
            this.Key9.Name = "Key9";
            this.Key9.Size = new System.Drawing.Size(64, 40);
            this.Key9.TabIndex = 27;
            this.Key9.TabStop = false;
            this.Key9.Text = "9";
            this.Key9.UseVisualStyleBackColor = true;
            this.Key9.Click += new System.EventHandler(this.Key9_Click);
            // 
            // Key8
            // 
            this.Key8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Key8.Location = new System.Drawing.Point(67, 43);
            this.Key8.Name = "Key8";
            this.Key8.Size = new System.Drawing.Size(64, 40);
            this.Key8.TabIndex = 26;
            this.Key8.TabStop = false;
            this.Key8.Text = "8";
            this.Key8.UseVisualStyleBackColor = true;
            this.Key8.Click += new System.EventHandler(this.Key8_Click);
            // 
            // Key7
            // 
            this.Key7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Key7.Location = new System.Drawing.Point(3, 43);
            this.Key7.Name = "Key7";
            this.Key7.Size = new System.Drawing.Size(64, 40);
            this.Key7.TabIndex = 25;
            this.Key7.TabStop = false;
            this.Key7.Text = "7";
            this.Key7.UseVisualStyleBackColor = true;
            this.Key7.Click += new System.EventHandler(this.Key7_Click);
            // 
            // KeyMinus
            // 
            this.KeyMinus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.KeyMinus.Location = new System.Drawing.Point(195, 3);
            this.KeyMinus.Name = "KeyMinus";
            this.KeyMinus.Size = new System.Drawing.Size(64, 40);
            this.KeyMinus.TabIndex = 24;
            this.KeyMinus.TabStop = false;
            this.KeyMinus.Text = "−";
            this.KeyMinus.UseVisualStyleBackColor = true;
            this.KeyMinus.Click += new System.EventHandler(this.KeyMinus_Click);
            // 
            // KeyMultiply
            // 
            this.KeyMultiply.Location = new System.Drawing.Point(131, 3);
            this.KeyMultiply.Name = "KeyMultiply";
            this.KeyMultiply.Size = new System.Drawing.Size(64, 40);
            this.KeyMultiply.TabIndex = 23;
            this.KeyMultiply.TabStop = false;
            this.KeyMultiply.Text = "✕";
            this.KeyMultiply.UseVisualStyleBackColor = true;
            this.KeyMultiply.Click += new System.EventHandler(this.KeyMultiply_Click);
            // 
            // KeyDivide
            // 
            this.KeyDivide.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.KeyDivide.Location = new System.Drawing.Point(67, 3);
            this.KeyDivide.Name = "KeyDivide";
            this.KeyDivide.Size = new System.Drawing.Size(64, 40);
            this.KeyDivide.TabIndex = 22;
            this.KeyDivide.TabStop = false;
            this.KeyDivide.Text = "÷";
            this.KeyDivide.UseVisualStyleBackColor = true;
            this.KeyDivide.Click += new System.EventHandler(this.KeyDivide_Click);
            // 
            // KeyCCE
            // 
            this.KeyCCE.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.KeyCCE.Location = new System.Drawing.Point(3, 3);
            this.KeyCCE.Name = "KeyCCE";
            this.KeyCCE.Size = new System.Drawing.Size(64, 40);
            this.KeyCCE.TabIndex = 21;
            this.KeyCCE.TabStop = false;
            this.KeyCCE.Text = "CE/C";
            this.KeyCCE.UseVisualStyleBackColor = true;
            this.KeyCCE.Click += new System.EventHandler(this.KeyCCE_Click);
            // 
            // TapeContainer
            // 
            this.TapeContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TapeContainer.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.TapeContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TapeContainer.Controls.Add(this.TapeScrollBar);
            this.TapeContainer.Controls.Add(this.TapeText0);
            this.TapeContainer.Location = new System.Drawing.Point(3, 27);
            this.TapeContainer.Name = "TapeContainer";
            this.TapeContainer.Size = new System.Drawing.Size(256, 187);
            this.TapeContainer.TabIndex = 5;
            // 
            // TapeScrollBar
            // 
            this.TapeScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TapeScrollBar.LargeChange = 1;
            this.TapeScrollBar.Location = new System.Drawing.Point(234, 0);
            this.TapeScrollBar.Name = "TapeScrollBar";
            this.TapeScrollBar.Size = new System.Drawing.Size(19, 183);
            this.TapeScrollBar.TabIndex = 0;
            this.TapeScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.TapeScrollBar_Scroll);
            this.TapeScrollBar.SizeChanged += new System.EventHandler(this.TapeScrollBar_SizeChanged);
            // 
            // TapeText0
            // 
            this.TapeText0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TapeText0.BackColor = System.Drawing.SystemColors.Window;
            this.TapeText0.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TapeText0.Location = new System.Drawing.Point(0, 162);
            this.TapeText0.Name = "TapeText0";
            this.TapeText0.Size = new System.Drawing.Size(233, 20);
            this.TapeText0.TabIndex = 1;
            this.TapeText0.Text = "0.00 GT";
            this.TapeText0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TapeText0.DoubleClick += new System.EventHandler(this.TapeText_DoubleClick);
            // 
            // DigitImages19
            // 
            this.DigitImages19.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.DigitImages19.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("DigitImages19.ImageStream")));
            this.DigitImages19.TransparentColor = System.Drawing.Color.Transparent;
            this.DigitImages19.Images.SetKeyName(0, "Digit19_0.png");
            this.DigitImages19.Images.SetKeyName(1, "Digit19_1.png");
            this.DigitImages19.Images.SetKeyName(2, "Digit19_2.png");
            this.DigitImages19.Images.SetKeyName(3, "Digit19_3.png");
            this.DigitImages19.Images.SetKeyName(4, "Digit19_4.png");
            this.DigitImages19.Images.SetKeyName(5, "Digit19_5.png");
            this.DigitImages19.Images.SetKeyName(6, "Digit19_6.png");
            this.DigitImages19.Images.SetKeyName(7, "Digit19_7.png");
            this.DigitImages19.Images.SetKeyName(8, "Digit19_8.png");
            this.DigitImages19.Images.SetKeyName(9, "Digit19_9.png");
            this.DigitImages19.Images.SetKeyName(10, "Digit19_0d.png");
            this.DigitImages19.Images.SetKeyName(11, "Digit19_1d.png");
            this.DigitImages19.Images.SetKeyName(12, "Digit19_2d.png");
            this.DigitImages19.Images.SetKeyName(13, "Digit19_3d.png");
            this.DigitImages19.Images.SetKeyName(14, "Digit19_4d.png");
            this.DigitImages19.Images.SetKeyName(15, "Digit19_5d.png");
            this.DigitImages19.Images.SetKeyName(16, "Digit19_6d.png");
            this.DigitImages19.Images.SetKeyName(17, "Digit19_7d.png");
            this.DigitImages19.Images.SetKeyName(18, "Digit19_8d.png");
            this.DigitImages19.Images.SetKeyName(19, "Digit19_9d.png");
            this.DigitImages19.Images.SetKeyName(20, "Digit19_0c.png");
            this.DigitImages19.Images.SetKeyName(21, "Digit19_1c.png");
            this.DigitImages19.Images.SetKeyName(22, "Digit19_2c.png");
            this.DigitImages19.Images.SetKeyName(23, "Digit19_3c.png");
            this.DigitImages19.Images.SetKeyName(24, "Digit19_4c.png");
            this.DigitImages19.Images.SetKeyName(25, "Digit19_5c.png");
            this.DigitImages19.Images.SetKeyName(26, "Digit19_6c.png");
            this.DigitImages19.Images.SetKeyName(27, "Digit19_7c.png");
            this.DigitImages19.Images.SetKeyName(28, "Digit19_8c.png");
            this.DigitImages19.Images.SetKeyName(29, "Digit19_9c.png");
            this.DigitImages19.Images.SetKeyName(30, "Digit19_Blank.png");
            this.DigitImages19.Images.SetKeyName(31, "Digit19_E.png");
            this.DigitImages19.Images.SetKeyName(32, "Digit19_Minus.png");
            // 
            // KeyFocusTimer
            // 
            this.KeyFocusTimer.Enabled = true;
            this.KeyFocusTimer.Interval = 50;
            this.KeyFocusTimer.Tick += new System.EventHandler(this.KeyFocusTimer_Tick);
            // 
            // DigitImages38
            // 
            this.DigitImages38.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.DigitImages38.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("DigitImages38.ImageStream")));
            this.DigitImages38.TransparentColor = System.Drawing.Color.Transparent;
            this.DigitImages38.Images.SetKeyName(0, "Digit38_0.png");
            this.DigitImages38.Images.SetKeyName(1, "Digit38_1.png");
            this.DigitImages38.Images.SetKeyName(2, "Digit38_2.png");
            this.DigitImages38.Images.SetKeyName(3, "Digit38_3.png");
            this.DigitImages38.Images.SetKeyName(4, "Digit38_4.png");
            this.DigitImages38.Images.SetKeyName(5, "Digit38_5.png");
            this.DigitImages38.Images.SetKeyName(6, "Digit38_6.png");
            this.DigitImages38.Images.SetKeyName(7, "Digit38_7.png");
            this.DigitImages38.Images.SetKeyName(8, "Digit38_8.png");
            this.DigitImages38.Images.SetKeyName(9, "Digit38_9.png");
            this.DigitImages38.Images.SetKeyName(10, "Digit38_0d.png");
            this.DigitImages38.Images.SetKeyName(11, "Digit38_1d.png");
            this.DigitImages38.Images.SetKeyName(12, "Digit38_2d.png");
            this.DigitImages38.Images.SetKeyName(13, "Digit38_3d.png");
            this.DigitImages38.Images.SetKeyName(14, "Digit38_4d.png");
            this.DigitImages38.Images.SetKeyName(15, "Digit38_5d.png");
            this.DigitImages38.Images.SetKeyName(16, "Digit38_6d.png");
            this.DigitImages38.Images.SetKeyName(17, "Digit38_7d.png");
            this.DigitImages38.Images.SetKeyName(18, "Digit38_8d.png");
            this.DigitImages38.Images.SetKeyName(19, "Digit38_9d.png");
            this.DigitImages38.Images.SetKeyName(20, "Digit38_0c.png");
            this.DigitImages38.Images.SetKeyName(21, "Digit38_1c.png");
            this.DigitImages38.Images.SetKeyName(22, "Digit38_2c.png");
            this.DigitImages38.Images.SetKeyName(23, "Digit38_3c.png");
            this.DigitImages38.Images.SetKeyName(24, "Digit38_4c.png");
            this.DigitImages38.Images.SetKeyName(25, "Digit38_5c.png");
            this.DigitImages38.Images.SetKeyName(26, "Digit38_6c.png");
            this.DigitImages38.Images.SetKeyName(27, "Digit38_7c.png");
            this.DigitImages38.Images.SetKeyName(28, "Digit38_8c.png");
            this.DigitImages38.Images.SetKeyName(29, "Digit38_9c.png");
            this.DigitImages38.Images.SetKeyName(30, "Digit38_Blank.png");
            this.DigitImages38.Images.SetKeyName(31, "Digit38_E.png");
            this.DigitImages38.Images.SetKeyName(32, "Digit38_Minus.png");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(262, 505);
            this.Controls.Add(this.TapeContainer);
            this.Controls.Add(this.KeyPanel);
            this.Controls.Add(this.DecimalOptionsPanel);
            this.Controls.Add(this.NumericDisplay);
            this.Controls.Add(this.MainFormMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(278, 900);
            this.MinimumSize = new System.Drawing.Size(278, 400);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Adding Machine";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DpiChanged += new System.Windows.Forms.DpiChangedEventHandler(this.MainForm_DpiChanged);
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.MainFormMenuStrip.ResumeLayout(false);
            this.MainFormMenuStrip.PerformLayout();
            this.NumericDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DigitBox0)).EndInit();
            this.DecimalOptionsPanel.ResumeLayout(false);
            this.KeyPanel.ResumeLayout(false);
            this.TapeContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip MainFormMenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private Panel NumericDisplay;
        private Panel DecimalOptionsPanel;
        private RadioButton DecimalOptionF;
        private RadioButton DecimalOption0;
        private RadioButton DecimalOption2;
        private RadioButton DecimalOption4;
        private RadioButton DecimalOption6;
        private ToolStripMenuItem NewTapeToolStripMenuItem;
        private ToolStripMenuItem OpenTapeToolStripMenuItem;
        private ToolStripMenuItem SaveTapeToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem CopyToolStripMenuItem;
        private ToolStripMenuItem PasteToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem AboutAddingMachineToolStripMenuItem;
        private Panel KeyPanel;
        private Button KeyDecimal;
        private Button Key0;
        private Button KeySTGT;
        private Button Key3;
        private Button Key2;
        private Button Key1;
        private Button Key6;
        private Button Key5;
        private Button Key4;
        private Button KeyPlusEquals;
        private Button Key9;
        private Button Key8;
        private Button Key7;
        private Button KeyMinus;
        private Button KeyMultiply;
        private Button KeyDivide;
        private Button KeyCCE;
        private Panel TapeContainer;
        private VScrollBar TapeScrollBar;
        private Label TapeText0;
        private PictureBox DigitBox0;
        private ImageList DigitImages19;
        private System.Windows.Forms.Timer KeyFocusTimer;
        private ImageList DigitImages38;
    }
}