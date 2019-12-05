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
    public partial class frmTransaction : Form
    {
        private IModel Model;
        private int idOfCurrentUser;
        public frmDashboard RefToDashboard { get; set; }
        public frmTransaction(IModel model)
        {
            InitializeComponent();
            this.Model = model;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            lstTransactions.Items.Clear();
            lstTransactions.BeginUpdate();

            foreach (Transaction transaction in Model.TransactionList)
            {
                if (transaction.TransactionDate.Date >= dtSearchBegin.Value.Date&& transaction.TransactionDate.Date <= dtSearchEnd.Value.Date)
                {
                    
                    string[] row = { transaction.TransactionID.ToString(), transaction.CustomerID.ToString(), transaction.UserID.ToString(), transaction.TransactionDate.ToString(), transaction.TransactionCost.ToString(), transaction.PaymentMethod.ToString(), transaction.Tax.ToString() };
                    var listViewItem = new ListViewItem(row);
                    lstTransactions.Items.Add(listViewItem);
                }
            }

            lstTransactions.EndUpdate();
            lstTransactions.Enabled = true;
            lstTransactions.FullRowSelect = true;

            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Transaction", idOfCurrentUser, "Searched");
        }

        private void frmTransaction_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString(); // show the durrent time
            lblDate.Text = DateTime.Now.ToShortDateString(); // show the current date
            timer1.Start(); // Start time 

            lstTransactions.Items.Clear();
            lstTransactions.BeginUpdate();


            foreach (Transaction transaction in Model.TransactionList)
            {
                string[] row = { transaction.TransactionID.ToString(), transaction.CustomerID.ToString(), transaction.UserID.ToString(), transaction.TransactionDate.ToString(), transaction.TransactionCost.ToString(), transaction.PaymentMethod.ToString(), transaction.Tax.ToString()};
                var listViewItem = new ListViewItem(row);
                lstTransactions.Items.Add(listViewItem);

            }
            lstTransactions.EndUpdate();
            lstTransactions.Enabled = true;
            lstTransactions.FullRowSelect = true;
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

        private void dtSearch_ValueChanged(object sender, EventArgs e)
        {
            foreach (Transaction transaction in Model.TransactionList)
            {

            }
        }

        private void lstTransactions_DoubleClick(object sender, EventArgs e)
        {
            string str = lblUserName.Text;
            int id = Convert.ToInt16(lstTransactions.SelectedItems[0].SubItems[0].Text);
            frmViewTransactionDetails viewDetails = new frmViewTransactionDetails(Model,id);
            viewDetails.RefToTransaction = this;
            this.Visible = false;
            viewDetails.Show();
            viewDetails.ShowUserName(str);
            //if (lstTransactions.SelectedItems.Count > 0)
            //{

            //    foreach (Transaction item in Model.TransactionList)
            //    {
            //        if (Convert.ToInt16(lstTransactions.SelectedItems[0].SubItems[0].Text) == item.TransactionID)
            //        {
            //            foreach(ITransaction_has_items tItems in Model.ItemsInTransaction)
            //            {
            //                if(tItems.TransactionID==item.TransactionID)
            //                MessageBox.Show(tItems.ItemID.ToString());
            //            }
            //            break;

            //        }
            //    }
            //}
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.RefToDashboard.Show();
            this.Close();
        }

        private void lstTransactions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
