using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public static class PrescriptionFactory
    {
        private static IPrescription Prescription  = null;

        public static IPrescription GetPrescription(int prescriptionID, string drugName, DateTime dateWritten, DateTime dateProcessed, DateTime dateDispensed, DateTime dateExpires, string instruction, int quantityWritten, int quantityDispensed, string drudCategory, int userID, string clientID, int gpID)
        {
            if (Prescription != null)
                return Prescription;
            else
                return new Prescription(prescriptionID, drugName, dateWritten, dateProcessed, dateDispensed, dateExpires, instruction, quantityWritten, quantityDispensed, drudCategory, userID, clientID, gpID);
        }

        public static void SetClient(IPrescription aPrescription)
        {
            Prescription = aPrescription;
        }
    }
}
