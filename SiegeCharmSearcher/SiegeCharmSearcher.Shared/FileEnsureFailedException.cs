namespace SiegeCharmSearcher.Shared {
    internal sealed class FileEnsureFailedException : Exception {
        internal FileEnsureFailedException(string message) : base(message) {}
    }
}