//Timos Mukoko
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
    public partial class frmResetUserPsw : Form
    {
        #region Instance Attributes
        IModel Model;
        //formContainer fc;
        #endregion 

        public frmResetUserPsw(IModel Model)
        {
            InitializeComponent();
            this.Model = Model;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult reset;
            reset = MessageBox.Show(" would you like to reset your password !" +
                "\r" + " Continue? ", " RESET PASSSWORD",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (txtNewPsw.Text == txtRePsw.Text)
            {
                if (reset == DialogResult.Yes)
                {
                    foreach (IUser user in Model.UserList)
                    {
                        if (txtUserName.Text == user.Username)
                        {
                            user.Password = txtNewPsw.Text;
                            Model.editUser(user);
                        }
                    }
                    this.Close();
                    frmLogin login = new frmLogin(Model);
                    login.Show();
                    MessageBox.Show(" Your password is successfully changed !", " PHARMACY MANAGEMENT SYSTEM ");
                }
            }
            else
                MessageBox.Show("Password does not match !", " PHARMACY MANAGEMENT SYSTEM ");
                txtUserName.Text = "";
                txtNewPsw.Text = "";
                txtRePsw.Text = "";
                txtUserName.Focus();

        }

        private void frmResetUserPsw_Load(object sender, EventArgs e)
        {

        }
    }
}
