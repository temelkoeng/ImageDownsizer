﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDownsizer
{
    class BilinearInterpolator
    {
        public static Color[,] ResizeImageSequential(Color[,] image, double scalePer)
        {
            int initialWidth = image.GetLength(0);
            int initialHeght = image.GetLength(1);

            double scale = scalePer / 100.0;
            int updatedWidth = (int)(initialWidth * scale);
            int updatedHeight = (int)(initialHeght * scale);
            
            Color[,] resultImage = new Color[updatedWidth, updatedHeight];

            double widthRatio = (double)(initialWidth - 1) / (updatedWidth - 1);
            double heightRatio = (double)(initialHeght - 1) / (updatedHeight - 1);

            for (int updatedY = 0; updatedY < updatedHeight; updatedY++)
            {
                int sourceY1 = (int)Math.Floor(updatedY * heightRatio);
                int sourceY2 = Math.Min(sourceY1 + 1, initialHeght - 1);
               
                double yFraction = (updatedY * heightRatio) - sourceY1;

                for (int updatedX = 0; updatedX < updatedWidth; updatedX++)
                {
                    int sourceX1 = (int)Math.Floor(updatedX * widthRatio);
                    int sourceX2 = Math.Min(sourceX1 + 1, initialWidth - 1);
                    double xFraction = updatedX * widthRatio - sourceX1;

                    Color c11 = image[sourceX1, sourceY1];
                    Color c12 = image[sourceX1, sourceY2];
                    Color c21 = image[sourceX2, sourceY1];
                    Color c22 = image[sourceX2, sourceY2];

                    byte red = (byte)((1 - xFraction) * (1 - yFraction) * c11.R +
                                    xFraction * (1 - yFraction) * c21.R +
                                    (1 - xFraction) * yFraction * c12.R +
                                    xFraction * yFraction * c22.R);

                    byte green = (byte)((1 - xFraction) * (1 - yFraction) * c11.G +
                                    xFraction * (1 - yFraction) * c21.G +
                                    (1 - xFraction) * yFraction * c12.G +
                                    xFraction * yFraction * c22.G);

                    byte blue = (byte)((1 - xFraction) * (1 - yFraction) * c11.B +
                                    xFraction * (1 - yFraction) * c21.B +
                                    (1 - xFraction) * yFraction * c12.B +
                                    xFraction * yFraction * c22.B);

                    resultImage[updatedX, updatedY] = Color.FromArgb(red, green, blue);
                }
            }

            return resultImage;
        }

        public static Color[,] ResizeImageParallel(Color[,] image, double scalePercent)
        {
            int initialHeight = image.GetLength(1);
            int initialWidth = image.GetLength(0);

            double scale = scalePercent / 100.0;
            int updatedHeight = (int)(initialHeight * scale);
            int updatedWidth = (int)(initialWidth * scale);

            Color[,] resultImage = new Color[updatedWidth, updatedHeight];

            double heightRatio = (double)(initialHeight - 1) / (updatedHeight - 1);
            double widthRatio = (double)(initialWidth - 1) / (updatedWidth - 1);

            // Parallelize the row processing
            Parallel.For(0, updatedHeight, updatedY =>
            {
                // Process each parallely
                for (int updatedX = 0; updatedX < updatedWidth; updatedX++)
                {
                    double sourceX = updatedX * widthRatio;
                    double sourceY = updatedY * heightRatio;

                    int x1 = (int)Math.Floor(sourceX);
                    int x2 = Math.Min(x1 + 1, initialWidth - 1);
                    int y1 = (int)Math.Floor(sourceY);
                    int y2 = Math.Min(y1 + 1, initialHeight - 1);

                    double xFraction = sourceX - x1;
                    double yFraction = sourceY - y1;

                    Color c11 = image[x1, y1];
                    Color c12 = image[x1, y2];
                    Color c21 = image[x2, y1];
                    Color c22 = image[x2, y2];

                    byte red = (byte)((1 - xFraction) * (1 - yFraction) * c11.R +
                                    xFraction * (1 - yFraction) * c21.R +
                                    (1 - xFraction) * yFraction * c12.R +
                                    xFraction * yFraction * c22.R);

                    byte green = (byte)((1 - xFraction) * (1 - yFraction) * c11.G +
                                    xFraction * (1 - yFraction) * c21.G +
                                    (1 - xFraction) * yFraction * c12.G +
                                    xFraction * yFraction * c22.G);

                    byte blue = (byte)((1 - xFraction) * (1 - yFraction) * c11.B +
                                    xFraction * (1 - yFraction) * c21.B +
                                    (1 - xFraction) * yFraction * c12.B +
                                    xFraction * yFraction * c22.B);

                    resultImage[updatedX, updatedY] = Color.FromArgb(red, green, blue);
                }
            });

            return resultImage;
        }
    }
}
