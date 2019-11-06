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
    /// Interaction logic for PriceControlSingleItem.xaml
    /// </summary>
    public partial class PriceControlSingleItem : Window
    {
        private int passedInId = 0;
        private bool itemLoaded = false;

        public PriceControlSingleItem(int itemId)
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

                //Set price box text to current price from database
                PriceBox.Text = requestedItem.Item_Price.ToString();

                //Get a list of all offer names (in order) from offers class 
                StandardAndLoyaltyOffers offers = new StandardAndLoyaltyOffers();
                string[] offersList = offers.getAllOfferNames();
                
                //Populate ComboBox with all offer types
                for (int i = 0; i < offersList.Length; i++)
                {
                    offerComboBox.Items.Add(offersList[i]);
                }

                //Set actively displayed item to current offer selection from database
                offerComboBox.SelectedIndex = requestedItem.Standard_Offer;
       
                itemLoaded = true;
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            //Check if an item is loaded to have it's information changed
            if (itemLoaded)
            {
                //Get contents of form
                string priceBoxContent = PriceBox.Text;
                int selectedOfferNo = offerComboBox.SelectedIndex;

                //Load class with price validation and send to DB methods
                InventoryCommunication validateAndSend = new InventoryCommunication();

                //check if price is valid
                bool priceValid = validateAndSend.validatePrice(priceBoxContent);

                if (priceValid)
                {
                    validateAndSend.sendPriceControlToUpdate(passedInId, priceBoxContent, selectedOfferNo);

                    MessageBox.Show("Details Updated!");
                }
                else
                {
                    MessageBox.Show("Price Invalid! Must be a number in the form PPPP.pp (eg/ 15.42) between 0.01 and 9999.99");
                }
            }
            else
            {
                MessageBox.Show("No item record loaded to be modified!");
            }   
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            PriceControl priceControl = new PriceControl();
            priceControl.Show();
            this.Close();
        }

    }
}