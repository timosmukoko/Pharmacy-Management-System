using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public interface IItem
    {
        int ItemID { get; set; }
        string Category { get; set; }
        string Vendor { get; set; }
        int Quantity { get; set; }
        double PurchaseUnit { get; set; }
        string ItemName { get; set; }
        string Description { get; set; }
        double SaleUnit { get; set; }
        string IsDeleted { get; set; }
    }
}
