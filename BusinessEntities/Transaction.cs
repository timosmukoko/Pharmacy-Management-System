using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Transaction: BusinessEntities.ITransaction
    {
        #region Instance Properties
        private int transactionID;
        private int customerID;
        private int userID;
        private DateTime transactionDate;
        private double transactionCost;
        private double tax;
        private string paymentMethod;
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

        public int CustomerID
        {
            get
            {
                return customerID; ;
            }
            set
            {
                customerID = value;
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

        public DateTime TransactionDate
        {
            get
            {
                return transactionDate; ;
            }
            set
            {
                transactionDate = value;
            }
        }

        public double TransactionCost
        {
            get
            {
                return transactionCost; ;
            }
            set
            {
                transactionCost = value;
            }
        }

        public double Tax
        {
            get
            {
                return tax; ;
            }
            set
            {
                tax = value;
            }
        }

        public string PaymentMethod
        {
            get
            {
                return paymentMethod; ;
            }
            set
            {
                paymentMethod = value;
            }
        }

        #region Constructors
        public Transaction()
        {
            throw new System.NotImplementedException();
        }

        public Transaction(int transactionID, int customerID, int userID, DateTime transactionDate, double transactionCost,  string paymentMethod, double tax)
        {
            this.transactionID = transactionID;
            this.customerID = customerID;
            this.userID = userID;
            this.transactionDate = transactionDate;
            this.transactionCost = transactionCost;
            this.tax = tax;
            this.paymentMethod = paymentMethod;

        }
        #endregion
    }
}
