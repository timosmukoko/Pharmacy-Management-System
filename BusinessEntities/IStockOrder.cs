using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public interface IStockOrder
    {
        int StockOrderID { get; set; }
        int UserID { get; set; }
        string Date { get; set; }
    }
}
