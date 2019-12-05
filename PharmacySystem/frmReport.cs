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

using BusinessLayer;
using BusinessEntities;
namespace PharmacySystem
{
    public partial class frmReport : Form
    {
        private IModel Model;
        private int idOfCurrentUser;
        public frmDashboard RefToDashboard { get; set; }
        public frmReport(IModel model, string name)
        {
            InitializeComponent();
            this.Model = model;
            lblUserName.Text = name;



        }

        private void button18_Click(object sender, EventArgs e)
        {
            listReport.Items.Clear();
            listReport.BeginUpdate();

            foreach (Report report in Model.ReportList)
            {

                if (report.StartDate.Date >= dtSearchBegin.Value.Date && report.EndDate.Date <= dtSearchEnd.Value.Date)
                {

                    string[] row = { report.ReportID.ToString(), report.NumTransactions.ToString(), report.TotalSales.ToString(), report.TotalTax.ToString(), report.StartDate.ToString(), report.EndDate.ToString() };
                    var listViewItem = new ListViewItem(row);
                    listReport.Items.Add(listViewItem);
                }
            }

            listReport.EndUpdate();
            listReport.Enabled = true;
            listReport.FullRowSelect = true;
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Report", idOfCurrentUser, "Searched");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.RefToDashboard.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Report", idOfCurrentUser, "Generating Reports");
            int numTransactions = 0;
            double salesTotal = 0;
            double totalTax = 0;

            foreach (Transaction transaction in Model.TransactionList)
            {
                if (transaction.TransactionDate.Date >= dateStart.Value.Date && transaction.TransactionDate.Date <= dateEnd.Value.Date)
                {
                    numTransactions++;
                    salesTotal += transaction.TransactionCost;
                    totalTax += transaction.Tax;
                }
            }
            Model.addNewReport(numTransactions, salesTotal, totalTax, dateStart.Value.Date, dateEnd.Value.Date);
            MessageBox.Show("Report Generated", "Notification"); 
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Report", idOfCurrentUser, "Deleting Reports");
            int index = listReport.FocusedItem.Index;

            if (MessageBox.Show("Delete", "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            foreach (Report report in Model.ReportList)
            {
                if (Convert.ToInt16(listReport.SelectedItems[0].SubItems[0].Text) == report.ReportID)
                {
                    Model.deleteReport(report);
                    listReport.Items.RemoveAt(index); //remove name from listbox
                    break;
                }
            }
        }

        private void btnListAll_Click(object sender, EventArgs e)
        {
            listReport.Items.Clear();
            listReport.BeginUpdate();

            foreach (Report report in Model.ReportList)
            {

               

                    string[] row = { report.ReportID.ToString(), report.NumTransactions.ToString(), report.TotalSales.ToString(), report.TotalTax.ToString(), report.StartDate.ToString(), report.EndDate.ToString() };
                    var listViewItem = new ListViewItem(row);
                    listReport.Items.Add(listViewItem);
                
            }

            listReport.EndUpdate();
            listReport.Enabled = true;
            listReport.FullRowSelect = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Report", idOfCurrentUser, "Printed Report");
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToLongTimeString(); // show the durrent time
            label3.Text = DateTime.Now.ToShortDateString(); // show the current date
            timer1.Start(); // Start time  
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
