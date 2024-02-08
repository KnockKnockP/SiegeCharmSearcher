namespace SiegeCharmSearcher.Shared {
    internal class BadSaveFileException : Exception {
        internal BadSaveFileException() { }

        internal BadSaveFileException(string message) : base(message) { }

        internal BadSaveFileException(string message, Exception innerException) : base(message, innerException) { }
    }
}