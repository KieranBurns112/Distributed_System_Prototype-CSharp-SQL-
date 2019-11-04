using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BusinessLayer
{
    public class dbConnection
    {
        public ListBox loadPriceControlData()
        {
            ListBox toFill = new ListBox();

            //  Test data
            toFill.Items.Add("Test for this"); //Test Code
            toFill.Items.Add("Another Test"); //Test Code
            //

            return toFill;
        }
    }
}
