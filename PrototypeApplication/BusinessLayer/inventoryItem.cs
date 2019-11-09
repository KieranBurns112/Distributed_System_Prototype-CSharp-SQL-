using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    /// <summary>
    /// 
    /// Kieran Burns - 40272382
    /// 
    /// Class with Get Set values for each heading in the Inventory database, to be used
    /// when passing "raw" database rows from the BusinessLayer to the PresentationLayer.
    /// 
    /// </summary>
    public class inventoryItem
    {
        private int _itemId;
        private string _itemName;
        private decimal _itemPrice;
        private int _standardOffer;
        private int _loyaltyOffer;
        private int _itemStock;

        public int Item_Id
        {
            get
            {
                return _itemId;
            }
            set
            {
                _itemId = value;
            }
        }

        public string Item_Name
        {
            get
            {
                return _itemName;
            }
            set
            {
                _itemName = value;
            }
        }

        public decimal Item_Price
        {
            get
            {
                return _itemPrice;
            }
            set
            {
                _itemPrice = value;
            }
        }

        public int Standard_Offer
        {
            get
            {
                return _standardOffer;
            }
            set
            {
                _standardOffer = value;
            }
        }

        public int Loyalty_Offer
        {
            get
            {
                return _loyaltyOffer;
            }
            set
            {
                _loyaltyOffer = value;
            }
        }

        public int Item_Stock
        {
            get
            {
                return _itemStock;
            }
            set
            {
                _itemStock = value;
            }
        }
    }
}
