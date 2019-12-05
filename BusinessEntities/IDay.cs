using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public interface IDay
    {
        int DayID { get; set; }
        string DayName { get; set; }
    }
}
