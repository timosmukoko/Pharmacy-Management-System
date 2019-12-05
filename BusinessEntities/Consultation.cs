using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Consultation : BusinessEntities.IConsultation
    {

        #region Instance Properties
        private int conID;
        private string firstName;
        private string lastName;
        private string phone;
        private string dob;
        private string address;
        private string symptoms;
        private string date;
        private string time;
        #endregion

        public int ConID
        {
            get
            {
                return conID;
            }
            set
            {
                conID = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone; ;
            }
            set
            {
                phone = value;
            }
        }

        public string DOB
        {
            get
            {
                return dob; ;
            }
            set
            {
                dob = value;
            }
        }

        public string Address
        {
            get
            {
                return address; ;
            }
            set
            {
                address = value;
            }
        }

        public string Symptoms
        {
            get
            {
                return symptoms; ;
            }
            set
            {
                symptoms = value;
            }
        }

        public string Date
        {
            get
            {
                return date; ;
            }
            set
            {
                date = value;
            }
        }

        public string Time
        {
            get
            {
                return time; ;
            }
            set
            {
                time = value;
            }
        }


        #region Constructors
        public Consultation()
        {
            throw new System.NotImplementedException();
        }

        public Consultation(int conID, string firstName, string lastName, string phone, string dob, string address, string symptoms, string date, string time)
        {
            this.conID = conID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phone = phone;
            this.dob = dob;
            this.address = address;
            this.symptoms = symptoms;
            this.date = date;
            this.time = time;
        }
        #endregion




    }
}
