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
    /// Interaction Logic for the page which allows the user to modify the active loyalty offer of a selected item.
    /// 
    /// This page contains a dropdown box to use when selecting a new offer to replace the active one,
    /// as well as buttons to return to the previous page, and to confirm the new selection.
    /// 
    /// This page closely resembles that of "PriceControlSingleItem", as the two would be part of the same page under
    /// most normal circumstances, however these two features are listed as seperate on the project specification 
    /// so are seperated in practice.
    /// 
    /// </summary>
    public partial class LoyaltyCardSingleItem : Window
    {
        private int passedInId = 0;
        private bool itemLoaded = false;

        public LoyaltyCardSingleItem(int itemId)
        {
            passedInId = itemId;
            InitializeComponent();

            InventoryCommunication dataCommunication = new InventoryCommunication();
            inventoryItem requestedItem = new inventoryItem();

            requestedItem = dataCommunication.getSingleItemById(passedInId);

            if (requestedItem.Item_Id == 0)
            {
                MessageBox.Show("Error Loading Record!");
            }
            else
            {
                //Set heading to item name
                ItemNameLabel.Content = requestedItem.Item_Name;

                //Get a list of all offer names (in order) from offers class 
                StandardAndLoyaltyOffers offers = new StandardAndLoyaltyOffers();
                string[] offersList = offers.getAllLoyaltyNames();

                //Populate ComboBox with all offer types
                for (int i = 0; i < offersList.Length; i++)
                {
                    offerComboBox.Items.Add(offersList[i]);
                }

                //Set actively displayed item to current offer selection from database
                offerComboBox.SelectedIndex = requestedItem.Loyalty_Offer;

                itemLoaded = true;
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (itemLoaded)
            {
                int selectedLoyaltyNo = offerComboBox.SelectedIndex;
                InventoryCommunication sendUpdate = new InventoryCommunication();
                sendUpdate.sendLoyaltyToUpdate(passedInId, selectedLoyaltyNo);
                MessageBox.Show("Details Updated!");
            }
            else
            {
                MessageBox.Show("No item record loaded to be modified!");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            LoyaltyCardItemList loyaltyOffers = new LoyaltyCardItemList();
            loyaltyOffers.Show();
            this.Close();
        }
    }
}
