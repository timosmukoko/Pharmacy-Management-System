using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Gp : BusinessEntities.IGp
    {

        #region Instance Properties
        private int gpID;
        private string firstName;
        private string lastName;
        private string address;
        private string phone;
        private string email;
        #endregion


        public int GpID
        {
            get
            {
                return gpID; 
            }
            set
            {
                gpID = value;
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

        public string Email
        {
            get
            {
                return email; ;
            }
            set
            {
                email = value;
            }
        }


        #region Constructors
        public Gp()
        {
            throw new System.NotImplementedException();
        }

        public Gp(int gpID, string firstName, string lastName, string address, string phone, string email)
        {
            this.gpID = gpID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.phone = phone;
            this.email = email;
        }
        #endregion




    }
}
