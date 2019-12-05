using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Client : BusinessEntities.IClient
    {
        private string PPS;
        private string firstName;
        private string lastName;
        private string street;
        private string county;
        private string country;
        private string phone;
        private string medicalCardHolder;
        private string cardNumber;
        private string nextOfKinName;
        private string nextOfKinPhone;
        private string imageLocation;
        private int gpID;

        public Client(string PPS, string firstName, string lastName, string street, string county, string country, string phone, string medicalCardHolder, string cardNumber, string nextOfKinName, string nextOfKinPhone, int gpID)
        {
            this.PPS = PPS;
            this.firstName = firstName;
            this.lastName = lastName;
            this.street = street;
            this.county = county;
            this.country = country;
            this.phone = phone;
            this.medicalCardHolder = medicalCardHolder;
            this.cardNumber = cardNumber;
            this.nextOfKinName = nextOfKinName;
            this.nextOfKinPhone = nextOfKinPhone;
            imageLocation = null;
            this.gpID = gpID;
        }

        public string Pps
        {
            get { return PPS; }
            set { PPS = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Street
        {
            get { return street; }
            set { street = value; }
        }

        public string County
        {
            get { return county; }
            set { county = value; }
        }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string MedicalCardHolder
        {
            get { return medicalCardHolder; }
            set { medicalCardHolder = value; }
        }
        public string CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value; }
        }

        public string NextOfKinName
        {
            get { return nextOfKinName; }
            set { nextOfKinName = value; }
        }

        public string NextOfKinPhone
        {
            get { return nextOfKinPhone; }
            set { nextOfKinPhone = value; }
        }

        public string ImageLocation
        {
            get { return imageLocation; }
            set { imageLocation = value; }
        }

        public int GpID
        {
            get { return gpID; }
            set { gpID = value; }
        }

        public Client()
        {
            throw new System.NotImplementedException();
        }
    }
}
