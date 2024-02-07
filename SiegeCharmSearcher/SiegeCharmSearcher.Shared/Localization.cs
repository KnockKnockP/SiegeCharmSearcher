using System.Globalization;

namespace SiegeCharmSearcher.Shared {
    internal static class Localization {
        private static Strings? strings = null;
        internal static Strings Strings {
            get {
                if (strings == null) {
                    if (CultureInfo.CurrentUICulture == CultureInfo.GetCultureInfo("ko-KR")) {
                        strings = new KoreanStrings();
                    } else {
                        strings = new USEnglishStrings();
                    }
                }

                return strings;
            }
        }
    }
}