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
    public partial class frmLogin : Form
    {

        #region Instance Attributes
        private IModel Model;
        private int idOfCurrentUser;
        #endregion

        #region Instance Properties

        #endregion

        #region Constructors

        public frmLogin(IModel Model)
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
            this.Model = Model;
        }
        #endregion
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                bool validUser = Model.login(txtUsername.Text, txtPassword.Text);
                if (validUser)
                {
                    string username = Model.getUserNameForCurrentuser();
                    string usertype = Model.getUserTypeForCurrentuser();
                    if (usertype == "Sales")
                    {
                        frmDashboardAssistantView dashboardSales = new frmDashboardAssistantView(Model);
                        dashboardSales.RefToLogin = this;
                        this.Visible = false;
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        dashboardSales.Show(); // show dashboard
                        dashboardSales.ShowUserName(usertype, username);//call ShowUserName method
                       
                    }
                    else
                    {
                        frmDashboard dashboard = new frmDashboard(Model);
                        dashboard.RefToLogin = this;
                        this.Visible = false;
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        dashboard.Show(); // show dashboard
                        dashboard.ShowUserName(usertype, username);//call ShowUserName method
                        
                    }
                    //frmDashboard dashboard = new frmDashboard(Model);//create a dashboard object

                    
                    
                    
                }
                else
                    MessageBox.Show("It appears your UserName or Password is incorrect! Please try again!", "PHARMACY MANAGEMENT SYSTEM - Login Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("It appears your UserName or Password is incorrect! Please try again!", "PHARMACY MANAGEMENT SYSTEM - Login Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Login", idOfCurrentUser, "Logged in");

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            frmResetUserPsw reset = new frmResetUserPsw(Model);
            reset.Show();
        }

        private void linkForgotPsw_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmResetUserPsw reset = new frmResetUserPsw(Model);
            reset.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you wish to close the MedEx Pharmacy management system?", "Important Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }
    }
}
