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

namespace PharmacySystem
{
    public partial class frmViewBookingDetails : Form
    {
        private IModel Model;
        private int gpId;
        public frmBooking RefToBooking { get; set; }
        public frmViewBookingDetails(IModel model, int id)
        {
            InitializeComponent();
            this.Model = model;
            this.gpId = id;
        }

        private void frmViewBookingDetails_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString(); // show the durrent time
            lblDate.Text = DateTime.Now.ToLongDateString(); // show the current date
            // timer1.Start(); // Start time 

            foreach (Gp gp in Model.GpList)
            {
                //get booking details
                if (gp.GpID == gpId)
                {
                   // txtGpRef.Text = gp.GpID.ToString();
                    txtFirst.Text = gp.FirstName.ToString();
                    txtLast.Text = gp.LastName.ToString();
                 //   txtAddress.Text = gp.Address.ToString();
                    txtPhone.Text = gp.Phone.ToString();
               //     txtEmail.Text = gp.Email.ToString();
                    break;
                }
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.RefToBooking.Show();
            this.Close();
        }
    }
}
