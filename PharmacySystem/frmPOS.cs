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
using BusinessLayer;
using BusinessEntities;
//author: Lorcan
namespace PharmacySystem
{
    public partial class frmPOS : Form
    {
        #region Instance Attributes
        private IModel Model;
        private int idOfCurrentUser;
        TextBox selTB =null;
        private List<Item> itemInTransaction = new List<Item>();
        private List<Item> itemList;
        private string userLoggedOn;
        public frmDashboard RefToDashboard { get; set; }
        #endregion
        public frmPOS(IModel model)
        {
            InitializeComponent();
            this.Model = model;
            //this.itemList = itemList;
            txtItemQuantity.Enter+= tb_Enter;
            txtItemCode.Enter+= tb_Enter;
            itemInTransaction.Clear();
        }

        private void tb_Enter(object sender, EventArgs e)
        {
            selTB = (TextBox)sender;
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
          
            lblBalance.Text = "0";
            label4.Text = DateTime.Now.ToLongTimeString(); // show the durrent time
            lblDate.Text = DateTime.Now.ToLongDateString(); // show the current date
            timer1.Start(); // Start time 
            lblName.Text = "";
            lblCategory.Text = "";
            lblVendor.Text = "";
            lblDescription.Text = "";
            txtItemCode.Select();
            label4.Text = DateTime.Now.ToLongTimeString(); // show the durrent time
            lblDate.Text = DateTime.Now.ToShortDateString(); // show the current date
            timer1.Start(); // Start time 

            frmDashboard add = new frmDashboard(Model);
            ListViewItem item = new ListViewItem();
            List<string> data = add.GetData();
            item.Text = data[0];
            item.SubItems.Add(data[1]);
            item.SubItems.Add(data[2]);
            //item.SubItems.Add(data[3]);
            listPos.Items.Add(item);
        }

        public void ShowUserName(string usertype, string username)
        {
            
            foreach(User user in Model.UserList)
            {
                if (user.UserType == usertype && user.Username == username)
                {
                    idOfCurrentUser=user.UserID;
                    
                }
            }
            lblUserName.Text = username;// Show user name
            userLoggedOn = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selTB.SelectedText += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selTB.SelectedText += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selTB.SelectedText += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            selTB.SelectedText += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            selTB.SelectedText += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            selTB.SelectedText += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            selTB.SelectedText += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            selTB.SelectedText += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            selTB.SelectedText += "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            selTB.SelectedText += "0";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            selTB.SelectedText += ".";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            selTB.Text = "";
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (itemInTransaction.Count != 0)
            {
                DialogResult result1 = MessageBox.Show("Are you sure you wish to cancel the transaction",
            "Important Question",
            MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    txtItemCode.Text = "";
                    txtItemQuantity.Text = "";
                 
                    lblBalance.Text = "0";
                    lblName.Text = "";
                    lblCategory.Text = "";
                    lblVendor.Text = "";
                    lblDescription.Text = "";
                    itemInTransaction.Clear();
                    listPos.Items.Clear();
                }
            }
            else
                MessageBox.Show("Can't cancel empty transaction");
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (itemInTransaction.Count != 0)
            {
                int id = 0;
                char vt = (char)11;
                DialogResult result1 = MessageBox.Show("Are you sure you wish to complete the transaction",
                "Important Question",
                MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    txtItemCode.Text = "";
                    txtItemQuantity.Text = "";
                   
                    lblBalance.Text = "0";
                    lblName.Text = "";
                    lblCategory.Text = "";
                    lblVendor.Text = "";
                    lblDescription.Text = "";
                    itemInTransaction.Clear();
                    listPos.Items.Clear();

                    //add to total tax
                    tax = (grand * 0.23);

                    //add to subtotal
                    sub = (grand - tax);

                    DateTime timeNow = DateTime.Now;
                    //return the payment method as a string
                    frmPaymentMethod paymentMethod = new frmPaymentMethod();
                    paymentMethod.ShowDialog();
                    string pMethod = paymentMethod.Value;

                    Model.addNewLog(timeNow, "Transaction", idOfCurrentUser, "Checkout");
                    Model.addNewTransaction(idOfCurrentUser, timeNow, grand, tax, pMethod);
                    foreach (Transaction t in Model.TransactionList)
                    {
                        if (t.TransactionDate == timeNow)
                        {
                            id = t.TransactionID;
                        }
                    }
                    foreach (Item currentItems in itemInTransaction)
                    {
                        Model.addNewItemToTransaction(id, currentItems.ItemID);
                    }

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
                    Word.Paragraph oPara2;

                    oPara2 = oDoc.Content.Paragraphs.Add(ref oMissing);
                    oPara2.Range.Text =
                            "Pats Pharmacy" + vt +
                            "Limerick" + vt +
                            "==================================" + vt;
                    oPara2.Range.Font.Size = 10;
                    oPara2.Range.Font.Name = "Arial";
                    oPara2.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    //add new paragraph
                    Word.Paragraph oPara1;
                    oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                    foreach (Item item in itemInTransaction)
                    {
                        oPara1.Range.Text +=
                            item.ItemName + "      " + item.SaleUnit.ToString("C") + item.Quantity + vt;
                    }
                    oPara1.Range.Text +=
                        "Total: " + grand.ToString("C") + vt +
                        "Vat Analysis: " + tax.ToString("C") + vt +
                        "Paid By: " + pMethod + vt +
                        "You were served by: " + userLoggedOn + vt +
                        "Date: " + timeNow + vt +
                        "TransactionID " + id + vt +
                        "Thank You" + vt +
                        "Please Call Again";

                    oPara1.Range.Font.Size = 10;
                    oPara1.Range.Font.Name = "Arial";
                    oPara1.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }
            }
            else
                MessageBox.Show("Can't checkout empty transaction");

            txtItemCode.Text = "";
            txtItemQuantity.Text = "";
          
            lblBalance.Text = "0";
            lblName.Text = "";
            lblCategory.Text = "";
            lblVendor.Text = "";
            lblDescription.Text = "";
            itemInTransaction.Clear();
            listPos.Items.Clear();
        }

