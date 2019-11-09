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
        //"StoreId" is used to refer to each instance of DE-Store. Within this prototype, only a single
        //instance exists, however as a fully distributed system, a login system would be used, which is
        //where "StoreId" would be nessisary. "StoreId" is only used as an identifier for mock messages 
        //sent to the mockup of the Central Inventory system when making an automated request for more 
        //stock when an item's stock is empty within this prototype.
        public int StoreId = 1;

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
            //Load and display the Inventory Management pages, closing this page.
            StockMonitor stockMonitor = new StockMonitor();
            stockMonitor.Show();

            //Both "central" and "manager" are used to exemplify external applications, outwith DE-System, to which
            //DE-System can send messages to.
            CentralInventoryRequests central = new CentralInventoryRequests(StoreId);
            central.Show();
            ManagerMobileMessageBox manager = new ManagerMobileMessageBox();
            manager.Show();

            this.Close();
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
            //Load and display the Finance Approval page, closing this one.
            FinanceApproval financeApproval = new FinanceApproval(StoreId);
            financeApproval.Show();
            this.Close();
        }

        private void ReportsAndAnalysisNavButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not Yet Implemented");
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            //Fully Quit the application.
            Application.Current.Shutdown();
        }
    }
}
