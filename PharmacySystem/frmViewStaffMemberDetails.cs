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
    public partial class frmViewStaffMemberDetails : Form
    {
        private IModel Model;
        private int empID;
        private int idOfCurrentUser;
        public frmEmployee RefToStaffMember { get; set; }
        public frmViewStaffMemberDetails(IModel model, int id, string name)
        {
            InitializeComponent();
            this.Model = model;
            this.empID = id;
            lblUserName.Text = name;
        }

        private void frmViewStaffMemberDetails_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString(); // show the durrent time
            lblDate.Text = DateTime.Now.ToShortDateString(); // show the current date
            timer1.Start(); // Start time 

            foreach (Employee emp in Model.EmployeeList)
            {
                //get employee details
                if (emp.EmployeeID == empID)
                {
                    txtEmpID.Text = emp.EmployeeID.ToString();
                    txtFirst.Text = emp.FirstName.ToString();
                    txtLast.Text = emp.LastName.ToString();
                    txtAddress.Text = emp.Address.ToString();
                    txtEmail.Text = emp.Email.ToString();
                    txtPhone.Text = emp.Phone.ToString();
                    txtNokName.Text = emp.NextOfKinName.ToString();
                    txtNokPhone.Text = emp.NextOfKinPhone.ToString();
                    txtSalery.Text = emp.Salery.ToString();
                    break;
                }
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.RefToStaffMember.Show();
            this.Close();
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

        }
    }
}
