using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public interface IEmployee
    {
        int EmployeeID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Address { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
        string NextOfKinName { get; set; }
        string NextOfKinPhone { get; set; }
        decimal Salery { get; set; }
        int UserID { get; set; }
        string Usertype { get; set; }
    }
}
