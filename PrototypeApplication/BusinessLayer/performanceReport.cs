using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    /// <summary>
    /// 
    /// Kieran Burns - 40272382
    /// 
    /// Class with Get Set values for each item contained within a performance report.
    /// Used for returning a whole report from the business layer to the presentation
    /// layer in an easy to display format.
    /// 
    /// </summary>
    public class performanceReport
    {
        //Broad Statistics for all time.
        private decimal _totalEarnings;
        private int _totalItemsSold;
        private int _totalCustomers;

        //Statistics for items over the past 12 months.
        private decimal _pastYearEarnings;
        private int _pastYearItemsSold;
        private int _pastYearCustomers;

        //Percentages of past year compared to the year prior.
        private decimal _percentageOfPriorYearEarnings;
        private decimal _percentageOfPriorYearItemsSold;
        private decimal _percentageOfPriorYearCustomers;


        public decimal Total_Earnings
        {
            get
            {
                return _totalEarnings;
            }
            set
            {
                _totalEarnings = value;
            }
        }

        public int Total_Items_Sold
        {
            get
            {
                return _totalItemsSold;
            }
            set
            {
                _totalItemsSold = value;
            }
        }

        public int Total_Customers
        {
            get
            {
                return _totalCustomers;
            }
            set
            {
                _totalCustomers = value;
            }
        }

        public decimal Past_Year_Earnings
        {
            get
            {
                return _pastYearEarnings;
            }
            set
            {
                _pastYearEarnings = value;
            }
        }

        public int Past_Year_Items_Sold
        {
            get
            {
                return _pastYearItemsSold;
            }
            set
            {
                _pastYearItemsSold = value;
            }
        }

        public int Past_Year_Customers
        {
            get
            {
                return _pastYearCustomers;
            }
            set
            {
                _pastYearCustomers = value;
            }
        }

        public decimal Percentage_Of_Prior_Year_Earnings
        {
            get
            {
                return _percentageOfPriorYearEarnings;
            }
            set
            {
                _percentageOfPriorYearEarnings = value;
            }
        }

        public decimal Percentage_Of_Prior_Year_Items_Sold
        {
            get
            {
                return _percentageOfPriorYearItemsSold;
            }
            set
            {
                _percentageOfPriorYearItemsSold = value;
            }
        }

        public decimal Percentage_Of_Prior_Year_Customers
        {
            get
            {
                return _percentageOfPriorYearCustomers;
            }
            set
            {
                _percentageOfPriorYearCustomers = value;
            }
        }
    }
}
