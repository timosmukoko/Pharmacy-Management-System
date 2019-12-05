using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public interface IReport
    {
         int ReportID { get; set; }
         int NumTransactions { get; set; }
         double TotalSales { get; set; }
         double TotalTax { get; set; }
         DateTime StartDate { get; set; }
         DateTime EndDate { get; set; }
    }
}
