using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Tools.Drawing
{
    /// <summary>
    /// Stellt Hilfsmethoden zum zeichnen mit System.Drawing bereit.
    /// </summary>
    public static class DrawingHelper
    {
        public static Color[,] GetColorData(Bitmap bitmap)
        {
            if (bitmap == null)
            {
                throw new ArgumentNullException("bitmap");
            }

            Color[,] colorData = null;

            try
            {
                BitmapData data = bitmap.LockBits(
                    new Rectangle(Point.Empty, bitmap.Size),
                    ImageLockMode.ReadOnly,
                    bitmap.PixelFormat);

                int pixelSize = data.PixelFormat == PixelFormat.Format32bppArgb ? 4 : 3;
                int padding = data.Stride - (data.Width * pixelSize);
                byte[] bytes = new byte[data.Height * data.Stride];

                Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);

                colorData = new Color[data.Width, data.Height];

                int index = 0;
                for (var y = 0; y < data.Height; y++)
                {
                    for (var x = 0; x < data.Width; x++)
                    {
                        Color pixelColor = Color.FromArgb(
                            pixelSize == 3 ? 255 : bytes[index + 3], // A component if present
                            bytes[index + 2], // R component
                            bytes[index + 1], // G component
                            bytes[index]      // B component
                            );

                        colorData[x, y] = pixelColor;

                        index += pixelSize;
                    }
                }

                bitmap.UnlockBits(data);
            }
            catch (Exception)
            {
                colorData = null;
            }

            return colorData;
        }
    }
}