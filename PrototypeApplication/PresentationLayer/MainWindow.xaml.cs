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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationLayer
{
    /// <summary>
    /// 
    /// Kieran Burns - 40272382
    /// 
    /// Interaction Logic for the Main "Hub" page of the application.
    /// 
    /// This page serves the purpose of allowing the user to navigate to each of the five individual
    /// segregated features of this prototype, each segregated for the sake of individual demonstration.
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PriceControlNavButton_Click(object sender, RoutedEventArgs e)
        {
            //Load and display the Price Control page, closing this one.
            PriceControl priceControl = new PriceControl();
            priceControl.Show();
            this.Close();
        }

        private void InventoryControlNavButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not Yet Implemented");
        }

        private void LoyaltyCardNavButton_Click(object sender, RoutedEventArgs e)
        {
            //Load and display the Loyalty Offers page, closing this one.
            LoyaltyCardItemList loyaltyCard = new LoyaltyCardItemList();
            loyaltyCard.Show();
            this.Close();
        }

        private void FinanceApprovalNavButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not Yet Implemented");
        }

        private void ReportsAndAnalysisNavButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not Yet Implemented");
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            //Quit the application.
            this.Close();
        }
    }
}
