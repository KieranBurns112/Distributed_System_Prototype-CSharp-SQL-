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
    /// <summary>
    /// 
    /// Kieran Burns - 40272382
    /// 
    /// Class used in communicating between the PresentationLayer and DataLayer where the Inventory
    /// table of the database is concerned. Also contains the method for validating a modified item price
    /// to ensure it is the correct format for the database.
    /// 
    /// </summary>
    public class InventoryCommunication
    {   
        
        public ListBox loadInventoryData(int formType)
        {
            ListBox toFill = new ListBox();

            dbQuery dbConnect = new dbQuery();
            DataTable dbItems = dbConnect.priceControlItems();
            string sp = "   -   "; //Uniform spacing between items in listbox
            string addItem;

            //Load class with written names for offer types (instead of Id's)
            StandardAndLoyaltyOffers offers = new StandardAndLoyaltyOffers();

            //"formType" refers to the form that calls the function, 0 is PriceControl,
            //1 is LoyaltyCard.
            if (formType == 0)
            {
                toFill.Items.Add("Item Id" + sp + "Item Name" + sp + "Price" + sp + "Standard Offer");

                //Populate requested listbox with formatted data.
                foreach (DataRow row in dbItems.Rows)
                {
                    addItem = row[0] + sp + row[1] + sp + "£" + row[2] + sp + offers.getOfferName(Int32.Parse(row[3].ToString()));
                    toFill.Items.Add(addItem);
                }
            }
            else if (formType == 1)
            {
                toFill.Items.Add("Item Id" + sp + "Item Name" + sp + "Loyalty Offer");

                //Populate requested listbox with formatted data.
                foreach (DataRow row in dbItems.Rows)
                {
                    addItem = row[0] + sp + row[1] + sp + offers.getLoyaltyName(Int32.Parse(row[4].ToString()));
                    toFill.Items.Add(addItem);
                }
            }

            //Return the requested data.
            return toFill;
        }

        public inventoryItem getSingleItemById(int itemId)
        {
            inventoryItem requestedItem = new inventoryItem();

            try
            {
                //Attempt to populate an instance of the "inventoryItem" class with the information requested from
                //the database.
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
                //If "inventoryItem" is not properly populated, return a 0 as item Id
                //(read as an error by the PresentationLayer).
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

                //min price is £0.01, max price is £9999.99 in database.
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
            catch {}

            return priceIsValid;
        }

        public void sendPriceControlToUpdate(int id, string validatedPriceData, int offerNo)
        {
            //Send altered PriceControl form to database to update information.
            decimal price = decimal.Parse(validatedPriceData);

            dbQuery updateDB = new dbQuery();
            updateDB.updateItemPrice(id, price);
            updateDB.updateItemStandardOffer(id, offerNo);
        }

        public void sendLoyaltyToUpdate(int id, int loyaltyNo)
        {
            //Send altered LoyaltyCard information to database.
            dbQuery updateDB = new dbQuery();
            updateDB.updateItemLoyaltyOffer(id, loyaltyNo);
        }
        
    }
}
