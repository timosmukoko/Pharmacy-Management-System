using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public interface ISupplier
    {
        //michael horgan
        //lorcan
        string supplierID { get; set; }
        string companyName { get; set; }
        string email { get; set; }
        string phone { get; set; }
        string street { get; set; }
        string city { get; set; }
        string county { get; set; }
        string country { get; set; }
    }
}

