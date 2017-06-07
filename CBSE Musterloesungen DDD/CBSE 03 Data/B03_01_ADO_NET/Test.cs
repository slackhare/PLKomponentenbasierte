using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using System.Data.OleDb;
using System.Data.Sql;


namespace ADO_NET_Data {

    class Test {

        #region Fields
        // State
        private string _connectionString ;

        // Association concrete OledDb Objects
        private System.Data.OleDb.OleDbConnection     _oleDbConnection;
        private System.Data.OleDb.OleDbCommand        _oleDbCommmand;
        private System.Data.OleDb.OleDbDataReader     _oleDbDataReader;
        private System.Data.OleDb.OleDbDataAdapter    _oleDbDataAdapter;

        //private System.Data.SqlClient.SqlConnection     _sqlConnection;
        //private System.Data.SqlClient.SqlCommand        _sqlCommmand;
        //private System.Data.SqlClient.SqlDataReader     _sqlDataReader;
        //private System.Data.SqlClient.SqlDataAdapter    _sqlDataAdapter;

        // Association abstract objects
        private System.Data.Common.DbProviderFactory    _dbProviderFactory;
        private System.Data.Common.DbConnection         _dbConnection;
        private System.Data.Common.DbCommand            _dbCommand;
        private System.Data.Common.DbDataReader         _dbDataReader;

        private System.Data.DataSet                    _dataSet;
        #endregion

        void Run( ) {

            // https://www.microsoft.com/en-us/download/confirmation.aspx?id=13255

            string path = @"C:\Users\rogallab\CBSE Autoverwaltung\CarDatabase.mdb";

            // Connection String
            _connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";";

            // OleDbConnection
            // ----------------------------------------------------------------------------
            _oleDbConnection = new OleDbConnection( );
            _oleDbConnection.ConnectionString = _connectionString;
            _oleDbConnection.Open( );
            // Test Connection
            if( _oleDbConnection.State == ConnectionState.Open ) {
                // ok
                _oleDbConnection.Close( );
            }
            else {
                // error
            }

            // OleDbCommand
            // ----------------------------------------------------------------------------
            _oleDbCommmand = new OleDbCommand( );
            _oleDbCommmand.Connection = _oleDbConnection;
            // alternative Objektkonstruktion durch oleDbConnection 
            // reduziert Kopplung
            _oleDbCommmand = _oleDbConnection.CreateCommand( );
            _oleDbCommmand.CommandType = CommandType.Text;

            // OleDbCommand - Execute Scalar
            _oleDbConnection.Open( );
            _oleDbCommmand.CommandText = "SELECT COUNT(*) FROM CarTable;";
            int nCars = (int) _oleDbCommmand.ExecuteScalar( );
            _oleDbConnection.Close( );

            // OleDbCommand - Execute Query
            _oleDbConnection.Open( );
            _oleDbCommmand.CommandText = "SELECT DISTINCT Make FROM CarTable ORDER BY Make;";
            _oleDbDataReader = _oleDbCommmand.ExecuteReader( );
            List<object> listMake = new List<object>();
            while( _oleDbDataReader.Read( ) ) {
                listMake.Add( _oleDbDataReader [ 0 ] );
            }
            _oleDbDataReader.Close( );
            _oleDbConnection.Close( );

            // OleDbCommand - Execute Reader
            _oleDbCommmand.CommandText = "SELECT * FROM CarTable WHERE Make='Opel'AND Model='Astra';";
            _oleDbConnection.Open( );
            _oleDbDataReader = _oleDbCommmand.ExecuteReader( );
            // Record Set 
            if( _oleDbDataReader.HasRows ) {
                // Data Record has nColumns
                int nColumns = _oleDbDataReader.FieldCount;
                while( _oleDbDataReader.Read( ) ) {
                    // Evaluate each column
                    // col 0
                    object o1 = _oleDbDataReader[0];

                    // Evaluate each column
                    var pkGUID   = _dbDataReader.GetString(0);
                    var make     = _dbDataReader.GetString(1);
                    var model    = _dbDataReader.GetString(2);
                    var price    =  _dbDataReader.GetDouble(3);
                    var registration = _dbDataReader.GetInt32(4);
                    var mileage  = _dbDataReader.GetInt32(5);
                    var fkSeller = _dbDataReader.GetInt32(6);
                }
            }
            _oleDbDataReader.Close( ); // !!! nicht vergessen !!!
            _oleDbConnection.Close( );

            // OleDbCommand DataAdapter und DataSet
            _dataSet = new DataSet( );
            _oleDbDataAdapter = new OleDbDataAdapter( );
            _oleDbDataAdapter.SelectCommand = _oleDbCommmand;

            _oleDbDataAdapter.Fill( _dataSet );
            //return ds.Tables[0].DefaultView;
        }

