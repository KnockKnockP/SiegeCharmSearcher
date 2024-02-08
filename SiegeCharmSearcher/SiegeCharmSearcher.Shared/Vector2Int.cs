namespace SiegeCharmSearcher.Shared {
    public struct Vector2Int(int x, int y) {
        public int x = x, y = y;

        public void Normalize(Vector2Int relativeTo) {
            x /= relativeTo.x;
            y /= relativeTo.y;
        }

        public static Vector2Int operator -(Vector2Int left, Vector2Int right) {
            return new((left.x - right.x), (left.y - right.y));
        }

        public static bool operator ==(Vector2Int left, Vector2Int right) {
            return ((left.x == right.x) && (left.y == right.y));
        }

        public static bool operator !=(Vector2Int left, Vector2Int right) {
            return ((left.x != right.x) || (left.y != right.y));
        }

        public readonly int ToScalar(int xScale) {
            return ((y * xScale) + x);
        }

        public override readonly string ToString() {
            return $"({x}, {y})";
        }
    }
}