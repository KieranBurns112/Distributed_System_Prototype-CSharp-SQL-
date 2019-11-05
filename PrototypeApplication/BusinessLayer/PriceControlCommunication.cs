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
        
        public ListBox loadPriceControlData()
        {
            ListBox toFill = new ListBox();

            dbQuery dbConnect = new dbQuery();
            DataTable dbItems = dbConnect.priceControlItems();
            string sp = "   -   "; //Uniform spacing between items in listbox
            string addItem;

            //Load class with written names for offer types (instead of Id's)
            StandardAndLoyaltyOffers offers = new StandardAndLoyaltyOffers();

            //Heading for listbox's first line
            toFill.Items.Add("Item Id" + sp + "Item Name" + sp + "Price" + sp + "Standard Offer" + sp + "Loyalty Offer" + sp + "Stock");

            foreach (DataRow row in dbItems.Rows)
            {
                //Add all parts together to make full lines that each align [[ALIGNMENT MODIFICATIONS REQUIRED!!!]]
                addItem = row[0] + sp + row[1] + sp + row[2] + sp + offers.getOfferName(Int32.Parse(row[3].ToString())) + sp +
                    offers.getLoyaltyName(Int32.Parse(row[4].ToString())) + sp + row[5];

                toFill.Items.Add(addItem);
            }

            return toFill;
        }

        public inventoryItem getSingleItem(int itemId)
        {
            inventoryItem requestedItem = new inventoryItem();

            try
            {
                dbQuery dbConnect = new dbQuery();
                DataTable dbRequest = dbConnect.requestInventoryItem(itemId);

                requestedItem.Item_Id = Int32.Parse((dbRequest.Rows[0][0]).ToString());
                requestedItem.Item_Name = (dbRequest.Rows[0][1]).ToString();
                requestedItem.Item_Price = decimal.Parse((dbRequest.Rows[0][2]).ToString());
                requestedItem.Standard_Offer = Int32.Parse((dbRequest.Rows[0][3]).ToString());
                requestedItem.Loyalty_Offer = Int32.Parse((dbRequest.Rows[0][4]).ToString());
                requestedItem.Item_Stock = Int32.Parse((dbRequest.Rows[0][0]).ToString());
            }
            catch
            {
                requestedItem.Item_Id = 0;
            }
           
            return requestedItem;
        }

        public bool validatePrice(string priceData)
        {
            bool priceIsValid = false;

            try
            {
                decimal price = decimal.Parse(priceData);

                //min price is £0.01, max price is £9999.99 in database
                if (price > 0 && price < 10000)
                {
                    string[] decimalPointSplit = priceData.Split(new char[] { '.' });
                    int numAfterSplit = decimalPointSplit[1].Length;
                    if (numAfterSplit == 2)
                    {
                        priceIsValid = true;
                    }
                }
            }
            catch{}

            return priceIsValid;
        }

        public void sendDetailsToUpdate(int id, string validatedPriceData, int offerNo)
        {
            decimal price = decimal.Parse(validatedPriceData);

            dbQuery updateDB = new dbQuery();
            updateDB.updateItemPrice(id, price);
            updateDB.updateItemStandardOffer(id, offerNo);
        }
    }
}
