namespace SiegeCharmSearcher.Shared {
    public static class FileManager {
        public static readonly string SettingsFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SiegeCharmSearcher", "settings.json");

        public static void SaveAsJson(string json, string path) {
            EnsurePath(path);
            File.WriteAllText(path, json);
        }

        public static string ReadJson(string path) {
            EnsurePath(path);
            using StreamReader streamReader = new(path);
            return streamReader.ReadToEnd();
        }

        public static void EnsurePath(string path) {
            DirectoryInfo? parent = Directory.GetParent(path) ?? throw new FileEnsureFailedException(path);
            Directory.CreateDirectory(parent.FullName);

            if (!File.Exists(path)) {
                File.Create(path).Close();
            }
        }
    }
}