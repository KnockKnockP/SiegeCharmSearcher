namespace SiegeCharmSearcher.Shared {
    public static class SearchStrategies {
        private static bool ContainsIgnoreCase(this string s, char c) {
            return s.Contains(c, StringComparison.InvariantCultureIgnoreCase);
        }

        private static bool ContainsIgnoreCase(this string s, string s2) {
            return s.Contains(s2, StringComparison.InvariantCultureIgnoreCase);
        }

        public static string[] LiteralSearchIgnoreCase(string query, string[] searchFrom) {
            List<string> results = [];
            foreach (string s in searchFrom) {
                if (s.ContainsIgnoreCase(query)) {
                    results.Add(s);
                }
            }

            return [.. results];
        }

        public static string[] LiteralSearchIgnoreSpaceWithoutSpaces(string query, string[] searchFrom) {
            const string spaceFilter = " ";

            string noSpaceQuery = query.RemoveAllCharactersInString(spaceFilter);
            string[] noSpaceSearchFrom = new string[searchFrom.Length];
            for (int i = 0; i < searchFrom.Length; ++i) {
                noSpaceSearchFrom[i] = searchFrom[i].RemoveAllCharactersInString(spaceFilter);
            }
            

            List<string> results = [];
            for (int i = 0; i < noSpaceSearchFrom.Length; ++i) {
                if (noSpaceSearchFrom[i].ContainsIgnoreCase(noSpaceQuery)) {
                    results.Add(searchFrom[i]);
                }
            }

            return [.. results];
        }

        public static string[] IncludesOneOfTheKeywords(string query, string[] searchFrom) {
            List<string> keywords = [];
            foreach (string keyword in query.Split([' '])) {
                if (keyword != string.Empty) {
                    keywords.Add(keyword);
                }
            }

            List<string> results = [];
            foreach (string s in searchFrom) {
                foreach (string keyword in keywords) {
                    if (s.ContainsIgnoreCase(keyword)) {
                        results.Add(s);
                        break;
                    }
                }
            }

            return [.. results];
        }
    }
}