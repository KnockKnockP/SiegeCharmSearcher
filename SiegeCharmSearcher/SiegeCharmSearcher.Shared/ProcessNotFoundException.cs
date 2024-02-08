namespace SiegeCharmSearcher.Shared {
    public class ProcessNotFoundException : Exception {
        public ProcessNotFoundException() {}

        public ProcessNotFoundException(string message) : base(message) {}

        public ProcessNotFoundException(string message, Exception innerException) : base(message, innerException) {}
    }
}