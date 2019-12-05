using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Transaction_has_items:BusinessEntities.ITransaction_has_items
    {
        #region Instance Properties
        private int transactionID;
        private int itemID;
        #endregion

        public int TransactionID
        {
            get
            {
                return transactionID; ;
            }
            set
            {
                transactionID = value;
            }
        }

        public int ItemID
        {
            get
            {
                return itemID; ;
            }
            set
            {
                itemID = value;
            }
        }

        #region Constructors
        public Transaction_has_items()
        {
            throw new System.NotImplementedException();
        }

        public Transaction_has_items(int transactionID, int itemID)
        {
            this.transactionID = transactionID;
            this.itemID = itemID;

        }

        #endregion
    }
}
