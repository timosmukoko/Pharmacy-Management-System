using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public static class ItemFactory
    {
        private static IItem item = null;

        public static IItem GetItem(int itemID, string category, string vendor, int quantity, double purchaseUnit, string itemName, string description, double saleUnit, string isDeleted)
        {
            if (item != null)  // ie is Factory is primed with an object. 
                return item;
            else
                return new Item( itemID,  category,  vendor,  quantity,  purchaseUnit,  itemName,  description,  saleUnit,   isDeleted); // Factory coughs up a regular user (for production code) 
        }
        public static void SetItem(IItem aItem)   // This provides a seam in the factory where I can prime the factory with the user it will then cough up. (for test code) 
        {
            item = aItem;
        }
    }
}
