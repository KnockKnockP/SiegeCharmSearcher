namespace SiegeCharmSearcher.Shared {
    public struct Vector2(float x, float y) {
        public float x = x, y = y;

        public void Normalize(Vector2 relativeTo) {
            x /= relativeTo.x;
            y /= relativeTo.y;
        }

        public static bool operator ==(Vector2 v1, Vector2 v2) => ((v1.x == v2.x) && (v1.y == v2.y));

        public static bool operator !=(Vector2 v1, Vector2 v2) => ((v1.x != v2.x) || (v1.y != v2.y));

        public override string ToString() {
            return $"({x}, {y})";
        }
    }
}