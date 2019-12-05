using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public static class SupplierFactory
    {
        private static ISupplier Supplier = null;

        public static ISupplier GetSupplier(string SupplierID, string CompanyName, string Email, string Phone, string Street, string City, string County, string Country)
        {
            if (Supplier != null)
                return Supplier;
            else
                return new Supplier(SupplierID, CompanyName, Email, Phone, Street, City, County, Country);
        }

        public static void SetSupplier(ISupplier aSupplier)
        {
            Supplier = aSupplier;
        }
    }
}
