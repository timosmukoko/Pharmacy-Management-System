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
using System.IO;

namespace PharmacySystem
{
    public partial class frmDashboard : Form
    {
        //private frmLogin login = new frmLogin();
        private string SAVE_DIR = Directory.GetCurrentDirectory() + "\\Res\\";
        private string SAVE_DIR_PRES = Directory.GetCurrentDirectory() + "\\Pres\\";
        private frmPOS Usefrm;

        #region Instance Attributes
        private IModel Model;
        private List<Item> itemInPrescription = new List<Item>();
        public frmLogin RefToLogin { get; set; }
        private int idOfCurrentUser;
        #endregion  
        #region Constructors

        public frmDashboard(IModel Model)
        {
          
            InitializeComponent();
            this.Model = Model;
        }
        #endregion

        public void ShowUserName(string usertype, string username)
        {
            //txtDispenser.Text = username;
            lblDispenser.Text = username;
            lblUserName.Text = username;// Show user name
            
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            
            lblTime.Text = DateTime.Now.ToLongTimeString(); // show the durrent time
            lblDate.Text = DateTime.Now.ToShortDateString(); // show the current date
            timer1.Start(); // Start time  

            //LIST VIEW ALL PRESCRIPTION
            #region
            listViewAllPrescription.Items.Clear();
            listViewAllPrescription.BeginUpdate();


            foreach (Prescription prescription in Model.PrescriptionList)
            {
                string[] row = { prescription.PrescriptionID.ToString(), prescription.DrugName.ToString(), prescription.DateWritten.ToString(), prescription.DateProcessed.ToString(), prescription.DateDispensed.ToString(), prescription.DateExpires.ToString(), prescription.Instruction.ToString(), prescription.QuantityWritten.ToString(), prescription.QuantityDispensed.ToString(), prescription.DrugCategory.ToString(), prescription.UserID.ToString(), prescription.ClientID.ToString(), prescription.GpID.ToString() };
                var listViewItemP = new ListViewItem(row);
                listViewAllPrescription.Items.Add(listViewItemP);

            }
            listViewAllPrescription.EndUpdate();
            listViewAllPrescription.Enabled = true;
            listViewAllPrescription.FullRowSelect = true;
            
            #endregion

            //LIST STOCK ITEM VIEW
            #region
            listViewStockItem.Items.Clear();
            listViewStockItem.BeginUpdate();


            foreach (Item item in Model.ItemList)
            {
                string[] row = { item.ItemID.ToString(), item.Category.ToString(), item.Vendor.ToString(), item.Quantity.ToString(), item.PurchaseUnit.ToString(), item.ItemName.ToString() };
                var listViewItem = new ListViewItem(row);
                listViewStockItem.Items.Add(listViewItem);

            }
            listViewStockItem.EndUpdate();
            listViewStockItem.Enabled = true;
            listViewStockItem.FullRowSelect = true;
            #endregion

            //LIST CLIENT VIEW
            #region
            listViewClient.Items.Clear();
            listViewClient.BeginUpdate();


            foreach (Client client in Model.ClientList)
            {
                string[] row = { client.Pps.ToString(), client.FirstName.ToString(), client.LastName.ToString(), client.Street.ToString(), client.County.ToString(), client.Country.ToString(), client.Phone.ToString(), client.MedicalCardHolder.ToString(), client.CardNumber.ToString(), client.NextOfKinName.ToString(), client.NextOfKinPhone.ToString(), client.GpID.ToString() };
                var listViewItem = new ListViewItem(row);
                listViewClient.Items.Add(listViewItem);

            }
            listViewClient.EndUpdate();
            listViewClient.Enabled = true;
            listViewClient.FullRowSelect = true;
            #endregion
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = lblUserName.Text;
            frmStockItem stockItem = new frmStockItem(Model);
            stockItem.RefToDashboard = this;
            this.Visible = false;
            stockItem.Show();
            stockItem.ShowUserName(str);// call ShowUserName method()
        }

        private void btnStaffMember_Click(object sender, EventArgs e)
        {
            string usertype = Model.getUserTypeForCurrentuser();
            string username = Model.getUserNameForCurrentuser();
            frmEmployee staffMember = new frmEmployee(Model);
            staffMember.RefToDashboard = this;
            this.Visible = false;
            staffMember.Show();
            staffMember.ShowUserName(usertype,username);

            
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            frmClient patient = new frmClient(Model);
            string usertype = Model.getUserTypeForCurrentuser();
            string username = Model.getUserNameForCurrentuser();
            patient.RefToDashboard = this;
            this.Visible = false;
            // pos.Show();
            patient.ShowUserName(usertype, username);
            //string str = lblUserName.Text;
            //frmClient patient = new frmClient(Model);
            patient.Show(); // show patient form                                
            //patient.ShowUserName(str);// call ShowUserName method()
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            string username = Model.getUserNameForCurrentuser();
            frmReport report = new frmReport(Model, username);
            report.RefToDashboard = this;
            this.Visible = false;
            report.Show();
        }

