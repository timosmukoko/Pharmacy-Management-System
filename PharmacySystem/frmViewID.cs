using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystem
{
    public partial class FrmViewID : Form
    {
        Image image;
        public FrmViewID(Image i)
        {
            InitializeComponent();
            image = i;
        }

        private void FrmViewID_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
