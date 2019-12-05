using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public static class ReportFactory
    {
        private static IReport report = null;

        public static IReport GetReport(int reportID, int numTransactions, double totalSales, double totalTax, DateTime startDate, DateTime endDate)
        {
            if (report != null)  // ie is Factory is primed with an object. 
                return report;
            else
                return new Report(reportID,  numTransactions,  totalSales,  totalTax,  startDate,  endDate); // Factory coughs up a regular user (for production code) 
        }
        public static void SetReport(IReport aReport)   // This provides a seam in the factory where I can prime the factory with the user it will then cough up. (for test code) 
        {
            report = aReport;
        }
    }
}
