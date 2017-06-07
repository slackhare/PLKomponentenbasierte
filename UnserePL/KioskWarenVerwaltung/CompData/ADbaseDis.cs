using System;
using System.Data;
using System.Data.Common;

using CompLogic;
namespace CompData {
    internal abstract class ADataDis : IDataDis {

        #region Fields        
        private    AData            _aData;
        protected  DbConnection     _dbConnection;
        #endregion

        #region Ctor
        internal ADataDis( AData aData ) {
            _aData        = aData;
            _dbConnection = aData.Connection;
        }
        #endregion

        public virtual void InsertCar(ICar iCar)
        {
            DbDataAdapter dbDataAdapter = this.CreateDbDataAdapter("CarTable");
            DataTable dataTable = this.GetSchema(dbDataAdapter);
            iCar.AddNewDataRow(dataTable);
        }
           
        public virtual void InsertProduct( IProduct iProduct) {
            DbDataAdapter dbDataAdapter = this.CreateDbDataAdapter( "Produkt" );
            DataTable dataTable = this.GetSchema( dbDataAdapter );
            iProduct.AddNewDataRow( dataTable );
        }

        public virtual void InsertProductCategory(IProductCategory iProductCategory)
        {
            DbDataAdapter dbDataAdapter = this.CreateDbDataAdapter("Produktkategorie");
            DataTable dataTable = this.GetSchema(dbDataAdapter);
            iProductCategory.AddNewDataRow(dataTable);
        }

        public void SelectCar( ICar iCar, ref DataTable dataTable) {            
            DbDataAdapter dbDataAdapter = this.CreateDbDataAdapter( "CarTable" );
            DbCommand dbCommand = dbDataAdapter.SelectCommand;
            this.DbCommandSelectCar( iCar, dbCommand );
            dbDataAdapter.Fill( dataTable );                      
        }

        public void SelectProduct(IProduct iProduct, ref DataTable dataTable)
        {
            DbDataAdapter dbDataAdapter = this.CreateDbDataAdapter("Produkt");
            DbCommand dbCommand = dbDataAdapter.SelectCommand;
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = @"SELECT * FROM Produkt";
            dbDataAdapter.Fill(dataTable);
        }
        public void SelectProductCategory(IProductCategory iProductCategory, ref DataTable dataTable)
        {
            DbDataAdapter dbDataAdapter = this.CreateDbDataAdapter("Produktkategorie");
            DbCommand dbCommand = dbDataAdapter.SelectCommand;
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = @"SELECT * FROM Produktkategorie";
            dbDataAdapter.Fill(dataTable);
        }

        public virtual void UpdateProduct(IProduct iProduct)
        {
            //TODO Methode Schreiben
        }

        protected virtual void DbCommandSelectCar( ICar iCar, DbCommand dbCommand ) {

            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();      
            dbCommand.CommandText =  @"SELECT * FROM CarTable";

            if( iCar.Make != "Alle" ) {
                dbCommand.CommandText += " WHERE Make = [pMake]";
                this.AddParameter( dbCommand, "pMake", iCar.Make );
            }
            if( iCar.Model != "Alle" ) {
                dbCommand.CommandText += " AND Model = [pModel]";
                this.AddParameter( dbCommand, "pModel", iCar.Model );
            }

            dbCommand.CommandText +=  " AND Price <= [pPrice]";
            this.AddParameter( dbCommand, "pPrice", iCar.Price );

            dbCommand.CommandText +=  " AND Registration >= [pRegistration]";
            this.AddParameter( dbCommand, "pRegistration", iCar.Registration  );
            
            dbCommand.CommandText +=  " AND Mileage <= [pMileage]";
            this.AddParameter( dbCommand, "pMileage", iCar.Mileage  );
            
            dbCommand.CommandText += " ORDER BY Price";
        }

        protected void AddParameter( DbCommand dbCommand, string name, object value ) {
            DbParameter dbParameter = _aData.ProviderFactory.CreateParameter();
            dbParameter.ParameterName = name;
            dbParameter.Value = value;
            dbCommand.Parameters.Add( dbParameter ); 
        }

        protected virtual DbDataAdapter CreateDbDataAdapter( string tableName ) {

            DbCommand dbSelectCommand = _aData.ProviderFactory.CreateCommand();
            dbSelectCommand.Connection = _dbConnection;
            dbSelectCommand.CommandText = string.Format("SELECT * FROM {0}",tableName);

            DbDataAdapter dbDataAdapter =  _aData.ProviderFactory.CreateDataAdapter();
            dbDataAdapter.SelectCommand = dbSelectCommand;
            // --- fertig, wenn keine schreibenden Datenbankzugriffe erforderlich ----

            DbCommandBuilder dbCommandBuilder = _aData.ProviderFactory.CreateCommandBuilder();
            dbCommandBuilder.DataAdapter = dbDataAdapter;
            dbDataAdapter.InsertCommand = dbCommandBuilder.GetInsertCommand();
            dbDataAdapter.UpdateCommand = dbCommandBuilder.GetUpdateCommand();
            dbDataAdapter.DeleteCommand = dbCommandBuilder.GetDeleteCommand();
            
            return dbDataAdapter;
        }

        protected virtual int Fill( DataTable dataTable, DbDataAdapter dbDataAdapter ) {
            // preconditions
            if( dataTable == null )
                throw new Exception( " ADatabase.Fill() dataTable is null" );
            if( dbDataAdapter == null )
                throw new Exception( " ADatabase.Fill() dbDataAdapter is null" );

            int nRows = 0;
            try {
                nRows = dbDataAdapter.Fill( dataTable );
                return nRows;
            }
            catch( Exception exception ) {
                string sql = dbDataAdapter.SelectCommand.CommandText;
                string message = string.Format("ADatabase.Fill() {0} fails\n",sql) + exception.Message;
                throw new Exception( message );
            }
        }

        protected virtual int Update( DataTable dataTable, DbDataAdapter dbDataAdapter ) {
            // preconditions
            if( dataTable == null )
                throw new Exception( " ADatabase.Update() dataTable is null" );
            if( dbDataAdapter == null )
                throw new Exception( " ADatabase.Update() dbDataAdapter is null" );

            int nRows = 0;
            try {
                nRows = dbDataAdapter.Update( dataTable );
                // post condition is nRows == 0 zulässig?
            }
            catch( Exception exception ) {
                string message = string.Format("ADatabase.Update() fails\n") + exception.Message;
                throw new Exception( message );
            }
            return nRows;
        }       
        
        public virtual DataTable GetSchema( DbDataAdapter dbDataAdapter ) {
            // preconditions
            if( dbDataAdapter == null)
                throw new Exception(" ADatabase.GetSchema() dbDataAdapter is null");

            try {
                DataTable dataTable = new DataTable();
                dataTable = dbDataAdapter.FillSchema( dataTable,SchemaType.Source );
                return dataTable;
            }
            catch( Exception exception ) {
                string message = string.Format("ADatabase.GetSchema() {0} fails\n") + exception.Message;
                throw new Exception( message );
            }
        }


    }
}
