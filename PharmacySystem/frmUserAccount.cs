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
    public partial class frmUserAccount : Form
    {
        #region Instance Attributes
        IModel Model;
        private int idOfCurrentUser;
       
        public frmEmployee RefToEmployee { get; set; }
        public frmDashboard RefToDashboard { get; set; }
        //formContainer fc;
        #endregion 
        public frmUserAccount(IModel Model)
        {
            InitializeComponent();
            //MdiParent = parent;
            //fc = parent;
            this.Model = Model;
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            
            //
               
                MessageBox.Show("User Created");
                //if (Model.addNewUser(1, txtUsername.Text, txtPassword.Text,listBoxUserType.SelectedItem.ToString(), true))
                //{
                //    MessageBox.Show("User created");
                //    txtUsername.Text = "";
                //    txtPassword.Text = "";
                //}
                //else
                //    MessageBox.Show("User has not been created, try again!");
            //}
            //else
            //{
            //    MessageBox.Show("You must select a user type!");
            //    txtUsername.Text = "";
            //    txtPassword.Text = "";

            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void listUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listUser.SelectedItems.Count > 0)
            {

                foreach (User user in Model.UserList)
                {
                    if (Convert.ToInt16(listUser.SelectedItems[0].SubItems[0].Text) == user.UserID)
                    {

                        txtUserIDM.Text = user.UserID.ToString();
                        txtUsertypeM.Text = user.UserType.ToString();
                        txtUsernameM.Text = user.Username.ToString();


                    }
                }
            }
        }

        private void frmUserAccount_Load(object sender, EventArgs e)
        {
            listUser.Items.Clear();
            listUser.BeginUpdate();


            foreach (User user in Model.UserList)
            {
                string[] row = { user.UserID.ToString() };
                var listViewItem = new ListViewItem(row);
                listUser.Items.Add(listViewItem);

            }
            listUser.EndUpdate();
            listUser.Enabled = true;
            listUser.FullRowSelect = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = listUser.FocusedItem.Index;


            if (MessageBox.Show("Delete", "Are you sure !", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            foreach (User user in Model.UserList)
            {

                if (Convert.ToInt16(listUser.SelectedItems[0].SubItems[0].Text) == user.UserID)
                {
                    Model.deleteUser(user);
                    listUser.Items.RemoveAt(index); //remove name from listbox
                    break;
                }


            }
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Account", idOfCurrentUser, "Deleted");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Account", idOfCurrentUser, "Searched");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            
                this.RefToEmployee.Show();
                this.Close();
            
        }
    }
}
