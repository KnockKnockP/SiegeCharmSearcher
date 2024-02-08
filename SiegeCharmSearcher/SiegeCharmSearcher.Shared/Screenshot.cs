using System.Drawing;

namespace SiegeCharmSearcher.Shared {
    public class Screenshot {
        public Bitmap image;
        public Charm charm = new();
        private readonly Vector2Int startingPoint, endingPoint;

        public Screenshot(Resolution resolution) {
            Vector2 startingPointNormalizedRelativeTo1080P = new(1110f, 160f);
            startingPointNormalizedRelativeTo1080P.Normalize(resolution.size.ToVector2());

            Vector2 endingPointNormalizedRelativeTo1080P = new(1920f, 220f);
            endingPointNormalizedRelativeTo1080P.Normalize(resolution.size.ToVector2());

            Vector2 startingPointNormalizedRelativeToUserResolution = resolution.size.ToVector2();
            startingPointNormalizedRelativeToUserResolution.x *= startingPointNormalizedRelativeTo1080P.x;
            startingPointNormalizedRelativeToUserResolution.y *= startingPointNormalizedRelativeTo1080P.y;

            Vector2 endingPointNormalizedRelativeToUserResolution = resolution.size.ToVector2();
            endingPointNormalizedRelativeToUserResolution.x *= endingPointNormalizedRelativeTo1080P.x;
            endingPointNormalizedRelativeToUserResolution.y *= endingPointNormalizedRelativeTo1080P.y;

            startingPoint = startingPointNormalizedRelativeToUserResolution.ToVector2Int();
            endingPoint = endingPointNormalizedRelativeToUserResolution.ToVector2Int();

            image = new Bitmap(endingPoint.x - startingPoint.x, endingPoint.y - startingPoint.y);
        }

        public void Capture() {
            using Graphics graphics = Graphics.FromImage(image);
            graphics.CopyFromScreen(startingPoint.x, startingPoint.y, 0, 0, image.Size, CopyPixelOperation.SourceCopy);
        }
    }
}