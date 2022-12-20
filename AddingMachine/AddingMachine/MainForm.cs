using AddingMachine.Core;
using AddingMachine.Properties;

namespace AddingMachine
{
    public partial class MainForm : Form
    {
        private const int MaxDigits = 12;
        private const int MaxTapeTextControls = 27;

        private bool TestMode = false;
        private bool Loading = false;
        private ImageList DigitImages = new();
        private int NumberOfVisibleTapeTextLines;
        private readonly List<Label> TapeText = new();
        private readonly List<PictureBox> DigitBoxes = new();
        private readonly List<TapeEntry> TapeEntries = new();
        private readonly Accumulator Accumulator = new(MaxDigits, DecimalOptions.Float);

        #region constructor and initialization

        public MainForm()
        {
            InitializeComponent();
            ProcessCommandLineArguments();

            KeyDecimal.Text = Accumulator.DecimalChar.ToString();

            SetDigitImageSource();
            PopulateTapeTextControls();
            PopulateNumericDisplayControls();
            SetDecimalOption();
            InitializeTapeEntries();
        }

        private void ProcessCommandLineArguments()
        {
            var args = Environment.GetCommandLineArgs();
            if (args != null)
            {
                foreach (var arg in args)
                {
                    switch(arg.ToLower())
                    {
                        case "/t":
                            TestMode = true;
                            break;
                    }
                }
            }
        }

        private void SetDigitImageSource()
        {
            if (DigitBox0.Size.Width >= 38)
                DigitImages = DigitImages38;
            else
                DigitImages = DigitImages19;
        }

        private void PopulateTapeTextControls()
        {
            TapeText0.Width = TapeContainer.ClientSize.Width - TapeScrollBar.Size.Width;
            TapeText0.Tag = -1;

            TapeText.Add(TapeText0);
            for (int i = 1; i < MaxTapeTextControls; ++i)
            {
                var label = new Label
                {
                    Name = "TapeText" + i,
                    Anchor = TapeText0.Anchor,
                    AutoSize = TapeText0.AutoSize,
                    BackColor = TapeText0.BackColor,
                    Font = TapeText0.Font,
                    Location = new Point(TapeText0.Location.X, TapeText0.Location.Y - TapeText0.Size.Height * i),
                    Size = TapeText0.Size,
                    Tag = -1,
                    TextAlign = TapeText0.TextAlign,
                    Visible = false,
                };

                label.DoubleClick += TapeText_DoubleClick;

                TapeContainer.Controls.Add(label);

                TapeText.Add(label);
            }
        }

        private void PopulateNumericDisplayControls()
        {
            DigitBox0.InitialImage = DigitImages.Images[(int)DI.DigitBlank];

            DigitBoxes.Add(DigitBox0);
            for (int i = 1; i < MaxDigits; ++i)
            {
                var digitBox = new PictureBox
                {
                    Name = "DigitBox" + i,
                    BackColor = DigitBox0.BackColor,
                    InitialImage = DigitBox0.InitialImage,
                    Location = new Point(DigitBox0.Location.X + DigitBox0.Size.Width * i, DigitBox0.Location.Y),
                    Size = DigitBox0.Size,
                    SizeMode = DigitBox0.SizeMode,
                    Visible = true
                };

                NumericDisplay.Controls.Add(digitBox);

                DigitBoxes.Add(digitBox);
            }
        }

        private void SetDecimalOption()
        {
            var option = (DecimalOptions)Settings.Default.DecimalOption;
            switch (option)
            {
                case DecimalOptions.Float:
                    DecimalOptionF.Checked = true;
                    break;

                case DecimalOptions.Zero:
                    DecimalOption0.Checked = true;
                    break;

                case DecimalOptions.Two:
                    DecimalOption2.Checked = true;
                    break;

                case DecimalOptions.Four:
                    DecimalOption4.Checked = true;
                    break;

                case DecimalOptions.Six:
                    DecimalOption6.Checked = true;
                    break;

                default:
                    DecimalOptionF.Checked = true;
                    break;
            }
        }

        private void InitializeTapeEntries()
        {
            TapeEntries.Clear();
            TapeEntries.Add(new());
            UpdateTapeControls(true);
        }

        #endregion

        #region form events

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Settings.Default.FormLeft == -1 && Settings.Default.FormTop == -1)
            {
                var screen = Screen.PrimaryScreen;
                Location = new Point((screen.WorkingArea.Width - Size.Width) / 2, (screen.WorkingArea.Height - Size.Height) / 2);
            }
            else
            {
                Size = new Size(Size.Width, Settings.Default.FormHeight);
                Location = new Point(Settings.Default.FormLeft, Settings.Default.FormTop);
            }

