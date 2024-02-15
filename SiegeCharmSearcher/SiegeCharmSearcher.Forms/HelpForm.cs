namespace SiegeCharmSearcher.Forms {
    internal sealed partial class HelpForm : Form {
        internal HelpForm() => InitializeComponent();

        private void OkButtonClick(object sender, EventArgs eventArgs) => Close();

        private void ExitButtonClick(object sender, EventArgs eventArgs) => Application.Exit();
    }
}