using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    /// <summary>
    /// 
    /// Kieran Burns - 40272382
    /// 
    /// Class containing a method to query the database, and methods with each possiblely required
    /// querry to communicate with the database to both send and recieve information.
    /// 
    /// </summary>
    public class dbQuery
    {

        private DataTable queryDatabase(string query)
        { 
            //Variable used to connect the local SQL database, could be substituted for a securely stored external database in a real-world version of the system
            string DEDatabaseConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\DESystemDatabase.mdf;Integrated Security=True";

                //[[[[Sometimes the |DataDirectory| doesn't work.]]]]
                //Below is the hardcoded path for development [[TO BE REMOVED BEFORE SUBMISSION]].
                //"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\evilr\\Desktop\\Software-Architecture-Coursework\\PrototypeApplication\\ClassLibrary1\\DESystemDatabase.mdf;Integrated Security=True";


            //Create DataTable to hold contents of query
            DataTable queriedItem = new DataTable();

            //Open database, fill DataTable with result of query, then close database
            SqlConnection DESystemDatabase = new SqlConnection(DEDatabaseConnectionString);
            DESystemDatabase.Open();
            SqlCommand command = new SqlCommand(query, DESystemDatabase);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(queriedItem);
            DESystemDatabase.Close();

            //Return the filled DataTable
            return queriedItem;
        }

        public DataTable priceControlItems()
        {
            //Send query to database
            string query = "SELECT * FROM inventory";
            DataTable itemsToPass = queryDatabase(query);

            //Return the DataTable
            return itemsToPass;
        }

        public DataTable requestInventoryItem(int itemId)
        {
            //Send query to database
            string query = "SELECT * FROM inventory WHERE ItemId=" + itemId;
            DataTable requestedItem = queryDatabase(query);

            //Return the DataTable
            return requestedItem;
        }

        public void updateItemPrice(int itemId, decimal newPrice)
        {
            //Send query to database
            string query = "UPDATE inventory SET Price=" + newPrice + " WHERE ItemId=" + itemId;
            queryDatabase(query);
        }

        public void updateItemStandardOffer(int itemId, int newOffer)
        {
            //Send query to database
            string query = "UPDATE inventory SET StandardOffer=" + newOffer + " WHERE ItemId=" + itemId;
            queryDatabase(query);
        }

        public void updateItemLoyaltyOffer(int itemId, int newLoyalty)
        {
            //Send query to database
            string query = "UPDATE inventory SET LoyaltyOffer=" + newLoyalty + " WHERE ItemId=" + itemId;
            queryDatabase(query);
        }
    }
}
