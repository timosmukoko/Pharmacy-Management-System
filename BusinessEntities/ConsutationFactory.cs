using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public static class ConsultationFactory
    {
        private static IConsultation consultation = null;

        public static IConsultation GetCon(int conID, string firstName, string lastName, string phone, string dob, string address, string symptoms, string date, string time)
        {
            if (consultation != null)  // ie is Factory is primed with an object. 
                return consultation;
            else
                return new Consultation(conID, firstName, lastName, phone, dob, address, symptoms, date, time); // Factory coughs up a regular user (for production code) 
        }
        public static void SetCon(IConsultation aCon)   // This provides a seam in the factory where I can prime the factory with the user it will then cough up. (for test code) 
        {
            consultation = aCon;
        }
    }
}
