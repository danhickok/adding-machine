using System.Reflection;

namespace AddingMachine
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            VersionLabel.Text = $"Version {version?.Major}.{version?.Minor} (build {version?.Build})";
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
