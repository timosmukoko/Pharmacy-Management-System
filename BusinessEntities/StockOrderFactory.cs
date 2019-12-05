using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public static class StockOrderFactory
    {
        private static IStockOrder StockOrder = null;

        public static IStockOrder GetStockOrder(int stockOrderID, int UserID, string date)
        {
            if (StockOrder != null)
                return StockOrder;
            else
                return new StockOrder(stockOrderID, UserID, date);
        }

        public static void SetStockOrder(IStockOrder aStockOrder)
        {
            StockOrder = aStockOrder;
        }
    }
}
