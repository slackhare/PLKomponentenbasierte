using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using CompLogic;
namespace CompData {
    internal abstract class ADataCon : IDataCon {

        #region Fields        
        private    AData            _aData;
        protected  DbConnection     _dbConnection;
        protected  DbCommand        _dbCommand;
        #endregion

        #region Ctor
        public ADataCon( AData aData ) {
            _aData                  = aData;
            _dbConnection           = aData.Connection;
            _dbCommand              = aData.ProviderFactory.CreateCommand();
            _dbCommand.Connection   = aData.Connection;
            _dbCommand.CommandType  = CommandType.Text;
        }
        #endregion

        #region interface IDataCon methods
        // number of cars in database
        public void Init( ref int nCars, out object[] arrayMake ) {
            this.DbCommandCountCars( _dbCommand );
            this.Open();
            nCars = (int) this.ExecuteScalar( _dbCommand );

            this.DbCommandGetMake( _dbCommand );
            DbDataReader dbDataReader = this.ExecuteQuery( _dbCommand );
            // Schleife über ResultSet
            List<object> listMake = new List<object>();
            while ( dbDataReader.Read() ) {
                listMake.Add(dbDataReader[0]);
            }
            arrayMake = listMake.ToArray();
            if( !dbDataReader.IsClosed) dbDataReader.Close();
            this.Close();
        }

        public void InitCat(out object[] arrayCategory)
        {
            this.DbCommandGetCategory(_dbCommand);
            this.Open();

            DbDataReader dbDataReader = this.ExecuteQuery(_dbCommand);
            // Schleife über ResultSet
            List<object> listCategory = new List<object>();
            while (dbDataReader.Read())
            {
                listCategory.Add(dbDataReader[0]);
            }
            arrayCategory = listCategory.ToArray();
            if (!dbDataReader.IsClosed) dbDataReader.Close();
            this.Close();
        }

        // List of models for a specified maker
        public object[] GetModel( string make) {
            this.DbCommandGetModel( make, _dbCommand );
            this.Open();
            DbDataReader dbDataReader = this.ExecuteQuery( _dbCommand );
            List<object> listModel = new List<object>();
            while ( dbDataReader.Read() ) {
                listModel.Add(dbDataReader[0]);
            }
            if( !dbDataReader.IsClosed)  dbDataReader.Close();
            this.Close();
            return listModel.ToArray();
        }        
        #endregion

        #region virtual methods
        protected virtual void DbCommandCountCars( DbCommand dbCommand ) {
            dbCommand.CommandText =
                 @"SELECT COUNT(*) FROM CarTable";
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
        }

        protected virtual void DbCommandGetMake( DbCommand dbCommand ) {
            dbCommand.CommandText =
                 @"SELECT DISTINCT Make FROM CarTable ORDER BY Make";
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
        }

        protected virtual void DbCommandGetCategory(DbCommand dbCommand)
        {
            dbCommand.CommandText =
                 @"SELECT DISTINCT Kategoriename FROM Produktkategorie ORDER BY Kategoriename";
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
        }

        protected virtual void DbCommandGetModel( string make, DbCommand dbCommand ) {
            dbCommand.CommandText =
                @"SELECT DISTINCT Model FROM CarTable WHERE Make = [pMake] ORDER BY Model";
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear( );
            DbParameter dbParameter = _aData.ProviderFactory.CreateParameter();
            dbParameter.ParameterName = "pMake";
            dbParameter.Value = make;
            dbCommand.Parameters.Add( dbParameter );
        }        
      
        protected virtual void Open( ) {
            // Ist die Db schon geöffent -> nichts tun
            if( _dbConnection.State != ConnectionState.Open ) {
                // DB öffnen
                _dbConnection.Open( );
                // Test ob DB jetz offen ist
                if( _dbConnection.State != ConnectionState.Open ) return;
            }
        }

        protected virtual void Close( ) {
            if( _dbConnection.State == ConnectionState.Open )
                _dbConnection.Close( );
        }
        
        protected virtual object ExecuteScalar( DbCommand dbCommand ) {
            if( ! ( _dbConnection.State == ConnectionState.Open)  )
                _dbConnection.Open();
            try {
                object obj = dbCommand.ExecuteScalar();
                return obj;
            }
            catch( Exception exception ) {
                string sql = dbCommand.CommandText;
                string message = string.Format("ADatabase.ExecuteScalar() {0} fails\n",sql) 
                               + exception.Message;
                throw new Exception( message );
            }
            
        }

        protected virtual DbDataReader ExecuteQuery( DbCommand dbCommand ) {
         
            DbDataReader dbDataReader = null;
            if( ! ( _dbConnection.State == ConnectionState.Open)  )
                _dbConnection.Open();

            try {
                dbDataReader = dbCommand.ExecuteReader( );
                return dbDataReader;
            }
            catch( Exception exception ) {
                string sql = dbCommand.CommandText;
                string message = string.Format("ADatabase.ExecuteQuery() {0} fails\n",sql) + exception.Message;
                throw new Exception( message );
            }
        }
        #endregion
    }
}