        private void btnConsultation_Click(object sender, EventArgs e)
        {
            string username = Model.getUserNameForCurrentuser();
            frmConsultation consultation = new frmConsultation(Model, username);
            consultation.RefToDashboard = this;
            this.Visible = false;
            consultation.Show();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            string usertype = Model.getUserTypeForCurrentuser();
            string username = Model.getUserNameForCurrentuser();
            frmTransaction transaction = new frmTransaction(Model);
            transaction.RefToDashboard = this;
            this.Visible = false;
            transaction.Show();
            transaction.ShowUserName(usertype, username);
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            string usertype = Model.getUserTypeForCurrentuser();
            string username = Model.getUserNameForCurrentuser();
            frmBooking booking = new frmBooking(Model);
            booking.RefToDashboard = this;
            this.Visible = false;
            booking.Show(); // show booking form                                
           booking.ShowUserName(usertype, username);// call ShowUserName method()        
        }

        private void btnGP_Click(object sender, EventArgs e)
        {
            string usertype = Model.getUserTypeForCurrentuser();
            string username = Model.getUserNameForCurrentuser();
            frmGP gp = new frmGP(Model);
            gp.RefToDashboard = this;
            this.Visible = false;
            gp.Show();
            gp.ShowUserName(usertype,username);
            
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            string usertype = Model.getUserTypeForCurrentuser();
            string username = Model.getUserNameForCurrentuser();
            frmSupplier supplier = new frmSupplier(Model);
            supplier.RefToDashboard = this;
            this.Visible = false;
            supplier.Show();
            supplier.ShowUserName(usertype, username);

            
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            
            frmPOS pos = new frmPOS(Model);
            string usertype = Model.getUserTypeForCurrentuser();
            string username = Model.getUserNameForCurrentuser();
            pos.RefToDashboard = this;
            this.Visible = false;
            pos.Show();
            pos.ShowUserName(usertype, username);//call ShowUserName method
                      
        }

        private void btnStaffRoster_Click(object sender, EventArgs e)
        {
            frmRoster roster = new frmRoster(Model);
            string usertype = Model.getUserTypeForCurrentuser();
            string username = Model.getUserNameForCurrentuser();
            roster.RefToDashboard = this;
            this.Visible = false;
            roster.Show();
            roster.ShowUserName(usertype, username);
        }

