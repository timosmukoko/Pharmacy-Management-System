using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public interface ITransaction
    {
        int TransactionID { get; set; }
        int CustomerID { get; set; }
        int UserID { get; set; }
        DateTime TransactionDate { get; set; }
        double TransactionCost { get; set; }
        double Tax { get; set; }
        string PaymentMethod { get; set; }
    }
}
