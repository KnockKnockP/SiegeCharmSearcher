using System.Drawing;

namespace SiegeCharmSearcher.Shared {
    public class Screenshot {
        internal Bitmap image;
        public Charm charm = new();
        private readonly Vector2Int startingPoint, endingPoint;

        public Screenshot(Resolution resolution) {
            Vector2 startingPointNormalizedRelativeTo1080P = new(1110f, 160f);
            Vector2 endingPointNormalizedRelativeTo1080P = new(1920f, 220f);

            switch (resolution.aspectRatio) {
                case AspectRatio._54:
                    startingPointNormalizedRelativeTo1080P = new(1115f, 273f);
                    endingPointNormalizedRelativeTo1080P = new(1920f, 314f);
                    break;
                case AspectRatio._43:
                    startingPointNormalizedRelativeTo1080P = new(1112f, 258f);
                    endingPointNormalizedRelativeTo1080P = new(1920f, 301f);
                    break;
                case AspectRatio._32:
                    startingPointNormalizedRelativeTo1080P = new(1115f, 224f);
                    endingPointNormalizedRelativeTo1080P = new(1920f, 268f);
                    break;
                case AspectRatio._1610:
                    startingPointNormalizedRelativeTo1080P = new(1113f, 203f);
                    endingPointNormalizedRelativeTo1080P = new(1920f, 251f);
                    break;
                case AspectRatio._53:
                    startingPointNormalizedRelativeTo1080P = new(1115f, 190f);
                    endingPointNormalizedRelativeTo1080P = new(1920f, 238f);
                    break;
                case AspectRatio._1910:
                    startingPointNormalizedRelativeTo1080P = new(1102f, 165f);
                    endingPointNormalizedRelativeTo1080P = new(1920f, 220f);
                    break;
                case AspectRatio._219:
                    startingPointNormalizedRelativeTo1080P = new(1076, 167f);
                    endingPointNormalizedRelativeTo1080P = new(1920f, 219f);
                    break;
            }

            startingPointNormalizedRelativeTo1080P.Normalize(resolution.size.ToVector2());
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

        internal void Capture() {
            using Graphics graphics = Graphics.FromImage(image);
            graphics.CopyFromScreen(startingPoint.x, startingPoint.y, 0, 0, image.Size, CopyPixelOperation.SourceCopy);
        }
    }
}