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
    /// Interaction Logic for the page which displays the Names, Id and Current Stock of each item in the Inventory database
    /// 
    /// This page contains a listbox to display each of the above details.
    /// 
    /// The page visually resembles that of "PriceControl" as a means of saving development time by copying the 
    /// template of that page. This page however does not contain the same level of interaction as that of 
    /// "PriceControl", as this is a simple visual interface for users to simply observe stock levels.
    /// 
    /// </summary>
    public partial class StockMonitor : Window
    {
        public StockMonitor()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //Close "connections" to ManagerMobileMessageBox and CentralInventoryRequests.
            //In this prototype that means literally closing the windows if they're still open.
            //Loop through all open windows except for this one.
            for (int i = App.Current.Windows.Count - 1; i >= 1; i--)
            {
                App.Current.Windows[i].Close();
            }

            //Return to the previous page, closing this one.
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void StockListBox_Loaded(object sender, RoutedEventArgs e)
        {
            //Load the Data for the table from database. 
            InventoryCommunication accessData = new InventoryCommunication();
            ListBox toFill = accessData.loadInventoryData(1);

            //Add loaded data to listbox.
            foreach (var thisItem in toFill.Items)
            {
                StockListBox.Items.Add(thisItem);
            }
        }
    }
}
