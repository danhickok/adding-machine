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
            this.TapeDisplay = new System.Windows.Forms.TextBox();
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutAddingMachineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NumericDisplay = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DecimalOptionsPanel = new System.Windows.Forms.Panel();
            this.DecimalOptionF = new System.Windows.Forms.RadioButton();
            this.DecimalOption0 = new System.Windows.Forms.RadioButton();
            this.DecimalOption2 = new System.Windows.Forms.RadioButton();
            this.DecimalOption4 = new System.Windows.Forms.RadioButton();
            this.DecimalOption6 = new System.Windows.Forms.RadioButton();
            this.KeyCCE = new System.Windows.Forms.Button();
            this.KeyDivide = new System.Windows.Forms.Button();
            this.KeyMultiply = new System.Windows.Forms.Button();
            this.KeyMinus = new System.Windows.Forms.Button();
            this.KeyPlusEquals = new System.Windows.Forms.Button();
            this.Key9 = new System.Windows.Forms.Button();
            this.Key8 = new System.Windows.Forms.Button();
            this.Key7 = new System.Windows.Forms.Button();
            this.Key6 = new System.Windows.Forms.Button();
            this.Key5 = new System.Windows.Forms.Button();
            this.Key4 = new System.Windows.Forms.Button();
            this.Key3 = new System.Windows.Forms.Button();
            this.Key2 = new System.Windows.Forms.Button();
            this.Key1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.KeyDecimal = new System.Windows.Forms.Button();
            this.Key0 = new System.Windows.Forms.Button();
            this.MainMenuStrip.SuspendLayout();
            this.NumericDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.DecimalOptionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TapeDisplay
            // 
            this.TapeDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TapeDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TapeDisplay.Location = new System.Drawing.Point(4, 27);
            this.TapeDisplay.Multiline = true;
            this.TapeDisplay.Name = "TapeDisplay";
            this.TapeDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TapeDisplay.Size = new System.Drawing.Size(260, 190);
            this.TapeDisplay.TabIndex = 0;
            this.TapeDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(270, 24);
            this.MainMenuStrip.TabIndex = 1;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTapeToolStripMenuItem,
            this.openTapeToolStripMenuItem,
            this.saveTapeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newTapeToolStripMenuItem
            // 
            this.newTapeToolStripMenuItem.Name = "newTapeToolStripMenuItem";
            this.newTapeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newTapeToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.newTapeToolStripMenuItem.Text = "&New tape";
            // 
            // openTapeToolStripMenuItem
            // 
            this.openTapeToolStripMenuItem.Name = "openTapeToolStripMenuItem";
            this.openTapeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openTapeToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.openTapeToolStripMenuItem.Text = "&Open tape...";
            // 
            // saveTapeToolStripMenuItem
            // 
            this.saveTapeToolStripMenuItem.Name = "saveTapeToolStripMenuItem";
            this.saveTapeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveTapeToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.saveTapeToolStripMenuItem.Text = "&Save tape";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(178, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutAddingMachineToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutAddingMachineToolStripMenuItem
            // 
            this.aboutAddingMachineToolStripMenuItem.Name = "aboutAddingMachineToolStripMenuItem";
            this.aboutAddingMachineToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.aboutAddingMachineToolStripMenuItem.Text = "&About Adding Machine...";
            // 
            // NumericDisplay
            // 
            this.NumericDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NumericDisplay.BackColor = System.Drawing.Color.Black;
            this.NumericDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NumericDisplay.Controls.Add(this.pictureBox1);
            this.NumericDisplay.Location = new System.Drawing.Point(4, 223);
            this.NumericDisplay.Name = "NumericDisplay";
            this.NumericDisplay.Size = new System.Drawing.Size(260, 40);
            this.NumericDisplay.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AddingMachine.Properties.Resources.SevenSeg;
            this.pictureBox1.Location = new System.Drawing.Point(1, 3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(608, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // DecimalOptionsPanel
            // 
            this.DecimalOptionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DecimalOptionsPanel.Controls.Add(this.DecimalOptionF);
            this.DecimalOptionsPanel.Controls.Add(this.DecimalOption0);
            this.DecimalOptionsPanel.Controls.Add(this.DecimalOption2);
            this.DecimalOptionsPanel.Controls.Add(this.DecimalOption4);
            this.DecimalOptionsPanel.Controls.Add(this.DecimalOption6);
            this.DecimalOptionsPanel.Location = new System.Drawing.Point(4, 269);
            this.DecimalOptionsPanel.Name = "DecimalOptionsPanel";
            this.DecimalOptionsPanel.Size = new System.Drawing.Size(260, 29);
            this.DecimalOptionsPanel.TabIndex = 3;
            // 
            // DecimalOptionF
            // 
            this.DecimalOptionF.Appearance = System.Windows.Forms.Appearance.Button;
            this.DecimalOptionF.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.DecimalOptionF.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DecimalOptionF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DecimalOptionF.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DecimalOptionF.Location = new System.Drawing.Point(95, 0);
            this.DecimalOptionF.Name = "DecimalOptionF";
            this.DecimalOptionF.Size = new System.Drawing.Size(18, 23);
            this.DecimalOptionF.TabIndex = 4;
            this.DecimalOptionF.Text = "F";
            this.DecimalOptionF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DecimalOptionF.UseVisualStyleBackColor = true;
            // 
            // DecimalOption0
            // 
            this.DecimalOption0.Appearance = System.Windows.Forms.Appearance.Button;
            this.DecimalOption0.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.DecimalOption0.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DecimalOption0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DecimalOption0.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DecimalOption0.Location = new System.Drawing.Point(72, 0);
            this.DecimalOption0.Name = "DecimalOption0";
            this.DecimalOption0.Size = new System.Drawing.Size(18, 23);
            this.DecimalOption0.TabIndex = 3;
            this.DecimalOption0.Text = "0";
            this.DecimalOption0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DecimalOption0.UseVisualStyleBackColor = true;
            // 
            // DecimalOption2
            // 
            this.DecimalOption2.Appearance = System.Windows.Forms.Appearance.Button;
            this.DecimalOption2.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.DecimalOption2.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DecimalOption2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DecimalOption2.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DecimalOption2.Location = new System.Drawing.Point(49, 0);
            this.DecimalOption2.Name = "DecimalOption2";
            this.DecimalOption2.Size = new System.Drawing.Size(18, 23);
            this.DecimalOption2.TabIndex = 2;
            this.DecimalOption2.Text = "2";
            this.DecimalOption2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DecimalOption2.UseVisualStyleBackColor = true;
            // 
            // DecimalOption4
            // 
            this.DecimalOption4.Appearance = System.Windows.Forms.Appearance.Button;
            this.DecimalOption4.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.DecimalOption4.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DecimalOption4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DecimalOption4.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DecimalOption4.Location = new System.Drawing.Point(26, 0);
            this.DecimalOption4.Name = "DecimalOption4";
            this.DecimalOption4.Size = new System.Drawing.Size(18, 23);
            this.DecimalOption4.TabIndex = 1;
            this.DecimalOption4.Text = "4";
            this.DecimalOption4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DecimalOption4.UseVisualStyleBackColor = true;
            // 
            // DecimalOption6
            // 
            this.DecimalOption6.Appearance = System.Windows.Forms.Appearance.Button;
            this.DecimalOption6.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.DecimalOption6.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DecimalOption6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DecimalOption6.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DecimalOption6.Location = new System.Drawing.Point(3, 0);
            this.DecimalOption6.Name = "DecimalOption6";
            this.DecimalOption6.Size = new System.Drawing.Size(18, 23);
            this.DecimalOption6.TabIndex = 0;
            this.DecimalOption6.Text = "6";
            this.DecimalOption6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DecimalOption6.UseVisualStyleBackColor = true;
            // 
            // KeyCCE
            // 
            this.KeyCCE.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.KeyCCE.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.KeyCCE.Location = new System.Drawing.Point(4, 304);
            this.KeyCCE.Name = "KeyCCE";
            this.KeyCCE.Size = new System.Drawing.Size(64, 40);
            this.KeyCCE.TabIndex = 4;
            this.KeyCCE.TabStop = false;
            this.KeyCCE.Text = "CE/C";
            this.KeyCCE.UseVisualStyleBackColor = true;
            // 
            // KeyDivide
            // 
            this.KeyDivide.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.KeyDivide.Location = new System.Drawing.Point(69, 304);
            this.KeyDivide.Name = "KeyDivide";
            this.KeyDivide.Size = new System.Drawing.Size(64, 40);
            this.KeyDivide.TabIndex = 5;
            this.KeyDivide.TabStop = false;
            this.KeyDivide.Text = "∕";
            this.KeyDivide.UseVisualStyleBackColor = true;
            // 
            // KeyMultiply
            // 
            this.KeyMultiply.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.KeyMultiply.Location = new System.Drawing.Point(134, 304);
            this.KeyMultiply.Name = "KeyMultiply";
            this.KeyMultiply.Size = new System.Drawing.Size(64, 40);
            this.KeyMultiply.TabIndex = 6;
            this.KeyMultiply.TabStop = false;
            this.KeyMultiply.Text = "✕";
            this.KeyMultiply.UseVisualStyleBackColor = true;
            // 
            // KeyMinus
            // 
            this.KeyMinus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.KeyMinus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.KeyMinus.Location = new System.Drawing.Point(199, 304);
            this.KeyMinus.Name = "KeyMinus";
            this.KeyMinus.Size = new System.Drawing.Size(64, 40);
            this.KeyMinus.TabIndex = 7;
            this.KeyMinus.TabStop = false;
            this.KeyMinus.Text = "−";
            this.KeyMinus.UseVisualStyleBackColor = true;
            // 
            // KeyPlusEquals
            // 
            this.KeyPlusEquals.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.KeyPlusEquals.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.KeyPlusEquals.Location = new System.Drawing.Point(199, 346);
            this.KeyPlusEquals.Name = "KeyPlusEquals";
            this.KeyPlusEquals.Size = new System.Drawing.Size(64, 82);
            this.KeyPlusEquals.TabIndex = 11;
            this.KeyPlusEquals.TabStop = false;
            this.KeyPlusEquals.Text = "+\r\n=";
            this.KeyPlusEquals.UseVisualStyleBackColor = true;
            // 
            // Key9
            // 
            this.Key9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Key9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Key9.Location = new System.Drawing.Point(134, 346);
            this.Key9.Name = "Key9";
            this.Key9.Size = new System.Drawing.Size(64, 40);
            this.Key9.TabIndex = 10;
            this.Key9.TabStop = false;
            this.Key9.Text = "9";
            this.Key9.UseVisualStyleBackColor = true;
            // 
            // Key8
            // 
            this.Key8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Key8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Key8.Location = new System.Drawing.Point(69, 346);
            this.Key8.Name = "Key8";
            this.Key8.Size = new System.Drawing.Size(64, 40);
            this.Key8.TabIndex = 9;
            this.Key8.TabStop = false;
            this.Key8.Text = "8";
            this.Key8.UseVisualStyleBackColor = true;
            // 
            // Key7
            // 
            this.Key7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Key7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Key7.Location = new System.Drawing.Point(4, 346);
            this.Key7.Name = "Key7";
            this.Key7.Size = new System.Drawing.Size(64, 40);
            this.Key7.TabIndex = 8;
            this.Key7.TabStop = false;
            this.Key7.Text = "7";
            this.Key7.UseVisualStyleBackColor = true;
            // 
            // Key6
            // 
            this.Key6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Key6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Key6.Location = new System.Drawing.Point(134, 388);
            this.Key6.Name = "Key6";
            this.Key6.Size = new System.Drawing.Size(64, 40);
            this.Key6.TabIndex = 14;
            this.Key6.TabStop = false;
            this.Key6.Text = "6";
            this.Key6.UseVisualStyleBackColor = true;
            // 
            // Key5
            // 
            this.Key5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Key5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Key5.Location = new System.Drawing.Point(69, 388);
            this.Key5.Name = "Key5";
            this.Key5.Size = new System.Drawing.Size(64, 40);
            this.Key5.TabIndex = 13;
            this.Key5.TabStop = false;
            this.Key5.Text = "5";
            this.Key5.UseVisualStyleBackColor = true;
            // 
            // Key4
            // 
            this.Key4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Key4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Key4.Location = new System.Drawing.Point(4, 388);
            this.Key4.Name = "Key4";
            this.Key4.Size = new System.Drawing.Size(64, 40);
            this.Key4.TabIndex = 12;
            this.Key4.TabStop = false;
            this.Key4.Text = "4";
            this.Key4.UseVisualStyleBackColor = true;
            // 
            // Key3
            // 
            this.Key3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Key3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Key3.Location = new System.Drawing.Point(134, 430);
            this.Key3.Name = "Key3";
            this.Key3.Size = new System.Drawing.Size(64, 40);
            this.Key3.TabIndex = 17;
            this.Key3.TabStop = false;
            this.Key3.Text = "3";
            this.Key3.UseVisualStyleBackColor = true;
            // 
            // Key2
            // 
            this.Key2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Key2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Key2.Location = new System.Drawing.Point(69, 430);
            this.Key2.Name = "Key2";
            this.Key2.Size = new System.Drawing.Size(64, 40);
            this.Key2.TabIndex = 16;
            this.Key2.TabStop = false;
            this.Key2.Text = "2";
            this.Key2.UseVisualStyleBackColor = true;
            // 
            // Key1
            // 
            this.Key1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Key1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Key1.Location = new System.Drawing.Point(4, 430);
            this.Key1.Name = "Key1";
            this.Key1.Size = new System.Drawing.Size(64, 40);
            this.Key1.TabIndex = 15;
            this.Key1.TabStop = false;
            this.Key1.Text = "1";
            this.Key1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(199, 430);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 82);
            this.button1.TabIndex = 18;
            this.button1.TabStop = false;
            this.button1.Text = "ST\r\nGT";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // KeyDecimal
            // 
            this.KeyDecimal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.KeyDecimal.Location = new System.Drawing.Point(134, 472);
            this.KeyDecimal.Name = "KeyDecimal";
            this.KeyDecimal.Size = new System.Drawing.Size(64, 40);
            this.KeyDecimal.TabIndex = 20;
            this.KeyDecimal.TabStop = false;
            this.KeyDecimal.Text = "·";
            this.KeyDecimal.UseVisualStyleBackColor = true;
            // 
            // Key0
            // 
            this.Key0.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Key0.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Key0.Location = new System.Drawing.Point(4, 472);
            this.Key0.Name = "Key0";
            this.Key0.Size = new System.Drawing.Size(129, 40);
            this.Key0.TabIndex = 19;
            this.Key0.TabStop = false;
            this.Key0.Text = "0";
            this.Key0.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 520);
            this.Controls.Add(this.KeyDecimal);
            this.Controls.Add(this.Key0);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Key3);
            this.Controls.Add(this.Key2);
            this.Controls.Add(this.Key1);
            this.Controls.Add(this.Key6);
            this.Controls.Add(this.Key5);
            this.Controls.Add(this.Key4);
            this.Controls.Add(this.KeyPlusEquals);
            this.Controls.Add(this.Key9);
            this.Controls.Add(this.Key8);
            this.Controls.Add(this.Key7);
            this.Controls.Add(this.KeyMinus);
            this.Controls.Add(this.KeyMultiply);
            this.Controls.Add(this.KeyDivide);
            this.Controls.Add(this.KeyCCE);
            this.Controls.Add(this.DecimalOptionsPanel);
            this.Controls.Add(this.NumericDisplay);
            this.Controls.Add(this.TapeDisplay);
            this.Controls.Add(this.MainMenuStrip);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(286, 900);
            this.MinimumSize = new System.Drawing.Size(286, 400);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Adding Machine";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.NumericDisplay.ResumeLayout(false);
            this.NumericDisplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.DecimalOptionsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox TapeDisplay;
        private MenuStrip MainMenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Panel NumericDisplay;
        private Panel DecimalOptionsPanel;
        private RadioButton DecimalOptionF;
        private RadioButton DecimalOption0;
        private RadioButton DecimalOption2;
        private RadioButton DecimalOption4;
        private RadioButton DecimalOption6;
        private Button KeyCCE;
        private Button KeyDivide;
        private Button KeyMultiply;
        private Button KeyMinus;
        private Button KeyPlusEquals;
        private Button Key9;
        private Button Key8;
        private Button Key7;
        private Button Key6;
        private Button Key5;
        private Button Key4;
        private Button Key3;
        private Button Key2;
        private Button Key1;
        private Button button1;
        private Button KeyDecimal;
        private Button Key0;
        private ToolStripMenuItem newTapeToolStripMenuItem;
        private ToolStripMenuItem openTapeToolStripMenuItem;
        private ToolStripMenuItem saveTapeToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutAddingMachineToolStripMenuItem;
        private PictureBox pictureBox1;
    }
}