//// SQL-Injection bezeichnet das Ausnutzen einer Sicherheitslücke in SQL-Datenbanken, 
//            // die durch mangelnde Maskierung oder Überprüfung von Metazeichen in Benutzereingaben 
//            // entsteht.
//            // CommandText = "SELECT DISTINCT Model FROM CarTable WHERE Make='Opel'";
//            // CommandText = "SELECT DISTINCT Model FROM CarTable WHERE Make='Opel';DELETE ...; ";
//            // -----------------------------------------------------------------------------            
//            // Create a Stored Procedure
//            //try {
//            //    DbCommand dbCommandStoredProcedure = _dbProviderFactory.CreateCommand();
//            //    dbCommandStoredProcedure.Connection = _dbConnection;
//            //    dbCommandStoredProcedure.CommandText =
//            //        "CREATE PROCEDURE CarTable_SelectModelByMake (pMake TEXT) "+
//            //        "as SELECT DISTINCT Model FROM CarTable WHERE Make= [pMake] ORDER BY Model;";
//            //    dbCommandStoredProcedure.CommandType = CommandType.Text; // Achtung Type
//            //    if( _dbConnection.State == ConnectionState.Closed) _dbConnection.Open();
//            //    dbCommandStoredProcedure.ExecuteNonQuery();
//            //    if( _dbConnection.State == ConnectionState.Open) _dbConnection.Close();
//            //}            
//            //catch( Exception e ) {
//            //    Console.WriteLine( e.Message );
//            //}

//            // Benutzen der Stored Procedure
//            try {
//                DbCommand dbCommand = _dbProviderFactory.CreateCommand();
//                dbCommand.Connection = _dbConnection;
//                dbCommand.CommandText ="CarTable_SelectModelByMake";
//                dbCommand.CommandType = CommandType.StoredProcedure;

//                DbParameter dbParameter = _dbProviderFactory.CreateParameter();
//                dbParameter.ParameterName = "pMake";
//                dbParameter.Value         = "Opel";
//                dbCommand.Parameters.Clear();
//                dbCommand.Parameters.Add( dbParameter );

//                if( _dbConnection.State == ConnectionState.Closed) _dbConnection.Open();
//                DbDataReader dataReader = dbCommand.ExecuteReader();
//                if( dataReader.HasRows ) {
//                    List<object> listModel = new List<object>();
//                    while( dataReader.Read( ) ) {
//                        listModel.Add( dataReader [ 0 ] );
//                    }
//                    dataReader.Close( );
//                }
//                if( _dbConnection.State == ConnectionState.Open) _dbConnection.Close();
//            }
//            catch( Exception e ) {
//                Console.WriteLine( e.Message );
//            }

//            // Dynamic SQL Statement
//            // ----------------------------------------------------------------------------------------
//            try {
//                DbCommand dbCommand = _dbProviderFactory.CreateCommand();
//                dbCommand.Connection = _dbConnection;
//                dbCommand.CommandText =
//                    "SELECT DISTINCT Model FROM CarTable WHERE Make= [pMake] ORDER BY Model;";
//                DbParameter dbParameter = _dbProviderFactory.CreateParameter();
//                dbCommand.CommandType = CommandType.Text;
//                dbParameter.ParameterName = "pMake";
//                dbParameter.Value         = "Audi";
//                dbCommand.Parameters.Clear();
//                dbCommand.Parameters.Add( dbParameter );

//                if( _dbConnection.State == ConnectionState.Closed) _dbConnection.Open();
//                DbDataReader dataReader = dbCommand.ExecuteReader();
//                if( dataReader.HasRows ) {
//                    List<object> listModel = new List<object>();
//                    while( dataReader.Read( ) ) {
//                        listModel.Add( dataReader [ 0 ] );
//                    }
//                    dataReader.Close( );
//                }
//                if( _dbConnection.State == ConnectionState.Open) _dbConnection.Close();
//                 }
//            catch( Exception e ) {
//                Console.WriteLine( e.Message );
//            }

//            // DataAdapter DataSet, DataTable
//            // ---------------------------------------------------------------------------------
//            DbDataAdapter dbDataAdapterCarTable = this.CreateDataAdapter("SELECT * FROM CarTable");
//            DataTable dataTable = new DataTable();
//            dbDataAdapterCarTable.Fill( dataTable );
//            if( dataTable.Rows.Count > 0) { 
//                object o11 = dataTable.Rows[0][1];
//                foreach( DataRow dataRow in dataTable.Rows) {
//                    string pk   = dataRow[0] as string;
//                    string make = dataRow["Make"] as string;
//                }
//            }
//            // -> Darstellung in der UI mit DataGridView ...

//            // Schreiber Zugriff - Insert
//            DataRow dataRowInsert = dataTable.NewRow();
//            string guid = CreateGUID();
//            dataRowInsert["pkGUID"] = guid;
//            dataRowInsert["Make"]   ="Audi";
//            dataRowInsert["Model"]  ="A8";
//            dataRowInsert["Price"]  = 45000;
//            dataRowInsert["Registration"]   = 2015;
//            dataRowInsert["Mileage"]   = 12000;
//            dataRowInsert["fkSeller"]   = -1;
//            dataTable.Rows.Add( dataRowInsert );
//            DataRowState dataRowState = dataRowInsert.RowState;

//            dbDataAdapterCarTable.Update( dataTable );
//        }


//        public DbDataAdapter CreateDataAdapter( string sqlTable ) {
//            // sqlTable: SELECT * FROM CarTable
//            DbCommand dbSelectCommand = _dbProviderFactory.CreateCommand();
//            dbSelectCommand.Connection = _dbConnection;
//            dbSelectCommand.CommandText = sqlTable;

//            DbDataAdapter dbDataAdapter = _dbProviderFactory.CreateDataAdapter();
//            dbDataAdapter.SelectCommand = dbSelectCommand;
//            // --- fertig, wenn keine schreibenden Datenbankzugriffe erforderlich ----

//            DbCommandBuilder dbCommandBuilder = _dbProviderFactory.CreateCommandBuilder();
//            dbCommandBuilder.DataAdapter = dbDataAdapter;
//            dbDataAdapter.InsertCommand = dbCommandBuilder.GetInsertCommand();
//            dbDataAdapter.UpdateCommand = dbCommandBuilder.GetUpdateCommand();
//            dbDataAdapter.DeleteCommand = dbCommandBuilder.GetDeleteCommand();
            
//            return dbDataAdapter;
//        }