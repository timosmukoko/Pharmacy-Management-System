using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Report : BusinessEntities.IReport
    {
        #region Instance Properties
        private int reportID;
        private int numTransactions;
        private double totalSales;
        private double totalTax;
        private DateTime startDate;
        private DateTime endDate;
        #endregion

        public int ReportID
        {
            get
            {
                return reportID; ;
            }
            set
            {
                reportID = value;
            }
        }

        public int NumTransactions
        {
            get
            {
                return numTransactions; ;
            }
            set
            {
                numTransactions = value;
            }
        }

        public double TotalSales
        {
            get
            {
                return totalSales; ;
            }
            set
            {
                totalSales = value;
            }
        }

        public double TotalTax
        {
            get
            {
                return totalTax; ;
            }
            set
            {
                totalTax = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return startDate; ;
            }
            set
            {
                startDate = value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return endDate; ;
            }
            set
            {
                endDate = value;
            }
        }

        #region Constructors
        public Report()
        {
            throw new System.NotImplementedException();
        }

        public Report(int reportID, int numTransactions, double totalSales,double totalTax, DateTime startDate, DateTime endDate)
        {
            this.reportID = reportID;
            this.numTransactions = numTransactions;
            this.totalSales = totalSales;
            this.totalTax = totalTax;
            this.startDate = startDate;
            this.endDate = endDate;
            
        }
        #endregion


    }
}
