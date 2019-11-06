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
    /// Interaction logic for LoyaltyCardItemList.xaml
    /// </summary>
    public partial class LoyaltyCardItemList : Window
    {
        public LoyaltyCardItemList()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void LoyaltyListBox_Loaded(object sender, RoutedEventArgs e)
        {
            //Load the Data for the table from database 
            InventoryCommunication accessData = new InventoryCommunication();
            ListBox toFill = accessData.loadInventoryData(1);

            //Add loaded data to listbox
            foreach (var thisItem in toFill.Items)
            {
                LoyaltyListBox.Items.Add(thisItem);
            }
        }

        private void LoyaltyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedItemId = LoyaltyListBox.SelectedIndex;

            if (selectedItemId > 0)
            {
                LoyaltyCardSingleItem loyaltyCardSingleItem = new LoyaltyCardSingleItem(selectedItemId);
                loyaltyCardSingleItem.Show();
                this.Close();
            }
        }
    }
}
