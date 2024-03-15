
namespace ImageDownsizer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.initialImageBox = new System.Windows.Forms.PictureBox();
            this.downScaledImageBox = new System.Windows.Forms.PictureBox();
            this.uploadImageButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.downscalePerTextbox = new System.Windows.Forms.TextBox();
            this.downscalePerLabel = new System.Windows.Forms.Label();
            this.consequentialButton = new System.Windows.Forms.Button();
            this.parallelButton = new System.Windows.Forms.Button();
            this.bitmapToColorArrLbl = new System.Windows.Forms.Label();
            this.resizingLbl = new System.Windows.Forms.Label();
            this.colorArrToBitmapLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.initialImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downScaledImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // initialImageBox
            // 
            this.initialImageBox.Location = new System.Drawing.Point(15, 15);
            this.initialImageBox.Name = "initialImageBox";
            this.initialImageBox.Size = new System.Drawing.Size(565, 208);
            this.initialImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.initialImageBox.TabIndex = 0;
            this.initialImageBox.TabStop = false;
            // 
            // downScaledImageBox
            // 
            this.downScaledImageBox.Location = new System.Drawing.Point(422, 366);
            this.downScaledImageBox.Name = "downScaledImageBox";
            this.downScaledImageBox.Size = new System.Drawing.Size(565, 181);
            this.downScaledImageBox.TabIndex = 1;
            this.downScaledImageBox.TabStop = false;
            // 
            // uploadImageButton
            // 
            this.uploadImageButton.Location = new System.Drawing.Point(718, 15);
            this.uploadImageButton.Name = "uploadImageButton";
            this.uploadImageButton.Size = new System.Drawing.Size(201, 53);
            this.uploadImageButton.TabIndex = 2;
            this.uploadImageButton.Text = "Upload";
            this.uploadImageButton.UseVisualStyleBackColor = true;
            this.uploadImageButton.Click += new System.EventHandler(this.uploadImageButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(106, 479);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(201, 53);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // downscalePerTextbox
            // 
            this.downscalePerTextbox.Location = new System.Drawing.Point(681, 85);
            this.downscalePerTextbox.Name = "downscalePerTextbox";
            this.downscalePerTextbox.Size = new System.Drawing.Size(171, 22);
            this.downscalePerTextbox.TabIndex = 4;
            // 
            // downscalePerLabel
            // 
            this.downscalePerLabel.AutoSize = true;
            this.downscalePerLabel.Location = new System.Drawing.Point(858, 88);
            this.downscalePerLabel.Name = "downscalePerLabel";
            this.downscalePerLabel.Size = new System.Drawing.Size(102, 17);
            this.downscalePerLabel.TabIndex = 6;
            this.downscalePerLabel.Text = "Downscale Per";
            // 
            // consequentialButton
            // 
            this.consequentialButton.Location = new System.Drawing.Point(718, 144);
            this.consequentialButton.Name = "consequentialButton";
            this.consequentialButton.Size = new System.Drawing.Size(201, 53);
            this.consequentialButton.TabIndex = 7;
            this.consequentialButton.Text = "Consequential";
            this.consequentialButton.UseVisualStyleBackColor = true;
            this.consequentialButton.Click += new System.EventHandler(this.consequentialButton_Click);
            // 
            // parallelButton
            // 
            this.parallelButton.Location = new System.Drawing.Point(718, 219);
            this.parallelButton.Name = "parallelButton";
            this.parallelButton.Size = new System.Drawing.Size(201, 53);
            this.parallelButton.TabIndex = 8;
            this.parallelButton.Text = "Parallel";
            this.parallelButton.UseVisualStyleBackColor = true;
            // 
            // bitmapToColorArrLbl
            // 
            this.bitmapToColorArrLbl.AutoSize = true;
            this.bitmapToColorArrLbl.Location = new System.Drawing.Point(15, 345);
            this.bitmapToColorArrLbl.Name = "bitmapToColorArrLbl";
            this.bitmapToColorArrLbl.Size = new System.Drawing.Size(145, 17);
            this.bitmapToColorArrLbl.TabIndex = 9;
            this.bitmapToColorArrLbl.Text = "Bitmap to Collor Array";
            // 
            // resizingLbl
            // 
            this.resizingLbl.AutoSize = true;
            this.resizingLbl.Location = new System.Drawing.Point(15, 381);
            this.resizingLbl.Name = "resizingLbl";
            this.resizingLbl.Size = new System.Drawing.Size(62, 17);
            this.resizingLbl.TabIndex = 10;
            this.resizingLbl.Text = "Resizing";
            // 
            // colorArrToBitmapLbl
            // 
            this.colorArrToBitmapLbl.AutoSize = true;
            this.colorArrToBitmapLbl.Location = new System.Drawing.Point(15, 418);
            this.colorArrToBitmapLbl.Name = "colorArrToBitmapLbl";
            this.colorArrToBitmapLbl.Size = new System.Drawing.Size(142, 17);
            this.colorArrToBitmapLbl.TabIndex = 11;
            this.colorArrToBitmapLbl.Text = "Color Array to Bitmap";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1021, 602);
            this.Controls.Add(this.colorArrToBitmapLbl);
            this.Controls.Add(this.resizingLbl);
            this.Controls.Add(this.bitmapToColorArrLbl);
            this.Controls.Add(this.parallelButton);
            this.Controls.Add(this.consequentialButton);
            this.Controls.Add(this.downscalePerLabel);
            this.Controls.Add(this.downscalePerTextbox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.uploadImageButton);
            this.Controls.Add(this.downScaledImageBox);
            this.Controls.Add(this.initialImageBox);
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.initialImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downScaledImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox initialImageBox;
        private System.Windows.Forms.PictureBox downScaledImageBox;
        private System.Windows.Forms.Button uploadImageButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox downscalePerTextbox;
        private System.Windows.Forms.Label downscalePerLabel;
        private System.Windows.Forms.Button consequentialButton;
        private System.Windows.Forms.Button parallelButton;
        private System.Windows.Forms.Label bitmapToColorArrLbl;
        private System.Windows.Forms.Label resizingLbl;
        private System.Windows.Forms.Label colorArrToBitmapLbl;
    }
}

