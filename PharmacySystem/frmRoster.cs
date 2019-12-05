using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BusinessLayer;
using BusinessEntities;
//Lorcan
namespace PharmacySystem
{
    public partial class frmRoster : Form
    {
        private IModel Model;
        private int idOfCurrentUser;
        private List<Employee> employeeInRoster = new List<Employee>();
        public frmDashboard RefToDashboard { get; set; }
        public frmRoster(IModel model)
        {
            InitializeComponent();
            this.Model = model;
            employeeInRoster.Clear();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
           
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            
        }

        private void frmRoster_Load(object sender, EventArgs e)
        {

            //load employee combo box with employees
            foreach (Employee employee in Model.EmployeeList)
            {
                cmboEmployee.Items.Add(employee.FirstName.ToString());

            }

            lblTime.Text = DateTime.Now.ToLongTimeString(); // show the durrent time
            lblDate.Text = DateTime.Now.ToShortDateString(); // show the current date
            timer1.Start(); // Start time 

            
            //lstMonday.Enabled = true;
            //lstMonday.FullRowSelect = true;
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            this.RefToDashboard.Show();
            this.Close();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            int weekNum = Convert.ToInt32(cmboWeekNum.SelectedItem);
            string weekDay = cmboDay.SelectedItem.ToString();
            string employeeName = cmboEmployee.SelectedItem.ToString();
            foreach (Employee employee in Model.EmployeeList)
            {
                if (cmboEmployee.SelectedItem.ToString() == employee.FirstName.ToString())
                {

                    if (cmboDay.SelectedItem.ToString() == "Monday")
                    {
                        
                            string[] row = { employee.FirstName.ToString() };
                            var listViewItem1 = new ListViewItem(row);
                            lstMonday.BeginUpdate();
                            lstMonday.Items.Add(listViewItem1);
                            lstMonday.EndUpdate();
                            Model.addNewRoster(weekNum, weekDay, employeeName);
                            //employeeInRoster.Add(employee);
                        

                    }

                    else if (cmboDay.SelectedItem.ToString() == "Tuesday")
                    {
                        string[] row = { employee.FirstName.ToString() };
                        var listViewItem2 = new ListViewItem(row);
                        lstTuesday.BeginUpdate();
                        lstTuesday.Items.Add(listViewItem2);
                        lstTuesday.EndUpdate();
                        Model.addNewRoster(weekNum, weekDay, employeeName);
                        //employeeInRoster.Add(employee);
                    }
                    else if (cmboDay.SelectedItem.ToString() == "Wednesday")
                    {
                        string[] row = { employee.FirstName.ToString() };
                        var listViewItem3 = new ListViewItem(row);
                        lstWednesday.BeginUpdate();
                        lstWednesday.Items.Add(listViewItem3);
                        lstWednesday.EndUpdate();
                        Model.addNewRoster(weekNum, weekDay, employeeName);
                        //employeeInRoster.Add(employee);
                    }
                    else if (cmboDay.SelectedItem.ToString() == "Thursday")
                    {
                        string[] row = { employee.FirstName.ToString() };
                        var listViewItem4 = new ListViewItem(row);
                        lstThursday.BeginUpdate();
                        lstThursday.Items.Add(listViewItem4);
                        lstThursday.EndUpdate();
                        //employeeInRoster.Add(employee);
                    }
                    else if (cmboDay.SelectedItem.ToString() == "Friday")
                    {
                        string[] row = { employee.FirstName.ToString() };
                        var listViewItem5 = new ListViewItem(row);
                        lstFriday.BeginUpdate();
                        lstFriday.Items.Add(listViewItem5);
                        lstFriday.EndUpdate();
                        Model.addNewRoster(weekNum, weekDay, employeeName);
                        //employeeInRoster.Add(employee);
                    }
                    else if (cmboDay.SelectedItem.ToString() == "Saturday")
                    {
                        string[] row = { employee.FirstName.ToString() };
                        var listViewItem6 = new ListViewItem(row);
                        lstSaturday.BeginUpdate();
                        lstSaturday.Items.Add(listViewItem6);
                        lstSaturday.EndUpdate();
                        Model.addNewRoster(weekNum, weekDay, employeeName);
                        //employeeInRoster.Add(employee);
                    }
                    else if (cmboDay.SelectedItem.ToString() == "Sunday")
                    {
                        string[] row = { employee.FirstName.ToString() };
                        var listViewItem7 = new ListViewItem(row);
                        lstSunday.BeginUpdate();
                        lstSunday.Items.Add(listViewItem7);
                        lstSunday.EndUpdate();
                        Model.addNewRoster(weekNum, weekDay, employeeName);
                        //employeeInRoster.Add(employee);
                    }
                }
            }
        }

