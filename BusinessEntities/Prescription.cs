using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Prescription : BusinessEntities.IPrescription
    {
        private int presciptionID;
        private string drugName;
        private DateTime dateWritten;      
        private DateTime dateProcessed;
        private DateTime dateDispensed;
        private DateTime dateExpires;
        private string instruction;
        private int quantityWritten;
        private int quantityDispensed;
        private string drugCategory;
        private int userID;
        private string clientID;
        private int gpID;
        private string imageLocation;
        

        public Prescription(int presciptionID, string drugName, DateTime dateWritten, DateTime dateProcessed, DateTime dateDispensed, DateTime dateExpires, string instruction, int quantityWritten, int quantityDispensed, string drugCategory, int userID, string clientID, int gpID)
        {
            this.presciptionID = presciptionID;
            this.drugName = drugName;
            this.dateWritten = dateWritten;
            this.dateProcessed = dateProcessed;
            this.dateDispensed = dateDispensed;
            this.dateExpires = dateExpires;
            this.instruction = instruction;
            this.quantityWritten = quantityWritten;
            this.quantityDispensed = quantityDispensed;
            this.drugCategory = drugCategory;
            this.userID = userID;
            this.clientID = clientID;
            this.gpID = gpID;
            imageLocation = null;
        }

        public int PrescriptionID
        {
            get { return presciptionID; }
            set { presciptionID = value; }
        }

        public string DrugName
        {
            get { return drugName; }
            set { drugName = value; }
        }

        public DateTime DateWritten
        {
            get { return dateWritten; }
            set { dateWritten = value; }
        }

        public DateTime DateProcessed
        {
            get { return dateProcessed; }
            set { dateProcessed = value; }
        }

        public DateTime DateDispensed
        {
            get { return dateDispensed; }
            set { dateDispensed = value; }
        }

        public DateTime DateExpires
        {
            get { return dateExpires; }
            set { dateExpires = value; }
        }

        public string Instruction
        {
            get { return instruction; }
            set { instruction = value; }
        }

        public int QuantityWritten
        {
            get { return quantityWritten; }
            set { quantityWritten = value; }
        }
        public int QuantityDispensed
        {
            get { return quantityDispensed; }
            set { quantityDispensed = value; }
        }

        public string DrugCategory
        {
            get { return drugCategory; }
            set { drugCategory = value; }
        }

        public int UserID
        {
            get { return userID; }
            //set { userID = value; }
        }

        public string ClientID
        {
            get { return clientID;}
            //set { clientID = value; }
        }

        public int GpID
        {
            get { return gpID; }
            //set { gpID = value; }
        }

        public string ImageLocation
        {
            get { return imageLocation; }
            set { imageLocation = value; }
        }
        public Prescription()
        {
            throw new System.NotImplementedException();
        }
    }
}
