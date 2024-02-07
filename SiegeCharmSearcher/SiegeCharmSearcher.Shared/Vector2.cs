namespace SiegeCharmSearcher.Shared {
    public struct Vector2(float x, float y) {
        public float x = x, y = y;

        public void Normalize(Vector2 relativeTo) {
            x /= relativeTo.x;
            y /= relativeTo.y;
        }

        public override string ToString() {
            return $"({x}, {y})";
        }
    }
}