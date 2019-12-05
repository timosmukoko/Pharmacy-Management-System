using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Day : BusinessEntities.IDay
    {
        #region Instance Properties
        private int dayID;
        private string dayName;
        #endregion
        public int DayID
        {
            get
            {
                return dayID; ;
            }
            set
            {
                dayID = value;
            }
        }

        public string DayName
        {
            get
            {
                return dayName; ;
            }
            set
            {
                dayName = value;
            }
        }

        #region Constructors
        public Day()
        {
            throw new System.NotImplementedException();
        }

        public Day(int dayID, string dayName)
        {
            this.dayID = dayID;
            this.dayName = dayName;
           
        }
        #endregion
    }

}

