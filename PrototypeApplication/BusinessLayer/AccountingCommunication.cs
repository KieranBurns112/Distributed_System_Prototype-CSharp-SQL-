using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using System.Data;
using System.Windows;

namespace BusinessLayer
{
    /// <summary>
    /// 
    /// Kieran Burns - 40272382
    /// 
    /// Class used to create and fill a performance report to be filled and send to the 
    /// presentation layer to be displayed.
    /// 
    /// </summary>
    public class AccountingCommunication
    {

        //System date to be used when calculating date based elements such as 
        //sales in the past year.
        private DateTime systemDate
            //Two dates are included here, the first is live date, based off system time,
            //which would likely be used in the actual system.
            //The other is a test date to prove the functionality of the prototype, based 
            //on the limited size of the existing database.
            //Uncomment one of the two below. Leave the other commented: 

            //= DateTime.Now;
            = DateTime.Parse("31/12/2019");


        public performanceReport GenerateReport()
        {
            //Report to be filled.
            performanceReport report = new performanceReport();

            //Fill a local variable with each of the sales records to be processed.
            dbQuery accessDB = new dbQuery();
            DataTable allSales = accessDB.allAccountingRecords();

            //Local Variables for working out the values to be inserted into the 
            //report.
            decimal totalEarnings = 0;
            int totalSales = 0;
            int totalCustomers = 0;

            DateTime saleDate;

            decimal thisYearEarnings = 0;
            decimal thisYearSales = 0;
            decimal thisYearCustomers = 0;

            decimal priorYearEarnings = 0;
            decimal priorYearSales = 0;
            decimal priorYearCustomers = 0;

            //Go through each record of the datatable.
            //Row[0] is Id.
            //Row[1] is date.
            //Row[2] is spend (earnings).
            //Row[3] is total individual items in purchase.
            foreach (DataRow Row in allSales.Rows)
            {
                totalEarnings += decimal.Parse(Row[2].ToString());
                totalSales += Int32.Parse(Row[3].ToString());
                totalCustomers++;

                //Get date associated with current row.
                saleDate = DateTime.Parse(Row[1].ToString());

                //If saleDate is within 1 year of current date.
                if (saleDate < systemDate && saleDate > systemDate.AddYears(-1))
                {
                    thisYearEarnings += decimal.Parse(Row[2].ToString());
                    thisYearSales += Int32.Parse(Row[3].ToString());
                    thisYearCustomers++;
                }
                //If saleDate is within 2 years of current date, but not within 1 year.
                else if (saleDate < systemDate.AddYears(-1) && saleDate > systemDate.AddYears(-2))
                {
                    priorYearEarnings += decimal.Parse(Row[2].ToString());
                    priorYearSales += Int32.Parse(Row[3].ToString());
                    priorYearCustomers++;
                }
            }

            //Append all of the calculated values to report.
            report.Total_Earnings = totalEarnings;
            report.Total_Items_Sold = totalSales;
            report.Total_Customers = totalCustomers;
            report.Past_Year_Earnings = thisYearEarnings;
            report.Past_Year_Items_Sold = decimal.ToInt32(thisYearSales);
            report.Past_Year_Customers = decimal.ToInt32(thisYearCustomers);

            //Calculate the percentage differences between this year and last,
            //then append them to the report.
            decimal percentageEarnings = thisYearEarnings / priorYearEarnings * 100;
            decimal percentageSales = thisYearSales / priorYearSales * 100;
            decimal percantageCustomers = thisYearCustomers / priorYearCustomers * 100;
            report.Percentage_Of_Prior_Year_Earnings = percentageEarnings;
            report.Percentage_Of_Prior_Year_Items_Sold = percentageSales;
            report.Percentage_Of_Prior_Year_Customers = percantageCustomers;

            //Return the filled out report class.
            return report;
        }
    }
}
