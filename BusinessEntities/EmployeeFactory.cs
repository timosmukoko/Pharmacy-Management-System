using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public static class EmployeeFactory
    {
        private static IEmployee employee = null;

        public static IEmployee GetEmployee(int employeeID, int userID, string firstName, string lastName, string address, string phone, string email, string nextOfKinName, string nextOfKinPhone, decimal salery, string usertype)
        {
            if (employee != null)  // ie is Factory is primed with an object. 
                return employee;
            else
                return new Employee(employeeID, userID, firstName, lastName, address, phone, email, nextOfKinName, nextOfKinPhone, salery,  usertype); // Factory coughs up a regular user (for production code) 
        }
        public static void SetEmployee(IEmployee aEmployee)   // This provides a seam in the factory where I can prime the factory with the user it will then cough up. (for test code) 
        {
            employee = aEmployee;
        }
    }
}
