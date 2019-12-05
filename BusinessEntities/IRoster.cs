using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public interface IRoster
    {
        int RosterID { get; set; }
        int WeekNumber { get; set; }
        string Day { get; set; }
        string Name { get; set; }
    }
}
