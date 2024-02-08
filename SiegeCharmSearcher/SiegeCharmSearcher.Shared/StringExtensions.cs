using System.Text;

namespace SiegeCharmSearcher.Shared {
    internal static class StringExtensions {
        internal static bool OnlyContains(this string s, char c) {
            foreach (char c1 in s) {
                if (c1 != c) {
                    return false;
                }
            }
            return true;
        }

        internal static string RemoveAllCharactersInString(this string s, string filter) {
            StringBuilder stringBuilder = new();
            foreach (char c in s) {
                if (!filter.Contains(c)) {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString();
        }
    }
}