using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public static class LogFactory
    {
        private static ILog log = null;

        public static ILog GetLog(int logId, DateTime date, string tableName, int userId, string action)
        {
            if (log != null)  // ie is Factory is primed with an object. 
                return log;
            else
                return new Log(logId, date, tableName, userId, action); // Factory coughs up a regular user (for production code) 
        }
        public static void SetLog(ILog alog)   // This provides a seam in the factory where I can prime the factory with the user it will then cough up. (for test code) 
        {
            log = alog;
        }
    }
}
