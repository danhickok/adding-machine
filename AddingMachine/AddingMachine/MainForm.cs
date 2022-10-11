namespace AddingMachine
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // for mockup/testing only
            DigitBox0.Image = DigitImages.Images["Digit8c"];
            DigitBox1.Image = DigitImages.Images["Digit8c"];
            DigitBox2.Image = DigitImages.Images["Digit8c"];
            DigitBox3.Image = DigitImages.Images["Digit8c"];
            DigitBox4.Image = DigitImages.Images["Digit8c"];
            DigitBox5.Image = DigitImages.Images["Digit8c"];
            DigitBox6.Image = DigitImages.Images["Digit8c"];
            DigitBox7.Image = DigitImages.Images["Digit8c"];
            DigitBox8.Image = DigitImages.Images["Digit8c"];
            DigitBox9.Image = DigitImages.Images["Digit8c"];
            DigitBox10.Image = DigitImages.Images["Digit8c"];
            DigitBox11.Image = DigitImages.Images["Digit8c"];
            DigitBox12.Image = DigitImages.Images["Digit8c"];
        }
    }
}