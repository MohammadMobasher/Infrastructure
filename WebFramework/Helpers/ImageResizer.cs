using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

namespace WebFramework.Helpers
{
    public static class ImageResizer
    {
        public static byte[] ResizeImage(byte[] imgBytes, int maxFileSize = 100)
        {
            if (imgBytes == null || imgBytes.Length == 0)
                return null;

            if (maxFileSize == 0)
                return null;
                
            System.Drawing.Image img = new Bitmap(new MemoryStream(imgBytes));

            maxFileSize *= 1024;

            const int reduce = 50;

            var ms = new MemoryStream();
            img.Save(ms, ImageFormat.Jpeg);

            while (ms.Length > maxFileSize)
            {
                try
                {
                    ms.Dispose();
                    ms = new MemoryStream();

                    var height = img.Height;
                    var width = img.Width;

                    img = ResizeImage(img, width - reduce, height - reduce);

                    img.Save(ms, ImageFormat.Jpeg);
                    ms.Flush();

                }
                catch (Exception ex)
                { }
            }

            return ms.ToArray();
        }
        public static System.Drawing.Image ResizeImage(System.Drawing.Image img, int maxWidth, int maxheight)
        {
            var width = (double)maxWidth / img.Width;
            var height = (double)maxheight / img.Height;

            var ratio = Math.Min(width, height);

            var newWidth = (int)(img.Width * ratio);
            var newHeight = (int)(img.Height * ratio);

            var newImage = new Bitmap(img, newWidth, newHeight);

            return newImage;
        }
    }
}
