using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtractTermo
{
    public partial class ImageControl : UserControl
    {
        public Image image;
        public string extension, path;
        public int id, pp_id;
        public ImageControl()
        {
            InitializeComponent();
        }

        public ImageControl(Image img)
        {
            image = img;            
            InitializeComponent();
            pictureBox1.Image = ScaleImage(img, pictureBox1);
        }

        public static Image ScaleImage(Image image, PictureBox pb)
        {
            double ratioX = (double)pb.Width / (double)image.Width;
            double ratioY = (double)pb.Height / (double)image.Height;
            double sz = (double)Math.Max(image.Width, image.Height);
            double ratio = (double)Math.Min(pb.Width, pb.Height) / sz;
            ratio = ratio > 1 ? 1 : ratio;

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }
    }
}
