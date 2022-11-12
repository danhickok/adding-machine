using System;

namespace AddingMachine
{
    public partial class MainForm : Form
    {
        public const int MaxDigits = 12;

        private const int MaxTapeTextControls = 27;
        private readonly List<Label> TapeText = new();
        private readonly List<PictureBox> DigitBoxes = new();

        private bool Loading = false;

        public MainForm()
        {
            InitializeComponent();
            PopulateTapeTextControls();
            PopulateNumericDisplayControls();
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
            DigitBoxes.Add(DigitBox0);
            for (int i = 1; i < MaxDigits; ++i)
            {
                var digitBox = new PictureBox
                {
                    Name = "DigitBox" + i,
                    BackColor = DigitBox0.BackColor,
                    InitialImage = DigitBox0.InitialImage,
                    Location = new Point(DigitBox0.Location.X + 19 * i, DigitBox0.Location.Y),
                    Size = DigitBox0.Size,
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
            SetNumericDisplay("111111111111");
        }

        private void Key1_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("1.1.1.1.1.1.1.1.1.1.1.1.");
        }

        private void Key2_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("1,1,1,1,1,1,1,1,1,1,1,1,");
        }

        private void Key3_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("E");
        }

        private void Key4_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("222222222222");
        }

        private void Key5_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("2.2.2.2.2.2.2.2.2.2.2.2.");
        }

        private void Key6_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("2,2,2,2,2,2,2,2,2,2,2,2,");
        }

        private void Key7_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("333333333333");
        }

        private void Key8_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("3.3.3.3.3.3.3.3.3.3.3.3.");
        }

        private void Key9_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("3,3,3,3,3,3,3,3,3,3,3,3,");
        }

        private void KeyDecimal_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("0.0000");
        }

        private void KeyCCE_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("0.");
        }

        private void KeyMultiply_Click(object sender, EventArgs e)
        {

        }

        private void KeyDivide_Click(object sender, EventArgs e)
        {

        }

        private void KeyMinus_Click(object sender, EventArgs e)
        {

        }

        private void KeyPlusEquals_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("-23,456,789.0123");
        }

        private void KeySTGT_Click(object sender, EventArgs e)
        {
            // for testing
            SetNumericDisplay("8,8,8,8,8,8,8,8,8,8,8,8,8,");
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            var eventArgs = new EventArgs();

            switch (e.KeyChar)
            {
                case '0':
                    Key0_Click(sender, eventArgs);
                    break;

                case '1':
                    Key1_Click(sender, eventArgs);
                    break;

                case '2':
                    Key2_Click(sender, eventArgs);
                    break;

                case '3':
                    Key3_Click(sender, eventArgs);
                    break;

                case '4':
                    Key4_Click(sender, eventArgs);
                    break;

                case '5':
                    Key5_Click(sender, eventArgs);
                    break;

                case '6':
                    Key6_Click(sender, eventArgs);
                    break;

                case '7':
                    Key7_Click(sender, eventArgs);
                    break;

                case '8':
                    Key8_Click(sender, eventArgs);
                    break;

                case '9':
                    Key9_Click(sender, eventArgs);
                    break;

                case '*':
                    KeyMultiply_Click(sender, eventArgs);
                    break;

                case '/':
                    KeyDivide_Click(sender, eventArgs);
                    break;

                case '-':
                    KeyMinus_Click(sender, eventArgs);
                    break;

                case '+':
                    KeySTGT_Click(sender, eventArgs);
                    break;

            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
            {
                KeyCCE_Click(sender, new EventArgs());
            }
            else if(e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                e.Handled = true;
                KeySTGT_Click(sender, new EventArgs());
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
    }
}