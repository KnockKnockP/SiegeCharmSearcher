namespace SiegeCharmSearcher.Shared {
    internal static class FileManager {
        public static void SaveAsJson(string json, string path) {
            using StreamWriter streamWriter = new(EnsurePathAndOpen(path));
            streamWriter.Write(json);
        }

        public static string ReadJson(string path) {
            using StreamReader streamReader = new(EnsurePathAndOpen(path));
            return streamReader.ReadToEnd();
        }

        public static FileStream EnsurePathAndOpen(string path) {
            DirectoryInfo? parent = Directory.GetParent(path) ?? throw new FileEnsureFailedException(path);
            Directory.CreateDirectory(parent.FullName);

            if (!File.Exists(path)) {
                return File.Create(path);
            }

            return File.Open(path, FileMode.Open);
        }
    }
}