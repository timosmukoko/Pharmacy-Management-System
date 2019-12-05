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
    public partial class frmViewTransactionDetails : Form
    {
        private IModel Model;
        private int transactionID;
        public frmTransaction RefToTransaction { get; set; }
        public frmViewTransactionDetails(IModel model, int id)
        {
            InitializeComponent();
            this.Model = model;
            this.transactionID = id;
        }

        private void frmViewTransactionDetails_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString(); // show the durrent time
            lblDate.Text = DateTime.Now.ToShortDateString(); // show the current date
            timer1.Start(); // Start time 

            foreach (Transaction transaction in Model.TransactionList)
            {
                //get transaction details
                if (transaction.TransactionID == transactionID)
                {
                    lblTransactionID.Text = transaction.TransactionID.ToString();
                    lblEmployee.Text = transaction.UserID.ToString();
                    lblCustomerID.Text = transaction.CustomerID.ToString();
                    lblDateOfTransaction.Text = transaction.TransactionDate.ToString();
                    lblTotal.Text = transaction.TransactionCost.ToString();
                    lblPaymentMethod.Text = transaction.PaymentMethod.ToString();
                    lblTax.Text = transaction.Tax.ToString();
                    break;
                }
            }

            //get the items from the above transaction
            lstTransactionDetails.Items.Clear();
            lstTransactionDetails.BeginUpdate();

            foreach (Transaction_has_items items in Model.ItemsInTransaction)
            {
                foreach (Item item in Model.ItemList)
                {
                    if (items.ItemID==item.ItemID&& items.TransactionID==transactionID)
                    {
                        string[] row = { item.ItemName.ToString(), item.Quantity.ToString(), item.Category.ToString()};
                        var listViewItem = new ListViewItem(row);
                        lstTransactionDetails.Items.Add(listViewItem);
                        
                    }
                }
            }
            lstTransactionDetails.EndUpdate();
           
        }

        public void ShowUserName(string username)
        {
            lblUserName.Text = username;// Show user name
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.RefToTransaction.Show();
            this.Close();
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            this.RefToTransaction.Show();
            this.Close();
        }
    }
}
