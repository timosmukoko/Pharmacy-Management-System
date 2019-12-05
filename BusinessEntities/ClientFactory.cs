using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public static class ClientFactory
    {
        private static IClient Client = null;

        public static IClient GetClient(string PPS, string firsName, string lastName, string street, string county, string country, string phone, string medicalCardHolder, string cardNumber, string nextOfKinName, string nextOfKinPhone, int gpID)
        {
            if (Client != null)
                return Client;
            else
                return new Client(PPS, firsName, lastName, street, county, country, phone, medicalCardHolder, cardNumber, nextOfKinName, nextOfKinPhone, gpID);
        }

        public static void SetClient(IClient aClient)
        {
            Client = aClient;
        }
    }
}
