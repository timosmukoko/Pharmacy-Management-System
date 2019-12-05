using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public interface IClient
    {
        string Pps { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Street { get; set; }
        string County { get; set; }
        string Country { get; set; }
        string Phone { get; set; }
        string MedicalCardHolder { get; set; }
        string CardNumber { get; set; }
        string NextOfKinName { get; set; }
        string NextOfKinPhone { get; set; }
        string ImageLocation { get; set; }
        int GpID { get; set; }
    }
}
