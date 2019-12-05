using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public static class Roster_has_employeesFactory
    {
        private static IRoster_has_employees roster = null;

        public static IRoster_has_employees GetRoster_has_employees(int rosterID, int employeeID)
        {
            if (roster != null)  // ie is Factory is primed with an object. 
                return roster;
            else
                return new Roster_has_employees(rosterID, employeeID); // Factory coughs up a regular user (for production code) 
        }
        public static void SetRoster_has_employees(IRoster_has_employees aRoster)   // This provides a seam in the factory where I can prime the factory with the user it will then cough up. (for test code) 
        {
            roster = aRoster;
        }
    }
}
