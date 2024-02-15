using System.Drawing;

namespace SiegeCharmSearcher.Shared {
    internal sealed class Screenshot {
        private readonly Vector2Int namePoint, ownedPoint, presentPoint;
        private readonly Bitmap presentImage;
        internal Bitmap NameImage { get; private set; }
        internal Bitmap OwnedImage { get; private set; }

        internal Screenshot(Resolution resolution) {
            Vector2 nameStartingPoint1080P = new(1110f, 160f),
                    nameEndingPoint1080P = new(1920f, 220f),
                    ownedStartingPoint1080P = new(1152f, 290f),
                    ownedEndingPoint1080P = new(1225f, 310f),
                    presentPoint1080P = new(1226f, 259f);

            switch (resolution.AspectRatio) {
                case AspectRatio._54:
                    nameStartingPoint1080P = new(1115f, 273f);
                    nameEndingPoint1080P = new(1920f, 314f);
                    ownedStartingPoint1080P = new(1148f, 363f);
                    ownedEndingPoint1080P = new(1234f, 378f);
                    presentPoint1080P = new(1216f, 344f);
                    break;
                case AspectRatio._43:
                    nameStartingPoint1080P = new(1112f, 258f);
                    nameEndingPoint1080P = new(1920f, 301f);
                    ownedStartingPoint1080P = new(1149f, 352f);
                    ownedEndingPoint1080P = new(1233f, 368f);
                    presentPoint1080P = new(1221f, 330f);
                    break;
                case AspectRatio._32:
                    nameStartingPoint1080P = new(1115f, 224f);
                    nameEndingPoint1080P = new(1920f, 268f);
                    ownedStartingPoint1080P = new(1149f, 328f);
                    ownedEndingPoint1080P = new(1232f, 345f);
                    presentPoint1080P = new(1217f, 304f);
                    break;
                case AspectRatio._1610:
                    nameStartingPoint1080P = new(1113f, 203f);
                    nameEndingPoint1080P = new(1920f, 251f);
                    ownedStartingPoint1080P = new(1150f, 314f);
                    ownedEndingPoint1080P = new(1231f, 333f);
                    presentPoint1080P = new(1218f, 288f);
                    break;
                case AspectRatio._53:
                    nameStartingPoint1080P = new(1115f, 190f);
                    nameEndingPoint1080P = new(1920f, 238f);
                    ownedStartingPoint1080P = new(1151f, 304f);
                    ownedEndingPoint1080P = new(1231f, 322f);
                    presentPoint1080P = new(1218f, 277f);
                    break;
                case AspectRatio._1910:
                    nameStartingPoint1080P = new(1102f, 165f);
                    nameEndingPoint1080P = new(1920f, 220f);
                    ownedStartingPoint1080P = new(1137f, 289f);
                    ownedEndingPoint1080P = new(1215f, 310f);
                    presentPoint1080P = new(1205f, 259f);
                    break;
                case AspectRatio._219:
                    nameStartingPoint1080P = new(1076, 167f);
                    nameEndingPoint1080P = new(1920f, 219f);
                    ownedStartingPoint1080P = new(1102f, 289f);
                    ownedEndingPoint1080P = new(1164f, 310f);
                    presentPoint1080P = new(1155f, 260f);
                    break;
            }

            Vector2Int size = resolution.Size;

            namePoint = _1080PToUser(nameStartingPoint1080P, size);
            Vector2Int nameEndingPoint = _1080PToUser(nameEndingPoint1080P, size),
                       nameSize = (nameEndingPoint - namePoint);
            NameImage = new Bitmap(nameSize.x, nameSize.y);

            ownedPoint = _1080PToUser(ownedStartingPoint1080P, size);
            Vector2Int ownedEndingPoint = _1080PToUser(ownedEndingPoint1080P, size),
                       ownedSize = (ownedEndingPoint - ownedPoint);
            OwnedImage = new Bitmap(ownedSize.x, ownedSize.y);

            presentPoint = _1080PToUser(presentPoint1080P, size);
            presentImage = new Bitmap(1, 1);
        }

        private static Vector2Int _1080PToUser(Vector2 _1080P, Vector2Int resolutionSize) {
            Vector2 normalized = _1080P;
            normalized.Normalize(resolutionSize.ToVector2());
            return new Vector2((resolutionSize.x * normalized.x), (resolutionSize.y * normalized.y)).ToVector2Int();
        }

        private static void CopyFromScreen(Graphics graphics, Bitmap image, Vector2Int point) =>
            graphics.CopyFromScreen(point.x,
                                    point.y,
                                    0,
                                    0,
                                    image.Size,
                                    CopyPixelOperation.SourceCopy);

        internal string AnalyzeName() {
            using Graphics name = Graphics.FromImage(NameImage);
            CopyFromScreen(name, NameImage, namePoint);

            return TextReader.Read(NameImage);
        }

        internal bool AnalyzeOwned() {
            using Graphics owned = Graphics.FromImage(OwnedImage);
            CopyFromScreen(owned, OwnedImage, ownedPoint);

            return TextReader.Read(OwnedImage).Contains("OW", StringComparison.InvariantCultureIgnoreCase);
        }

        internal (bool, Color) AnalyzePresent() {
            using Graphics present = Graphics.FromImage(presentImage);
            CopyFromScreen(present, presentImage, presentPoint);

            Color color = presentImage.GetPixel(0, 0);
            const byte maximum = 35;
            return ((MathHelper.InBetweenInclusive(color.R, 0, maximum) &&
                     MathHelper.InBetweenInclusive(color.G, 0, maximum) &&
                     MathHelper.InBetweenInclusive(color.B, 0, maximum)), color);
        }
    }
}