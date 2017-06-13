using System;
using System.Data;
using System.Data.Common;

using CompLogic;
using System.Windows.Forms;

namespace CompData
{
    internal abstract class ADataDis : IDataDis
    {

        #region Fields        
        private AData _aData;
        protected DbConnection _dbConnection;
        #endregion

        #region Ctor
        internal ADataDis(AData aData)
        {
            _aData = aData;
            _dbConnection = aData.Connection;
        }
        #endregion

        public virtual void InsertProduct(IProduct iProduct)
        {
            DbDataAdapter dbDataAdapter = this.CreateDbDataAdapter("Produkt");
            DataTable dataTable = this.GetSchema(dbDataAdapter);

            DbCommand dbCommand = dbDataAdapter.InsertCommand;
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = @"INSERT INTO Produkt ( [GUID], [Produktname], [Lagerbestand], [Kategorie], [Preis] ) VALUES (";
            dbCommand.CommandText += "[pGUID], [pProduktname], [pLagerbestand], [pKategorie], [pPreis])";
            this.AddParameter(dbCommand, "pGUID", Utils.CreateGUID().ToString());
            this.AddParameter(dbCommand, "pProduktname", iProduct.Name);
            this.AddParameter(dbCommand, "pLagerbestand", iProduct.Stock);
            this.AddParameter(dbCommand, "pKategorie", iProduct.Category);
            this.AddParameter(dbCommand, "pPreis", iProduct.Price);
            _dbConnection.Open();
            dbCommand.ExecuteNonQuery();
        }

        public virtual void InsertProductCategory(IProductCategory iProductCategory)
        {
            DbDataAdapter dbDataAdapter = this.CreateDbDataAdapter("Produktkategorie");
            DataTable dataTable = this.GetSchema(dbDataAdapter);

            DbCommand dbCommand = dbDataAdapter.InsertCommand;
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = @"INSERT INTO Produktkategorie ( [GUID], [Kategoriename]) VALUES (";
            dbCommand.CommandText += "[pGUID], [pKategoriename])";
            this.AddParameter(dbCommand, "pGUID", Utils.CreateGUID().ToString());
            this.AddParameter(dbCommand, "pKategoriename", iProductCategory.Name);
            _dbConnection.Open();
            dbCommand.ExecuteNonQuery();
        }

        public void SelectAllProducts(ref DataTable dataTable)
        {
            DbDataAdapter dbDataAdapter = this.CreateDbDataAdapter("Produkt");
            DbCommand dbCommand = dbDataAdapter.SelectCommand;
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = @"SELECT Produkt.*, Produktkategorie.Kategoriename FROM Produkt, Produktkategorie WHERE Produktkategorie.GUID = Produkt.Kategorie";
            Fill(dataTable, dbDataAdapter);
        }

        public void SelectProduct(IProduct iProduct, ref DataTable dataTable)
        {
            DbDataAdapter dbDataAdapter = this.CreateDbDataAdapter("Produkt");
            DbCommand dbCommand = dbDataAdapter.SelectCommand;
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = @"SELECT Produkt.*, Produktkategorie.Kategoriename FROM Produkt, Produktkategorie WHERE Produktkategorie.GUID = Produkt.Kategorie AND Produkt.GUID = [pGUID] order by Produktkategorie.Kategoriename";
            this.AddParameter(dbCommand, "pGUID", iProduct.GUID);
            Fill(dataTable, dbDataAdapter);
        }

        public void SelectAllProductCategories(ref DataTable dataTable)
        {
            DbDataAdapter dbDataAdapter = this.CreateDbDataAdapter("Produktkategorie");
            DbCommand dbCommand = dbDataAdapter.SelectCommand;
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = @"SELECT * FROM Produktkategorie";
            Fill(dataTable, dbDataAdapter);
        }

        public void SelectProductCategory(IProductCategory iProductCategory, ref DataTable dataTable)
        {
            DbDataAdapter dbDataAdapter = this.CreateDbDataAdapter("Produktkategorie");
            DbCommand dbCommand = dbDataAdapter.SelectCommand;
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = @"SELECT * FROM Produktkategorie WHERE GUID = [pGUID]";
            this.AddParameter(dbCommand, "pGUID", iProductCategory.GUID);
            Fill(dataTable, dbDataAdapter);
        }

