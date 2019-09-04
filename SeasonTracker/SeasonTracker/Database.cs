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
        private SqlConnection _sqlConnection;
        private bool _connectionOpen;
        private bool _tableIsCreated;

        //Public properties
        public List<string> DatabaseColumns;

        //Constructor - create by typing "ctor" (snippet) and then tab key
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

            //On object creation, initialize the connection state
            _connectionOpen = false;

            //Define and create the SQL connection object with the connection string.
            this._sqlConnection = new SqlConnection(@"Data Source = " + _serverName + @";Initial Catalog=" + _databaseName + @";User ID=" + _userName + @";Password=" + _password + @";Pooling=False");

            //Populate the database record columns. This is what defines the records in the database.
            DatabaseColumns.Add("Id");
            DatabaseColumns.Add("show_name");
            DatabaseColumns.Add("season_num");
            DatabaseColumns.Add("episode_count");
            DatabaseColumns.Add("watch_list");

            //Create the database
            CreateDatabase();

            //Verify the database table was created. If not, create it.
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
            //-> Currently just the database needs to be created in server explorer.
            //     However, the table can be created programmatically as seen in this class. 
        }

        /// <summary>
        /// Returns TRUE if Table is created, FALSE if Table is not created.
        /// </summary>
        /// <returns></returns>
        private bool VerifyTable()
        {
            _tableIsCreated = false;
            OpenConnection();
            if (_connectionOpen)
            {
                string _checkTableQuery = "SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[" + TableName + "]')";

                SqlCommand _cmd = new SqlCommand(_checkTableQuery, _sqlConnection);
                //int exists = (int)_cmd.ExecuteScalar();
                if ((int)_cmd.ExecuteScalar() > 0)
                {
                    _tableIsCreated = true;
                }
            }
            else
            {
                //TODO: raise issue with connection/unable to verify table
            }
            CloseConnection();
            return _tableIsCreated;
        }

        /// <summary>
        /// Creates the table in the database
        /// </summary>
        private void CreateTable()
        {
            //All of the text I got from using Visual Studio's built in "Add New Table" to 
            //get a prototype. Type of "VARCHAR(MAX)" needs to be used instead of "Text", as "Text" is 
            //being deprecated (http://sqlhints.com/2016/05/11/differences-between-sql-server-text-and-varcharmax-data-type/)
            OpenConnection();
            if (_connectionOpen)
            {
                try
                {
                    string _cmdCreateTable = "CREATE TABLE[dbo].[" + _tableName + "] " +
                                "([" + DatabaseColumns[0] + "] INT IDENTITY(1,1) NOT NULL, " +
                                "[" + DatabaseColumns[1] + "] VARCHAR(MAX) NULL, " +
                                "[" + DatabaseColumns[2] + "] INT NULL, " +
                                "[" + DatabaseColumns[3] + "] INT NULL, " +
                                "[" + DatabaseColumns[4] + "] VARCHAR(MAX) NULL)";

                    SqlCommand _cmd = new SqlCommand(_cmdCreateTable, _sqlConnection);
                    _cmd.ExecuteNonQuery();
                }
                catch(Exception exc)
                {
                    //TODO: raise issue with unable to create table
                }
            }
            else
            {
                //TODO: raise issue with connection
            }
            CloseConnection();
        }





        /// <summary>
        /// Opens the database connection and sets the _connectionOpen state as TRUE if opened, FALSE if closed.
        /// </summary>
        /// <returns>None</returns>
        private void OpenConnection()
        {
            try
            {
                _sqlConnection.Open();
                if (_sqlConnection.State == ConnectionState.Open)
                    _connectionOpen = true;
            }
            catch (Exception ex)
            {
                //TODO: define what to happen here. Bring the message to the main window? show dialog?
                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }
                _connectionOpen = false;
            }
        }

        /// <summary>
        /// Closes the database connection and sets the _connectionOpen state as FALSE if closed, TRUE if opened.
        /// </summary>
        /// <returns>None</returns>
        private void CloseConnection()
        {
            try
            {
                _sqlConnection.Close();
                if (_sqlConnection.State == ConnectionState.Closed)
                    _connectionOpen = false;
            }
            catch (Exception ex)
            {
                //TODO: define what to happen here. Bring it to the main window? show dialog?
                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }
                _connectionOpen = false;
            }
        }



        /*
         * Database Operations
         */

        /// <summary>
        /// TODO:
        /// </summary>
        /// <param name="TBD"></param>
        /// <returns>None</returns>
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
        /// <returns>None</returns>
        public void AddRecord()
        {

        }

        /// <summary>
        /// TODO:
        /// </summary>
        /// <param name="TBD"></param>
        /// <returns>None</returns>
        public void UpdateRecord()
        {

        }

        /// <summary>
        /// TODO:
        /// </summary>
        /// <param name="TBD"></param>
        /// <returns>None</returns>
        public void DeleteRecord()
        {

        }
    }
}
