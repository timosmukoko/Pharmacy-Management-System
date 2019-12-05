using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessEntities;
using System.Windows.Forms;

namespace PharmacySystem
{
    public partial class frmViewLogsDetails : Form
    {
        private IModel Model;
        private int logId;
        public frmLog RefToLog { get; set; }
        public frmViewLogsDetails(IModel model, int id)
        {
            InitializeComponent();
            this.Model = model;
            this.logId = id;
        }

        public void ShowUserName(string username)
        {
            lblUserName.Text = username;// Show user name

        }

        private void frmViewLogsDetails_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString(); // show the durrent time
            lblDate.Text = DateTime.Now.ToShortDateString(); // show the current date
            timer1.Start(); // Start time 

            foreach (Log log in Model.LogList)
            {
                //get gp details
                if (log.LogId == logId)
                {
                    ID.Text = log.LogId.ToString();
                    date.Text = log.Date.ToString();
                    tableName.Text = log.TableName.ToString();
                    userID.Text = log.UserId.ToString();
                    action.Text = log.Action.ToString();
                    break;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.RefToLog.Show();
            this.Close();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.RefToLog.Show();
            this.Close();
        }
    }
}
