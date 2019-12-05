using BusinessLayer;
using BusinessEntities;
using System;
using System.Windows.Forms;

namespace PharmacySystem
{
    public partial class frmViewClientDetails : Form
    {
        private IModel Model;
        private string clientId;
        public frmClient RefToClient { get; set; }
        public frmViewClientDetails(IModel model, string id)
        {
            InitializeComponent();

            this.Model = model;
            this.clientId = id;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void ShowUserName(string username)
        {
            lblUserName.Text = username;// Show user name

        }

        private void frmViewClientDeatils_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString(); // show the durrent time
            lblDate.Text = DateTime.Now.ToShortDateString(); // show the current date
            timer1.Start(); // Start time 

            foreach (Client client in Model.ClientList)
            {
                //get gp details
                if (client.Pps == clientId)
                {
                    PPS.Text = client.Pps.ToString();
                    firstName.Text = client.FirstName.ToString();
                    lastName.Text = client.LastName.ToString();
                    street.Text = client.Street.ToString();
                    county.Text = client.County.ToString();
                    txtCountry.Text = client.Country.ToString();
                    phone.Text = client.Phone.ToString();
                    med_card.Text = client.MedicalCardHolder.ToString();
                    cardNumber.Text = client.CardNumber.ToString();
                    nextOfKinName.Text = client.NextOfKinName.ToString();
                    nextOfKinPhone.Text = client.NextOfKinPhone.ToString();
                    gpRefNum.Text = client.GpID.ToString();
                    break;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.RefToClient.Show();
            this.Close();
        }
    }
}
