using System;
using System.Diagnostics;

namespace AddingMachine
{
    public partial class MainForm : Form
    {
        public const int MaxDigits = 12;

        private const int MaxTapeTextControls = 27;
        private readonly List<Label> TapeText = new();
        private readonly List<PictureBox> DigitBoxes = new();
        private ImageList? DigitImages;

        private bool Loading = false;

        public MainForm()
        {
            InitializeComponent();

            DetermineImageSource();
            PopulateTapeTextControls();
            PopulateNumericDisplayControls();
        }

        private void DetermineImageSource()
        {
            if (DigitBox0.Size.Width >= 38)
                DigitImages = DigitImages38;
            else
                DigitImages = DigitImages19;
        }

        private void PopulateTapeTextControls()
        {
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
                    Location = new Point(TapeText0.Location.X, TapeText0.Location.Y - 20 * i),
                    Size = TapeText0.Size,
                    TextAlign = TapeText0.TextAlign,
                    Visible = false,
                };

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

        private void MainForm_Load(object sender, EventArgs e)
        {
            //TODO: restore position, size, and screen
        }

        public void SetNumericDisplay(string value)
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

        private void Key0_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("000000000000");
            StartKeyTimer();
        }

        private void Key1_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("111111111111");
            StartKeyTimer();
        }

        private void Key2_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("222222222222");
            StartKeyTimer();
        }

        private void Key3_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("333333333333");
            StartKeyTimer();
        }

        private void Key4_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("444444444444");
            StartKeyTimer();
        }

        private void Key5_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("555555555555");
            StartKeyTimer();
        }

        private void Key6_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("666666666666");
            StartKeyTimer();
        }

        private void Key7_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("777777777777");
            StartKeyTimer();
        }

        private void Key8_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("888888888888");
            StartKeyTimer();
        }

        private void Key9_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("999999999999");
            StartKeyTimer();
        }

        private void KeyDecimal_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("0.0000");
            StartKeyTimer();
        }

        private void KeyCCE_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("0.");
            StartKeyTimer();
        }

        private void KeyMultiply_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("-E-");
            StartKeyTimer();
        }

        private void KeyDivide_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("8,8,8,8,8,8,8,8,8,8,8,8,");
            StartKeyTimer();
        }

        private void KeyMinus_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("-1-1-1-1-1-1");
            StartKeyTimer();
        }

        private void KeyPlusEquals_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("-23,456,789.0123");
            StartKeyTimer();
        }

        private void KeySTGT_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("9876543210.12");
            StartKeyTimer();
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
                    KeyDecimal_Click(sender, eventArgs);
                    KeyDecimal.Focus();
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
            else if(e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                KeySTGT_Click(sender, new EventArgs());
                KeySTGT.Focus();
            }
        }

        private void DecimalOptionF_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DecimalOption0_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DecimalOption2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DecimalOption4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DecimalOption6_CheckedChanged(object sender, EventArgs e)
        {

        }

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

        private void MainForm_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            DetermineImageSource();
        }
    }
}