        void Run2( ) {

            // Connection String
            string path = @"C:\Users\rogallab\CBSE Autoverwaltung\CarDatabase.mdb";
            _connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";";

            path = @"C:\Users\rogallab\CBSE Autoverwaltung\CarDatabase.accdb";
            _connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";";

            // Data Provider Abstract Factory
            _dbProviderFactory = DbProviderFactories.GetFactory( "System.Data.OleDb" );

            // DbConnection - Factory Method CreateConnection()
            _dbConnection = _dbProviderFactory.CreateConnection( );
            _dbConnection.ConnectionString = _connectionString;

            // DbCommand - Factory Method CreateCommand()
            // ----------------------------------------------------------------------------            
            _dbCommand = _dbProviderFactory.CreateCommand( );
            _dbCommand.Connection = _dbConnection;
            _dbCommand.CommandType = CommandType.Text;

            // DbCommand - Execute Scalar   CountCars
            // -----------------------------------------------------------------------------
            try {
                if( _dbConnection.State == ConnectionState.Closed ) _dbConnection.Open( );
                _dbCommand.CommandText = "SELECT COUNT(*) FROM CarTable;";
                int nCars = (int) _dbCommand.ExecuteScalar( );
                if( _dbConnection.State == ConnectionState.Open ) _dbConnection.Close( );

                // DbCommand Execute Query (Alle Hersteller als Liste)
                if( _dbConnection.State == ConnectionState.Closed ) _dbConnection.Open( );
                _dbCommand.CommandText = "SELECT DISTINCT Make FROM CarTable ORDER BY Make;";
                _dbDataReader = _dbCommand.ExecuteReader( );
                List<object> listMake = new List<object>();
                while( _dbDataReader.Read( ) ) {
                    listMake.Add( _dbDataReader [ 0 ] );
                }
                _dbDataReader.Close( );
                if( _dbConnection.State == ConnectionState.Open ) _dbConnection.Close( );
            }
            catch( Exception e ) {
                Console.WriteLine( e.Message );
            }

            // DbCommand Execute Query - Execute Query (Alle Modelle eines Herstellers)
            // -----------------------------------------------------------------------------            
            try {
                if( _dbConnection.State == ConnectionState.Closed ) _dbConnection.Open( );
                _dbCommand.CommandText = "SELECT DISTINCT Model FROM CarTable WHERE Make='Opel' ORDER BY Model;";
                _dbDataReader = _dbCommand.ExecuteReader( );
                List<object> listModel = new List<object>();
                while( _dbDataReader.Read( ) ) {
                    listModel.Add( _dbDataReader [ 0 ] );
                }
                _dbDataReader.Close( );
                if( _dbConnection.State == ConnectionState.Open ) _dbConnection.Close( );

                // DataReader  Execute Reader
                _dbCommand.CommandText = "SELECT * FROM CarTable WHERE Make='Opel' ORDER BY model;";
                if( _dbConnection.State == ConnectionState.Closed ) _dbConnection.Open( );
                _dbDataReader = _dbCommand.ExecuteReader( );
                // Record Set 
                if( _dbDataReader.HasRows ) {
                    // Data Record has nColumns
                    int nColumns = _dbDataReader.FieldCount;
                    while( _dbDataReader.Read( ) ) {
                        // Evaluate each column
                        var pkGUID   = _dbDataReader.GetString(0);
                        var make     = _dbDataReader.GetString(1);
                        var model    = _dbDataReader.GetString(2);
                        var price    =  _dbDataReader.GetDouble(3);
                        var registration = _dbDataReader.GetInt32(4);
                        var mileage  = _dbDataReader.GetInt32(5);
                        var fkSeller = _dbDataReader.GetInt32(6);
                    }
                }
                _dbDataReader.Close( ); // !!! nicht vergessen !!!
                _dbConnection.Close( );
            }
            catch( Exception e ) {
                Console.WriteLine( e.Message );
            }

            // SQL-Injection bezeichnet das Ausnutzen einer Sicherheitslücke in SQL-Datenbanken, 
            // die durch mangelnde Maskierung oder Überprüfung von Metazeichen in Benutzereingaben 
            // entsteht.
            // CommandText = "SELECT DISTINCT Model FROM CarTable WHERE Make='Opel'";
            // CommandText = "SELECT DISTINCT Model FROM CarTable WHERE Make='Opel';DELETE ...; ";
            // -----------------------------------------------------------------------------            
            // Create a Stored Procedure            
            try {
                DbCommand dbCommandStoredProcedure   = _dbProviderFactory.CreateCommand();
                dbCommandStoredProcedure.Connection = _dbConnection;
                dbCommandStoredProcedure.CommandText =
                    @"CREATE PROCEDURE CarTable_SelectModelbyMake (pMake TEXT) as
                          SELECT DISTINCT Model FROM CarTable WHERE Make = [pMake] ORDER BY Model";
                dbCommandStoredProcedure.CommandType = CommandType.Text;
                if( _dbConnection.State == ConnectionState.Closed ) _dbConnection.Open( );
                dbCommandStoredProcedure.ExecuteNonQuery( );
                if( _dbConnection.State == ConnectionState.Open ) _dbConnection.Close( );
            }
            catch( Exception e ) {
                Console.WriteLine( e.Message );
            }

            // Used a Stored Procedure
            try {
                DbCommand dbCommandUseStoreProcedure   = _dbProviderFactory.CreateCommand();
                dbCommandUseStoreProcedure.Connection = _dbConnection;
                dbCommandUseStoreProcedure.CommandText = "CarTable_SelectModelbyMake";
                dbCommandUseStoreProcedure.CommandType = CommandType.StoredProcedure;
                DbParameter dbParameter = _dbProviderFactory.CreateParameter();
                dbParameter.ParameterName ="pMake";
                dbParameter.Value         ="Opel";
                dbCommandUseStoreProcedure.Parameters.Clear( );
//                dbCommandUseStoreProcedure.Parameters.Add( new OleDbParameter( "pMake", "Opel" ) );
                dbCommandUseStoreProcedure.Parameters.Add( dbParameter );
                if( _dbConnection.State == ConnectionState.Closed ) _dbConnection.Open( );
                _dbDataReader = dbCommandUseStoreProcedure.ExecuteReader( );
                List<object> listModelStoredProcedure = new List<object>();
                if( _dbDataReader.HasRows ) {
                    while( _dbDataReader.Read( ) ) {
                        listModelStoredProcedure.Add( _dbDataReader [ 0 ] );
                    }
                }
                if( !_dbDataReader.IsClosed ) _dbDataReader.Close( );
                if( _dbConnection.State == ConnectionState.Open ) _dbConnection.Close( );
            }
            catch( Exception e ) {
                Console.WriteLine( e.Message );
            }


            // Dynamic SQL Statement - User input via Parameter
            // ------------------------------------------------
            try {
                DbCommand dbCommandDynamic   = _dbProviderFactory.CreateCommand();
                dbCommandDynamic.Connection = _dbConnection;
                dbCommandDynamic.CommandText =
                     @"SELECT DISTINCT Model FROM CarTable WHERE Make = [pMake] ORDER BY Model";
                dbCommandDynamic.CommandType = CommandType.Text;

                DbParameter dbParameter = _dbProviderFactory.CreateParameter();
                dbParameter.ParameterName ="pMake";
                dbParameter.Value         ="Opel";
                dbCommandDynamic.Parameters.Clear( );
                dbCommandDynamic.Parameters.Add( dbParameter );
                if( _dbConnection.State == ConnectionState.Closed ) _dbConnection.Open( );
                DbDataReader dbDataReaderDynamic = dbCommandDynamic.ExecuteReader( );
                List<object> listModelDynamic = new List<object>();
                while( dbDataReaderDynamic.Read( ) ) {
                    listModelDynamic.Add( dbDataReaderDynamic [ 0 ] );
                }
                dbCommandDynamic.Parameters.Clear( );
                if( _dbConnection.State == ConnectionState.Open ) _dbConnection.Close( );
                if( !dbDataReaderDynamic.IsClosed ) dbDataReaderDynamic.Close( );
            }
            catch( Exception e ) {
                Console.WriteLine( e.Message );
            }


            // DataSet, DataTable DataAdapter
            // -----------------------------------------------------------------------------          
            try {
                // Lesender Zugriff  - Select     
                DbDataAdapter dbDataAdapterCarTable = CreateDataAdapter("Select * from CarTable");
                DataTable dataTable = new DataTable();
                dbDataAdapterCarTable.Fill( dataTable );
        
                object o11 = dataTable.Rows[0][1];

                foreach( DataRow dataRow in dataTable.Rows ) {
                    object o1 = dataRow[0];
                }

                // Schreibender Zugriff - Insert
                DataRow dataRowInsert = dataTable.NewRow();
                string guid = CreateGUID();
                dataRowInsert [ "pkGUID" ] = guid;
                dataRowInsert [ "Make" ] = "Audi";
                dataRowInsert [ "Model" ] = "A8";
                dataRowInsert [ "Price" ] = 45000;
                dataRowInsert [ "Registration" ] = 2015;
                dataRowInsert [ "Mileage" ] = 12200;
                dataRowInsert [ "fkSeller" ] = -1;
                DataRowState dataRowState       =   dataRowInsert.RowState;
                dataTable.Rows.Add( dataRowInsert );
                dataRowState = dataRowInsert.RowState;                
            //  dbDataAdapterCarTable.Update( dataTable );

                // Schreibender Zugriff - Update
                DataRow dataRowUpdate = dataTable.Rows[5];
                double priceUpdate = Double.Parse(dataRowUpdate["Price"].ToString());
                dataRowUpdate [ "Price" ] = priceUpdate - 500;
                dataRowState = dataRowUpdate.RowState;
            //  dbDataAdapterCarTable.Update( dataTable );


                //  Schreibender Zugriff - Delete
                DataRow dataRowDelete = dataTable.Rows[10];
                dataRowDelete.Delete();
                dataRowState = dataRowDelete.RowState;
            //  dbDataAdapterCarTable.Update( dataTable );
            }
            catch( Exception e ) {
                Console.WriteLine( e.Message );
            }
        }

