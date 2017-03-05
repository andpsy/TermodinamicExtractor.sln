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
        public string extension, path;
        public int id, pp_id;
        public ImageControl()
        {
            InitializeComponent();
        }
    }
}
