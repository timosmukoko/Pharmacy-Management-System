using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class StockOrder : BusinessEntities.IStockOrder
    {
        #region Instance Properties
        private int stockOrderID;
        private int userID;
        private string date;
        #endregion

        public int StockOrderID
        {
            get { return stockOrderID; }
            set { stockOrderID = value; }
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        #region Constructors
        public StockOrder()
        {
            throw new System.NotImplementedException();
        }
        public StockOrder(int stockOrderID, int userID, string date)
        {
            this.stockOrderID = stockOrderID;
            this.userID = userID;
            this.date = date;

        }
        #endregion
    }
}

