using CompLogic.Product;
using CompLogic.ProductCategory;
using System.Collections.Generic;
using System.Data;

namespace CompLogic
{

    internal class CLogic : ILogicSearch, ILogicInsert, ILogicUpdate, ILogicWarning, ILogic
    {

        #region Fields
        private IData _iData;
        private IDataAccess _iDataDis;
        #endregion

        #region Properties         
        public ILogicSearch LogicSearch { get { return this; } }
        public ILogicInsert LogicInsert { get { return this; } }
        public ILogicUpdate LogicUpdate { get { return this; } }
        public ILogicWarning LogicWarning { get { return this; } }
        #endregion

        #region Ctor
        internal CLogic(IData iData)
        {
            _iData = iData;
            _iDataDis = iData.DataAccess;
        }
        #endregion

        #region Interface ILogicSearch Methods
        // Füllt die übergebene DataTable mit den Komletten Daten der Produkttabelle
        public void SelectAllProducts(ref DataTable datatable)
        {
            // Reicht den Aufruf zur füllung des DataTables in die Datenschicht runter
            _iDataDis.SelectAllProducts(ref datatable);
            // Löscht alle Leeren Zeilen
            foreach (DataRow row in datatable.Rows)
            {
                if (row.IsNull(0))
                {
                    row.Delete();
                }
            }
        }
        // Füllt die ubergebene DataTable mit den Kompletten daten der Produktkategorietabelle
        public void SelectAllProductCategories(ref DataTable datatable) // Not needed
        {
            // Reicht den Aufruf zur füllung des DataTables in die Datenschicht runter
            _iDataDis.SelectAllProductCategories(ref datatable);
        }
        //Liste der Produkte wird mit Daten aus der Produckttabelle gefüllt
        public void FillListProduct(ref List<IProduct> listIProduct, List<IProductCategory> listIProductCategory)
        {
            listIProduct.Clear();
            //Tabelle wird aus Datenbank geholt
            DataTable datatable = new DataTable();
            _iDataDis.SelectAllProducts(ref datatable);
            // Für jede Zeile der Tabelle wird ein Produktobjekt erstellt und in die Liste eingefügt
            foreach (DataRow row in datatable.Rows)
            {
                foreach(IProductCategory category in listIProductCategory)
                {
                    // Passenedes Kategorieobjekt aus der Kategorieliste wird gesucht
                    if (row["Kategorie"].ToString().CompareTo(category.GUID) == 0)
                    {
                        // Liste wird mit neuen Objekten gefüllt
                        listIProduct.Add(new CProduct(row["GUID"].ToString(), row["Produktname"].ToString(), category, double.Parse(row["Preis"].ToString()), int.Parse(row["Lagerbestand"].ToString())));
                    }
                }
            }
        }
        // Liste der Kategorien wird mit den Daten der Producktkategorien Tabelle gefüllt
        public void FillListCategory(ref List<IProductCategory> listICategory)
        {
            listICategory.Clear();
            // Tabelle wird aus Datenbank geholt
            DataTable datatable = new DataTable();
            _iDataDis.SelectAllProductCategories(ref datatable);
            foreach (DataRow row in datatable.Rows)
            {
                // Liste wird mit neuen objekten gefüllt
                listICategory.Add(new CProductCategory(row["GUID"].ToString(), row["Kategoriename"].ToString()));
            }
        }
        #endregion

        #region Interface ILogicInsert Methods
        // Gibt den Aufruf für das einfügen eines neuen Produktes in die Produkttabelle an die  Datenschicht weiter
        public void InsertProduct(IProduct iProduct)
        {
            _iDataDis.InsertProduct(iProduct);
        }
        // Gibt den Aufruf für das einfügen einer neuen Produktkategorie in die Produktkategorietabelle an die Datenschichrt weiter
        public void InsertProductCategory(IProductCategory iProductCategory)
        {
            _iDataDis.InsertProductCategory(iProductCategory);
        }
        #endregion

        #region Interface ILogicUpdate Methods
        //Stockt ein Produkt mit einer guid um einer Menge auf
        public bool RestockProduct(string guid, int restockNumber)
        {
            DataTable dataTable = new DataTable();

            IProduct iProduct = new CFactoryCProduct().Create();
            iProduct.GUID = guid;
            // Alter Lagerbestand wir aus Datenbank geholt
            _iDataDis.SelectProduct(iProduct, ref dataTable);
            int oldStock = (System.Int32)dataTable.Rows[0]["Lagerbestand"];
            
            // neuer Lagerbestand wird errechnet
            iProduct.Stock = oldStock + restockNumber;
            if (iProduct.Stock >= 0)
            {
                // Datensatz wird zum Update in die Datenschicht gegeben
                _iDataDis.UpdateProduct(iProduct);
                return true;
            }
            else
            {
                return false;
            }
        }
        // Restocks a Product with an IProduct and the Attributes associated with it
        public void RestockProduct(IProduct iProduct)
        {
            if(iProduct.Stock >=0)
            {
                _iDataDis.UpdateProduct(iProduct);
            }
        }
        // Verkauft ein Produkt nutzt die Restock funktion der Datenschicht negiert aber den Wert sodass er abgezuogen wird
        public bool SellProduct(string guid, int restockNumber)
        {
            return RestockProduct(guid, restockNumber * -1);
        }
        #endregion

        #region Interface ILogicWarning Methods
        /// <summary>
        /// Returns a formated DataTable where all unnecessary columns and rows witch are above the given limit of stock,
        /// are deleted
        /// </summary>
        /// <param name="toformat">DataTable that needs to be formated</param>
        /// <param name="limit">limit at witch the rows with more stock will be removed</param>
        /// <returns>The formated DataTable</returns>
        public DataTable Format(DataTable toformat, decimal limit)
        {
            toformat.Columns.Remove("GUID");
            toformat.Columns.Remove("Kategorie");
            toformat.Columns.Remove("Preis");
            toformat.Columns.Remove("Kategoriename");

            for (int row = toformat.Rows.Count - 1; row >= 0; row--)
            {
                if (((System.Int32)toformat.Rows[row]["Lagerbestand"]) > limit)
                {
                    toformat.Rows[row].Delete();
                }
            }
            toformat.AcceptChanges();
            return toformat;
        }
        /// <summary>
        /// Returns a formated DataTable where all unnecessary columns and rows witch are above the given limit of stock<
        /// </summary>
        /// <param name="limit">limit at witch the rows with more stock will be removed</param>
        /// <returns>The formated DataTable</returns>
        public DataTable Format(decimal limit)
        {
            // Holt die Komplette Produkttabelle aus der Datenbank
            DataTable toformat = new DataTable();
            _iDataDis.SelectAllProducts(ref toformat);

            // Löscht Spalten, die für die Darstellung unwichtig sind
            toformat.Columns.Remove("GUID");
            toformat.Columns.Remove("Kategorie");
            toformat.Columns.Remove("Preis");
            toformat.Columns.Remove("Kategoriename");

            // Löscht alle Zeilen aus der DatatTable, die Über dem übergeben Grenzwert liegen, sodass nur die Für die Warung nötigen Zeilen übrig bleiben
            for (int row = toformat.Rows.Count - 1; row >= 0; row--)
            {
                if (((System.Int32)toformat.Rows[row]["Lagerbestand"]) > limit)
                {
                    toformat.Rows[row].Delete();
                }
            }
            // Nötig da DataTable transaktionsbasiert ist
            toformat.AcceptChanges();
            return toformat;
        }
        #endregion
    }
}
