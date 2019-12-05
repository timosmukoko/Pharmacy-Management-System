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
    public partial class frmViewRoster : Form
    {
        #region Instance Attributes
        private IModel Model;
        private int idOfCurrentUser;
        public frmDashboard RefToDashboard { get; set; }
        #endregion
        #region Constructors
        public frmViewRoster(IModel Model)
        {
            InitializeComponent();
            this.Model = Model;
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void ShowUserName(string usertype, string username)
        {

            foreach (User user in Model.UserList)
            {
                if (user.UserType == usertype && user.Username == username)
                {
                    idOfCurrentUser = user.UserID;
                    lblUserName.Text = username.ToString();// Show user name
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            lstMonday.Items.Clear();
            lstTuesday.Items.Clear();
            lstWednesday.Items.Clear();
            lstThursday.Items.Clear();
            lstFriday.Items.Clear();
            lstSaturday.Items.Clear();
            lstSunday.Items.Clear();



            foreach (Roster roster in Model.RosterList)
            {
                if (roster.Name.ToString() == lblUserName.Text)
                {
                    if (roster.WeekNumber.ToString() == cmboWeekNum.Text)
                    {
                        if (roster.Day.ToString() == "Monday")
                        {
                            lstMonday.Items.Add(roster.Name.ToString());
                        }
                        else if (roster.Day.ToString() == "Tuesday")
                        {
                            lstTuesday.Items.Add(roster.Name.ToString());
                        }
                        else if (roster.Day.ToString() == "Wednesday")
                        {
                            lstWednesday.Items.Add(roster.Name.ToString());
                        }
                        else if (roster.Day.ToString() == "Thursday")
                        {
                            lstThursday.Items.Add(roster.Name.ToString());
                        }
                        else if (roster.Day.ToString() == "Friday")
                        {
                            lstFriday.Items.Add(roster.Name.ToString());
                        }
                        else if (roster.Day.ToString() == "Saturday")
                        {
                            lstSaturday.Items.Add(roster.Name.ToString());
                        }
                        else if (roster.Day.ToString() == "Sunday")
                        {
                            lstSunday.Items.Add(roster.Name.ToString());
                        }
                    }
                }


            }
        }

    }
}