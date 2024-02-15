using System.Drawing;

namespace SiegeCharmSearcher.Shared {
    public sealed class ProgressImage(Bitmap image, AnalyzingImage analyzingImage) : AProgress {
        public Bitmap Image { get; private set; } = image;
        public AnalyzingImage AnalyzingImage { get; private set; } = analyzingImage;
    }
}