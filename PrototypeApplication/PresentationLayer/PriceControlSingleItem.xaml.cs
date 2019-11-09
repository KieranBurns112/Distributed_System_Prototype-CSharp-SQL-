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
    /// Interaction Logic for the page which allows the user to modify the price and active offer of a selected item.
    /// 
    /// This page contains an inputbox for the price to be entered and a dropdown box to use when selecting 
    /// a new offer to replace the active one, as well as buttons to return to the previous page, and to confirm 
    /// the new selection.
    /// 
    /// </summary>
    public partial class PriceControlSingleItem : Window
    {
        //Variables used within muliple methods of the class.
        private int passedInId = 0;
        private bool itemLoaded = false;

        public PriceControlSingleItem(int itemId)
        {
            //Set local variable of Id to passed in Id.
            passedInId = itemId;

            InitializeComponent();

            //Create instances of required BusinessLayer Classes.
            InventoryCommunication dataCommunication = new InventoryCommunication();
            inventoryItem requestedItem = new inventoryItem();

            //Request the details of the item which had its Id passed in.
            requestedItem = dataCommunication.getSingleItemById(passedInId);

            //If item couldn't be found, display and error message.
            if (requestedItem.Item_Id == 0)
            {
                MessageBox.Show("Error Loading Record!");
            }
            else
            {
                //Set heading to item name.
                ItemNameLabel.Content = requestedItem.Item_Name;

                //Set price box text to current price from database.
                PriceBox.Text = requestedItem.Item_Price.ToString();

                //Get a list of all offer names (in order) from offers class.
                StandardAndLoyaltyOffers offers = new StandardAndLoyaltyOffers();
                string[] offersList = offers.getAllOfferNames();
                
                //Populate ComboBox with all offer types.
                for (int i = 0; i < offersList.Length; i++)
                {
                    offerComboBox.Items.Add(offersList[i]);
                }

                //Set actively displayed item to current offer selection from database.
                offerComboBox.SelectedIndex = requestedItem.Standard_Offer;

                //Confirm an item was found (for later use).
                itemLoaded = true;
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            //Check to ensure an item has been found to be modified.
            if (itemLoaded)
            {
                //Get contents of form.
                string priceBoxContent = PriceBox.Text;
                int selectedOfferNo = offerComboBox.SelectedIndex;

                //Instantiate BusinessLayer Class with price validation and send to DB methods.
                InventoryCommunication validateAndSend = new InventoryCommunication();

                //check if price is valid.
                bool priceValid = validateAndSend.validatePrice(priceBoxContent);

                if (priceValid)
                {
                    //Send changes to get updated in the database.
                    validateAndSend.sendPriceControlToUpdate(passedInId, priceBoxContent, selectedOfferNo);

                    //Confirm the database was updated.
                    MessageBox.Show("Details Updated!");
                }
                else
                {
                    //If Price isn't valid, display appropriate error message.
                    MessageBox.Show("Price Invalid! Must be a number in the form PPPP.pp (eg/ 15.42) between 0.01 and 9999.99");
                }
            }
            else
            {
                //If item isn't loaded to be modified, display approprated error message.
                MessageBox.Show("No item record loaded to be modified!");
            }   
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //Return to the previous page, closing this one.
            PriceControl priceControl = new PriceControl();
            priceControl.Show();
            this.Close();
        }
    }
}