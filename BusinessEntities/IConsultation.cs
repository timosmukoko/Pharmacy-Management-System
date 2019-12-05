using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public interface IConsultation
    {
        int ConID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Phone { get; set; }
        string DOB { get; set; }
        string Address { get; set; }
        string Symptoms { get; set; }
        string Date { get; set; }
        string Time { get; set; }
    }
}
