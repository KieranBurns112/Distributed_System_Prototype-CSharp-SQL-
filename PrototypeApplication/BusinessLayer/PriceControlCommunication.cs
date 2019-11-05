using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DataLayer;
using System.Windows;
using System.Data;

namespace BusinessLayer
{
    public class PriceControlCommunication
    {   
        private string getOfferName(int offerInt)
        {
            string standardOffer;

            //Get plaintext name for standard offer type
            if (offerInt == 1)
            {
                standardOffer = "Buy 1 Get 1 Free";
            }
            else
            {
                standardOffer = "No Offer";
            }

            return standardOffer;
        }

        private string getLoyaltyRewardName(int loyaltyInt)
        {
            string loyaltyOffer;
        
            //Get plaintext name for standard offer type
            if (loyaltyInt == 1)
            {
                loyaltyOffer = "50% Off";
            }
            else
            {
                loyaltyOffer = "No Offer";
            }

            return loyaltyOffer;
        }


        public ListBox loadPriceControlData()
        {
            ListBox toFill = new ListBox();

            dbQuery dbConnect = new dbQuery();
            DataTable dbItems = dbConnect.priceControlItems();
            string sp = "   -   "; //Uniform spacing between items in listbox
            string addItem;


            toFill.Items.Add("Item Id" + sp + "Item Name" + sp + "Price" + sp + "Standard Offer" + sp + "Loyalty Offer" + sp + "Stock");
            foreach (DataRow row in dbItems.Rows)
            {


                //Add all parts together to make full name
                addItem = row[0] + sp + row[1] + sp + row[2] + sp + getOfferName(Int32.Parse(row[3].ToString())) + sp +
                    getLoyaltyRewardName(Int32.Parse(row[4].ToString())) + sp + row[5];

                toFill.Items.Add(addItem);
            }

            return toFill;
        }
    }
}
