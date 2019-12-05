using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Employee : BusinessEntities.IEmployee
    {

        #region Instance Properties
        private int employeeID;
        private string firstName;
        private string lastName;
        private string address;
        private string phone;
        private string email;
        private string nextOfKinName;
        private string nextOfKinPhone;
        private decimal salery;
        private int userID;
        private string usertype;
       
        #endregion


        public int EmployeeID
        {
            get
            {
                return employeeID; ;
            }
            set
            {
                employeeID = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName; ;
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
                return lastName; ;
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

        public string NextOfKinName
        {
            get
            {
                return nextOfKinName; ;
            }
            set
            {
                nextOfKinName = value;
            }
        }

        public string NextOfKinPhone
        {
            get
            {
                return nextOfKinPhone; ;
            }
            set
            {
                nextOfKinPhone = value;
            }
        }

        public decimal Salery
        {
            get
            {
                return salery; ;
            }
            set
            {
                salery = value;
            }
        }

        public int UserID
        {
            get
            {
                return userID; ;
            }
            set
            {
                userID = value;
            }
        }

        public string Usertype
        {
            get
            {
                return usertype; ;
            }
            set
            {
                usertype = value;
            }
        }







        #region Constructors
        public Employee()
        {
            throw new System.NotImplementedException();
        }

        public Employee(int employeeID, int userID, string firstName, string lastName, string address, string phone, string email, string nextOfKinName, string nextOfKinPhone, decimal salery, string usertype)
        {
            this.employeeID = employeeID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.phone = phone;
            this.email = email;
            this.nextOfKinName = nextOfKinName;
            this.nextOfKinPhone = nextOfKinPhone;
            this.salery = salery;
            this.userID = userID;
            this.usertype = usertype;
        }
        #endregion
    }
}
