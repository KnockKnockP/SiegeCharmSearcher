namespace SiegeCharmSearcher.Shared {
    public struct Vector2Int(int x, int y) {
        public int x = x, y = y;

        public void Normalize(Vector2Int relativeTo) {
            x /= relativeTo.x;
            y /= relativeTo.y;
        }

        public static bool operator ==(Vector2Int v1, Vector2Int v2) => ((v1.x == v2.x) && (v1.y == v2.y));

        public static bool operator !=(Vector2Int v1, Vector2Int v2) => ((v1.x != v2.x) || (v1.y != v2.y));

        public override readonly string ToString() {
            return $"({x}, {y})";
        }
    }
}