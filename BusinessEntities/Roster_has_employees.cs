using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Roster_has_employees : BusinessEntities.IRoster_has_employees
    {
        #region Instance Properties
        private int rosterID;
        private int employeeID;
        
        #endregion

        public int RosterID
        {
            get
            {
                return rosterID; ;
            }
            set
            {
                rosterID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return employeeID; ;
            }
            set
            {
                employeeID = value;
            }
        }

        

        #region Constructors
        public Roster_has_employees()
        {
            throw new System.NotImplementedException();
        }

        public Roster_has_employees(int rosterID, int employeeID)
        {
            this.rosterID = rosterID;
            this.employeeID = employeeID;
         
        }
        #endregion
    }
}
