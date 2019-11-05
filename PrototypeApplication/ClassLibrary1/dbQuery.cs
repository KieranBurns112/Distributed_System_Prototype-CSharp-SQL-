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
        //Variable used to connect to local SQL database, could be substituted for a securely stored external database in a real-world version of the system.
        private SqlConnection DESystemDatabase = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename =\"|DataDirectory|\\DESystemDatabase.mdf\"; Integrated Security = True");
         
        public DataTable priceControlItems()
        {
            //Create DataTable to hold contents of "inventory" table
            DataTable itemsToPass = new DataTable();

            //Open database, fill DataTable with contents of "inventory", then close database
            DESystemDatabase.Open();
            string query = "SELECT * FROM inventory";
            SqlCommand command = new SqlCommand(query, DESystemDatabase);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(itemsToPass);
            DESystemDatabase.Close();

            //Return the DataTable
            return itemsToPass;
        }
    }
}
