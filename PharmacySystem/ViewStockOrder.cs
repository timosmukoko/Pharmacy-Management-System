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
    public partial class ViewStockOrderDetails : Form
    {
        private IModel Model;
        private int logId;
        public ViewStockOrderDetails(IModel model, int id)
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
            lblDate.Text = DateTime.Now.ToLongDateString(); // show the current date
            timer1.Start(); // Start time 

            foreach (StockOrder StockOrder in Model.StockOrderList)
            {
                //get gp details
                if (StockOrder.StockOrderID == logId)
                {
                    StockOrderID.Text = StockOrder.StockOrderID.ToString();
                    UserID.Text = StockOrder.UserID.ToString();
                    Date.Text = StockOrder.Date.ToString();
                    break;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }
    }
   
    }

