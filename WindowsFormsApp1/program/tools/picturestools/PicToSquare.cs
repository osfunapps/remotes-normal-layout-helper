using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.program
{
    internal class PicToSquare
    {

        /// <summary>
        /// with pictures that their height will ALWAYS be greater then the width, we will take the 0,0,image.width,image.width parameters of the image. 
        /// </summary>
        /// <param name="imgPath">the path to the image to crop.</param>
        /// <returns>bitmap of the cropped size</returns>
        public static Image CropImage(string imgPath)
        {
            Bitmap bmpImage = Image.FromFile(imgPath) as Bitmap;
            var cropArea = new Rectangle(0,0,bmpImage.Width, bmpImage.Width);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

    }
}
