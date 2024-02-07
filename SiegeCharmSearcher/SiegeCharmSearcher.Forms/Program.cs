namespace SiegeCharmSearcher.Forms {
    internal static class Program {
        [STAThread]
        internal static void Main() {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}