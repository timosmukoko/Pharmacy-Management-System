using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public static class TransactionFactory
    {
        private static ITransaction transaction = null;

        public static ITransaction GetTransaction(int transactionID, int customerID, int userID, DateTime transactionDate, double transactionCost,  string paymentMethod, double tax)
        {
            if (transaction != null)  // ie is Factory is primed with an object. 
                return transaction;
            else
                return new Transaction(transactionID, customerID, userID, transactionDate, transactionCost, paymentMethod, tax); // Factory coughs up a regular user (for production code) 
        }
        public static void SetTransaction(ITransaction aTransaction)   // This provides a seam in the factory where I can prime the factory with the user it will then cough up. (for test code) 
        {
            transaction = aTransaction;
        }
    }
}
