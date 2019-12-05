using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystem
{
    
    public partial class frmPaymentMethod : Form
    {
        private string _value;
        public frmPaymentMethod()
        {
            InitializeComponent();
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            _value = "Cash";
            this.Close();
        }
        public string Value
        {
            get { return _value; }
        }

        private void btnCredit_Click(object sender, EventArgs e)
        {
            _value = "Credit";
            this.Close();
        }
    }
}
