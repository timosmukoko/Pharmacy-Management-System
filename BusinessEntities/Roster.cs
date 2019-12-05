using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Roster : BusinessEntities.IRoster
    {
        #region Instance Properties
        private int rosterID;
        private int weekNumber;
        private string day;
        private string name;
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

        public int WeekNumber
        {
            get
            {
                return weekNumber; ;
            }
            set
            {
                weekNumber = value;
            }
        }

        public string Day
        {
            get
            {
                return day; ;
            }
            set
            {
                day = value;
            }
        }


            public string Name
        {
            get
            {
                return name; ;
            }
            set
            {
                name = value;
            }
        }

        #region Constructors
        public Roster()
        {
            throw new System.NotImplementedException();
        }

        public Roster(int rosterID, int weekNumber, string day, string name )
        {
            this.rosterID = rosterID;
            this.weekNumber = weekNumber;
            this.day = day;
            this.name = name;
        }
        #endregion

    }

}
