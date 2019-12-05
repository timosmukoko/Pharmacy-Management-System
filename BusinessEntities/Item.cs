using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
  
    public class Item: BusinessEntities.IItem
    {

        #region Instance Properties
        private int itemID;
        private string category;
        private string vendor;
        private int quantity;
        private double purchaseUnit;
        private string itemName;
        private string description;
        private double saleUnit;
        private int quantityPerBox;
        private string isDeleted;
        #endregion


        public int ItemID
        {
            get
            {
                return itemID; ;
            }
            set
            {
                itemID = value;
            }
        }

        public string Category
        {
            get
            {
                return category; ;
            }
            set
            {
                category = value;
            }
        }

        public string Vendor
        {
            get
            {
                return vendor; ;
            }
            set
            {
                vendor = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity; ;
            }
            set
            {
                quantity = value;
            }
        }

        public double PurchaseUnit
        {
            get
            {
                return purchaseUnit; ;
            }
            set
            {
                purchaseUnit = value;
            }
        }

        public string ItemName
        {
            get
            {
                return itemName; ;
            }
            set
            {
                itemName = value;
            }
        }

        public string Description
        {
            get
            {
                return description; ;
            }
            set
            {
                description = value;
            }
        }

        public double SaleUnit
        {
            get
            {
                return saleUnit; ;
            }
            set
            {
                saleUnit = value;
            }
        }

        

        public string IsDeleted
        {
            get
            {
                return isDeleted; ;
            }
            set
            {
                isDeleted = value;
            }
        }

        #region Constructors
        public Item()
        {
            throw new System.NotImplementedException();
        }

        public Item(int itemID, string category, string vendor, int quantity, double purchaseUnit, string itemName, string description, double saleUnit,  string isDeleted)
        {
            this.itemID = itemID;
            this.category = category;
            this.vendor = vendor;

            this.quantity = quantity;
            this.purchaseUnit = purchaseUnit;
            this.itemName = itemName;

            this.description = description;
            this.saleUnit = saleUnit;
           

            this.isDeleted = isDeleted;
        }

        #endregion




    }
}
