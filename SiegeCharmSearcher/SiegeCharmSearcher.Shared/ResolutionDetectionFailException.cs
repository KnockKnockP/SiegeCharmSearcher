namespace SiegeCharmSearcher.Shared {
    internal class ResolutionDetectionFailException : Exception {
        internal ResolutionDetectionFailException() {}

        internal ResolutionDetectionFailException(string message) : base(message) {}

        internal ResolutionDetectionFailException(string message, Exception innerException) : base(message, innerException) {}
    }
}