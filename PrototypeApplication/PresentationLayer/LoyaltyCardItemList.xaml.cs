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
    /// Interaction Logic for the page which displays Id, Name and Loyalty Offer types of each item in the Inventory.
    /// 
    /// This page contains a listbox to display each of the above details, which can be clicked on to progress to 
    /// the inidividual page for the clicked on item, as well as a button to return to the previous page.
    /// 
    /// This page closely resembles that of "PriceControl", as the two would be part of the same page under most
    /// normal circumstances, however these two features are listed as seperate on the project specification so are
    /// seperated in this case.
    /// 
    /// </summary>
    public partial class LoyaltyCardItemList : Window
    {
        public LoyaltyCardItemList()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //Return to the previous page, closing this one.
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void LoyaltyListBox_Loaded(object sender, RoutedEventArgs e)
        {
            //Load the Data for the table from database. 
            InventoryCommunication accessData = new InventoryCommunication();
            ListBox toFill = accessData.loadInventoryData(2);

            //Add loaded data to listbox.
            foreach (var thisItem in toFill.Items)
            {
                LoyaltyListBox.Items.Add(thisItem);
            }
        }

        private void LoyaltyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //If an item is clicked on, save the item to a variable.
            int selectedItemId = LoyaltyListBox.SelectedIndex;

            //If the selected item is a valid item from the database (and not the header of the listbox).
            if (selectedItemId > 0)
            {
                //Open the page with the inidividual details of the clicked on item, closing this page.
                LoyaltyCardSingleItem loyaltyCardSingleItem = new LoyaltyCardSingleItem(selectedItemId);
                loyaltyCardSingleItem.Show();
                this.Close();
            }
        }
    }
}
