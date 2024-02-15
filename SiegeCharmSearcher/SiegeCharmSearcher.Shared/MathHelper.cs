namespace SiegeCharmSearcher.Shared {
    internal static class MathHelper {
        internal static bool InBetweenInclusive(byte number, byte minimum, byte maximum) =>
            ((number >= minimum) && (number <= maximum));
    }
}