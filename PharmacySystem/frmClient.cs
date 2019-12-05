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
using Word = Microsoft.Office.Interop.Word;

using System.IO;


namespace PharmacySystem
{
    public partial class frmClient : Form
    {
        
        #region Instance Attributes
        private IModel Model;
        public frmDashboard RefToDashboard { get; set; }
        public frmDashboardAssistantView RefToDashboardAssistant { get; set; }
        private int idOfCurrentUser;

        #endregion
        #region Constructors
        public frmClient(IModel model)
        {
            InitializeComponent();
            this.Model = model;

        }

        //public void ShowUserName(string username)
        //{
        //    lblUserName.Text = username;// Show user name
        //    if (username == "manager") // get user name privilegies
        //    {
        //        grpManageClient.Enabled = true;
        //        grpManageClient.Enabled = true;
        //        grpManageClient.Visible = true;
        //    }
        //}

        public void ShowUserName(string usertype, string username)
        {
            lblUserName.Text = username;// Show user name
            if (usertype == "Manager") // get user name privilegies
            {
                grpManageClient.Enabled = true;

            }
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString(); // show the durrent time
            lblDate.Text = DateTime.Now.ToShortDateString(); // show the current date
            timer1.Start(); // Start time  

            listViewClient.Items.Clear();
            listViewClient.BeginUpdate();


            foreach (Client client in Model.ClientList)
            {
                string[] row = { client.Pps.ToString(), client.FirstName.ToString(), client.LastName.ToString(), client.Street.ToString(), client.County.ToString(), client.Country.ToString(), client.Phone.ToString(), client.MedicalCardHolder.ToString(), client.CardNumber.ToString(), client.NextOfKinName.ToString(), client.NextOfKinPhone.ToString(), Convert.ToString(client.GpID) };
                var listViewItem = new ListViewItem(row);
                listViewClient.Items.Add(listViewItem);

            }
            listViewClient.EndUpdate();
            listViewClient.Enabled = true;
            listViewClient.FullRowSelect = true;

        }

        private void button18_Click(object sender, EventArgs e)
        {
            //listViewPatient.Items.Clear();
            //bool val = validatePatient();


            //if (val == false)
            //{
            //    MessageBox.Show("Please fill in required data", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}


            //string line;
            //string[] tempArray;
            //string n = Convert.ToString(txtSearchPatient.Text);

            //try
            //{
            //    using (StreamReader input1 = new StreamReader("patients.txt"))
            //    {
            //        while ((line = input1.ReadLine()) != null)
            //        {
            //            tempArray = line.Split(' ');

            //            Patient pat = new Patient(tempArray[0], tempArray[1], (tempArray[2]), tempArray[3], tempArray[4], tempArray[5], tempArray[6], tempArray[7], tempArray[8]);
            //            string fullName = pat.firstName + " " + pat.lastName;

            //            if (n == (pat.pps) || n == (fullName))
            //            {
            //                ListViewItem lvi = new ListViewItem(pat.pps);
            //                lvi.SubItems.Add(pat.firstName);
            //                lvi.SubItems.Add(pat.lastName);
            //                lvi.SubItems.Add(pat.street);
            //                lvi.SubItems.Add(pat.city);
            //                lvi.SubItems.Add(pat.county);
            //                lvi.SubItems.Add(pat.country);
            //                lvi.SubItems.Add(pat.nextOfKin);
            //                lvi.SubItems.Add(pat.phone);
            //                listViewPatient.Items.Add(lvi);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("  The patients file was not found or could not be opened     \n" + ex);
            //}
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            Model.addNewClient(txtPPS.Text, txtFirstName.Text, txtLastName.Text, txtStreet.Text, txtCounty.Text, txtCountry.Text, txtPhone.Text, cmbMedCardHolder.Text, txtMedCardNum.Text, txtNextOfKinName.Text, txtNextOfKinPhone.Text, Convert.ToInt32(txtGpRefNum.Text));
            clearClientField();
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Client", idOfCurrentUser, "Added");
        }