            Accumulator.DisplayChanged += Accumulator_DisplayChanged;
            Accumulator.NewTapeEntryPublished += Accumulator_NewTapeEntryPublished;
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            Settings.Default.FormLeft = Location.X;
            Settings.Default.FormTop = Location.Y;
            Settings.Default.FormHeight = Size.Height;
            Settings.Default.Save();
        }

        private void MainForm_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            SetDigitImageSource();
            RecalculateNumberOfVisibleTapeTextLines();
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            var eventArgs = new EventArgs();

            switch (e.KeyChar)
            {
                case '0':
                    Key0_Click(sender, eventArgs);
                    Key0.Focus();
                    break;

                case '1':
                    Key1_Click(sender, eventArgs);
                    Key1.Focus();
                    break;

                case '2':
                    Key2_Click(sender, eventArgs);
                    Key2.Focus();
                    break;

                case '3':
                    Key3_Click(sender, eventArgs);
                    Key3.Focus();
                    break;

                case '4':
                    Key4_Click(sender, eventArgs);
                    Key4.Focus();
                    break;

                case '5':
                    Key5_Click(sender, eventArgs);
                    Key5.Focus();
                    break;

                case '6':
                    Key6_Click(sender, eventArgs);
                    Key6.Focus();
                    break;

                case '7':
                    Key7_Click(sender, eventArgs);
                    Key7.Focus();
                    break;

                case '8':
                    Key8_Click(sender, eventArgs);
                    Key8.Focus();
                    break;

                case '9':
                    Key9_Click(sender, eventArgs);
                    Key9.Focus();
                    break;

                case '.':
                    if (e.KeyChar == Accumulator.DecimalChar)
                    {
                        KeyDecimal_Click(sender, eventArgs);
                        KeyDecimal.Focus();
                    }
                    break;

                case ',':
                    if (e.KeyChar == Accumulator.DecimalChar)
                    {
                        KeyDecimal_Click(sender, eventArgs);
                        KeyDecimal.Focus();
                    }
                    break;

                case '*':
                    KeyMultiply_Click(sender, eventArgs);
                    KeyMultiply.Focus();
                    break;

                case '/':
                    KeyDivide_Click(sender, eventArgs);
                    KeyDivide.Focus();
                    break;

                case '-':
                    KeyMinus_Click(sender, eventArgs);
                    KeyMinus.Focus();
                    break;

                case '+':
                    KeyPlusEquals_Click(sender, eventArgs);
                    KeyPlusEquals.Focus();
                    break;
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
            {
                KeyCCE_Click(sender, new EventArgs());
                KeyCCE.Focus();
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                KeySTGT_Click(sender, new EventArgs());
                KeySTGT.Focus();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Accumulator.DisplayChanged -= Accumulator_DisplayChanged;
            Accumulator.NewTapeEntryPublished -= Accumulator_NewTapeEntryPublished;
        }

        #endregion

        #region key button events

        private void Key0_Click(object sender, EventArgs e)
        {
            if (TestMode)
                SetNumericDisplay("000000000000");
            else
                Accumulator.AddKey('0');
            StartKeyTimer();
        }

        private void Key1_Click(object sender, EventArgs e)
        {
            if (TestMode)
                SetNumericDisplay("111111111111");
            else
                Accumulator.AddKey('1');
            StartKeyTimer();
        }

        private void Key2_Click(object sender, EventArgs e)
        {
            if (TestMode)
                SetNumericDisplay("222222222222");
            else
                Accumulator.AddKey('2');
            StartKeyTimer();
        }

        private void Key3_Click(object sender, EventArgs e)
        {
            if (TestMode)
                SetNumericDisplay("333333333333");
            else
                Accumulator.AddKey('3');
            StartKeyTimer();
        }

        private void Key4_Click(object sender, EventArgs e)
        {
            if (TestMode)
                SetNumericDisplay("444444444444");
            else
                Accumulator.AddKey('4');
            StartKeyTimer();
        }

        private void Key5_Click(object sender, EventArgs e)
        {
            if (TestMode)
                SetNumericDisplay("555555555555");
            else
                Accumulator.AddKey('5');
            StartKeyTimer();
        }

        private void Key6_Click(object sender, EventArgs e)
        {
            if (TestMode)
                SetNumericDisplay("666666666666");
            else
                Accumulator.AddKey('6');
            StartKeyTimer();
        }

        private void Key7_Click(object sender, EventArgs e)
        {
            if (TestMode)
                SetNumericDisplay("777777777777");
            else
                Accumulator.AddKey('7');
            StartKeyTimer();
        }

        private void Key8_Click(object sender, EventArgs e)
        {
            if (TestMode)
                SetNumericDisplay("888888888888");
            else
                Accumulator.AddKey('8');
            StartKeyTimer();
        }

        private void Key9_Click(object sender, EventArgs e)
        {
            if (TestMode)
                SetNumericDisplay("999999999999");
            else
                Accumulator.AddKey('9');
            StartKeyTimer();
        }

        private void KeyDecimal_Click(object sender, EventArgs e)
        {
            if (TestMode)
                SetNumericDisplay("0.0000");
            else
                Accumulator.AddKey('.');
            StartKeyTimer();
        }

        private void KeyCCE_Click(object sender, EventArgs e)
        {
            if (TestMode)
                SetNumericDisplay("0.");
            else
                Accumulator.AddKey('C');
            StartKeyTimer();
        }

        private void KeyMultiply_Click(object sender, EventArgs e)
        {
            if (TestMode)
                SetNumericDisplay(Accumulator.ErrorDisplay);
            else
                Accumulator.AddKey('*');
            StartKeyTimer();
        }

        private void KeyDivide_Click(object sender, EventArgs e)
        {
            if (TestMode)
                SetNumericDisplay("8,8,8,8,8,8,8,8,8,8,8,8,");
            else
                Accumulator.AddKey('/');
            StartKeyTimer();
        }

        private void KeyMinus_Click(object sender, EventArgs e)
        {
            if (TestMode)
                SetNumericDisplay("-1-1-1-1-1-1");
            else
                Accumulator.AddKey('-');
            StartKeyTimer();
        }

        private void KeyPlusEquals_Click(object sender, EventArgs e)
        {
            if (TestMode)
                SetNumericDisplay("-23,456,789.0123");
            else
                Accumulator.AddKey('+');
            StartKeyTimer();
        }

        private void KeySTGT_Click(object sender, EventArgs e)
        {
            if (TestMode)
                SetNumericDisplay("9876543210.12");
            else
                Accumulator.AddKey('T');
            StartKeyTimer();
        }

        #endregion

        #region decimal option events

        private void DecimalOptionF_Click(object sender, EventArgs e)
        {
            Accumulator.DecimalOption = DecimalOptions.Float;
            SaveDecimalOption();
        }

        private void DecimalOption0_Click(object sender, EventArgs e)
        {
            Accumulator.DecimalOption = DecimalOptions.Zero;
            SaveDecimalOption();
        }

        private void DecimalOption2_Click(object sender, EventArgs e)
        {
            Accumulator.DecimalOption = DecimalOptions.Two;
            SaveDecimalOption();
        }

        private void DecimalOption4_Click(object sender, EventArgs e)
        {
            Accumulator.DecimalOption = DecimalOptions.Four;
            SaveDecimalOption();
        }

        private void DecimalOption6_Click(object sender, EventArgs e)
        {
            Accumulator.DecimalOption = DecimalOptions.Six;
            SaveDecimalOption();
        }

        private void SaveDecimalOption()
        {
            Settings.Default.DecimalOption = (int)Accumulator.DecimalOption;
            Settings.Default.Save();
        }

        #endregion

        #region menu events

        private void NewTapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: ask to save tape
            InitializeTapeEntries();
        }

        private void OpenTapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: open and read in saved tape
        }

        private void SaveTapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: write out tape to file
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: copy current value from accumulator to clipboard
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: assign value to accumulator from text in clipboard
        }

        private void AboutAddingMachineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: open an about form
        }

        #endregion

        #region display events

        private void Accumulator_DisplayChanged(object? sender, DisplayChangedEventArgs e)
        {
            SetNumericDisplay(e.Display);
        }

        private void SetNumericDisplay(string value)
        {
            // clear the display
            for (var i = 0; i < MaxDigits; ++i)
            {
                DigitBoxes[i].Image = DigitImages.Images[(int)DI.DigitBlank];
            }

            if (value.Trim() == "E")
            {
                DigitBoxes[MaxDigits - 1].Image = DigitImages.Images[(int)DI.DigitE];
                return;
            }

            // find number of digits to display
            var numberToDisplay = 0;
            for (var i = 0; i < value.Length; ++i)
            {
                if (value[i] >= '0' && value[i] <= '9' || value[i] == '-' || value[i] == 'E')
                    numberToDisplay++;
            }

            // set the images in the display
            var p = Math.Max(0, MaxDigits - numberToDisplay);
            for (var i = 0; i < value.Length; ++i)
            {
                if (p > MaxDigits - 1)
                    continue;

                if (value[i] == '.' || value[i] == ',')
                    continue;

                else if (value[i] == '-')
                {
                    DigitBoxes[p].Image = DigitImages.Images[(int)DI.DigitMinus];
                    p++;
                }

                else if (value[i] == 'E')
                {
                    DigitBoxes[p].Image = DigitImages.Images[(int)DI.DigitE];
                    p++;
                }

                else if (value[i] >= '0' && value[i] <= '9')
                {
                    // assumes index for "0" is 0, 1 is for "1", etc.
                    // also assumes digit with decimal starts at index 10 and digit with comma starts at index 20
                    var index = (int)value[i] - 48;
                    if (i < value.Length - 1)
                    {
                        if (value[i + 1] == '.')
                            index += 10;
                        else if (value[i + 1] == ',')
                            index += 20;
                    }

                    DigitBoxes[p].Image = DigitImages.Images[index];
                    p++;
                }
            }
        }

        #endregion

        #region tape events

        private void TapeText_DoubleClick(object? sender, EventArgs e)
        {
            var entryIndex = (int?)(sender as Label)?.Tag;
            if (entryIndex.HasValue && entryIndex.Value >= 0 && entryIndex.Value < TapeEntries.Count)
            {
                Accumulator.Value = TapeEntries[entryIndex.Value].Value;
            }
        }

        private void TapeScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            if (!Loading)
            {
                UpdateTapeControls();
            }
        }

        private void TapeScrollBar_SizeChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                RecalculateNumberOfVisibleTapeTextLines();
                UpdateTapeControls();
            }
        }

        private void Accumulator_NewTapeEntryPublished(object? sender, NewTapeEntryPublishedEventArgs e)
        {
            TapeEntries.Add(e.NewTapeEntry);
            UpdateTapeControls(true);
        }

        private void UpdateTapeControls(bool forceScrollToBottom = false)
        {
            Loading = true;
            UpdateTapeScrollBarRange();
            if (forceScrollToBottom)
            {
                TapeScrollBar.Value = TapeScrollBar.Maximum;
            }
            Loading = false;

            // to fill in the tape text, we start with the lowest tape text, counting up,
            // and the highest tape value, counting down
            
            var textIndex = 0;
            var entryIndex = Math.Max(0, Math.Min(TapeEntries.Count, TapeScrollBar.Value + NumberOfVisibleTapeTextLines)) - 1;

            // visible tape text
            while (textIndex < TapeText.Count)
            {
                if (entryIndex < 0 || entryIndex >= TapeEntries.Count)
                    break;
                
                var operation = TapeEntries[entryIndex].Operation;
                if (operation == "*")
                    operation = KeyMultiply.Text;
                else if (operation == "/")
                    operation = KeyDivide.Text;

                TapeText[textIndex].Tag = entryIndex;
                TapeText[textIndex].Text = $"{TapeEntries[entryIndex].Display}  {operation,-2}    ";
                TapeText[textIndex].Visible = true;

                if (TapeEntries[entryIndex].Value < 0 || TapeEntries[entryIndex].Operation.Contains('-'))
                    TapeText[textIndex].ForeColor = Color.DarkRed;
                else
                    TapeText[textIndex].ForeColor = SystemColors.ControlText;

                textIndex++;
                entryIndex--;
            }

            // hidden tape text
            while (textIndex < TapeText.Count)
            {
                TapeText[textIndex].Tag = -1;
                TapeText[textIndex].Visible = false;
                textIndex++;
            }
        }

        private void UpdateTapeScrollBarRange()
        {
            TapeScrollBar.Minimum = 0;
            TapeScrollBar.Maximum = Math.Max(NumberOfVisibleTapeTextLines, TapeEntries.Count);

            TapeScrollBar.LargeChange = NumberOfVisibleTapeTextLines + 1;
        }

        private void RecalculateNumberOfVisibleTapeTextLines()
        {
            NumberOfVisibleTapeTextLines = (int)Math.Floor((double)TapeContainer.ClientSize.Height / TapeText0.Height);
        }

        #endregion

        #region timer events

        private void KeyFocusTimer_Tick(object sender, EventArgs e)
        {
            KeyFocusTimer.Stop();
            KeyFocusTimer.Enabled = false;
            NumericDisplay.Focus();
        }

        private void StartKeyTimer()
        {
            KeyFocusTimer.Enabled = true;
            KeyFocusTimer.Start();
        }

        #endregion
    }
}