//using System.Globalization;

namespace SiegeCharmSearcher.Forms {
    internal static class Program {
        [STAThread]
        internal static void Main() {
            //CultureInfo.CurrentUICulture = new CultureInfo("ko-KR");

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}