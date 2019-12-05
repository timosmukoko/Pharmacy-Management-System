using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public interface IRoster_has_employees
    {
        int RosterID { get; set; }
        int EmployeeID { get; set; }

        
    }
}
