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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PriceControlNavButton_Click(object sender, RoutedEventArgs e)
        {
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
            this.Close();
        }
    }
}
