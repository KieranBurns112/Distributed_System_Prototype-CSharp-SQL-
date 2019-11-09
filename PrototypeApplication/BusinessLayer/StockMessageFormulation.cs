using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DataLayer;

namespace BusinessLayer
{
    /// <summary>
    /// 
    /// Kieran Burns - 40272382
    /// 
    /// Class used to calculate all stock items from the inventory database table which are eleigable to have a 
    /// "low stock" or "no stock" warning message sent to the store manager's inbox.
    /// 
    /// </summary>
    public class StockMessageFormulation
    {
        //Threshold for low stock warning - Low Stock message triggers when stock is less than or equal to "lowStockThreshold".
        private int lowStockThreshold = 5;

        public ListBox getAllMessages(int messageType, int storeId)
        {
            ListBox allMessages = new ListBox();

            InventoryCommunication itemInformationRequests = new InventoryCommunication();
            inventoryItem currentItem = new inventoryItem(); 

            int totalItems = itemInformationRequests.inventoryItemCount();
            int currentId;
            string thisStockMessage = "";

            //Loop through each different item from the inventory database table.
            for (int i = 0; i < totalItems; i++)
            {
                //Set loop variables back to default values.
                currentId = i + 1;

                currentItem = itemInformationRequests.getSingleItemById(currentId);

                //Message type 0 refers to messages to send to the managers inbox,
                //type 1 refers to a stock request to the central system.
                if (messageType == 0)
                {
                    thisStockMessage = formulateManagerMessage(currentItem);
                }
                else if (messageType == 1)
                {
                    thisStockMessage = formulateRequestToCentral(currentItem, storeId);
                }
              
                //If one of the two stock messages were generated, the generated message to the list of stock warnings.
                if (thisStockMessage != "")
                {
                    allMessages.Items.Add(thisStockMessage);
                }
            }

            //Return all the stock warnings.
            return allMessages;
        }

        private string formulateManagerMessage(inventoryItem item)
        {
            string stockMessage = "";

            //If an item is whithin the "low stock" threshold, generale a low stock message.
            if (item.Item_Stock <= lowStockThreshold && item.Item_Stock > 0)
            {
                stockMessage = "Low Stock Warning: " + item.Item_Name + " (Id: " + item.Item_Id + ")";
            }
            //If an item has specifically NO stock, generate a unique message.
            else if (item.Item_Stock == 0)
            {
                stockMessage = "Out of Stock Warning: " + item.Item_Name + " (Id: " + item.Item_Id + ")";
            }

            return stockMessage;
        }
        private string formulateRequestToCentral(inventoryItem item, int storeId)
        {
            string stockMessage = "";

            //If an item has no stock, generate a stock request.
            if (item.Item_Stock == 0)
            {
                stockMessage = "Automated Stock Request: " + item.Item_Name + " (Item Id: " + item.Item_Id + ") from Store " + storeId;
            }

            return stockMessage;
        }
    }
}
