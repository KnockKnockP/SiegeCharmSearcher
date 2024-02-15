using System.Drawing;

namespace SiegeCharmSearcher.Shared {
    public sealed class ProgressPresent(Color present) : AProgress {
        public Color Present { get; private set; } = present;
    }
}