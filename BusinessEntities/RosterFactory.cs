using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public static class RosterFactory
    {
        private static IRoster roster = null;

        public static IRoster GetRoster(int rosterID, int weekNumber, string day, string name)
        {
            if (roster != null)  // ie is Factory is primed with an object. 
                return roster;
            else
                return new Roster(rosterID, weekNumber, day, name); // Factory coughs up a regular user (for production code) 
        }
        public static void SetRoster(IRoster aRoster)   // This provides a seam in the factory where I can prime the factory with the user it will then cough up. (for test code) 
        {
            roster = aRoster;
        }
    }
}
