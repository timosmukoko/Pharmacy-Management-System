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
    public partial class FrmViewConsultation : Form
    {
        private IModel Model;
        private int ID;
        public frmConsultation RefToConsultation { get; set; }
        public FrmViewConsultation(IModel model, int iD)
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


        private void FrmViewConsultation_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString(); // show the durrent time
            lblDate.Text = DateTime.Now.ToShortDateString(); // show the current date
            timer1.Start(); // Start time 

            foreach (Consultation Consultation in Model.ConList)
            {
                //get consultation details
                if (Consultation.ConID == ID)
                {
                    ConsultationIDLbl.Text = Consultation.ConID.ToString();
                    FirstLbl.Text = Consultation.FirstName.ToString();
                    LastLbl.Text = Consultation.LastName.ToString();
                    PhoneLbl.Text = Consultation.Phone.ToString();
                    DobLbl.Text = Consultation.DOB.ToString();
                    AddressLbl.Text = Consultation.Address.ToString();
                    symptomsLbl.Text = Consultation.Symptoms.ToString();
                    DateLbl.Text = Consultation.Date.ToString();
                    TimeLbl.Text = Consultation.Time.ToString();
                    break;
                }
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.RefToConsultation.Show();
            this.Close();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
