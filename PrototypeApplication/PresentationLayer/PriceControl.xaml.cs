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
    /// Interaction logic for PriceControl.xaml
    /// </summary>
    public partial class PriceControl : Window
    {
        public PriceControl()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void PriceControlListBox_Loaded(object sender, RoutedEventArgs e)
        {
            //Default loading message since the database takes time to load and is inconsistent
            PriceControlListBox.Items.Add("Loading...");

            //Load the Data for the table from database 
            PriceControlCommunication accessData = new PriceControlCommunication();
            ListBox toFill = accessData.loadPriceControlData();

            //Clear default loading message
            PriceControlListBox.Items.Clear();

            //Add loaded data to listbox
            foreach (var thisItem in toFill.Items)
            {
                PriceControlListBox.Items.Add(thisItem);
            }
        }

        private void PriceControlListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedItemId = PriceControlListBox.SelectedIndex;

            if(selectedItemId > 0)
            {
                PriceControlSingleItem priceControlSingleItem = new PriceControlSingleItem(selectedItemId);
                priceControlSingleItem.Show();
                this.Close(); 
           }
        }
    }
}
