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
    /// Interaction Logic for the page which displays the report information generated
    /// by "AccountingCommunication", via the "prerformanceReport" class
    /// 
    /// </summary>
    public partial class ReportsAndAnalysis : Window
    {
        public ReportsAndAnalysis()
        {
            InitializeComponent();

            displayReport();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void displayReport()
        {
            //Create instance of class used to get report contents.
            AccountingCommunication generateReport = new AccountingCommunication();

            //Create instance of report contents class and fill it.
            performanceReport reportContent = generateReport.GenerateReport();

            //Display the report contents on the form.
            totalEarnings.Content = "£" + reportContent.Total_Earnings;
            totalItemsSold.Content = reportContent.Total_Items_Sold;
            totalCustomers.Content = reportContent.Total_Customers;
            past12Earnings.Content = "£" + reportContent.Past_Year_Earnings;
            past12Sold.Content = reportContent.Past_Year_Items_Sold;
            past12Customers.Content = reportContent.Past_Year_Customers;
            //Each of the percentages were truncated as to avoid large trailing decimal points.
            percentageEarnings.Content = decimal.Truncate(reportContent.Percentage_Of_Prior_Year_Earnings) + "%";
            percentageSold.Content = decimal.Truncate(reportContent.Percentage_Of_Prior_Year_Items_Sold) + "%";
            percentageCustomers.Content = decimal.Truncate(reportContent.Percentage_Of_Prior_Year_Customers) + "%";
        }
    }
}
