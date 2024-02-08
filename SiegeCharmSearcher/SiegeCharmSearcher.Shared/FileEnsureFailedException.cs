namespace SiegeCharmSearcher.Shared {
    internal class FileEnsureFailedException : Exception {
        internal FileEnsureFailedException() {}

        internal FileEnsureFailedException(string message) : base(message) {}

        internal FileEnsureFailedException(string message, Exception innerException) : base(message, innerException) {}
    }
}