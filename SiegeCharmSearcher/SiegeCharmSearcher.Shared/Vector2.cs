namespace SiegeCharmSearcher.Shared {
    internal struct Vector2(float x, float y) {
        internal float x = x, y = y;

        internal void Normalize(Vector2 relativeTo) {
            x /= relativeTo.x;
            y /= relativeTo.y;
        }
    }
}