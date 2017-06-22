using System;
using System.Data;
using System.Data.Common;

using CompLogic;
using System.Windows.Forms;

namespace CompData
{
    //Dient als Vaterklasse für CDataDisAccess. Implementiert die Funktionen, die in IDataDis definiert werden.
    internal abstract class ADataAccess : IDataAccess
    {

        #region Fields        
        private AData _aData;
        protected DbConnection _dbConnection;
        #endregion

        #region Ctor
        internal ADataAccess(AData aData)
        {
            _aData = aData;
            _dbConnection = aData.Connection;
        }
        #endregion

        //Fügt das IProduct in die Datenbank ein
        public virtual bool InsertProduct(IProduct iProduct)
        {
            DbDataAdapter dbDataAdapter = this.CreateDbDataAdapter("Produkt");
            DataTable dataTable = this.GetSchema(dbDataAdapter);

            DbCommand dbCommand = dbDataAdapter.InsertCommand;
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = @"INSERT INTO Produkt ( [GUID], [Produktname], [Lagerbestand], [Kategorie], [Preis] ) VALUES (";
            dbCommand.CommandText += "[pGUID], [pProduktname], [pLagerbestand], [pKategorie], [pPreis])";
            this.AddParameter(dbCommand, "pGUID", iProduct.GUID);
            this.AddParameter(dbCommand, "pProduktname", iProduct.Name);
            this.AddParameter(dbCommand, "pLagerbestand", iProduct.Stock);
            this.AddParameter(dbCommand, "pKategorie", iProduct.Category.GUID);
            this.AddParameter(dbCommand, "pPreis", iProduct.Price);
            _dbConnection.Open();
            bool result = true;
            try
            {
                dbCommand.ExecuteNonQuery();
            }
            catch (System.Data.OleDb.OleDbException)
            {
                result = false;
            }
            _dbConnection.Close();
            return result;
        }

        //Fügt die IProductCategory in die Datenbank ein
        public virtual void InsertProductCategory(IProductCategory iProductCategory)
        {
            DbDataAdapter dbDataAdapter = this.CreateDbDataAdapter("Produktkategorie");
            DataTable dataTable = this.GetSchema(dbDataAdapter);

            DbCommand dbCommand = dbDataAdapter.InsertCommand;
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = @"INSERT INTO Produktkategorie ( [GUID], [Kategoriename]) VALUES (";
            dbCommand.CommandText += "[pGUID], [pKategoriename])";
            this.AddParameter(dbCommand, "pGUID", iProductCategory.GUID);
            this.AddParameter(dbCommand, "pKategoriename", iProductCategory.Name);
            _dbConnection.Open();
            dbCommand.ExecuteNonQuery();
            _dbConnection.Close();
        }

        //Führt einen full-table-scan der Produkt-Tabelle aus
        public void SelectAllProducts(ref DataTable dataTable)
        {
            DbDataAdapter dbDataAdapter = this.CreateDbDataAdapter("Produkt");
            DbCommand dbCommand = dbDataAdapter.SelectCommand;
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = @"SELECT Produkt.*, Produktkategorie.Kategoriename FROM Produkt, Produktkategorie WHERE Produktkategorie.GUID = Produkt.Kategorie order by Produktkategorie.Kategoriename, Produkt.Produktname, Produkt.GUID";
            Fill(dataTable, dbDataAdapter);
        }

        //Selektiert ein IProduct via GUID-Index
        public void SelectProduct(IProduct iProduct, ref DataTable dataTable)
        {
            DbDataAdapter dbDataAdapter = this.CreateDbDataAdapter("Produkt");
            DbCommand dbCommand = dbDataAdapter.SelectCommand;
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = @"SELECT Produkt.*, Produktkategorie.Kategoriename FROM Produkt, Produktkategorie WHERE Produktkategorie.GUID = Produkt.Kategorie AND Produkt.GUID = [pGUID]";
            this.AddParameter(dbCommand, "pGUID", iProduct.GUID);
            Fill(dataTable, dbDataAdapter);
        }

        //Führt einen full-table-scan der Produkt-Kategorie-Tabelle aus
        public void SelectAllProductCategories(ref DataTable dataTable)
        {
            DbDataAdapter dbDataAdapter = this.CreateDbDataAdapter("Produktkategorie");
            DbCommand dbCommand = dbDataAdapter.SelectCommand;
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = @"SELECT * FROM Produktkategorie";
            Fill(dataTable, dbDataAdapter);
        }

        //Selektiert eine IProductCategory via GUID-Index
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

        //Ändert die Werte der Datarow mit der GUID von IProduct ab, sodass alle Werte denen von IProduct entsprechen.
        //null-Werte werden ignoriert.
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
                    if (iProduct.Category != null) row["Kategorie"] = iProduct.Category.GUID;
                    if (iProduct.Stock != null) row["Lagerbestand"] = iProduct.Stock;
                    if (iProduct.Price != null) row["Preis"] = iProduct.Price;
                    break;
                }
            }
            Update(tableContent, dbDataAdapter);
        }

        //Fügt dbCommand einen dbParameter mit den Werten name und value hinzu.
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

        //Rumrahmt die DbDataAdapter.Fill-Methode mit Fehlerbehandelungen
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

        //Rumrahmt die DbDataAdapter.Update-Methode mit Fehlerbehandelungen
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

        //Rumrahmt die DbDataAdapter.FillSchema-Methode mit Fehlerbehandelungen
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
