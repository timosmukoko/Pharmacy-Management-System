//Author Lee

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
    public partial class frmGP : Form
    {

        #region Instance Attributes
        private IModel Model;
        private int idOfCurrentUser;
        public frmDashboard RefToDashboard { get; set; }
        public frmDashboardAssistantView RefToDashboardAssistant { get; set; }
        #endregion
        #region Constructors
        public frmGP(IModel model)
        {
            InitializeComponent();
            this.Model = model;
            
            foreach (Gp gp in Model.GpList)
            {
                string[] row = { gp.GpID.ToString(), gp.FirstName.ToString(), gp.LastName.ToString(), gp.Address.ToString(), gp.Phone.ToString(), gp.Email.ToString() };
                var listViewItem = new ListViewItem(row);
                listGps.Items.Add(listViewItem);
            }
            listGps.Enabled = true;
            listGps.FullRowSelect = true;
        }
        #endregion

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Model.addNewGp(Convert.ToInt32(textID.Text), textFirstName.Text, textLastName.Text, textAddress.Text, textPhone.Text, textEmail.Text);
            cleartextFieldAndLoad();
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "GP", idOfCurrentUser, "Added");
        }

        private void cleartextFieldAndLoad()
        {          
            textID.Text = "";
            textFirstName.Text = "";
            textLastName.Text = "";
            textAddress.Text = "";
            textPhone.Text = "";
            textEmail.Text = "";

            listGps.Items.Clear();

            foreach (Gp gp in Model.GpList)
            {
                string[] row = { gp.GpID.ToString(), gp.FirstName.ToString(), gp.LastName.ToString(), gp.Address.ToString(), gp.Phone.ToString(), gp.Email.ToString() };
                var listViewItem = new ListViewItem(row);
                listGps.Items.Add(listViewItem);
            }
            listGps.Enabled = true;
            listGps.FullRowSelect = true;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int index = listGps.FocusedItem.Index;

            if (MessageBox.Show("Delete", "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            foreach (Gp gp in Model.GpList)
            {
                if (Convert.ToInt16(listGps.SelectedItems[0].SubItems[0].Text) == gp.GpID)
                {
                    Model.deleteGp(gp);
                    listGps.Items.RemoveAt(index); //remove name from listbox
                    break;
                }
            }

            textID.Text = "";
            textFirstName.Text = "";
            textLastName.Text = "";
            textAddress.Text = "";
            textEmail.Text = "";
            textPhone.Text = "";

            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "GP", idOfCurrentUser, "Deleted");
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Update", "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (Gp gp in Model.GpList)
                {
                    if (Convert.ToInt16(listGps.SelectedItems[0].SubItems[0].Text) == gp.GpID)
                    {
                        gp.GpID = Convert.ToInt32(textID.Text);
                        gp.FirstName = textFirstName.Text;
                        gp.LastName = textLastName.Text;
                        gp.Address = textAddress.Text;
                        gp.Phone = textPhone.Text;
                        gp.Email = textEmail.Text;

                        Model.editGp(gp);
                    }
                }
                listGps.Items.Clear();
                foreach (Gp gp in Model.GpList)
                {
                    string[] row = { gp.GpID.ToString(), gp.FirstName.ToString(), gp.LastName.ToString(), gp.Address.ToString(), gp.Phone.ToString(), gp.Email.ToString() };
                    var listViewItem = new ListViewItem(row);
                    listGps.Items.Add(listViewItem);
                }

                textID.Text = "";
                textFirstName.Text = "";
                textLastName.Text = "";
                textAddress.Text = "";
                textEmail.Text = "";
                textPhone.Text = "";       
            }

            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "GP", idOfCurrentUser, "Updated");
        }


        public void ShowUserName(string usertype, string username)
        {

            foreach (User user in Model.UserList)
            {
                if (user.UserType == usertype && user.Username == username)
                {
                    idOfCurrentUser = user.UserID;
                    lblUserName.Text = username;
                }
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            int numGpsInlist = Model.GpList.Count;

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
            Word.Table oTable;

            foreach (Gp gp in Model.GpList)
            {
                char vt = (char)11;

                oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara1.Range.Text =
                    "Gp ID: " + gp.GpID.ToString() + vt +
                    "Gp First Name: " + gp.FirstName.ToString() + vt +
                    "Gp Last Name: " + gp.LastName.ToString() + vt +
                    "Gp Address: " + gp.Address.ToString() + vt +
                    "Gp Phone: " + gp.Phone.ToString() + vt +
                    "Gp Email: " + gp.Email.ToString();
                oPara1.Range.Font.Bold = 1;
                oPara1.Format.SpaceAfter = 24;    //24 pt spacing after paragraph.
                oPara1.Range.InsertParagraphAfter();

                //Close this form.
               
            }

            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "GP", idOfCurrentUser, "Printed");
        }

        private void buttonExit_Click(object sender, EventArgs e)
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

       private void buttonSearch_Click(object sender, EventArgs e)
        {
            listGps.Items.Clear();
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "GP", idOfCurrentUser, "Searched");

            foreach (Gp gp in Model.GpList)
               {
                   if (gp.GpID.ToString() == comboResults.Text || (gp.FirstName.ToString() + " " + gp.LastName.ToString()) == comboResults.Text)
                    {
                         string[] row = { gp.GpID.ToString(), gp.FirstName.ToString(), gp.LastName.ToString(), gp.Address.ToString(), gp.Phone.ToString(), gp.Email.ToString() };
                         var listViewItem = new ListViewItem(row);
                         listGps.Items.Add(listViewItem);
                    }
               }
        }

        private void comboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> gpID = new List<string>();
            List<String> gpName = new List<string>();

            if (comboSearch.SelectedIndex == 0)
            {
                comboResults.Items.Clear();
                foreach (Gp gp in Model.GpList)
                {
                    if (!gpID.Contains(gp.GpID.ToString()))
                    {
                        comboResults.Items.Add(gp.GpID.ToString());
                        gpID.Add(gp.GpID.ToString());
                    }
                }
                comboResults.SelectedItem = gpID.First();
            }
            else 
            {
                comboResults.Items.Clear();
                foreach (Gp gp in Model.GpList)
                {
                    if (!gpName.Contains(gp.FirstName.ToString() + " " + gp.LastName.ToString()))
                    {
                        comboResults.Items.Add(gp.FirstName.ToString() + " " + gp.LastName.ToString());
                        gpName.Add(gp.FirstName.ToString() + " " + gp.LastName.ToString());
                    }
                }
                comboResults.SelectedItem = gpName.First();
            }
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            listGps.Items.Clear();

            foreach (Gp gp in Model.GpList)
            {
                string[] row = { gp.GpID.ToString(), gp.FirstName.ToString(), gp.LastName.ToString(), gp.Address.ToString(), gp.Phone.ToString(), gp.Email.ToString() };
                var listViewItem = new ListViewItem(row);
                listGps.Items.Add(listViewItem);
            }
            listGps.Enabled = true;
            listGps.FullRowSelect = true;
        }

        private void frmGP_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToShortDateString(); // show the durrent time
            label4.Text = DateTime.Now.ToLongTimeString(); // show the current date
            timer1.Start(); // Start time 
        }

        private void listGps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listGps.SelectedItems.Count > 0)
            {
                foreach (Gp gp in Model.GpList)
                {
                    if (Convert.ToInt16(listGps.SelectedItems[0].SubItems[0].Text) == gp.GpID)
                    {
                        textID.Text = gp.GpID.ToString();
                        textFirstName.Text = gp.FirstName;
                        textLastName.Text = gp.LastName;
                        textAddress.Text = gp.Address;
                        textPhone.Text = gp.Phone;
                        textEmail.Text = gp.Email;
                    }
                }
            }
        }


        private void listGps_DoubleClick(object sender, EventArgs e)
        {
            string str = lblUserName.Text;
            int id = Convert.ToInt16(listGps.SelectedItems[0].SubItems[0].Text);
            frmViewGpDetails viewDetails = new frmViewGpDetails(Model, id);
            viewDetails.RefToGP = this;
            this.Visible = false;
            viewDetails.Show();
            viewDetails.ShowUserName(str);
            //if (lstTransactions.SelectedItems.Count > 0)
            //{

            //    foreach (Transaction item in Model.TransactionList)
            //    {
            //        if (Convert.ToInt16(lstTransactions.SelectedItems[0].SubItems[0].Text) == item.TransactionID)
            //        {
            //            foreach(ITransaction_has_items tItems in Model.ItemsInTransaction)
            //            {
            //                if(tItems.TransactionID==item.TransactionID)
            //                MessageBox.Show(tItems.ItemID.ToString());
            //            }
            //            break;

            //        }
            //    }
            //}
        }
        private void comboResults_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
