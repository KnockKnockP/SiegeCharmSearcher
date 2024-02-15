using Newtonsoft.Json;

namespace SiegeCharmSearcher.Shared {
    public sealed class Settings {
        public Resolution Resolution { get; set; } = new(new Vector2Int(1920, 1080), AspectRatio._169);
        public int Delay { get; set; } = 500;
        public bool HasSeenHelp { get; set; }

        public string SerializeAsJson() => JsonConvert.SerializeObject(this);

        public void LoadFromJson(string json) {
            Settings? settings = (JsonConvert.DeserializeObject<Settings>(json) ?? throw new BadSaveFileException());
            Resolution = settings.Resolution;
            Delay = settings.Delay;
            HasSeenHelp = settings.HasSeenHelp;
        }
    }
}