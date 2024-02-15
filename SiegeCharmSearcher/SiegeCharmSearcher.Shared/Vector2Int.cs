namespace SiegeCharmSearcher.Shared {
    public struct Vector2Int(int x, int y) {
        public int x = x, y = y;

        public static Vector2Int operator -(Vector2Int left, Vector2Int right) =>
            new((left.x - right.x), (left.y - right.y));

        public static bool operator ==(Vector2Int left, Vector2Int right) =>
            ((left.x == right.x) && (left.y == right.y));

        public static bool operator !=(Vector2Int left, Vector2Int right) =>
            ((left.x != right.x) || (left.y != right.y));

        public readonly override string ToString() => $"({x}, {y})";
    }
}