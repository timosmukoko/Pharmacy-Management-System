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
    public partial class frmViewSupplierDetails : Form
    {
        private IModel Model;
        private string supID;
        public frmSupplier RefToSupplier { get; set; }
        public frmViewSupplierDetails(IModel model, string id)
        {
            InitializeComponent();
            this.Model = model;
            lblUserName.Text = id;
        }

        private void frmViewSupplierDetails_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString(); // show the durrent time
            lblDate.Text = DateTime.Now.ToLongDateString(); // show the current date
            timer1.Start(); // Start time 

            foreach (Supplier sup in Model.SupplierList)
            {
                //get supplier details
                if (sup.supplierID == supID)
                {
                    txtSupID.Text = sup.supplierID.ToString();
                    txtName.Text = sup.companyName.ToString();
                    txtEmail.Text = sup.email.ToString();
                    txtPhone.Text = sup.phone.ToString();
                    txtStreet.Text = sup.street.ToString();
                    txtCity.Text = sup.city.ToString();
                    txtCounty.Text = sup.county.ToString();
                    txtCountry.Text = sup.country.ToString();
                    break;
                }
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.RefToSupplier.Show();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
