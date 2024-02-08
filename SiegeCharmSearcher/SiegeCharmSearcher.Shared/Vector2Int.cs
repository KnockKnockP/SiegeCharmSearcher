namespace SiegeCharmSearcher.Shared {
    public struct Vector2Int(int x, int y) {
        public int x = x, y = y;

        public void Normalize(Vector2Int relativeTo) {
            x /= relativeTo.x;
            y /= relativeTo.y;
        }

        public override readonly string ToString() {
            return $"({x}, {y})";
        }
    }
}