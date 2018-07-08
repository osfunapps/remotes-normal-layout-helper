using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace LayoutProject
{

    

    /// <summary>
    /// a generic image resizer class. Save the image file to a new image file in the given output, with the new dimensions.
    /// This class can keep aspect ratio and can also go for specific dimens.
    /// </summary>
    internal class PicResizer
    {

        /// <summary>
        /// Resize the image to the specified desiredWidth and desiredHeight.
        /// You can either set image or put a path to an image.
        /// </summary>
        /// <param name="image">Optional: the image to resize.</param>
        /// <param name="desiredWidth">The desiredWidth to resize to. Leave as zero to keep aspect ratio of desiredHeight.</param>
        /// <param name="desiredHeight">The desiredHeight to resize to. Leave as zero to keep aspect ratio of desiredWidth.</param>
        /// <returns>The resized image.</returns>
        public static bool ResizeImage(int desiredWidth, int desiredHeight, string outputFileName, string path ="", Image image = null)
        {
            if(image == null)
                image = Image.FromFile(path);
            if (desiredWidth == 0)
            {
                var heightMultiplier = (double) desiredHeight / (double) image.Height;
                desiredWidth = (int) Math.Round( (double) ((double) heightMultiplier * (double)image.Width));
            }
            else if (desiredHeight == 0)
            {
                var widthMultiplier = (double) desiredWidth / (double) image.Width;
                desiredHeight = (int)Math.Round((double)((double)widthMultiplier * (double)image.Height));
            }
            var destRect = new Rectangle(0, 0, desiredWidth, desiredHeight);
            var destImage = new Bitmap(desiredWidth, desiredHeight);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
             
            destImage.Save(outputFileName);
            destImage.Dispose();
            return true;
        }
    }

    
}