        private void clearClientField()
        {
            txtPPS.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtStreet.Text = "";
            txtCounty.Text = "";
            txtCountry.Text = "";
            txtPhone.Text = "";
            cmbMedCardHolder.Text = "";
            txtMedCardNum.Text = "";
            txtNextOfKinName.Text = "";
            txtNextOfKinPhone.Text = "";
            txtGpRefNum.Text = "";
            

            listViewClient.Items.Clear();
            

            foreach (Client client in Model.ClientList)
            {
                string[] row = { client.Pps.ToString(), client.FirstName.ToString(), client.LastName.ToString(), client.Street.ToString(), client.County.ToString(), client.Country.ToString(), client.Phone.ToString(), client.MedicalCardHolder.ToString(), client.CardNumber.ToString(), client.NextOfKinName.ToString(), client.NextOfKinPhone.ToString(), client.GpID.ToString()};
                var listViewItem = new ListViewItem(row);
                listViewClient.Items.Add(listViewItem);

            }
            
            listViewClient.Enabled = true;
            listViewClient.FullRowSelect = true;

        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            clearClientField();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult update;
            update = MessageBox.Show(" Are sure you want to update?", " UPDATE CLIENT",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (update == DialogResult.Yes)
   
              //  if (MessageBox.Show("Update", "Are you sure !", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (Client client in Model.ClientList)
                {
                    if (listViewClient.SelectedItems[0].SubItems[0].Text == client.Pps)
                    {
                        client.Pps = txtPPS.Text;
                        client.FirstName = txtFirstName.Text;
                        client.LastName = txtLastName.Text;
                        client.Street = txtStreet.Text;
                        client.County = txtCounty.Text;
                        client.Country = txtCountry.Text;
                        client.Phone = txtPhone.Text;
                        client.MedicalCardHolder = cmbMedCardHolder.Text;
                        client.CardNumber = txtMedCardNum.Text;
                        client.NextOfKinName = txtNextOfKinName.Text;
                        client.NextOfKinPhone = txtNextOfKinPhone.Text;
                        client.GpID = Convert.ToInt16(txtGpRefNum.Text);

                        Model.editClient(client);
                    }
                }
                
                foreach (Client client in Model.ClientList)
                {
                    string[] row = { client.Pps.ToString(), client.FirstName.ToString(), client.LastName.ToString(), client.Street.ToString(), client.County.ToString(), client.Country.ToString(), client.Phone.ToString(), client.MedicalCardHolder.ToString(), client.CardNumber.ToString(), client.NextOfKinName.ToString(), client.NextOfKinPhone.ToString(), client.GpID.ToString() };
                    var listViewItem = new ListViewItem(row);
                    listViewClient.Items.Add(listViewItem);
                }

                listViewClient.Items.Clear();
            }
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Client", idOfCurrentUser, "Updated");
        }

