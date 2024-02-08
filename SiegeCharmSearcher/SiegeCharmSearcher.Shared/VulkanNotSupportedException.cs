namespace SiegeCharmSearcher.Shared {
    public class VulkanNotSupportedException : Exception {
        public VulkanNotSupportedException() { }

        public VulkanNotSupportedException(string message) : base(message) { }

        public VulkanNotSupportedException(string message, Exception innerException) : base(message, innerException) { }
    }
}