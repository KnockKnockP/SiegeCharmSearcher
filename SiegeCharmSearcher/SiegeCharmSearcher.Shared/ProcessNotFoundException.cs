namespace SiegeCharmSearcher.Shared {
    internal class ProcessNotFoundException : Exception {
        internal ProcessNotFoundException() {}

        internal ProcessNotFoundException(string message) : base(message) {}

        internal ProcessNotFoundException(string message, Exception innerException) : base(message, innerException) {}
    }
}