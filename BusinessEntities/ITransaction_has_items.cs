using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public interface ITransaction_has_items
    {
        int TransactionID { get; set; }
        int ItemID { get; set; }
        
    }
}
