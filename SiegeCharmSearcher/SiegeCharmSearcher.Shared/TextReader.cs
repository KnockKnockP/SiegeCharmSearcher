using System.Drawing;
using Tesseract;

namespace SiegeCharmSearcher.Shared {
    internal static class TextReader {
        private static readonly TesseractEngine tesseractEngine = new("./tessdata-4.1.0", "eng", EngineMode.TesseractAndLstm);

        internal static string Read(Bitmap image) {
            using Page page = tesseractEngine.Process(image);
            return page.GetText().RemoveAllCharactersInString("`1234567890=[]\\;',./~!@#$%^&*()_+{}|:\"<>?\n");
        }
    }
}