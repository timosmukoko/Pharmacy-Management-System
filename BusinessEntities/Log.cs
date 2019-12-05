using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Log : BusinessEntities.ILog
    {
        #region Instance Properties
        private int logId;
        private DateTime date;
        private string tableName;
        private int userId;
        private string action;
        #endregion

        public int LogId
        {
            get
            {
                return logId;
            }
            set
            {
                logId = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }

        public string TableName
        {
            get
            {
                return tableName;
            }
            set
            {
                TableName = value;
            }
        }

        public int UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
            }
        }

        public string Action
        {
            get
            {
                return action;
            }
            set
            {
                action = value;
            }
        }
        #region Constructors
        public Log()
        {
            throw new System.NotImplementedException();
        }

        public Log(int logId, DateTime date,string tableName, int userId, string action)
        {
            this.logId = logId;
            this.date = date;
            this.tableName = tableName;
            this.userId = userId;
            this.action = action;
            
        }
        #endregion
    }
}
