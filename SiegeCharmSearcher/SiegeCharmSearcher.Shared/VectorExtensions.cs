namespace SiegeCharmSearcher.Shared {
    internal static class VectorExtensions {
        internal static Vector2 ToVector2(this Vector2Int vector2Int) =>
            new(vector2Int.x, vector2Int.y);

        internal static Vector2Int ToVector2Int(this Vector2 vector2) =>
            new((int)(vector2.x), (int)(vector2.y));
    }
}