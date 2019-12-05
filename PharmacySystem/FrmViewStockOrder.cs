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
    public partial class FrmViewStockOrder : Form
    {
        private IModel Model;
        private int ID;
        public frmStockOrder RefToStockOrder { get; set; }
        public FrmViewStockOrder(IModel model, int iD)
        {
            InitializeComponent();
            this.Model = model;
            this.ID = iD;
        }

        public void ShowUserName(string username)
        {
            lblUserName.Text = username;// Show user name

        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FrmViewStockOrder_Load_1(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString(); // show the durrent time
            lblDate.Text = DateTime.Now.ToShortDateString(); // show the current date
            timer1.Start(); // Start time 

            foreach (StockOrder StockOrder in Model.StockOrderList)
            {
                //get Store Order details
                if (StockOrder.StockOrderID == ID)
                {
                    label3.Text = StockOrder.StockOrderID.ToString();
                    UserID.Text = StockOrder.UserID.ToString();
                    Date.Text = StockOrder.Date.ToString();
                    break;
                }
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.RefToStockOrder.Show();
            this.Close();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
