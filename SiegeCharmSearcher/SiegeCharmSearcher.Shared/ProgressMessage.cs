namespace SiegeCharmSearcher.Shared {
    public sealed class ProgressMessage(string message) : AProgress {
        public string Message { get; private set; } = message;
    }
}