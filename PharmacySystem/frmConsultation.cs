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
    public partial class frmConsultation : Form
    {
        #region Instance Attributes
        private IModel Model;
        private int idOfCurrentUser;
        public frmDashboard RefToDashboard { get; set; }
        #endregion
        #region Constructors
        public frmConsultation(IModel model, string name)
        {
            InitializeComponent();
            this.Model = model;
            lblUserName.Text = name;
            

            foreach (Consultation con in Model.ConList)
            {
                string[] row = { con.ConID.ToString(), con.FirstName.ToString(), con.LastName.ToString(), con.Date.ToString(), con.Time.ToString(), con.Address.ToString() };
                var listViewItem = new ListViewItem(row);
                listCon.Items.Add(listViewItem);
            }
            listCon.Enabled = true;
            listCon.FullRowSelect = true;
        }
        #endregion

        private void frmConsultation_Load(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToLongTimeString(); // show the durrent time
            label3.Text = DateTime.Now.ToShortDateString(); // show the current date
            timer1.Start(); // Start time 
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Comsultation", idOfCurrentUser, "Deleted");
            int index = listCon.FocusedItem.Index;

            if (MessageBox.Show("Delete", "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            foreach (Consultation cons in Model.ConList)
            {
                if (Convert.ToInt16(listCon.SelectedItems[0].SubItems[0].Text) == cons.ConID)
                {
                    Model.deleteCon(cons);
                    listCon.Items.RemoveAt(index); //remove name from listbox
                    break;
                }
            }

            textConID.Text = "";
            textFirstName.Text = "";
            textLastName.Text = "";
            textPhone.Text = "";
            textDOB.Text = "";
            textAddress.Text = "";
            textSymptoms.Text = "";
            textDate.Text = "";
            comboTime.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {

            Model.addNewCon(Convert.ToInt32(textConID.Text), textFirstName.Text, textLastName.Text, textPhone.Text, textDOB.Text, textAddress.Text, textSymptoms.Text, textDate.Text, comboTime.Text);
            cleartextFieldAndLoad();
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Consultation", idOfCurrentUser, "Added");
        }

        private void cleartextFieldAndLoad()
        {
            textConID.Text = "";
            textFirstName.Text = "";
            textLastName.Text = "";
            textPhone.Text = "";
            textDOB.Text = "";
            textAddress.Text = "";
            textSymptoms.Text = "";
            textDate.Text = "";
            comboTime.Text = "";

            listCon.Items.Clear();

            foreach (Consultation con in Model.ConList)
            {
                string[] row = {con.ConID.ToString(), con.FirstName.ToString(), con.LastName.ToString(), con.Date.ToString(), con.Time.ToString(), con.Address.ToString() };
                var listViewItem = new ListViewItem(row);
                listCon.Items.Add(listViewItem);
            }
            listCon.Enabled = true;
            listCon.FullRowSelect = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Update", "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (Consultation con in Model.ConList)
                {
                    if (Convert.ToInt16(listCon.SelectedItems[0].SubItems[0].Text) == con.ConID)
                    {
                        con.ConID = Convert.ToInt32(textConID.Text);
                        con.FirstName = textFirstName.Text;
                        con.LastName = textLastName.Text;
                        con.Phone = textAddress.Text;
                        con.DOB = textPhone.Text;
                        con.Address = textAddress.Text;
                        con.Symptoms = textSymptoms.Text;
                        con.Date = textDate.Text;
                        con.Time = comboTime.Text;

                        Model.editCon(con);
                    }
                }
                listCon.Items.Clear();

                foreach (Consultation con in Model.ConList)
                {
                    string[] row = { con.ConID.ToString(), con.FirstName.ToString(), con.LastName.ToString(), con.Date.ToString(), con.Time.ToString(), con.Address.ToString() };
                    var listViewItem = new ListViewItem(row);
                    listCon.Items.Add(listViewItem);
                }

                textConID.Text = "";
                textFirstName.Text = "";
                textLastName.Text = "";
                textPhone.Text = "";
                textDOB.Text = "";
                textAddress.Text = "";
                textSymptoms.Text = "";
                textDate.Text = "";
                comboTime.Text = "";
            }

            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Consultation", idOfCurrentUser, "Updated");

        }
    

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void listCon_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void listCon_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listCon.SelectedItems.Count > 0)
            {
                foreach (Consultation con in Model.ConList)
                {
                    if (Convert.ToInt16(listCon.SelectedItems[0].SubItems[0].Text) == con.ConID)
                    {
                        textConID.Text = con.ConID.ToString();
                        textFirstName.Text = con.FirstName;
                        textLastName.Text = con.LastName;
                        textPhone.Text = con.Phone;
                        textDOB.Text = con.DOB;
                        textAddress.Text = con.Address;
                        textSymptoms.Text = con.Symptoms;
                        textDate.Text = con.Date;
                        comboTime.Text = con.Time;
                    }
                }
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            int numConsInlist = Model.ConList.Count;

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

            foreach (Consultation con in Model.ConList)
            {
                char vt = (char)11;

                oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara1.Range.Text =
                    "Consultation ID: " + con.ConID.ToString() + vt +
                    "First Name: " + con.FirstName.ToString() + vt +
                    "Last Name: " + con.LastName.ToString() + vt +
                    "Phone: " + con.Phone.ToString() + vt +
                    "DOB: " + con.DOB.ToString() + vt +
                    "Address: " + con.Address.ToString() + vt +
                    "Symptoms: " + con.Symptoms.ToString() + vt +
                    "Date: " + con.Date.ToString() + vt +
                    "Time: " + con.Time.ToString();
                oPara1.Range.Font.Bold = 1;
                oPara1.Format.SpaceAfter = 24;    //24 pt spacing after paragraph.
                oPara1.Range.InsertParagraphAfter();

                //Close this form.
               
            }

            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Consultation", idOfCurrentUser, "Printed");
        }

        private void comboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> conID = new List<string>();
            List<String> Name = new List<string>();

            if (comboSearch.SelectedIndex == 0)
            {
                comboResults.Items.Clear();
                foreach (Consultation con in Model.ConList)
                {
                    if (!conID.Contains(con.ConID.ToString()))
                    {
                        comboResults.Items.Add(con.ConID.ToString());
                        conID.Add(con.ConID.ToString());
                    }
                }
                comboResults.SelectedItem = conID.First();
            }
            else
            {
                comboResults.Items.Clear();
                foreach (Consultation con in Model.ConList)
                {
                    if (!Name.Contains(con.FirstName.ToString() + " " + con.LastName.ToString()))
                    {
                        comboResults.Items.Add(con.FirstName.ToString() + " " + con.LastName.ToString());
                        Name.Add(con.FirstName.ToString() + " " + con.LastName.ToString());
                    }
                }
                comboResults.SelectedItem = Name.First();
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            listCon.Items.Clear();
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Consultaions", idOfCurrentUser, "Searched");

            foreach (Consultation con in Model.ConList)
            {
                if (con.ConID.ToString() == comboResults.Text || (con.FirstName.ToString() + " " + con.LastName.ToString()) == comboResults.Text)
                {
                    string[] row = { con.ConID.ToString(), con.FirstName.ToString(), con.LastName.ToString(), con.Date.ToString(), con.Time.ToString(), con.Address.ToString() };
                    var listViewItem = new ListViewItem(row);
                    listCon.Items.Add(listViewItem);
                }
            }
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            listCon.Items.Clear();

            foreach (Consultation con in Model.ConList)
            {
                string[] row = { con.ConID.ToString(), con.FirstName.ToString(), con.LastName.ToString(), con.Date.ToString(), con.Time.ToString(), con.Address.ToString() };
                var listViewItem = new ListViewItem(row);
                listCon.Items.Add(listViewItem);
            }
            listCon.Enabled = true;
            listCon.FullRowSelect = true;

            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Consultation", idOfCurrentUser, "Viewed All");
        }

        private void textConID_TextChanged(object sender, EventArgs e)
        {

        }

        private void listCon_DoubleClick(object sender, EventArgs e)
        {
            string str = lblUserName.Text;
            int ID = Convert.ToInt32(listCon.SelectedItems[0].SubItems[0].Text);
            FrmViewConsultation viewDetails = new FrmViewConsultation(Model, ID);
            viewDetails.RefToConsultation = this;
            this.Visible = false;
            viewDetails.Show();
            viewDetails.ShowUserName(str);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToLongTimeString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.RefToDashboard.Show();
            this.Close();
        }
    }
}
