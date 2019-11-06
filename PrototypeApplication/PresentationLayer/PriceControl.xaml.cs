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
using System.Data.Common;

namespace PresentationLayer
{
    /// <summary>
    /// 
    /// Kieran Burns - 40272382
    /// 
    /// Interaction Logic for the page which displays Id, Name, Price and Standard Offer types of each item in 
    /// the Inventory.
    /// 
    /// This page contains a listbox to display each of the above details, which can be clicked on to progress to 
    /// the inidividual page for the clicked on item, as well as a button to return to the previous page.
    /// 
    /// </summary>
    public partial class PriceControl : Window
    {
        public PriceControl()
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

        private void PriceControlListBox_Loaded(object sender, RoutedEventArgs e)
        {
            //Load the Data for the table from database. 
            InventoryCommunication accessData = new InventoryCommunication();
            ListBox toFill = accessData.loadInventoryData(0);

            //Add loaded data to listbox.
            foreach (var thisItem in toFill.Items)
            {
                PriceControlListBox.Items.Add(thisItem);
            }
        }

        private void PriceControlListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //If an item is clicked on, save the item to a variable.
            int selectedItemId = PriceControlListBox.SelectedIndex;

            //If the selected item is a valid item from the database (and not the header of the listbox).
            if(selectedItemId > 0)
            {
                //Open the page with the inidividual details of the clicked on item, closing this page.
                PriceControlSingleItem priceControlSingleItem = new PriceControlSingleItem(selectedItemId);
                priceControlSingleItem.Show();
                this.Close(); 
           }
        }
    }
}
