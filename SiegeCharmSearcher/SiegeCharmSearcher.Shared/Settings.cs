using Newtonsoft.Json;

namespace SiegeCharmSearcher.Shared {
    public class Settings {
        public Resolution resolution = new(new Vector2Int(1920, 1080), 60, AspectRatio._169);
        public int delay = 500;

        public string SerializeAsJson() {
            return JsonConvert.SerializeObject(this);
        }

        public void LoadFromJson(string json) {
            Settings? settings = JsonConvert.DeserializeObject<Settings>(json) ?? throw new BadSaveFileException();
            resolution = settings.resolution;
            delay = settings.delay;
        }
    }
}