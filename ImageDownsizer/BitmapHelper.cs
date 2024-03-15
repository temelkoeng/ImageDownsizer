using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace ImageDownsizer
{
    class BitmapHelper
    {
        public static Color[,] BitmapToColorArray(Bitmap bitmap)
        {
            int height = bitmap.Height;
            int width = bitmap.Width;
            Color[,] colors = new Color[width, height];

            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            unsafe
            {
                byte* pointer = (byte*)bitmapData.Scan0;

                // Calculate the number of bytes per scanline
                int stride = bitmapData.Stride;

                // Go over each pixel
                Parallel.For(0, height, y =>
                {
                    byte* row = pointer + (y * stride); // Start at current row

                    for (int x = 0; x < width; x++)
                    {
                        // Get the components of the color
                        byte a = row[x * 4 + 3];
                        byte r = row[x * 4 + 2];
                        byte g = row[x * 4 + 1];
                        byte b = row[x * 4];

                        // Store the color object
                        colors[x, y] = Color.FromArgb(a, r, g, b);
                    }
                });
            }
            bitmap.UnlockBits(bitmapData);

            return colors;
        }

        public static Bitmap ColorArrayToBitmap(Color[,] colorArray)
        {
            int width = colorArray.GetLength(0);
            int height = colorArray.GetLength(1);

            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            Rectangle rectangle = new Rectangle(0, 0, width, height);
            BitmapData bitmapData = bitmap.LockBits(rectangle, ImageLockMode.WriteOnly, bitmap.PixelFormat);

            int stride = bitmapData.Stride;
            IntPtr scan0 = bitmapData.Scan0;

            unsafe
            {
                byte* pattern = (byte*)scan0;

                // Iterate over rows for better memory access patterns
                for (int y = 0; y < height; y++)
                {
                    byte* rowPtr = pattern + (y * stride);

                    for (int x = 0; x < width; x++)
                    {
                        Color color = colorArray[x, y];
                        rowPtr[x * 3 + 2] = color.R; // <-- Red
                        rowPtr[x * 3 + 1] = color.G; // <-- Green
                        rowPtr[x * 3] = color.B; // <-- Blue
                    }
                }
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }
    }
}
