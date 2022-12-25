using AddingMachine.Properties;

namespace AddingMachine
{
    public partial class OptionsDialog : Form
    {
        public OptionsDialog()
        {
            InitializeComponent();
        }

        private void OptionsDialog_Load(object sender, EventArgs e)
        {
            var numberOfLines = Settings.Default.TapeLinesToKeep;
            if (numberOfLines > 0)
            {
                TapeLinesKeepOption.Checked = true;
                TapeLinesKeepNumber.Value = numberOfLines;
                TapeLinesKeepNumber.Enabled = true;
            }
            else
            {
                TapeLinesNewOption.Checked = true;
                TapeLinesKeepNumber.Enabled = false;
            }
        }

        private void AppOptionsOKButton_Click(object sender, EventArgs e)
        {
            if (TapeLinesNewOption.Checked)
            {
                Settings.Default.TapeLinesToKeep = 0;
            }
            else
            {
                Settings.Default.TapeLinesToKeep = (int)TapeLinesKeepNumber.Value;
            }
            Settings.Default.Save();

            this.Close();
        }

        private void AppOptionsCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TapeLinesKeepOption_CheckedChanged(object sender, EventArgs e)
        {
            TapeLinesKeepNumber.Enabled = true;
        }

        private void TapeLinesNewOption_CheckedChanged(object sender, EventArgs e)
        {
            TapeLinesKeepNumber.Enabled = false;
        }
    }
}
