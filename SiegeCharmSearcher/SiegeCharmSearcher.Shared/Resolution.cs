namespace SiegeCharmSearcher.Shared {
    public sealed class Resolution(Vector2Int size, AspectRatio aspectRatio) {
        public Vector2Int Size { get; set; } = size;
        public AspectRatio AspectRatio { get; set; } = aspectRatio;
    }
}