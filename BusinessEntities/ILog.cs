using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public interface ILog
    {
        int LogId { get; set; }
        DateTime Date { get; set; }
        string TableName { get; set; }
        int UserId { get; set; }
        string Action { get; set; }
    }
}
