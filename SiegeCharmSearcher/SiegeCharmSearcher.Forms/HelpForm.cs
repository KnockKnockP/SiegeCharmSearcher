namespace SiegeCharmSearcher.Forms {
    public partial class HelpForm : Form {
        public HelpForm() {
            InitializeComponent();
        }

        private void OkButtonClick(object sender, EventArgs eventArgs) => Close();

        private void ExitButtonClick(object sender, EventArgs eventArgs) => Application.Exit();
    }
}