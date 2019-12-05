using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using BusinessLayer;
using BusinessEntities;

namespace PharmacySystem
{
    public partial class frmStockOrder : Form
    {
        #region Instance Attributes
        IModel model;
        private int idOfCurrentUser;
        public frmStockItem RefToStock { get; set; }
        #endregion
        #region Constructors

        public frmStockOrder(IModel Model)

        {
            model = Model;
            InitializeComponent();
        }
        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            textBox6.Text = "Select Category...";
            textBox2.Text = "";
            textBox1.Text = "";
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            DateTime timeNow = DateTime.Now;
            model.addNewLog(timeNow, "Stock Order", idOfCurrentUser, "Searched");

            listOrders.Items.Clear();

            foreach (StockOrder StockOrder in model.StockOrderList)
            {
                if (StockOrder.StockOrderID.ToString() == comboResults.Text || StockOrder.UserID.ToString() == comboResults.Text)
                {
                    string[] row = { StockOrder.StockOrderID.ToString(), StockOrder.UserID.ToString() };
                    var listViewItem = new ListViewItem(row);
                    listOrders.Items.Add(listViewItem);
                }
            }
        }

        private void frmStockOrder_Load(object sender, EventArgs e)
        {
            listOrders.Items.Clear();
            listOrders.BeginUpdate();


            foreach (StockOrder StockOrder in model.StockOrderList)
            {
                string[] row = { StockOrder.StockOrderID.ToString(), StockOrder.UserID.ToString(), StockOrder.Date.ToString() };
                var listViewItem = new ListViewItem(row);
                listOrders.Items.Add(listViewItem);

            }
            listOrders.EndUpdate();
            listOrders.Enabled = true;
            listOrders.FullRowSelect = true;

            label4.Text = DateTime.Now.ToLongTimeString(); // show the current time
            label3.Text = DateTime.Now.ToShortDateString(); // show the current date
            timer1.Start(); // Start time 
        }


        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button_add_order_Click(object sender, EventArgs e)
        {
            model.addnewStockOrder(Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox2.Text), textBox1.Text);
            cleartextFieldAndLoad();
            DateTime timeNow = DateTime.Now;
            model.addNewLog(timeNow, "Supplier", idOfCurrentUser, "Added");

        }

        private void cleartextFieldAndLoad()
        {
            textBox6.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";

            listOrders.Items.Clear();

            foreach (StockOrder StockOrder in model.StockOrderList)
            {

                string[] row = { StockOrder.StockOrderID.ToString(), StockOrder.UserID.ToString(), StockOrder.Date.ToString() };
                var listViewItem = new ListViewItem(row);
                listOrders.Items.Add(listViewItem);

            }

            listOrders.Enabled = true;
            listOrders.FullRowSelect = true;

        }



        private void listOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listOrders.SelectedItems.Count > 0)

            {

                foreach (StockOrder stockOrder in model.StockOrderList)
                {
                    if (Convert.ToInt16(listOrders.SelectedItems[0].SubItems[0].Text) == stockOrder.StockOrderID)
                    {
                        textBox6.Text = stockOrder.StockOrderID.ToString();
                        textBox2.Text = stockOrder.UserID.ToString();
                        textBox1.Text = stockOrder.Date;

                    }


                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.RefToStock.Show();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Update", "Are you sure !", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DateTime timeNow = DateTime.Now;
                model.addNewLog(timeNow, "StockOrder", idOfCurrentUser, "Updated");
                foreach (StockOrder StockOrder in model.StockOrderList)
                {
                    if (Convert.ToString(listOrders.SelectedItems[0].SubItems[0].Text) == Convert.ToString(StockOrder.StockOrderID))
                    {
                        StockOrder.StockOrderID = Convert.ToInt32(textBox6.Text);
                        StockOrder.UserID = Convert.ToInt32(textBox2.Text);
                        StockOrder.Date = textBox1.Text;


                        model.editStockOrder(StockOrder);

                    }
                }
                listOrders.Items.Clear();
                foreach (StockOrder stockOrder in model.StockOrderList)
                {
                    string[] row = { stockOrder.StockOrderID.ToString(), stockOrder.UserID.ToString(), stockOrder.Date.ToString() };
                    var listViewItem = new ListViewItem(row);
                    listOrders.Items.Add(listViewItem);

                }
                //textBoxName.Text = "";
                //textBoxPassword.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = listOrders.FocusedItem.Index;


            if (MessageBox.Show("Delete", "Are you sure !", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            foreach (StockOrder StockOrder in model.StockOrderList)
            {

                if (Convert.ToString(listOrders.SelectedItems[0].SubItems[0].Text) == Convert.ToString(StockOrder.StockOrderID))
                {
                    DateTime timeNow = DateTime.Now;
                    model.addNewLog(timeNow, "StockOrder", idOfCurrentUser, "Deleted");

                    model.deleteStockOrder(StockOrder);
                    listOrders.Items.RemoveAt(index); //remove name from listbox
                    break;
                }
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToLongTimeString();
        }

        private void timer1_Tick_2(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToLongTimeString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime timeNow = DateTime.Now;
            model.addNewLog(timeNow, "Stock Order", idOfCurrentUser, "Printed");
            if (listOrders.SelectedItems.Count > 0)
            {

                foreach (StockOrder StockOrder in model.StockOrderList)
                {
                    if (Convert.ToInt32(listOrders.SelectedItems[0].SubItems[0].Text) == StockOrder.StockOrderID)
                    {
                        char vt = (char)11;

                        textBox2.Text = StockOrder.UserID.ToString();
                        textBox1.Text = StockOrder.Date.ToString();

                        object oMissing = System.Reflection.Missing.Value;
                        object oEndOfDoc = "\\endofdoc";
                    }
                }
            }
        }

        public void ShowUserName(string usertype, string username)
        {

            foreach (User user in model.UserList)
            {
                if (user.UserType == usertype && user.Username == username)
                {
                    idOfCurrentUser = user.UserID;
                    lblUserName.Text = username;// Show user name
                }
            }
        }

        private void comboStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> StockOrderID = new List<string>();
            List<String> UserID = new List<string>();


            if (comboStock.SelectedIndex == 0)
            {
                comboResults.Items.Clear();
                foreach (StockOrder StockOrder in model.StockOrderList)
                {
                    if (!StockOrderID.Contains(StockOrder.StockOrderID.ToString()))
                    {
                        comboResults.Items.Add(StockOrder.StockOrderID.ToString());
                        StockOrderID.Add(StockOrder.StockOrderID.ToString());
                    }
                }
                comboResults.SelectedItem = StockOrderID.First();
            }
            else if (comboStock.SelectedIndex == 1)
            {
                comboResults.Items.Clear();
                foreach (StockOrder StockOrder in model.StockOrderList)
                {
                    if (!UserID.Contains(StockOrder.UserID.ToString()))
                    {
                        comboResults.Items.Add(StockOrder.UserID.ToString());
                        UserID.Add(StockOrder.UserID.ToString());
                    }
                }
                comboResults.SelectedItem = UserID.First();
            }
        }

        private void comboResults_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listOrders_DoubleClick(object sender, EventArgs e)
        {
            string str = lblUserName.Text;
            int ID = Convert.ToInt32(listOrders.SelectedItems[0].SubItems[0].Text);
            FrmViewStockOrder viewDetails = new FrmViewStockOrder(model, ID);
            viewDetails.RefToStockOrder = this;
            this.Visible = false;
            viewDetails.Show();
            viewDetails.ShowUserName(str);
        }

        private void frmStockOrder_DoubleClick(object sender, EventArgs e)
        {

        }

    }
}

      