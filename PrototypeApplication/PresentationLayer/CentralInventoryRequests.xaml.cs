using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessLayer;

namespace PresentationLayer
{
    /// <summary>
    /// 
    /// Kieran Burns - 40272382
    /// 
    /// Interaction Logic for the Central Inventory Stock requests page, a page used to simulate the concept
    /// of the central inventory, a seperate system where all items which are out of stock automatically
    /// request more.
    /// 
    /// Visually similar to "ManagerMobileMessageBox" within this prototype to save on development time as
    /// the two are functionally very similar in this iteration of DE-System.
    /// 
    /// "thisStoreId" is passed in as an identifier to send to the Central Inventory system to flag which
    /// store's instance of DE-Store is sending the request for more stock.
    /// 
    /// </summary>
    public partial class CentralInventoryRequests : Window
    {
        public CentralInventoryRequests(int thisStoreId)
        {
            InitializeComponent();

            //Call the method that populates the ListBox used to represent any stock requests sent to central.
            getRequests(thisStoreId);
        }

        private void getRequests(int storeId)
        {
            StockMessageFormulation requests = new StockMessageFormulation();

            ListBox recievedRequests = requests.getAllMessages(1, storeId);

            //Display all formulated Requests.
            //Spacings were added between each item for the sake of readability.
            foreach (var item in recievedRequests.Items)
            {
                MessageListBox.Items.Add(item);
                MessageListBox.Items.Add("");
            }
        }
    }
}
