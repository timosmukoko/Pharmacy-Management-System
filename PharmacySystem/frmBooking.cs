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
    public partial class frmBooking : Form
    {
        #region Instance Attributes
        //private formContainer fc;
        private IModel Model;
        private int idOfCurrentUser;
        public frmDashboard RefToDashboard { get; set; }
        public frmDashboardAssistantView RefToDashboardAssistant { get; set; }
        #endregion
        public frmBooking(IModel model)
        {
            InitializeComponent();
            this.Model = model;
            dateTimePicker2.CustomFormat = "HH:mm";
        }

        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void frmBooking_Load(object sender, EventArgs e)
        {
            string[] row = { "12321", "Lorcan", "O Toole", "087 2323222", "BMI Test", "12/12/2012", "12:00" };
            var listViewItem = new ListViewItem(row);
            listView6.Items.Add(listViewItem);
            string[] row1 = { "12324", "Mary", "O Mahony", "084 323332", "Consultation", "12/11/2012", "15:00" };
            var listViewItem1 = new ListViewItem(row1);
            listView6.Items.Add(listViewItem1);
            string[] row2 = { "12329", "Paul", "Kennedy", "085 657543", "Fitness Test", "12/12/2012", "17:00" };
            var listViewItem2 = new ListViewItem(row2);
            listView6.Items.Add(listViewItem2);

            lblTime.Text = DateTime.Now.ToLongTimeString(); // show the durrent time
            lblDate.Text = DateTime.Now.ToShortDateString(); // show the current date
            timer1.Start(); // Start time  
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Booking", idOfCurrentUser, "Created");
            string[] row = { "12325", textBox2.Text, textBox3.Text, textBox1.Text, comboBox1.GetItemText(comboBox1.SelectedItem), dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToString() };
            var listViewItem = new ListViewItem(row);
            listView6.Items.Add(listViewItem);
        }

        private void listView6_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listView6.SelectedItems.Count > 0)
            {
                ListViewItem itm = listView6.SelectedItems[0];
                textBox2.Text = itm.SubItems[1].Text;
                textBox3.Text = itm.SubItems[2].Text;
                textBox1.Text = itm.SubItems[3].Text;
                comboBox1.SelectedItem = itm.SubItems[4].Text;
                dateTimePicker1.Value = Convert.ToDateTime(itm.SubItems[5].Text);
                dateTimePicker2.Value = Convert.ToDateTime(itm.SubItems[6].Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int index = listView6.FocusedItem.Index;
            DateTime timeNow = DateTime.Now;
            listView6.Items.RemoveAt(index);
            string[] row = { "12325", textBox2.Text, textBox3.Text, textBox1.Text, comboBox1.GetItemText(comboBox1.SelectedItem), dateTimePicker1.Value.ToShortDateString(), dateTimePicker1.Value.ToShortDateString() };
            var listViewItem = new ListViewItem(row);
            Model.addNewLog(timeNow, "Booking", idOfCurrentUser, "Updated");
            listView6.Items.Add(listViewItem);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            int index = listView6.FocusedItem.Index;
            MessageBox.Show(index.ToString());
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Booking", idOfCurrentUser, "Deleted");
            listView6.Items.RemoveAt(index);

        }

        private void button18_Click(object sender, EventArgs e)
        {
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Booking", idOfCurrentUser, "Searched");
            string search = comboBox2.GetItemText(comboBox2.SelectedItem);
            if (search == "Booking ID")
            {
                foreach (ListViewItem item in listView6.Items)
                {
                    if (item.SubItems[0].Text == search)
                    {
                        this.listView6.Items[2].Selected = true;
                    }
                }
            }
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
                    lblUserName.Text = username;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Booking", idOfCurrentUser, "Printed");
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

        private void btnLogOut_Click(object sender, EventArgs e)
        {

        }

        private void listView6_DoubleClick(object sender, EventArgs e)
        {
            string str = lblUserName.Text;
            int id = Convert.ToInt16(listView6.SelectedItems[0].SubItems[0].Text);
            frmViewBookingDetails viewDetails = new frmViewBookingDetails(Model, id);
            viewDetails.Show();
            //viewDetails.ShowUserName(str);
        }
    }
}
    
    
    