        public DbDataAdapter CreateDataAdapter( string sqlTable ) {

            DbCommand dbSelectCommand   = _dbProviderFactory.CreateCommand();
            dbSelectCommand.Connection = _dbConnection;
            dbSelectCommand.CommandText = sqlTable;

            DbDataAdapter dbDataAdapter = _dbProviderFactory.CreateDataAdapter();
            dbDataAdapter.SelectCommand = dbSelectCommand;

            DbCommandBuilder dbCommandBuilder = _dbProviderFactory.CreateCommandBuilder();
            dbCommandBuilder.DataAdapter = dbDataAdapter;
            dbDataAdapter.InsertCommand = dbCommandBuilder.GetInsertCommand( );
            dbDataAdapter.UpdateCommand = dbCommandBuilder.GetUpdateCommand( );
            dbDataAdapter.DeleteCommand = dbCommandBuilder.GetDeleteCommand( );

            return dbDataAdapter;
        }

        /// <summary>
        /// Erzeugen eines 8-Byte Schlüssels
        /// </summary>
        /// <returns></returns>
        public static string CreateGUID( ) {

            // 16 Byte Schlüssel
            System.Guid gUID = System.Guid.NewGuid();
            string strgUID = gUID.ToString();
            byte[] bUID = gUID.ToByteArray();

            // die ersten 8 Bytes werden verwendet
            long lUID = 0;
            lUID = lUID | ( long ) bUID [ 0 ];
            int shift = 8;
            for( int i = 1; i < 8; i++ ) {
                lUID = lUID | ( long ) bUID [ i ] << shift;
                shift = shift + 8;
            }
            //Console.WriteLine (string.Format("getGUID:{0:d}={1:s}",
            //    lUID,Utils.ToBinaryString (lUID)));

            return string.Format( "{0:d}", lUID );
        }

        static void Main( string [ ] args ) {
            new Test( ).Run2( );
            Console.ReadKey( );
        }
    }
}
/*
        "SELECT DISTINCT Make FROM CarTable ORDER BY Make;";
        
        "SELECT DISTINCT Model FROM CarTable WHERE Make='{0}' ORDER BY Model;",make);

        "SELECT * FROM CarDataTable WHERE Make='{0}' AND Model='{1}' AND "+
        "Preis >= {2} And Preis <={3} AND Zulassung >= {4} AND Zulassung <= {5}"
        , iCar.Make,iCar.Model,iCar.Price,iCar.PriceTo,iCar.Reg,iCar.RegTo);


        "SELECT COUNT(*) FROM CarTable;"
*/
