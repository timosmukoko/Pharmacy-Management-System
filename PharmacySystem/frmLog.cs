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
    public partial class frmLog : Form
    {
        private IModel Model;
        public frmDashboard RefToDashboard { get; set; }
        private int idOfCurrentUser;
        public frmLog(IModel model)
        {
            InitializeComponent();
            this.Model = model;
        }

        private void frmLog_Load(object sender, EventArgs e)
        {
            lstLogs.Items.Clear();
            lstLogs.BeginUpdate();


            foreach (Log log in Model.LogList)
            {
                string[] row = { log.LogId.ToString(), log.Date.ToString(), log.TableName.ToString(), log.UserId.ToString(), log.Action.ToString() };
                var listViewItem = new ListViewItem(row);
                lstLogs.Items.Add(listViewItem);

            }
            lstLogs.EndUpdate();
            lstLogs.Enabled = true;
            lstLogs.FullRowSelect = true;
            lblDate.Text = DateTime.Now.ToShortDateString(); // show the durrent time
            lblTime.Text = DateTime.Now.ToLongTimeString(); // show the current date
            timer1.Start(); // Start time 
        }

        private void button18_Click(object sender, EventArgs e)
        {
            lstLogs.Items.Clear();
            lstLogs.BeginUpdate();

            foreach (Log log in Model.LogList)
            {
                if (log.Date.Date >= dtSearchBegin.Value.Date && log.Date.Date <= dtSearchEnd.Value.Date)
                {

                    string[] row = { log.LogId.ToString(), log.Date.ToString(), log.TableName.ToString(), log.UserId.ToString(), log.Action.ToString() };
                    var listViewItem = new ListViewItem(row);
                    lstLogs.Items.Add(listViewItem);
                }
            }

            lstLogs.EndUpdate();
            lstLogs.Enabled = true;
            lstLogs.FullRowSelect = true;
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Events", idOfCurrentUser, "Searched");
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
                    lblUserName.Text = username;
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.RefToDashboard.Show();
            this.Close();
        }

        private void lstLogs_DoubleClick(object sender, EventArgs e)
        {
            string str = lblUserName.Text;
            int id = Convert.ToInt16(lstLogs.SelectedItems[0].SubItems[0].Text);
            frmViewLogsDetails viewDetails = new frmViewLogsDetails(Model, id);
            viewDetails.RefToLog = this;
            this.Visible = false;
            viewDetails.Show();
            viewDetails.ShowUserName(str);
        }
    }
}
