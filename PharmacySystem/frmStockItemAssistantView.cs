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
    public partial class frmStockItemAssistantView : Form
    {
        #region Instance Attributes
        private IModel Model;
        private int idOfCurrentUser;
        public frmDashboardAssistantView RefToDashboardAssistant { get; set; }

        #endregion
        public frmStockItemAssistantView(IModel model)
        {
            InitializeComponent();
            this.Model = model;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.RefToDashboardAssistant.Show();
            this.Close();
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

        private void frmStockItemAssistantView_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString(); // show the durrent time
            lblDate.Text = DateTime.Now.ToLongDateString(); // show the current date
            timer1.Start(); // Start time 

            listOrders.Items.Clear();
            listOrders.BeginUpdate();


            foreach (Item item in Model.ItemList)
            {
                if (item.IsDeleted.ToString() == "NO")
                {
                    string[] row = { item.ItemID.ToString(), item.Category.ToString(), item.Vendor.ToString(), item.Quantity.ToString(), item.PurchaseUnit.ToString(), item.ItemName.ToString() };
                    var listViewItem = new ListViewItem(row);
                    listOrders.Items.Add(listViewItem);
                }
            }

            listOrders.EndUpdate();
            listOrders.Enabled = true;
            listOrders.FullRowSelect = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            listOrders.Items.Clear();

            foreach (Item item in Model.ItemList)
            {
                if (item.Category.ToString() == comboResults.Text || item.ItemName.ToString() == comboResults.Text || item.Vendor.ToString() == comboResults.Text && item.IsDeleted == "NO")
                {
                    string[] row = { item.ItemID.ToString(), item.Category.ToString(), item.Vendor.ToString(), item.Quantity.ToString(), item.PurchaseUnit.ToString(), item.ItemName.ToString() };
                    var listViewItem = new ListViewItem(row);
                    listOrders.Items.Add(listViewItem);
                }
            }
        }

        private void comboStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> vendors = new List<string>();
            List<String> itemName = new List<string>();
            List<String> category = new List<string>();

            if (comboStock.SelectedIndex == 0)
            {
                comboResults.Items.Clear();
                foreach (Item item in Model.ItemList)
                {
                    if (!category.Contains(item.Category.ToString()))
                    {
                        comboResults.Items.Add(item.Category.ToString());
                        category.Add(item.Category.ToString());
                    }
                }
                comboResults.SelectedItem = category.First();
            }
            else if (comboStock.SelectedIndex == 1)
            {
                comboResults.Items.Clear();
                foreach (Item item in Model.ItemList)
                {
                    if (!vendors.Contains(item.Vendor.ToString()))
                    {
                        comboResults.Items.Add(item.Vendor.ToString());
                        vendors.Add(item.Vendor.ToString());
                    }
                }
                comboResults.SelectedItem = vendors.First();
            }
            else
            {
                comboResults.Items.Clear();
                foreach (Item item in Model.ItemList)
                {
                    if (!itemName.Contains(item.ItemName.ToString()))
                    {
                        comboResults.Items.Add(item.ItemName.ToString());
                        itemName.Add(item.ItemName.ToString());
                    }
                }
                comboResults.SelectedItem = itemName.First();
            }
        }
    }
}
