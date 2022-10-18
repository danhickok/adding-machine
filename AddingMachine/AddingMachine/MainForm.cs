namespace AddingMachine
{
    public partial class MainForm : Form
    {
        private const int MaxTapeTextControls = 27;
        private readonly List<Label> TapeText = new();

        public MainForm()
        {
            InitializeComponent();
            PopulateTapeTextControls();
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
                    Font = TapeText0.Font,
                    Location = new System.Drawing.Point(TapeText0.Location.X, TapeText0.Location.Y - 20 * i),
                    Size = TapeText0.Size,
                    TextAlign = TapeText0.TextAlign,
                    Visible = true,
                };

                TapeContainer.Controls.Add(label);

                TapeText.Add(label);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}