        // Exit 
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult exit;
            exit = MessageBox.Show(" You should log out first before exiting the dashboard." + 
                "\r" + " Do you realy want to exit? ", " PHARMACY MANAGEMENT SYSTEM",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (exit == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // Log Out 
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Logout", idOfCurrentUser, "Logged out");
            DialogResult logOut;
            logOut = MessageBox.Show(" Confirm if you want to log out.", " PHARMACY MANAGEMENT SYSTEM",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (logOut == DialogResult.Yes)
            {
                this.RefToLogin.Show();
                this.Close();
            }
        }

        private void btnLogOut_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void btnLogOut_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Image idImage = picID.Image;

            FrmViewID idForm = new FrmViewID(idImage);
            idForm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Image prescriptionImage = pictureBox3.Image;

            frmViewPrescription preForm = new frmViewPrescription(prescriptionImage);
            preForm.Show();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnSearchByPPS_Click(object sender, EventArgs e)
        {
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Dashboard", idOfCurrentUser, "Updated");
            listViewClient.SelectedItems.Clear();
            if (!string.IsNullOrWhiteSpace(txtPPS.Text))
            {
                bool found = false;
                foreach (Client client in Model.ClientList)
                {
                    if (txtPPS.Text == client.Pps.ToString())
                    {
                        listViewClient.Items[Model.ClientList.IndexOf(client)].Selected = true;
                        listViewClient.Select();
                        found = true;
                        string[] row = { client.Pps.ToString(), client.FirstName.ToString(), client.LastName.ToString(), client.Street.ToString(), client.County.ToString(), client.Country.ToString(), client.Phone.ToString(), client.MedicalCardHolder.ToString(), client.CardNumber.ToString(), client.NextOfKinName.ToString(), client.NextOfKinPhone.ToString() };
                        var listViewClients = new ListViewItem(row);
                        listViewClient.Items.Add(listViewClients);                       
                    }
                }

                if (!found)
                    MessageBox.Show("PPS: " + txtPPS.Text + ", was not found OR Client is not found in the system.", "PHARMACY MANAGEMENT SYSTEM - Search",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Please enter in a PPS.", "PHARMACY MANAGEMENT SYSTEM - Search",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSearchByLastName_Click(object sender, EventArgs e)
        {
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Dashboard", idOfCurrentUser, "Updated");

            listViewClient.SelectedItems.Clear();
            if (!string.IsNullOrWhiteSpace(txtPPS.Text))
            {
                bool found = false;
                foreach (Client client in Model.ClientList)
                {
                    if (txtClientLastName.Text == client.LastName.ToString())
                    {
                        listViewClient.Items[Model.ClientList.IndexOf(client)].Selected = true;
                        listViewClient.Select();
                        string[] row = { client.Pps.ToString(), client.FirstName.ToString(), client.LastName.ToString(), client.Street.ToString(), client.County.ToString(), client.Country.ToString(), client.Phone.ToString(), client.MedicalCardHolder.ToString(), client.CardNumber.ToString(), client.NextOfKinName.ToString(), client.NextOfKinPhone.ToString() };
                        var listViewClientL = new ListViewItem(row);
                        listViewClient.Items.Add(listViewClientL);
                        found = true;
                    }
                }

                if (!found)
                    MessageBox.Show("LastName: " + txtClientLastName.Text + ", was not found / Client is not found in the system.", "PHARMACY MANAGEMENT SYSTEM - Search",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Please enter in Name.", "PHARMACY MANAGEMENT SYSTEM - Search",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void listViewClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewClient.SelectedItems.Count > 0)
            {

                foreach (Client client in Model.ClientList)
                {
                    if (listViewClient.SelectedItems[0].SubItems[0].Text == client.Pps)
                    {
                        txtPPS.Text = client.Pps;
                        txtClientLastName.Text = client.LastName;
                        lblFirstName.Text = client.FirstName;
                        lblLastName.Text = client.LastName;
                        lblPPS.Text = client.Pps;
                        lblStreet.Text = client.Street;
                        lblCounty.Text = client.County;
                        lblCountry.Text = client.County;
                        lblPhone.Text = client.Phone;
                        lblGPRef.Text = client.GpID.ToString();

                        picID.ImageLocation = client.ImageLocation;

                    }
                }
            }


        }

        private void btnSearchByItem_Click(object sender, EventArgs e)
        {
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Dashboard", idOfCurrentUser, "Updated");
            listViewStockItem.SelectedItems.Clear();
            if (!string.IsNullOrWhiteSpace(txtPPS.Text))
            {
                bool found = false;
                foreach (Item item in Model.ItemList)
                {
                    if (txtItemName.Text == item.ItemName.ToString())
                    {
                        listViewStockItem.Items[Model.ItemList.IndexOf(item)].Selected = true;
                        listViewStockItem.Select();
                        string[] row = { item.ItemID.ToString(), item.Category.ToString(), item.Vendor.ToString(), item.Quantity.ToString(), item.PurchaseUnit.ToString(), item.ItemName.ToString() };
                        var listViewItem = new ListViewItem(row);
                        listViewStockItem.Items.Add(listViewItem);
                        found = true;
                    }
                }

                if (!found)
                    MessageBox.Show("PPS: " + txtItemName.Text + ", was not found / Item is not found in the Stock.", "PHARMACY MANAGEMENT SYSTEM - Search",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Please enter in a Stock.", "PHARMACY MANAGEMENT SYSTEM - Search",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            //listViewStockItem.Items.Clear();

            //foreach (Item item in Model.ItemList)
            //{
            //    if (txtItemName.Text == item.ItemName.ToString())
            //    {
            //        string[] row = { item.ItemID.ToString(), item.Category.ToString(), item.Vendor.ToString(), item.Quantity.ToString(), item.PurchaseUnit.ToString(), item.ItemName.ToString() };
            //        var listViewItem = new ListViewItem(row);
            //        listViewStockItem.Items.Add(listViewItem);
            //    }
            //}
        }

        private void listViewStockItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewStockItem.SelectedItems.Count > 0)
            {

                foreach (Item item in Model.ItemList)
                {
                    if (Convert.ToInt16(listViewStockItem.SelectedItems[0].SubItems[0].Text) == item.ItemID)
                    {
                        txtItemName.Text = item.ItemName;
                        txtUnitPrice.Text = item.SaleUnit.ToString();
                    }
                }
            }
        }

        private void btnClearOrLoad_Click(object sender, EventArgs e)
        {
            clearClientField();
        }


        private void clearClientField()
        {
            // Clear All fields
            txtClientLastName.Text = "";
            txtInstruction.Text = "";
            txtItemName.Text = "";
            txtPPS.Text = "";
            txtQtyDispensed.Text = "";
            txtQtytWritten.Text = "";
            txtUnitPrice.Text = "";       
            picID.Image = null;
            lblFirstName.Text = "";
            lblLastName.Text = "";
            lblPPS.Text = "";
            lblStreet.Text = "";
            lblCounty.Text = "";
            lblCountry.Text = "";
            lblPhone.Text = "";
            lblGPRef.Text = "";

            // Load Client List
            listViewClient.Items.Clear();

            foreach (Client client in Model.ClientList)
            {
                string[] row = { client.Pps.ToString(), client.FirstName.ToString(), client.LastName.ToString(), client.Street.ToString(), client.County.ToString(), client.Country.ToString(), client.Phone.ToString(), client.MedicalCardHolder.ToString(), client.CardNumber.ToString(), client.NextOfKinName.ToString(), client.NextOfKinPhone.ToString() };
                var listViewItem = new ListViewItem(row);
                listViewClient.Items.Add(listViewItem);

            }

            listViewClient.Enabled = true;
            listViewClient.FullRowSelect = true;

            // Load Stock List
            listViewStockItem.Items.Clear();
         
            foreach (Item item in Model.ItemList)
            {
                string[] row = { item.ItemID.ToString(), item.Category.ToString(), item.Vendor.ToString(), item.Quantity.ToString(), item.PurchaseUnit.ToString(), item.ItemName.ToString() };
                var listViewItem = new ListViewItem(row);
                listViewStockItem.Items.Add(listViewItem);

            }
            listViewStockItem.Enabled = true;
            listViewStockItem.FullRowSelect = true;

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Dashboard", idOfCurrentUser, "ID Upload");
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg;*png;*gif)|*.jpg;*png;*gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                picID.Image = Image.FromFile(opf.FileName);

                if (!Directory.Exists(SAVE_DIR))
                    Directory.CreateDirectory(SAVE_DIR);

                File.Copy(opf.FileName, SAVE_DIR + txtPPS.Text, true);
            }
        }

        private void btnBrowsePres_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg;*png;*gif)|*.jpg;*png;*gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                picID.Image = Image.FromFile(opf.FileName);

                if (!Directory.Exists(SAVE_DIR_PRES))
                    Directory.CreateDirectory(SAVE_DIR_PRES);

                File.Copy(opf.FileName, SAVE_DIR_PRES + txtPPS.Text, true);
            }

        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            string usertype = Model.getUserTypeForCurrentuser();
            string username = Model.getUserNameForCurrentuser();
            frmLog log = new frmLog(Model);
            log.RefToDashboard = this;
            this.Visible = false;
            log.Show();
            log.ShowUserName(usertype, username);

        }

        private void lblGPRef_Click(object sender, EventArgs e)
        {

        }

        private void lblGPRef_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //string str = lblGPRef.Text;                           
            frmGP openGp = new frmGP(Model);
            openGp.Show();
           // lblGPRef.Text = openGp.comboResults.Text;
        }

       

        private void lblUserName_Click(object sender, EventArgs e)
        {
            string usertype = Model.getUserTypeForCurrentuser();
            string username = Model.getUserNameForCurrentuser();
            frmManageAccount log = new frmManageAccount(Model);
            log.RefToDashboard = this;
            this.Visible = false;
            log.Show();
            log.ShowUserName(usertype, username);
        }

        private void btnAddPresc_Click(object sender, EventArgs e)
        {
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Dashboard", idOfCurrentUser, "Perscription");
            

            DialogResult addPresc;
            addPresc = MessageBox.Show(" Are sure want to add this Presc ?", " PHARMACY MANAGEMENT SYSTEM",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (addPresc == DialogResult.Yes)
            {
                //Prescription prescription = new Prescription();
                Model.addNewPrescription(txtItemName.Text, Convert.ToDateTime(dateWritten.Text), Convert.ToDateTime(timeNow), Convert.ToDateTime(dateDispensed.Text), Convert.ToDateTime(dateExpires.Text), txtInstruction.Text, Convert.ToInt16(txtQtytWritten.Text), Convert.ToInt16(txtQtyDispensed.Text), cmbDrugCategory.Text, txtPPS.Text);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            #region
            listViewAllPrescription.Items.Clear();
            listViewAllPrescription.BeginUpdate();


            foreach (Prescription prescription in Model.PrescriptionList)
            {
                string[] row = { prescription.PrescriptionID.ToString(), prescription.DrugName.ToString(), prescription.DateWritten.ToString(), prescription.DateProcessed.ToString(), prescription.DateDispensed.ToString(), prescription.DateExpires.ToString(), prescription.Instruction.ToString(), prescription.QuantityWritten.ToString(), prescription.QuantityDispensed.ToString(), prescription.DrugCategory.ToString(), prescription.UserID.ToString(), prescription.ClientID.ToString(), prescription.GpID.ToString() };
                var listViewItemP = new ListViewItem(row);
                listViewAllPrescription.Items.Add(listViewItemP);

            }
            listViewAllPrescription.EndUpdate();
            listViewAllPrescription.Enabled = true;
            listViewAllPrescription.FullRowSelect = true;
            #endregion
        }

        private void listViewClient_DoubleClick_1(object sender, EventArgs e)
        {
            string str = lblUserName.Text;
            string id = listViewClient.SelectedItems[0].SubItems[0].Text;
            frmViewClientDetails viewDetails = new frmViewClientDetails(Model, id);
            viewDetails.Show();
            viewDetails.ShowUserName(str);
        }

        private void lblGPRef_DoubleClick(object sender, EventArgs e)
        {
            //string str = lblUserName.Text;
            //int id = 0;
            //foreach (Gp gp in Model.GpList)
            //{
            //    //get gp details
            //    if (gp.GpID == id)
            //    {
                    //frmViewGpDetails viewDetails = new frmViewGpDetails(Model, id);
                    //viewDetails.Show();
                    //viewDetails.ShowUserName(str);
                    //break;
            //    }
            //}
            
            
        }

        private void txtPPS_TextChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewClient.Items)
            {
                //Selected = true, won't show until the listview has focus, but setting it to true puts it in the 
                //SelectedItems collection.
                if (item.Text.ToLower().StartsWith(txtPPS.Text.ToLower()))
                {
                    item.Selected = true;
                    item.BackColor = Color.CornflowerBlue;
                    item.ForeColor = Color.White;
                }
                else
                {
                    item.Selected = false;
                    item.BackColor = Color.White;
                    item.ForeColor = Color.Black;
                }
            }
            //When the selection is narrowed to one the user can stop typing
            if (listViewClient.SelectedItems.Count == 2)
            {
                listViewClient.Focus();
            }

        }

        public List<string> GetData()
        {
            List<string> list = new List<string>();
            list.Add(txtItemName.Text);
            list.Add(txtQtyDispensed.Text);
            list.Add(txtUnitPrice.Text);
            //foreach(Item item in Model.ItemList)
            //{
                //item.ItemID.ToString();
                //item.ItemName = txtItemName.ToString();
                //item.Quantity = Convert.ToInt16(txtQtyDispensed);
                //item.PurchaseUnit = Convert.ToInt16(txtUnitPrice);
                //itemInPrescription.Add(item);
            //}
            return list;
        }

        public void setPos(frmPOS frm)
        {
            Usefrm = frm;
        }
        private void btnAddItem_Click(object sender, EventArgs e)
        {


            frmPOS pos = new frmPOS(Model);
            string usertype = Model.getUserTypeForCurrentuser();
            string username = Model.getUserNameForCurrentuser();
            pos.RefToDashboard = this;
            this.Visible = false;
            pos.Show();
            pos.ShowUserName(usertype, username);//call ShowUserName method
            ////frmPOS add = new frmPOS(Model);

            //foreach (Item item in Model.ItemList)
            //{
            //    item.ItemName = txtItemName.ToString();
            //    item.Quantity = Convert.ToInt32(txtQtyDispensed);
            //    item.PurchaseUnit = Convert.ToInt32(txtUnitPrice);

            //    string[] row = { item.ItemID.ToString(), txtQtyDispensed.ToString(), txtUnitPrice.ToString(), txtItemName.ToString() };
            //    var listViewItem = new ListViewItem(row);
            //    listViewStockItem.Items.Add(listViewItem);

            //}




            // ListViewItem item = new ListViewItem();
            // item.SubItems.Add(txtItemName.Text);
            // item.SubItems.Add(txtQtyDispensed.Text);
            // item.SubItems.Add(txtUnitPrice.Text);
            //// listPos.Items.Add(item);
            // txtItemName.Clear();
            // txtQtyDispensed.Clear();
            // txtUnitPrice.Clear();
            // txtQtytWritten.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