        private void btnSaveRoster_Click(object sender, EventArgs e)
        {
            //Model.addNewRoster(12, timeNow, grand, tax, pMethod);
        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            lstMonday.Items.Clear();
            lstTuesday.Items.Clear();
            lstWednesday.Items.Clear();
            lstThursday.Items.Clear();
            lstFriday.Items.Clear();
            lstSaturday.Items.Clear();
            lstSunday.Items.Clear();

            foreach (Roster roster in Model.RosterList)
            {
                if (roster.WeekNumber.ToString() == cmboWeekNum.Text)
                {
                    if (roster.Day.ToString()=="Monday")
                    {
                        lstMonday.Items.Add(roster.Name.ToString());
                    }
                    else if(roster.Day.ToString() == "Tuesday")
                    {
                        lstTuesday.Items.Add(roster.Name.ToString());
                    }
                    else if (roster.Day.ToString() == "Wednesday")
                    {
                        lstWednesday.Items.Add(roster.Name.ToString());
                    }
                    else if (roster.Day.ToString() == "Thursday")
                    {
                        lstThursday.Items.Add(roster.Name.ToString());
                    }
                    else if (roster.Day.ToString() == "Friday")
                    {
                        lstFriday.Items.Add(roster.Name.ToString());
                    }
                    else if (roster.Day.ToString() == "Saturday")
                    {
                        lstSaturday.Items.Add(roster.Name.ToString());
                    }
                    else if (roster.Day.ToString() == "Sunday")
                    {
                        lstSunday.Items.Add(roster.Name.ToString());
                    }
                    //string[] row = { item.ItemID.ToString(), item.Category.ToString(), item.Vendor.ToString(), item.Quantity.ToString(), item.PurchaseUnit.ToString(), item.ItemName.ToString() };
                    //var listViewItem = new ListViewItem(row);
                    //listOrders.Items.Add(listViewItem);
                }
            }
        }

        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            if (lstMonday.SelectedItems.Count > 0)
            {
                int index = lstMonday.FocusedItem.Index;
                if (MessageBox.Show("Delete", "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;
                foreach (Roster roster in Model.RosterList)
                {
                    if (lstMonday.SelectedItems[0].SubItems[0].Text == roster.Name.ToString())
                    {
                     
                        Model.deleteRoster(roster);

                        lstMonday.Items.RemoveAt(index); //remove name from listbox
                        break;
                    }
                }
            }
            else if (lstTuesday.SelectedItems.Count > 0)
            {
                int index = lstTuesday.FocusedItem.Index;
                if (MessageBox.Show("Delete", "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;
                foreach (Roster roster in Model.RosterList)
                {
                    if (lstTuesday.SelectedItems[0].SubItems[0].Text == roster.Name.ToString())
                    {

                        Model.deleteRoster(roster);

                        lstTuesday.Items.RemoveAt(index); //remove name from listbox
                        break;
                    }
                }
            }
            else if (lstWednesday.SelectedItems.Count > 0)
            {
                int index = lstWednesday.FocusedItem.Index;
                if (MessageBox.Show("Delete", "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;
                foreach (Roster roster in Model.RosterList)
                {
                    if (lstWednesday.SelectedItems[0].SubItems[0].Text == roster.Name.ToString())
                    {

                        Model.deleteRoster(roster);

                        lstWednesday.Items.RemoveAt(index); //remove name from listbox
                        break;
                    }
                }
            }
            else if (lstThursday.SelectedItems.Count > 0)
            {
                int index = lstThursday.FocusedItem.Index;
                if (MessageBox.Show("Delete", "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;
                foreach (Roster roster in Model.RosterList)
                {
                    if (lstThursday.SelectedItems[0].SubItems[0].Text == roster.Name.ToString())
                    {

                        Model.deleteRoster(roster);

                        lstThursday.Items.RemoveAt(index); //remove name from listbox
                        break;
                    }
                }
            }
            else if (lstFriday.SelectedItems.Count > 0)
            {
                int index = lstFriday.FocusedItem.Index;
                if (MessageBox.Show("Delete", "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;
                foreach (Roster roster in Model.RosterList)
                {
                    if (lstFriday.SelectedItems[0].SubItems[0].Text == roster.Name.ToString())
                    {

                        Model.deleteRoster(roster);

                        lstFriday.Items.RemoveAt(index); //remove name from listbox
                        break;
                    }
                }
            }
            else if (lstSaturday.SelectedItems.Count > 0)
            {
                int index = lstSaturday.FocusedItem.Index;
                if (MessageBox.Show("Delete", "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;
                foreach (Roster roster in Model.RosterList)
                {
                    if (lstSaturday.SelectedItems[0].SubItems[0].Text == roster.Name.ToString())
                    {

                        Model.deleteRoster(roster);

                        lstSaturday.Items.RemoveAt(index); //remove name from listbox
                        break;
                    }
                }
            }
            else if (lstSunday.SelectedItems.Count > 0)
            {
                int index = lstSunday.FocusedItem.Index;
                if (MessageBox.Show("Delete", "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;
                foreach (Roster roster in Model.RosterList)
                {
                    if (lstSunday.SelectedItems[0].SubItems[0].Text == roster.Name.ToString())
                    {

                        Model.deleteRoster(roster);

                        lstSunday.Items.RemoveAt(index); //remove name from listbox
                        break;
                    }
                }
            }
        }

        public void ShowUserName(string usertype, string username)
        {

            foreach (User user in Model.UserList)
            {
                if (user.UserType == usertype && user.Username == username)
                {
                    idOfCurrentUser = user.UserID;
                }
            }
            lblUserName.Text = username;// Show user name

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
                lblTime.Text = DateTime.Now.ToLongTimeString();
            
        }
    }
}
