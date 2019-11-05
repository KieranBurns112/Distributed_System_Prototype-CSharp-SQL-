using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class dbQuery
    {

        private DataTable queryDatabase(string query)
        { 
            //Local version of the connection string for when it does the finicky thing
           // string DEDatabaseConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\evilr\\Desktop\\Software-Architecture-Coursework\\PrototypeApplication\\ClassLibrary1\\DESystemDatabase.mdf;Integrated Security=True";
            
            //Variable used to connect to local SQL database, could be substituted for a securely stored external database in a real-world version of the system
            string DEDatabaseConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\DESystemDatabase.mdf;Integrated Security=True";

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
            string query = "UPDATE inventory SET Price=" + newPrice + " WHERE ItemId=" + itemId;
            queryDatabase(query);
        }

        public void updateItemStandardOffer(int itemId, int newOffer)
        {
            string query = "UPDATE inventory SET StandardOffer=" + newOffer + " WHERE ItemId=" + itemId;
            queryDatabase(query);
        }
    }
}
