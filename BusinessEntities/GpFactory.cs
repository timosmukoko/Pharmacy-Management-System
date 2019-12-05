using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public static class GpFactory
    {
        private static IGp gp = null;

        public static IGp GetGp(int gpID, string firstName, string lastName, string address, string phone, string email)
        {
            if (gp != null)  // ie is Factory is primed with an object. 
                return gp;
            else
                return new Gp(gpID, firstName, lastName, address, phone, email); // Factory coughs up a regular user (for production code) 
        }
        public static void SetGp(IGp aGp)   // This provides a seam in the factory where I can prime the factory with the user it will then cough up. (for test code) 
        {
            gp = aGp;
        }
    }
}
