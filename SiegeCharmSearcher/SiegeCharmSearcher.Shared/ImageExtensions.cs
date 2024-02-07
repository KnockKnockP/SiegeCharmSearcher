/*
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp;
using System.Drawing.Imaging;

namespace SiegeCharmSearcher.Shared {
    //https://github.com/SixLabors/Samples/issues/15#issuecomment-790467094
    internal static class ImageExtensions {
        /// <summary>
        /// Extension method that converts a Image to an byte array
        /// </summary>
        /// <param name="image">The Image to convert</param>
        /// <returns>An byte array containing the JPG format Image</returns>
        internal static byte[] ToArray(this Image image) {
            using MemoryStream memoryStream = new();
            image.Save(memoryStream, JpegFormat.Instance);
            return memoryStream.ToArray();
        }

        /// <summary>
        /// Extension method that converts a Image to an byte array
        /// </summary>
        /// <param name="image">The Image to convert</param>
        /// <param name="imageFormat"></param>
        /// <returns>An byte array containing the JPG format Image</returns>
        internal static byte[] ToArray(this Image image, IImageFormat imageFormat) {
            using MemoryStream memoryStream = new();
            image.Save(memoryStream, imageFormat);
            return memoryStream.ToArray();
        }

        /// <summary>
        /// Extension method that converts a Image to an byte array
        /// </summary>
        /// <param name="image">The Image to convert</param>
        /// <returns>An byte array containing the JPG format Image</returns>
        internal static byte[] ToArray(this System.Drawing.Image image) {
            return ToArray(image, ImageFormat.Png);
        }

        /// <summary>
        /// Converts the image data into a byte array.
        /// </summary>
        /// <param name="image">The image to convert to an array</param>
        /// <param name="imageFormat">The format to save the image in</param>
        /// <returns>An array of bytes</returns>
        internal static byte[] ToArray(this System.Drawing.Image image, ImageFormat imageFormat) {
            using MemoryStream memoryStream = new();
            image.Save(memoryStream, imageFormat);
            return memoryStream.ToArray();
        }

        /// <summary>
        /// Extension method that converts a byte array with JPG data to an Image
        /// </summary>
        /// <param name="bytes">The byte array with JPG data</param>
        /// <returns>The reconstructed Image</returns>
        internal static Image ToImage(this byte[] bytes) {
            using MemoryStream memoryStream = new(bytes);
            Image image = Image.Load(memoryStream);
            return image;
        }
    }
}
*/