using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace SimpleSeasonTracker
{
    public class Database
    {
        private static readonly Lazy<Database> lazy = new Lazy<Database>(() => new Database());
        public static Database Instance { get { return lazy.Value; } }

        //Class member variables
        private string _databaseStatus;

        private string _idColumn;
        private string _showNameColumn;
        private string _seasonNumColumn;
        private string _episodeCountColumn;
        private string _watchlistColumn;

        public int ID_COL_NUM { get; }
        public int SHOWNAME_COL_NUM { get; }
        public int SEASONNUM_COL_NUM { get; }
        public int EPISODECOUNT_COL_NUM { get; }
        public int WATCHLIST_COL_NUM { get; }

        private string _cmdCreateTable;     //TODO: may be able to just define this in the private function

        private string _databaseName;
        //private string TableName;

        private bool _connectionOpen = false;
        private bool _tableIsCreated = false;

        private SqlConnection _dbConnection;

        /// <summary>
        /// Constructor for Database
        /// </summary>
        private Database()
        {
            //Define the SQL Server Database
            _databaseName = "SeasonTrackerDatabase";

            //Define the SQL Server Table Name
            TableName = "SeasonTrackerTable";

            //Set the Connection String:
            ConnectionString = @"Data Source=DESKTOP-9C0DIO8;Initial Catalog=" + _databaseName + @";User ID=sa;Password=tucson;Pooling=False";

            //Define the SQL connection object
            _dbConnection = new SqlConnection(ConnectionString);

            //Define and add the Column Names (to add more, need to update the "CreateTable" function)
            _idColumn = "Id";
            _showNameColumn = "show_name";
            _seasonNumColumn = "season_num";
            _episodeCountColumn = "episode_count";
            _watchlistColumn = "watch_list";

            //Order in which the columns appear in the database table
            ID_COL_NUM = 0;
            SHOWNAME_COL_NUM = 1;
            SEASONNUM_COL_NUM = 2;
            EPISODECOUNT_COL_NUM = 3;
            WATCHLIST_COL_NUM = 4;

            CreateDatabase();
            if (!VerifyTable())
            {
                CreateTable();
            }
        }

        public event EventHandler<DatabaseStatusRaisedEventArgs> StatusRaised;

        public void GetStatus()
        {
            ReadStatus();
        }

        private void ReadStatus()
        {
            //_databaseStatus = "From Database Class";

            DatabaseStatusRaisedEventArgs args = new DatabaseStatusRaisedEventArgs();
            args.Status = _databaseStatus;
            OnDatabaseStatusRaised(args);
        }

        /// <summary>
        /// Returns connection string for the database
        /// </summary>
        public string ConnectionString { get; }

        /// <summary>
        /// Returns table name for the database
        /// </summary>
        public string TableName { get; }


        /// <summary>
        /// TODO: Create this function when I know how to do it programatically
        /// </summary>
        private void CreateDatabase()
        {
            //TODO: Need to figure out how to create a database programmatically.
            //-> currently needs to be done in server explorer
        }

        /// <summary>
        /// Opens the database connection and returns the state as TRUE if success, FALSE if fail.
        /// </summary>
        /// <returns></returns>
        private bool OpenConnection()
        {
            try
            {
                _dbConnection.Open();
                if (_dbConnection.State == ConnectionState.Open)
                    _connectionOpen = true;
            }
            catch(System.Exception ex)
            {
                //TODO: define what to happen here. Bring the message to the main window? show dialog?
                if (_dbConnection.State == ConnectionState.Open)
                {
                    _dbConnection.Close();
                }
                _connectionOpen = false;
            }
            return _connectionOpen;
        }
        
        /// <summary>
        /// Closes connection
        /// </summary>
        private void CloseConnection()
        {
            try
            {
                _dbConnection.Close();
                if (_dbConnection.State == ConnectionState.Closed)
                    _connectionOpen = false;
            }
            catch (System.Exception ex)
            {
                //TODO: define what to happen here. Bring it to the main window? show dialog?
                if (_dbConnection.State == ConnectionState.Open)
                {
                    _dbConnection.Close();
                }
                _connectionOpen = false;
            }
        }

        /// <summary>
        /// Returns TRUE if Table is created, FALSE if Table is not created.
        /// </summary>
        /// <returns></returns>
        private bool VerifyTable()
        {
            _tableIsCreated = false;
            if (OpenConnection())
            {
                string _checkTableQuery = "SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[" + TableName + "]')";

                SqlCommand _cmd = new SqlCommand(_checkTableQuery, _dbConnection);
                //int exists = (int)_cmd.ExecuteScalar();
                if ((int)_cmd.ExecuteScalar() > 0 )
                {
                    _tableIsCreated = true;
                }
            }
            else
            {
                //TODO: raise issue with connection/unable to create table
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
            if (OpenConnection())
            {
                _cmdCreateTable = "CREATE TABLE[dbo].[" + TableName + "] " +
                                "([" + _idColumn + "] INT IDENTITY(1,1) NOT NULL, " +
                                "[" + _showNameColumn + "] VARCHAR(MAX) NULL, " +
                                "[" + _seasonNumColumn + "] INT NULL, " +
                                "[" + _episodeCountColumn + "] INT NULL, " +
                                "[" + _watchlistColumn + "] VARCHAR(MAX) NULL)";

                SqlCommand _cmd = new SqlCommand(_cmdCreateTable, _dbConnection);
                _cmd.ExecuteNonQuery();

                //_databaseStatus = "Table Created";
                //ReadStatus();
                //UpdateStatus("Table Created!");
            }
            else
            {
                //TODO: raise issue with connection/unable to create table
            }
            CloseConnection();
        }

        /// <summary>
        /// TODO: create this function whan I know how to do it programatically
        /// </summary>
        private void VerifyDatabase()
        {
            //TODO: Verify if database exits before creating
        }

        public DataSet LoadDataGrid()
        {
            DataSet ds = new DataSet();

            if (OpenConnection())
            {
                string selectString = "SELECT * FROM " + TableName;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectString, _dbConnection);
                dataAdapter.Fill(ds, TableName);
            }
            else
            {
                //TODO: raise issue with connection/unable to create table
            }
            CloseConnection();

            return ds;
        }

        /// <summary>
        /// TODO:
        /// </summary>
        /// <param name="showName"></param>
        /// <param name="seasonNum"></param>
        /// <param name="episodeCount"></param>
        /// <param name="watchList"></param>
        public void AddRecord(string showName, int seasonNum, int episodeCount, string watchList)
        {
            if (OpenConnection())
            {
                SqlCommand _cmd = new SqlCommand("INSERT INTO " + TableName +
                                                "(" +
                                                _showNameColumn + "," +
                                                _seasonNumColumn + "," +
                                                _episodeCountColumn + "," +
                                                _watchlistColumn +
                                                ")" + " VALUES(" + 
                                                "@showName," +
                                                "@seasonNum," +
                                                "@episodeCount," +
                                                "@watchList" +
                                                ")", _dbConnection);

                _cmd.Parameters.Add("@showName", SqlDbType.VarChar);
                _cmd.Parameters.Add("@seasonNum", SqlDbType.Int);
                _cmd.Parameters.Add("@episodeCount", SqlDbType.Int);
                _cmd.Parameters.Add("@watchList", SqlDbType.VarChar);

                _cmd.Parameters["@showName"].Value = showName;
                _cmd.Parameters["@seasonNum"].Value = seasonNum;
                _cmd.Parameters["@episodeCount"].Value = episodeCount;
                _cmd.Parameters["@watchList"].Value = watchList;

                _cmd.ExecuteNonQuery();

                _databaseStatus = "Record Added";
                ReadStatus();
            }
            else
            {
                //TODO: raise issue with connection/unable to create table
            }
            CloseConnection();
        }

        public void UpdateRecord(int table_id, string showName, int seasonNum, int episodeCount, string watchList)
        {
            if (OpenConnection())
            {
                SqlCommand _cmd = new SqlCommand("UPDATE " + TableName +
                                                " SET " +
                                                _showNameColumn + "=@showName, " +
                                                _seasonNumColumn + "=@seasonNum, " +
                                                _episodeCountColumn + "=@episodeCount, " +
                                                _watchlistColumn + "=@watchList" +
                                                " WHERE " +
                                                _idColumn + "=" + table_id.ToString(),
                                                _dbConnection);
             
                _cmd.Parameters.Add("@showName", SqlDbType.VarChar);
                _cmd.Parameters.Add("@seasonNum", SqlDbType.Int);
                _cmd.Parameters.Add("@episodeCount", SqlDbType.Int);
                _cmd.Parameters.Add("@watchList", SqlDbType.VarChar);

                _cmd.Parameters["@showName"].Value = showName;
                _cmd.Parameters["@seasonNum"].Value = seasonNum;
                _cmd.Parameters["@episodeCount"].Value = episodeCount;
                _cmd.Parameters["@watchList"].Value = watchList;

                _cmd.ExecuteNonQuery();

                _databaseStatus = String.Format("Record with ID:{0} updated", table_id.ToString());
                ReadStatus();
            }
            else
            {
                //TODO: raise issue with connection/unable to create table
            }
            CloseConnection();
        }

        public void DeleteRecord(int table_id)
        {
            if (OpenConnection())
            {
                SqlCommand _cmd = new SqlCommand("DELETE FROM " + TableName +
                                                " WHERE " + 
                                                _idColumn + " = '" + table_id.ToString() + "'", 
                                                _dbConnection);

               _cmd.ExecuteNonQuery();

                _databaseStatus = String.Format("Record with ID:{0} deleted", table_id.ToString() );
                ReadStatus();
            }
            else
            {
                //TODO: raise issue with connection/unable to create table
            }
            CloseConnection();
        }

        protected virtual void OnDatabaseStatusRaised(DatabaseStatusRaisedEventArgs e)
        {
            EventHandler<DatabaseStatusRaisedEventArgs> handler = StatusRaised;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }

    public class DatabaseStatusRaisedEventArgs : EventArgs
    {
        public string Status { get; set; }
    }
}
