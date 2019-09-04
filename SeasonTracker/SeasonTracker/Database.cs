using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace SeasonTracker
{
    public class Database
    {
        //Private properties, hidden from the outside world - Encapsulation.
        //Nobody should care how the database is connected or what these properties are.
        private string _databaseName;
        private string _tableName;
        private string _serverName;
        private string _userName;
        private string _password;
        private SqlConnection _dbConnection;
        

        //Public auto implemented properties
        //TBD

        //Constructor - create by typing "ctor" (snippet) and then tab
        public Database(string DatabaseName, 
            string TableName, 
            string ServerName, 
            string UserName, 
            string Password)
        {
            //Set the private properties
            this._databaseName = DatabaseName;
            this._tableName = TableName;
            this._serverName = ServerName;
            this._userName = UserName;
            this._password = Password;

            //Define the SQL connection object
            this._dbConnection = new SqlConnection(@"Data Source = " + _serverName + @";Initial Catalog=" + _databaseName + @";User ID=" + _userName + @";Password=" + _password + @";Pooling=False");

            CreateDatabase();
            if (!VerifyTable())
            {
                CreateTable();
            }
        }


        /// <summary>
        /// TODO: Create this function when I know how to do it programatically
        /// </summary>
        private void CreateDatabase()
        {
            //TODO: Need to figure out how to create a database programmatically.
            //-> currently needs to be done in server explorer
        }

        /// <summary>
        /// Returns TRUE if Table is created, FALSE if Table is not created.
        /// </summary>
        /// <returns></returns>
        private bool VerifyTable()
        {


            return true;
        }

        /// <summary>
        /// Creates the table in the database
        /// </summary>
        public void CreateTable()
        {

        }





        /// <summary>
        /// Opens the database connection and returns the state as TRUE if success, FALSE if fail.
        /// </summary>
        /// <returns></returns>
        private bool OpenConnection()
        {

        }

        /// <summary>
        /// Closes connection
        /// </summary>
        private void CloseConnection()
        {

        }



        /*
         * Database Operations
         */

        /// <summary>
        /// TODO:
        /// </summary>
        /// <param name="TBD"></param>
        public void LoadDataGrid()
        {

        }

        /// <summary>
        /// TODO:
        /// </summary>
        /// <param name="showName"></param>
        /// <param name="seasonNum"></param>
        /// <param name="episodeCount"></param>
        /// <param name="watchList"></param>
        public void AddRecord()
        {

        }

        /// <summary>
        /// TODO:
        /// </summary>
        /// <param name="TBD"></param>
        public void UpdateRecord()
        {

        }

        /// <summary>
        /// TODO:
        /// </summary>
        /// <param name="TBD"></param>
        public void DeleteRecord()
        {

        }
    }
}
