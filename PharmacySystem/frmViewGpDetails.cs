using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BusinessLayer;
using BusinessEntities;
//author: Lorcan
namespace PharmacySystem
{
    public partial class frmViewGpDetails : Form
    {
        private IModel Model;
        private int gpId;
        public frmGP RefToGP { get; set; }
        public frmViewGpDetails(IModel model, int id)
        {
            InitializeComponent();
            this.Model = model;
            this.gpId = id;
        }

        private void frmViewGpDetails_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString(); // show the durrent time
            lblDate.Text = DateTime.Now.ToShortDateString(); // show the current date
            timer1.Start(); // Start time 

            foreach (Gp gp in Model.GpList)
            {
                //get gp details
                if (gp.GpID == gpId)
                {
                    txtGpRef.Text = gp.GpID.ToString();
                    txtFirst.Text = gp.FirstName.ToString();
                    txtLast.Text = gp.LastName.ToString();
                    txtAddress.Text = gp.Address.ToString();
                    txtPhone.Text = gp.Phone.ToString();
                    txtEmail.Text = gp.Email.ToString();
                    break;
                }
            }
        }

        public void ShowUserName(string username)
        {
            lblUserName.Text = username;// Show user name

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void button22_Click(object sender, EventArgs e)
        {
            this.RefToGP.Show();
            this.Close();
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            this.RefToGP.Show();
            this.Close();
        }
    }
}
