namespace SiegeCharmSearcher.Shared {
    public sealed class Charm {
        public string Name { get; set; } = string.Empty;
        public Vector2Int Position { get; set; }

        public Charm() {}

        public Charm(string name) => Name = name;

        public Charm(Vector2Int position) => Position = position;
    }
}