        public void UpdateProduct(IProduct iProduct)
        {
            DbDataAdapter dbDataAdapter = this.CreateDbDataAdapter("Produkt");
            DataTable tableContent = new DataTable();
            SelectAllProducts(ref tableContent);
            foreach (DataRow row in tableContent.Rows)
            {
                if (row["GUID"].ToString().CompareTo(iProduct.GUID) == 0)
                {
                    if (iProduct.Name != null) row["Produktname"] = iProduct.Name;
                    if (iProduct.Category != null) row["Kategorie"] = iProduct.Category;
                    if (iProduct.Stock != null) row["Lagerbestand"] = iProduct.Stock;
                    if (iProduct.Price != null) row["Preis"] = iProduct.Price;
                    break;
                }
            }
            Update(tableContent, dbDataAdapter);
        }

        /*
        public virtual void RestockProduct(string guid, int restockNumber)
        {
            DbDataAdapter dbDataAdapter = this.CreateDbDataAdapter("Produkt");
            DataTable tableContent = new DataTable();
            SelectAllProducts(ref tableContent);
            foreach (DataRow row in tableContent.Rows)
            {
                if (row["GUID"].ToString().CompareTo(guid) == 0)
                {
                    int stock = Utils.ParseInt(row["Lagerbestand"].ToString(), 0);
                    row["Lagerbestand"] = stock + restockNumber;
                    break;
                }
            }
            Update(tableContent, dbDataAdapter);
        }
        */

        protected void AddParameter(DbCommand dbCommand, string name, object value)
        {
            DbParameter dbParameter = _aData.ProviderFactory.CreateParameter();
            dbParameter.ParameterName = name;
            dbParameter.Value = value;
            dbCommand.Parameters.Add(dbParameter);
        }

        protected virtual DbDataAdapter CreateDbDataAdapter(string tableName)
        {

            DbCommand dbSelectCommand = _aData.ProviderFactory.CreateCommand();
            dbSelectCommand.Connection = _dbConnection;
            dbSelectCommand.CommandText = string.Format("SELECT * FROM {0}", tableName);

            DbDataAdapter dbDataAdapter = _aData.ProviderFactory.CreateDataAdapter();
            dbDataAdapter.SelectCommand = dbSelectCommand;
            // --- fertig, wenn keine schreibenden Datenbankzugriffe erforderlich ----

            DbCommandBuilder dbCommandBuilder = _aData.ProviderFactory.CreateCommandBuilder();
            dbCommandBuilder.DataAdapter = dbDataAdapter;
            dbDataAdapter.InsertCommand = dbCommandBuilder.GetInsertCommand();
            dbDataAdapter.UpdateCommand = dbCommandBuilder.GetUpdateCommand();
            dbDataAdapter.DeleteCommand = dbCommandBuilder.GetDeleteCommand();

            return dbDataAdapter;
        }

        protected virtual int Fill(DataTable dataTable, DbDataAdapter dbDataAdapter)
        {
            // preconditions
            if (dataTable == null)
                throw new Exception(" ADatabase.Fill() dataTable is null");
            if (dbDataAdapter == null)
                throw new Exception(" ADatabase.Fill() dbDataAdapter is null");

            int nRows = 0;
            try
            {
                nRows = dbDataAdapter.Fill(dataTable);
                return nRows;
            }
            catch (Exception exception)
            {
                string sql = dbDataAdapter.SelectCommand.CommandText;
                string message = string.Format("ADatabase.Fill() {0} fails\n", sql) + exception.Message;
                throw new Exception(message);
            }
        }

        protected virtual int Update(DataTable dataTable, DbDataAdapter dbDataAdapter)
        {
            // preconditions
            if (dataTable == null)
                throw new Exception(" ADatabase.Update() dataTable is null");
            if (dbDataAdapter == null)
                throw new Exception(" ADatabase.Update() dbDataAdapter is null");

            int nRows = dbDataAdapter.Update(dataTable);
            // post condition is nRows == 0 zulässig?

            return nRows;
        }

        public virtual DataTable GetSchema(DbDataAdapter dbDataAdapter)
        {
            // preconditions
            if (dbDataAdapter == null)
                throw new Exception(" ADatabase.GetSchema() dbDataAdapter is null");

            try
            {
                DataTable dataTable = new DataTable();
                dataTable = dbDataAdapter.FillSchema(dataTable, SchemaType.Source);
                return dataTable;
            }
            catch (Exception exception)
            {
                string message = string.Format("ADatabase.GetSchema() {0} fails\n") + exception.Message;
                throw new Exception(message);
            }
        }


    }
}
