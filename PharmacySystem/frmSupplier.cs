//michael
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Word = Microsoft.Office.Interop.Word;
using System.Reflection;

using BusinessLayer;
using BusinessEntities;

namespace PharmacySystem
{
    public partial class frmSupplier : Form
    {
        #region Instance Attributes
        private IModel Model;
        private int idOfCurrentUser;
        public frmDashboard RefToDashboard { get; set; }
        #endregion
        #region Constructors

        public frmSupplier(IModel model)
        {
            InitializeComponent();
            this.Model = model;
        }

        #endregion

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            listSupplier.Items.Clear();
            listSupplier.BeginUpdate();


            foreach (Supplier supplier in Model.SupplierList)
            {
                string[] row = { supplier.supplierID.ToString(), supplier.email.ToString(), supplier.street.ToString(), supplier.city.ToString(), supplier.county.ToString(), supplier.country.ToString() };
                var listViewItem = new ListViewItem(row);
                listSupplier.Items.Add(listViewItem);

            }

            listSupplier.EndUpdate();
            listSupplier.Enabled = true;
            listSupplier.FullRowSelect = true;


            lblTime.Text = DateTime.Now.ToLongTimeString(); // show the current time
            lblDate.Text = DateTime.Now.ToShortDateString();
            timer1.Start(); // Start time 
        }


        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Update", "Are you sure !", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DateTime timeNow = DateTime.Now;
                Model.addNewLog(timeNow, "Supplier", idOfCurrentUser, "Updated");
                foreach (Supplier Supplier in Model.SupplierList)
                {
                    if (Convert.ToString(listSupplier.SelectedItems[0].SubItems[0].Text) == Supplier.supplierID)
                    {
                        Supplier.supplierID = textBox1.Text;
                        Supplier.companyName = CompanyTextbox.Text;
                        Supplier.email = EmailTextbox.Text;
                        Supplier.phone = PhoneTextBox.Text;
                        Supplier.street = StreettextBox.Text;
                        Supplier.city = CityTextbox.Text;
                        Supplier.county = CountyTextbox.Text;
                        Supplier.country = CountrytextBox.Text;


                        Model.editSupplier(Supplier);

                    }
                }
                listSupplier.Items.Clear();
                foreach (Supplier supplier in Model.SupplierList)
                {
                    string[] row = { supplier.supplierID.ToString(), supplier.companyName.ToString(), supplier.email.ToString(), supplier.phone.ToString(), supplier.street.ToString(), supplier.city.ToString(), supplier.county.ToString(), supplier.country.ToString() };
                    var listViewItem = new ListViewItem(row);
                    listSupplier.Items.Add(listViewItem);

                }
                //textBoxName.Text = "";
                //textBoxPassword.Text = "";
            }
        }

        private void UserSupLBL_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void NameTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void listSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listSupplier.SelectedItems.Count > 0)

            {

                foreach (Supplier supplier in Model.SupplierList)
                {
                    if (Convert.ToString(listSupplier.SelectedItems[0].SubItems[0].Text) == supplier.supplierID)
                    {
                        textBox1.Text = supplier.supplierID.ToString();
                        CompanyTextbox.Text = supplier.companyName.ToString();
                        EmailTextbox.Text = supplier.email.ToString();
                        PhoneTextBox.Text = supplier.phone.ToString();
                        StreettextBox.Text = supplier.street.ToString();
                        CityTextbox.Text = supplier.city.ToString();
                        CountyTextbox.Text = supplier.county.ToString();
                        CountrytextBox.Text = supplier.country.ToString();



                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            int index = listSupplier.FocusedItem.Index;


            if (MessageBox.Show("Delete", "Are you sure !", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            foreach (Supplier supplier in Model.SupplierList)
            {

                if (Convert.ToString(listSupplier.SelectedItems[0].SubItems[0].Text) == supplier.supplierID)
                {
                    DateTime timeNow = DateTime.Now;
                    Model.addNewLog(timeNow, "Supplier", idOfCurrentUser, "Deleted");

                    Model.deleteSupplier(supplier);
                    listSupplier.Items.RemoveAt(index); //remove name from listbox
                    break;
                }
            }
        }


        private void StreettextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Supplier", idOfCurrentUser, "Searched");

            listSupplier.Items.Clear();

            foreach (Supplier supplier in Model.SupplierList)
            {
                if (supplier.supplierID.ToString() == comboResults.Text || supplier.companyName.ToString() == comboResults.Text)
                {
                    string[] row = { supplier.supplierID.ToString(), supplier.companyName.ToString(), supplier.email.ToString(), supplier.phone.ToString(), supplier.street.ToString(), supplier.city.ToString(), supplier.county.ToString(), supplier.country.ToString() };
                    var listViewItem = new ListViewItem(row);
                    listSupplier.Items.Add(listViewItem);
                }
            }
        }

        
            

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Supplier", idOfCurrentUser, "Printed");
            if (listSupplier.SelectedItems.Count > 0)
            {

                foreach (Supplier supplier in Model.SupplierList)
                {
                    if (Convert.ToString(listSupplier.SelectedItems[0].SubItems[0].Text) == supplier.supplierID)
                    {
                        char vt = (char)11;

                        CompanyTextbox.Text = supplier.companyName.ToString();
                        EmailTextbox.Text = supplier.email.ToString();
                        PhoneTextBox.Text = supplier.phone.ToString();
                        StreettextBox.Text = supplier.street.ToString();
                        CityTextbox.Text = supplier.city.ToString();
                        CountyTextbox.Text = supplier.county.ToString();
                        CountrytextBox.Text = supplier.country.ToString();


                        object oMissing = System.Reflection.Missing.Value;
                        object oEndOfDoc = "\\endofdoc";
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CompanyTextbox.Text = "Select Category...";
            EmailTextbox.Text = "";
            PhoneTextBox.Text = "";
            StreettextBox.Text = "";
            CityTextbox.Text = "";
            CountyTextbox.Text = "";
            CountrytextBox.Text = "";
            
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.RefToDashboard.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Model.addnewSupplier(textBox1.Text, CompanyTextbox.Text, EmailTextbox.Text, PhoneTextBox.Text, StreettextBox.Text, CityTextbox.Text, CountyTextbox.Text, CountrytextBox.Text);
            cleartextFieldAndLoad();
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Supplier", idOfCurrentUser, "Added");

        }

        private void cleartextFieldAndLoad()
        {
            textBox1.Text = "";
            CompanyTextbox.Text = "";
            EmailTextbox.Text = "";
            PhoneTextBox.Text = "";
            StreettextBox.Text = "";
            CityTextbox.Text = "";
            CountyTextbox.Text = "";
            CountrytextBox.Text = "";


            listSupplier.Items.Clear();

            foreach (Supplier supplier in Model.SupplierList)
            {
               
                    string[] row = { supplier.supplierID.ToString(), supplier.companyName.ToString(), supplier.email.ToString(), supplier.phone.ToString(), supplier.street.ToString(), supplier.city.ToString(), supplier.county.ToString(), supplier.country.ToString() };
                    var listViewItem = new ListViewItem(row);
                    listSupplier.Items.Add(listViewItem);
                
            }

            listSupplier.Enabled = true;
            listSupplier.FullRowSelect = true;

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        public void ShowUserName(string usertype, string username)
        {

            foreach (User user in Model.UserList)
            {
                if (user.UserType == usertype && user.Username == username)
                {
                    idOfCurrentUser = user.UserID;
                    lblUsername.Text = username;// Show user name
                }
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void comboStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> SupplierID = new List<string>();
            List<String> ComapnyName = new List<string>();


            if (comboStock.SelectedIndex == 0)
            {
                comboResults.Items.Clear();
                foreach (Supplier supplier in Model.SupplierList)
                {
                    if (!SupplierID.Contains(supplier.supplierID.ToString()))
                    {
                        comboResults.Items.Add(supplier.supplierID.ToString());
                        SupplierID.Add(supplier.supplierID.ToString());
                    }
                }
                comboResults.SelectedItem = SupplierID.First();
            }
            else if (comboStock.SelectedIndex == 1)
            {
                comboResults.Items.Clear();
                foreach (Item supplier in Model.ItemList)
                {
                    if (!ComapnyName.Contains(supplier.Vendor.ToString()))
                    {
                        comboResults.Items.Add(supplier.Vendor.ToString());
                        ComapnyName.Add(supplier.Vendor.ToString());
                    }
                }
                comboResults.SelectedItem = ComapnyName.First();
            }
        }

        private void listSupplier_DoubleClick(object sender, EventArgs e)
        {
            string str = lblUsername.Text;
            string id = listSupplier.SelectedItems[0].SubItems[0].Text;
            frmViewSupplierDetails viewDetails = new frmViewSupplierDetails(Model, str);
            viewDetails.RefToSupplier= this;
            this.Visible = false;
            viewDetails.Show();
            //viewDetails.ShowUserName(str);
        }
    }
}
    

