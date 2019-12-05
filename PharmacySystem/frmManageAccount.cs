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
    public partial class frmManageAccount : Form
    {
        #region Instance Attributes
        private IModel Model;
        private int idOfCurrentUser;
        public frmDashboard RefToDashboard { get; set; }
        #endregion
        public frmManageAccount(IModel model)
        {
            InitializeComponent();
            this.Model = model;
        }

        private void frmManageAccount_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString(); // show the durrent time
            lblDate.Text = DateTime.Now.ToLongDateString(); // show the current date
            timer1.Start(); // Start time 

            //load users info into textboxes


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

                }
            }
            lblUserName.Text = username;// Show user name
            foreach(Employee employee in Model.EmployeeList)
            {
                if (employee.FirstName.ToString() == username)
                {
                  
                    txtAddress.Text = employee.Address.ToString();
                    txtEmail.Text = employee.Email.ToString();
                    txtPhone.Text = employee.Phone.ToString();
                    txtNextOfKinName.Text = employee.NextOfKinName.ToString();
                    txtNextOfKinPhone.Text = employee.NextOfKinPhone.ToString();

                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Update", "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (Employee employee in Model.EmployeeList)
                {
                    if (employee.FirstName.ToString() == lblUserName.Text)
                    {
                        
                        employee.Address = txtAddress.Text;
                        employee.Email = txtEmail.Text;
                        employee.Phone=txtPhone.Text;
                        employee.NextOfKinName = txtNextOfKinName.Text;
                        employee.NextOfKinPhone=txtNextOfKinPhone.Text;
                        Model.editEmployee(employee);

                    }
                }
            }
        }

        private void buttonViewRoster_Click(object sender, EventArgs e)
        {
            string usertype = Model.getUserTypeForCurrentuser();
            string username = Model.getUserNameForCurrentuser();
            frmViewRoster roster = new frmViewRoster(Model);
            //report.RefToDashboard = this;
            //this.Visible = false;
            roster.Show();
            roster.ShowUserName(usertype, username);
        }
    }
}
