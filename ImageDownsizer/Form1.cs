using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageDownsizer
{
    public partial class Form1 : Form
    {
        private Bitmap selectedImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void uploadImageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string selectedImagePath = openFileDialog.FileName;
                        selectedImage = new Bitmap(openFileDialog.FileName);
                        initialImageBox.Image = selectedImage;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error! " + ex.Message);
                    }
                }
            }
        }

        private Tuple<long, long, long> ProcessBilinearSequential(Bitmap selectedImage, double downscaleFactor)
        {
            long bitmapToColorArrayTime, resizeTime, colorArrayToBitmapTime;

            var colorArrayResult = MeasureExecutionTime(() =>
            {
                var array = BitmapHelper.BitmapToColorArray(selectedImage);
                return array;
            }, out bitmapToColorArrayTime);

            var resizedImageResult = MeasureExecutionTime(() =>
            {
                var image = BilinearInterpolator.ResizeImageSequential(colorArrayResult, downscaleFactor);
                return image;
            }, out resizeTime);

            var result = MeasureExecutionTime(() =>
            {
                var resultBitmap = BitmapHelper.ColorArrayToBitmap(resizedImageResult);
                downScaledImageBox.Image = resultBitmap;
                return resultBitmap;
            }, out colorArrayToBitmapTime);

            return Tuple.Create(bitmapToColorArrayTime, resizeTime, colorArrayToBitmapTime);
        }

        private T MeasureExecutionTime<T>(Func<T> action, out long executionTime)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = action();
            stopwatch.Stop();
            executionTime = stopwatch.ElapsedMilliseconds;
            return result;
        }

        private void Downsize(bool isConsequential)
        {
            if (selectedImage == null)
            {
                MessageBox.Show("You have to select an image!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double downscalePer;

            if (!double.TryParse(downscalePerTextbox.Text, out downscalePer) || downscalePer <= 0 || downscalePer > 100)
            {
                MessageBox.Show("Please enter a valid percantage (1-100).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long bitmapToCollorArrResult = 0;
            long resizeResult = 0;
            long collorArrayToBitmapTime = 0;

            if (isConsequential)
            {
                (bitmapToCollorArrResult, resizeResult, collorArrayToBitmapTime) = ProcessBilinearSequential(selectedImage, downscalePer);
            }

            bitmapToColorArrLbl.Text = bitmapToCollorArrResult.ToString();
            resizingLbl.Text = resizeResult.ToString();
            colorArrToBitmapLbl.Text = collorArrayToBitmapTime.ToString();
        }

        private void consequentialButton_Click(object sender, EventArgs e)
        {
            Downsize(true);
        }
    }
}
