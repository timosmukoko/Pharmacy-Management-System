using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public static class DayFactory
    {
        private static IDay day = null;

        public static IDay GetDay(int dayID, string dayName)
        {
            if (day != null)  // ie is Factory is primed with an object. 
                return day;
            else
                return new Day(dayID,  dayName); // Factory coughs up a regular user (for production code) 
        }
        public static void SetDay(IDay aDay)   // This provides a seam in the factory where I can prime the factory with the user it will then cough up. (for test code) 
        {
            day = aDay;
        }
    }
}
