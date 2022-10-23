namespace AddingMachine
{
    public partial class MainForm : Form
    {
        private const int MaxTapeTextControls = 27;
        private const int MaxDigits = 11;
        private readonly List<Label> TapeText = new();
        private readonly List<PictureBox> DigitBoxes = new();

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

        private Accumulator _accumulator;
        internal void SetAccumulator(Accumulator accumulator)
        {
            _accumulator = accumulator;
        }

        private AppConfig _appConfig;
        internal void SetAppConfig(AppConfig appConfig)
        {
            _appConfig = appConfig;
        }

        private NumericDisplayHandler _numericDisplayHandler;
        internal void SetNumericDisplayHandler(NumericDisplayHandler numericDisplayHandler)
        {
            _numericDisplayHandler = numericDisplayHandler;
        }

        private TapeHandler _tapeHandler;
        internal void SetTapeHandler(TapeHandler tapeHandler)
        {
            _tapeHandler = tapeHandler;
        }

    }
}