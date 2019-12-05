//Author Lee

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
    public partial class frmEmployee : Form
    {
        #region Instance Attributes
        //private formContainer fc;
        private IModel Model;
        private int idOfCurrentUser;
        public frmDashboard RefToDashboard { get; set; }
        #endregion

        #region Constructors
        public frmEmployee(IModel model)
        {
            InitializeComponent();
            this.Model = model;


            foreach (Employee employee in Model.EmployeeList)
            {
                string[] row = { employee.EmployeeID.ToString(), employee.FirstName.ToString(), employee.LastName.ToString(), employee.Phone.ToString(), employee.Address.ToString(), employee.Usertype.ToString() };
                var listViewItem = new ListViewItem(row);
                listStaff.Items.Add(listViewItem);
            }
            listStaff.Enabled = true;
            listStaff.FullRowSelect = true;
        }
        #endregion

        private void btnCreateUserAccount_Click(object sender, EventArgs e)
        {

            frmUserAccount userAccount = new frmUserAccount(Model);
            userAccount.RefToEmployee = this;
            this.Visible = false;
            userAccount.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            listStaff.Items.Clear();
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Employee", idOfCurrentUser, "Searched");
            foreach (Employee employee in Model.EmployeeList)
            {
                if (employee.EmployeeID.ToString() == comboResults.Text || (employee.FirstName.ToString() + " " + employee.LastName.ToString()) == comboResults.Text)
                {
                    string[] row = { employee.EmployeeID.ToString(), employee.FirstName.ToString(), employee.LastName.ToString(), employee.Address.ToString(), employee.Phone.ToString(), employee.Email.ToString(), employee.Usertype.ToString() };
                    var listViewItem = new ListViewItem(row);
                    listStaff.Items.Add(listViewItem);
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Employee", idOfCurrentUser, "Added");
            //Model.addNewUser();
            Model.addNewEmployee(textFirstName.Text, textLastName.Text, textAddress.Text, textPhone.Text, textEmail.Text, textNextOfKinName.Text, textNextOfKinPhone.Text, Convert.ToDecimal(textSalery.Text), cmboEmpType.SelectedItem.ToString());
            cleartextFieldAndLoad();
        }

        private void cleartextFieldAndLoad()
        {
            //textEmployeeID.Text = "";
            textFirstName.Text = "";
            textLastName.Text = "";
            textAddress.Text = "";
            textPhone.Text = "";
            textEmail.Text = "";
            textNextOfKinName.Text = "";
            textNextOfKinPhone.Text = "";
            textSalery.Text = "";
            cmboEmpType.Text = "Employee Type...";

            listStaff.Items.Clear();

            foreach (Employee employee in Model.EmployeeList)
            {
                string[] row = { employee.EmployeeID.ToString(), employee.FirstName.ToString(), employee.LastName.ToString(), employee.Phone.ToString(), employee.Address.ToString(), employee.Usertype.ToString()};
                var listViewItem = new ListViewItem(row);
                listStaff.Items.Add(listViewItem);
            }
            listStaff.Enabled = true;
            listStaff.FullRowSelect = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            int index = listStaff.FocusedItem.Index;

            if (MessageBox.Show("Delete", "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            foreach (Employee employee in Model.EmployeeList)
            {
                if (Convert.ToInt16(listStaff.SelectedItems[0].SubItems[0].Text) == employee.EmployeeID)
                {
                    DateTime timeNow = DateTime.Now;
                    Model.addNewLog(timeNow, "Employee", idOfCurrentUser, "Deleted");
                    Model.deleteEmployee(employee);
                   
                    listStaff.Items.RemoveAt(index); //remove name from listbox
                    break;
                }
            }

            //textEmployeeID.Text = "";
            textFirstName.Text = "";
            textLastName.Text = "";
            textAddress.Text = "";
            cmboEmpType.Text = "Employee Type...";
            textEmail.Text = "";
            textPhone.Text = "";
            textNextOfKinName.Text = "";
            textNextOfKinPhone.Text = "";
            textSalery.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.RefToDashboard.Show();
            this.Close();
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            listStaff.Items.Clear();
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Employee", idOfCurrentUser, "Viewed All");
            foreach (Employee employee in Model.EmployeeList)
            {
                string[] row = { employee.EmployeeID.ToString(), employee.FirstName.ToString(), employee.LastName.ToString(), employee.Phone.ToString(), employee.Address.ToString(), employee.Usertype.ToString() };
                var listViewItem = new ListViewItem(row);
                listStaff.Items.Add(listViewItem);
            }
            listStaff.Enabled = true;
            listStaff.FullRowSelect = true;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Update", "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DateTime timeNow = DateTime.Now;
                foreach (Employee employee in Model.EmployeeList)
                {
                    if (Convert.ToInt32(listStaff.SelectedItems[0].SubItems[0].Text) == employee.EmployeeID)
                    {
                       // employee.EmployeeID = Convert.ToInt32(textEmployeeID.Text);
                        employee.FirstName = textFirstName.Text;
                        employee.LastName = textLastName.Text;
                        employee.Address = textAddress.Text;
                        employee.Phone = textPhone.Text;
                        employee.Email = textEmail.Text;
                        employee.NextOfKinName = textNextOfKinName.Text;
                        employee.NextOfKinPhone = textNextOfKinPhone.Text;
                        employee.Salery = Convert.ToDecimal(textSalery.Text);
                        employee.Usertype = cmboEmpType.SelectedItem.ToString();

                        Model.addNewLog(timeNow, "Employee", idOfCurrentUser, "Updated");
                        Model.editEmployee(employee);
                        
                    }
                }
                listStaff.Items.Clear();
                foreach (Employee employee in Model.EmployeeList)
                {
                    string[] row = { employee.EmployeeID.ToString(), employee.FirstName.ToString(), employee.LastName.ToString(), employee.Phone.ToString(), employee.Address.ToString(), employee.Usertype.ToString() };
                    var listViewItem = new ListViewItem(row);
                    listStaff.Items.Add(listViewItem);
                }
                //textEmployeeID.Text = "";
                textFirstName.Text = "";
                textLastName.Text = "";
                textAddress.Text = "";
                textEmail.Text = "";
                textPhone.Text = "";
                textNextOfKinName.Text = "";
                textNextOfKinPhone.Text = "";
                textSalery.Text = "";
                cmboEmpType.Text = "Employee Type...";
            }
        }

        private void listStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listStaff.SelectedItems.Count > 0)
            {
                foreach (Employee employee in Model.EmployeeList)
                {
                    if (Convert.ToInt16(listStaff.SelectedItems[0].SubItems[0].Text) == employee.EmployeeID)
                    {
                       // textEmployeeID.Text = employee.EmployeeID.ToString();
                        textFirstName.Text = employee.FirstName;
                        textLastName.Text = employee.LastName;
                        textAddress.Text = employee.Address;
                        textPhone.Text = employee.Phone;
                        textEmail.Text = employee.Email;
                        textNextOfKinName.Text = employee.NextOfKinName;
                        textNextOfKinPhone.Text = employee.NextOfKinPhone;
                        textSalery.Text = employee.Salery.ToString();
                        cmboEmpType.SelectedItem = employee.Usertype;
                    }
                }
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            DateTime timeNow = DateTime.Now;
            Model.addNewLog(timeNow, "Employee", idOfCurrentUser, "Printed");
            int numEmployeesInlist = Model.EmployeeList.Count;

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
            Word.Table oTable;

            foreach (Employee employee in Model.EmployeeList)
            {
                char vt = (char)11;

                oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara1.Range.Text =
                    "Employee ID: " + employee.EmployeeID.ToString() + vt +
                    "Employee First Name: " + employee.FirstName.ToString() + vt +
                    "Employee Last Name: " + employee.LastName.ToString() + vt +
                    "Employee Address: " + employee.Address.ToString() + vt +
                    "Employee Phone: " + employee.Phone.ToString() + vt +
                    "Employee Email: " + employee.Email.ToString() + vt +
                    "Employee Next of Kin Name: " + employee.NextOfKinName.ToString() + vt +
                    "Employee Next of Kin Phone: " + employee.NextOfKinPhone.ToString() + vt +
                    "Employee Salery: " + employee.Salery.ToString();
                oPara1.Range.Font.Bold = 1;
                oPara1.Format.SpaceAfter = 24;    //24 pt spacing after paragraph.
                oPara1.Range.InsertParagraphAfter();

                //Close this form.
                
            }
        }

        private void comboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> employeeID = new List<string>();
            List<String> employeeName = new List<string>();

            if (comboSearch.SelectedIndex == 0)
            {
                comboResults.Items.Clear();
                foreach (Employee employee in Model.EmployeeList)
                {
                    if (!employeeID.Contains(employee.EmployeeID.ToString()))
                    {
                        comboResults.Items.Add(employee.EmployeeID.ToString());
                        employeeID.Add(employee.EmployeeID.ToString());
                    }
                }
                comboResults.SelectedItem = employeeID.First();
            }
            else
            {
                comboResults.Items.Clear();
                foreach (Employee employee in Model.EmployeeList)
                {
                    if (!employeeName.Contains(employee.FirstName.ToString() + " " + employee.LastName.ToString()))
                    {
                        comboResults.Items.Add(employee.FirstName.ToString() + " " + employee.LastName.ToString());
                        employeeName.Add(employee.FirstName.ToString() + " " + employee.LastName.ToString());
                    }
                }
                comboResults.SelectedItem = employeeName.First();
            }
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToShortDateString(); // show the durrent time
            label4.Text = DateTime.Now.ToLongTimeString(); // show the current date
            timer1.Start(); // Start time 


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToLongTimeString();
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

        private void listStaff_DoubleClick(object sender, EventArgs e)
        {
            string str = lblUserName.Text;
            int id = Convert.ToInt16(listStaff.SelectedItems[0].SubItems[0].Text);
            frmViewStaffMemberDetails viewDetails = new frmViewStaffMemberDetails(Model, id, str);
            viewDetails.RefToStaffMember = this;
            this.Visible = false;
            viewDetails.Show();
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
    }
}