        private void listViewClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewClient.SelectedItems.Count > 0)
            {

                foreach (IClient client in Model.ClientList)
                {
                    if (listViewClient.SelectedItems[0].SubItems[0].Text == client.Pps)
                    {

                        txtPPS.Text = client.Pps;
                        txtFirstName.Text = client.FirstName;
                        txtLastName.Text = client.LastName;
                        txtStreet.Text = client.Street;
                        txtCounty.Text = client.County;
                        txtCountry.Text = client.Country;
                        txtPhone.Text = client.Phone;
                        cmbMedCardHolder.Text = client.MedicalCardHolder;
                        txtMedCardNum.Text = client.CardNumber;
                        txtNextOfKinName.Text = client.NextOfKinName;
                        txtNextOfKinPhone.Text = client.NextOfKinPhone;
                        txtGpRefNum.Text = client.GpID.ToString();

                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = listViewClient.FocusedItem.Index;



            DialogResult delete;
            delete = MessageBox.Show(" Are sure you want to delete.", " DELETE CLIENT",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (delete == DialogResult.Yes)
            {
             
            //if (MessageBox.Show("Are you sure !", " Delete ", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            //    return;

            foreach (Client client in Model.ClientList)
            {

                if (listViewClient.SelectedItems[0].SubItems[0].Text == client.Pps)
                {
                    Model.deleteClient(client);
                    listViewClient.Items.RemoveAt(index); //remove name from listbox
                    break;
                }


            }
           }
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Client", idOfCurrentUser, "Deleted");
        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> pps = new List<string>();
            List<String> lastName = new List<string>();
            List<String> phone = new List<string>();

            if (cmbSearch.SelectedIndex == 0)
            {
                cmbSearchResult.Items.Clear();
                foreach (Client client in Model.ClientList)
                {
                    if (!pps.Contains(client.Pps.ToString()))
                    {
                        cmbSearchResult.Items.Add(client.Pps.ToString());
                        pps.Add(client.Pps.ToString());
                    }
                }
                cmbSearchResult.SelectedItem = pps.First();
            }
            else if (cmbSearch.SelectedIndex == 1)
            {
                cmbSearchResult.Items.Clear();
                foreach (Client client in Model.ClientList)
                {
                    if (!lastName.Contains(client.LastName.ToString()))
                    {
                        cmbSearchResult.Items.Add(client.LastName.ToString());
                        lastName.Add(client.LastName.ToString());
                    }
                }
                cmbSearchResult.SelectedItem = lastName.First();
            }
            else
            {
                cmbSearchResult.Items.Clear();
                foreach (Client client in Model.ClientList)
                {
                    if (!phone.Contains(client.Phone.ToString()))
                    {
                        cmbSearchResult.Items.Add(client.Phone.ToString());
                        phone.Add(client.Phone.ToString());
                    }
                }
                cmbSearchResult.SelectedItem = phone.First();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            listViewClient.Items.Clear();

            foreach (IClient client in Model.ClientList)
            {
                if (client.Pps.ToString() == cmbSearchResult.Text || client.LastName.ToString() == cmbSearchResult.Text || client.Phone.ToString() == cmbSearchResult.Text)
                {
                    string[] row = { client.Pps.ToString(), client.FirstName.ToString(), client.LastName.ToString(), client.Street.ToString(), client.County.ToString(), client.Country.ToString(), client.Phone.ToString(), client.MedicalCardHolder.ToString(), client.CardNumber.ToString(), client.NextOfKinName.ToString(), client.NextOfKinPhone.ToString() };
                    var listViewItem = new ListViewItem(row);
                    listViewClient.Items.Add(listViewItem);
                }
            }
        }

        private void txtCountry_TextChanged(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            foreach (User user in Model.UserList)
            {
                if (user.Username == lblUserName.Text)
                {
                    if (user.UserType == "Sales")
                    {
                        this.RefToDashboardAssistant.Show();
                        this.Close();
                    }
                    else
                        this.RefToDashboard.Show();
                        this.Close();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void listViewClient_DoubleClick(object sender, EventArgs e)
        {
            string str = lblUserName.Text;
            string id = listViewClient.SelectedItems[0].SubItems[0].Text;
            frmViewClientDetails viewDetails = new frmViewClientDetails(Model, id);
            viewDetails.RefToClient = this;
            this.Visible = false;
            viewDetails.Show();
            viewDetails.ShowUserName(str);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int numItemsInlist = Model.ItemList.Count;

            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
            //Start Word and create a new document.
            Word._Application oWord;
            Word._Document oDoc;
            oWord = new Word.Application();
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
            ref oMissing, ref oMissing);

            //Insert a paragraph at the beginning of the document.
            Word.Paragraph oPara1;
            //Insert table
            //Word.Table oTable;

            foreach (Client client in Model.ClientList)
            {
                char vt = (char)11;

                oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara1.Range.Text =
                    "PPS: " + client.Pps.ToString() + vt +
                    "Client First Name: " + client.FirstName.ToString() + vt +
                    "Client Last Name: " + client.LastName.ToString() + vt +
                    "Street: " + client.Street.ToString() + vt +
                    "County: " + client.County.ToString() + vt +
                    "Country: " + client.Country.ToString() + vt +
                    "Phone: " + client.Phone.ToString() + vt +
                    "Medical Card: " + client.MedicalCardHolder.ToString() + vt +
                    "Med Card Number: " + client.CardNumber.ToString() + vt +
                    "Next Of Kin Name: " + client.NextOfKinName.ToString() + vt +
                    "Next Of Kin Phone: " + client.NextOfKinPhone.ToString() + vt +
                    "GP Ref Num: " + client.GpID.ToString();
                    
                oPara1.Range.Font.Size = 10;
                oPara1.Range.Font.Name = "Arial";
                oPara1.Format.SpaceAfter = 24;    //24 pt spacing after paragraph.
                oPara1.Range.InsertParagraphAfter();
               

            }
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Client", idOfCurrentUser, "Printed");
        }

        private void txtPPS_Validating(object sender, CancelEventArgs e)
        {

        }
    }
}
#endregion