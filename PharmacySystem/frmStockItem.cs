
// Author Lorcan
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;

using BusinessLayer;
using BusinessEntities;

namespace PharmacySystem
{

    public partial class frmStockItem : Form
    {
        #region Instance Attributes
        private IModel Model;
        private int idOfCurrentUser;
        public frmDashboard RefToDashboard { get; set; }
        #endregion
        #region Constructors

        public frmStockItem(IModel model)
        {
            InitializeComponent();
            this.Model = model;
            
        }
        #endregion
       
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmStockItem_Load(object sender, EventArgs e)
        {

            lblTime.Text = DateTime.Now.ToLongTimeString(); // show the durrent time
            lblDate.Text = DateTime.Now.ToShortDateString(); // show the current date
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


        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Delete", "Are you sure !", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (Item item in Model.ItemList)
                {
                    if (Convert.ToInt16(listOrders.SelectedItems[0].SubItems[0].Text) == item.ItemID)
                    {
                        item.Category = comboBox2.Text;
                        item.Vendor = textBox6.Text;
                        item.Quantity = Convert.ToInt16(textBox2.Text);
                        item.PurchaseUnit = Convert.ToDouble(textBox4.Text);
                        item.ItemName = textBox7.Text;
                        item.Description = textBox1.Text;
                        item.SaleUnit = Convert.ToDouble(textBox3.Text);
                       
                        item.IsDeleted = "YES";

                        Model.editItem(item);

                    }
                }
                listOrders.Items.Clear();
                displayInList();
                //textBoxName.Text = "";
                //textBoxPassword.Text = "";
            }

            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Stock Item", idOfCurrentUser, "Deleted");

        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            Model.addNewItem(comboBox2.Text, textBox6.Text, Convert.ToInt16(textBox2.Text), Convert.ToDouble(textBox4.Text), textBox7.Text, textBox1.Text, Convert.ToDouble(textBox3.Text),  "NO");
            cleartextFieldAndLoad();
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Stock Item", idOfCurrentUser, "Added");
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Update", "Are you sure !", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (Item item in Model.ItemList)
                {
                    if (Convert.ToInt16(listOrders.SelectedItems[0].SubItems[0].Text) == item.ItemID)
                    {
                        
                        item.Category = comboBox2.Text;
                        item.Vendor = textBox6.Text;
                        item.Quantity = Convert.ToInt16(textBox2.Text);
                        item.PurchaseUnit = Convert.ToDouble(textBox4.Text);
                        item.ItemName = textBox7.Text;
                        item.Description = textBox1.Text;
                        item.SaleUnit = Convert.ToDouble(textBox3.Text);
                     
                        item.IsDeleted = "NO";
                        Model.editItem(item);
                        break;
                    }
                }
                listOrders.Items.Clear();
                displayInList();
                //textBoxName.Text = "";
                //textBoxPassword.Text = "";
            }

            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Stock Item", idOfCurrentUser, "Updated");
        }

        private void listOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listOrders.SelectedItems.Count > 0)
            {

                foreach (Item item in Model.ItemList)
                {
                    if (Convert.ToInt16(listOrders.SelectedItems[0].SubItems[0].Text) == item.ItemID)
                    {
                        
                        comboBox2.Text = item.Category;
                        textBox6.Text = item.Vendor;
                        textBox2.Text = item.Quantity.ToString();
                        textBox4.Text = item.PurchaseUnit.ToString();
                        textBox7.Text = item.ItemName;
                        textBox1.Text = item.Description;
                        textBox3.Text = item.SaleUnit.ToString();
                    

                       
                    }
                }
            }

        }
        //comment
        private void listOrders_DoubleClick(object sender, EventArgs e)
        {
           // string str = lblUserName.Text;
           // int id = Convert.ToInt16(listOrders.SelectedItems[0].SubItems[0].Text);
           // frmViewStockItemDetails viewDetails = new frmViewStockItemDetails(Model, id);
           // viewDetails.Show();
            //viewDetails.ShowUserName(str);
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

        private void button18_Click(object sender, EventArgs e)
        {
            listOrders.Items.Clear();
            //comment
            foreach (Item item in Model.ItemList)
            {
                if (item.Category.ToString() == comboResults.Text||item.ItemName.ToString()== comboResults.Text||item.Vendor.ToString() == comboResults.Text&&item.IsDeleted=="NO")
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

        private void button4_Click(object sender, EventArgs e)
        {
            int numItemsInlist = Model.ItemList.Count;

            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
            //Start Word and create a new document.
            Word._Application oWord;
            Word._Document oDoc;
            oWord = new Word.Application();
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
            ref oMissing, ref oMissing);
            
            //Insert a paragraph at the beginning of the document.
            Word.Paragraph oPara1;
            //Insert table
            //Word.Table oTable;

            foreach (Item item in Model.ItemList)
                {
                        char vt = (char)11;

                oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara1.Range.Text =
                    "Item ID: " + item.ItemID.ToString() + vt +
                    " Item Name: " + item.ItemName.ToString() + vt +
                    "Item Category: " + item.Category.ToString() + vt +
                    "Item Vendor: " + item.Vendor.ToString() + vt +
                    "Item Quantity: " + item.Quantity.ToString() + vt +
                    "Item Purchase Unit: " + item.PurchaseUnit.ToString() + vt +
                    "Item Sale Unit: " + item.SaleUnit.ToString() + vt +
                    
                    "Item Description: " + item.Description.ToString();
                oPara1.Range.Font.Size = 10;
                oPara1.Range.Font.Name = "Arial";
                oPara1.Format.SpaceAfter = 24;    //24 pt spacing after paragraph.
                oPara1.Range.InsertParagraphAfter();



                //        Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                //        oTable = oDoc.Tables.Add(wrdRng, 2, numItemsInlist, ref oMissing, ref oMissing);
                //        oTable.Range.ParagraphFormat.SpaceAfter = 6;
                //        int r, c;
                //        string strText= "Item ID: " + item.ItemID.ToString() + vt +
                //            " Item Name: " + item.ItemName.ToString() + vt +
                //            "Item Category: " + item.Category.ToString() + vt +
                //            "Item Vendor: " + item.Vendor.ToString() + vt +
                //            "Item Quantity: " + item.Quantity.ToString() + vt +
                //            "Item Purchase Unit: " + item.PurchaseUnit.ToString() + vt +
                //            "Item Sale Unit: " + item.SaleUnit.ToString() + vt +
                //            "Item Quantity per Box: " + item.QuantityPerBox.ToString() + vt +
                //            "Item Description: " + item.Description.ToString(); ;
                //for (r = 1; r <= 2; r++)
                //            for (c = 1; c <= numItemsInlist; c++)
                //            {
                //                strText = "r" + r + "c" + c;
                //                oTable.Cell(r, c).Range.Text = strText;
                //            }
                //        oTable.Rows[1].Range.Font.Bold = 1;
                //        oTable.Rows[1].Range.Font.Italic = 1;
                //Close this form.
                

                    }

            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Stock Item", idOfCurrentUser, "Printed");
        }

        private void cleartextFieldAndLoad()
        {
            comboBox2.SelectedIndex = -1;
            textBox7.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
            

            listOrders.Items.Clear();

            displayInList();

            listOrders.Enabled = true;
            listOrders.FullRowSelect = true;

        }

        private void displayInList()
        {
            foreach (Item item in Model.ItemList)
            {
                if (item.IsDeleted.ToString() == "NO")
                {
                    string[] row = { item.ItemID.ToString(), item.Category.ToString(), item.Vendor.ToString(), item.Quantity.ToString(), item.PurchaseUnit.ToString(), item.ItemName.ToString() };
                    var listViewItem = new ListViewItem(row);
                    listOrders.Items.Add(listViewItem);
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            comboBox2.Text = "Select Category...";
            textBox7.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
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

        private void button22_Click(object sender, EventArgs e)
        {
            this.RefToDashboard.Show();
            this.Close();
        }

        private void comboResults_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        public void ShowUserName(string username)
        {
            lblUserName.Text = username;// Show user name
            //if (username == "manager") // get user name privilegies
            //{
            //    grpAddCustomer.Enabled = true;
            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string usertype = Model.getUserTypeForCurrentuser();
            string username = Model.getUserNameForCurrentuser();
            frmStockOrder stockorder = new frmStockOrder(Model);
            stockorder.RefToStock = this;
            this.Visible = false;
            stockorder.Show();
            stockorder.ShowUserName(usertype, username);
        }

        private void frmStockItem_DoubleClick(object sender, EventArgs e)
        {

        }

        private void listOrders_DoubleClick_1(object sender, EventArgs e)
        {
            string str = lblUserName.Text;
            int id = Convert.ToInt16(listOrders.SelectedItems[0].SubItems[0].Text);
            frmViewStockItemDetails viewDetails = new frmViewStockItemDetails(Model, id, str);
            viewDetails.RefToStockItem = this;
            this.Visible = false;

            viewDetails.Show();
            //viewDetails.ShowUserName(str);
        }
    }
}
