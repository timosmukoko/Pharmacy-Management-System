using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem
{
    class StaffMember
    {
        public string staffID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string county { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string nextOfKin { get; set; }
        public string allergens { get; set; }

        public StaffMember(string staffID, string firstName, string lastName, string street, string city, string county, string country, string email, string phone, string nextOfKin, string allergens)
        {
            this.staffID = staffID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.street = street;
            this.city = city;
            this.county = county;
            this.country = country;
            this.email = email;
            this.phone = phone;
            this.nextOfKin = nextOfKin;
            this.allergens = allergens;

        }

        public string displayDetails()
        {
            return staffID + " " + firstName + " " + lastName + " " + street + " " + city + " " + county + " " + country + " " + email + " " + phone + " " + nextOfKin + " " + allergens;
        }
    }

    //class Patient
    //{
    //    public string PPS { get; set; }
    //    public string firstName { get; set; }
    //    public string lastName { get; set; }
    //    public string street { get; set; }
    //    public string city { get; set; }
    //    public string county { get; set; }
    //    public string country { get; set; }
    //    public string email { get; set; }
    //    public string phone { get; set; }
    //    public string nextOfKin { get; set; }
       

    //    public Patient(string PPS, string firstName, string lastName, string street, string city, string county, string country, string email,string nextOfKin, string phone)
    //    {
    //        this.PPS = PPS;
    //        this.firstName = firstName;
    //        this.lastName = lastName;
    //        this.street = street;
    //        this.city = city;
    //        this.county = county;
    //        this.country = country;
    //        this.email = email;
    //        this.nextOfKin = nextOfKin;
    //        this.phone = phone;

    //    }

    //    public string displayDetails()
    //    {
    //        return PPS + " " + firstName + " " + lastName + " " + street + " " + city + " " + county + " " + country + " " + email + " " + nextOfKin + " " + phone ;
    //    }

    //}

}