        double sub, tax, grand, minusSub, minusTax, minusGrand;

        private void button22_Click(object sender, EventArgs e)
        {
            this.RefToDashboard.Show();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            int quantity = 0;
            int index = listPos.FocusedItem.Index;
            if (listPos.SelectedItems.Count > 0)
            {
                if (listPos.SelectedItems[0].ForeColor == Color.Red)
                {
                    MessageBox.Show("Item(s) already removed from the transaction",
                    "Important Notice", MessageBoxButtons.OK);
                }
                else
                {
                    foreach (Item item in Model.ItemList)
                    {
                        if (Convert.ToInt16(listPos.SelectedItems[0].SubItems[0].Text) == item.ItemID)
                        {
                            DialogResult result1 = MessageBox.Show("Are you sure you wish to remove the item(s) from the transaction",
                            "Important Question",
                            MessageBoxButtons.YesNo);
                            if (result1 == DialogResult.Yes)
                            {
                                quantity = Convert.ToInt32(listPos.SelectedItems[0].SubItems[2].Text);
                                listPos.SelectedItems[0].ForeColor = Color.Red;

                                //subtract item quantity from stock
                                item.Quantity += quantity;
                                Model.editItem(item);

                                //need to fix

                                minusGrand = (item.SaleUnit * quantity);

                                grand -= minusGrand;
                               
                                lblBalance.Text = grand.ToString("C");

                                itemInTransaction.Remove(item);
                            }
                        }
                    }
                }
            }
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Transaction", idOfCurrentUser, "Item Removed");
        }

        private void listPos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPos.SelectedItems.Count > 0)
            {

                foreach (Item item in Model.ItemList)
                {
                    if (Convert.ToInt16(listPos.SelectedItems[0].SubItems[0].Text) == item.ItemID)
                    {

                        if (item.Category == "Controlled")
                        {
                            grBxItem.ForeColor = Color.Red;
                            grBxItem.Text = "Controlled Drug";
                            grBxItem.Font = new Font(grBxItem.Font, FontStyle.Bold);


                        }
                        else
                        {
                            grBxItem.ForeColor = Color.Black;
                            grBxItem.Text = "Item Details";
                            grBxItem.Font = new Font(grBxItem.Font, FontStyle.Regular);
                        }


                        lblName.Text = item.ItemName;
                        lblCategory.Text = item.Category;
                        lblVendor.Text = item.Vendor;
                        lblDescription.Text = item.Description;


                    }
                }
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {

            bool codeExists = false;
            bool quantityExists = false;

            if (txtItemQuantity.Text == "" && txtItemCode.Text != "")
            {
                MessageBox.Show("Please enter the quantity of items");
                return;
            }
            else if (txtItemCode.Text == "" && txtItemQuantity.Text != "")
            {
                MessageBox.Show("Please enter the item code");
                return;

            }
            else if (txtItemCode.Text == "" && txtItemQuantity.Text == "")
            {
                MessageBox.Show("Please enter the item code and item quantity");
                return;
            }
            else
                foreach (Item item in Model.ItemList)
                {
                    if (Convert.ToInt32(txtItemCode.Text) == item.ItemID)
                    {
                        codeExists = true;
                        if (Convert.ToInt32(txtItemQuantity.Text) <= item.Quantity)
                        {
                            quantityExists = true;
                            string[] row = { item.ItemID.ToString(), item.ItemName.ToString(), txtItemQuantity.Text, item.SaleUnit.ToString() };
                            var listViewItem = new ListViewItem(row);
                            listPos.BeginUpdate();
                            listPos.Items.Add(listViewItem);
                            listPos.EndUpdate();



                            if (item.Category == "Controlled")
                            {
                                grBxItem.ForeColor = Color.Red;
                                grBxItem.Text = "Controlled Drug";
                                grBxItem.Font = new Font(grBxItem.Font, FontStyle.Bold);


                            }
                            else
                            {
                                grBxItem.ForeColor = Color.Black;
                                grBxItem.Text = "Item Details";
                                grBxItem.Font = new Font(grBxItem.Font, FontStyle.Regular);
                            }


                            lblName.Text = item.ItemName;
                            lblCategory.Text = item.Category;
                            lblVendor.Text = item.Vendor;
                            lblDescription.Text = item.Description;

                            //add to balance due
                            grand += (item.SaleUnit * Convert.ToInt32(txtItemQuantity.Text));
                            lblBalance.Text = grand.ToString("C");

                            //subtract item quantity from stock
                            item.Quantity -= Convert.ToInt16(txtItemQuantity.Text);
                            Model.editItem(item);

                            itemInTransaction.Add(item);
                            break;
                        }
                        else if (Convert.ToInt32(txtItemQuantity.Text) > item.Quantity)
                        {
                            quantityExists = false;
                        }
                        break;
                    }
                }
            if (codeExists == false && quantityExists == false)
                MessageBox.Show("Incorrect item code entered");
            if (codeExists == true && quantityExists == false)
                MessageBox.Show("Quantity entered exceeds the quantity in stock");


            //MessageBox.Show("Please enter a valid item code");
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Transaction", idOfCurrentUser, "Item Added");
        }
    }
    }

