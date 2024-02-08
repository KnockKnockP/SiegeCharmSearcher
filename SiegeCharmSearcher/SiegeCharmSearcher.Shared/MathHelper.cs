namespace SiegeCharmSearcher.Shared {
    internal static class MathHelper {
        internal static bool InBetweenInclusive(byte number, byte minimum, byte maximum) {
            return ((number >= minimum) && (number <= maximum));
        }
    }
}