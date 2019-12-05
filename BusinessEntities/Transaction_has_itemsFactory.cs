using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public static class Transaction_has_itemsFactory
    {
        private static ITransaction_has_items transaction_has_items = null;

        public static ITransaction_has_items GetItemInTransaction(int transactionID, int itemID)
        {
            if (transaction_has_items != null)  // ie is Factory is primed with an object. 
                return transaction_has_items;
            else
                return new Transaction_has_items(transactionID, itemID); // Factory coughs up a regular user (for production code) 
        }
        public static void SetItemsInTransaction(ITransaction_has_items aItemInTransaction)   // This provides a seam in the factory where I can prime the factory with the user it will then cough up. (for test code) 
        {
            transaction_has_items = aItemInTransaction;
        }
    }
}
