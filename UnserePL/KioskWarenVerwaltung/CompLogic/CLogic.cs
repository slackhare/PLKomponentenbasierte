using System.Data;
using CompLogic.Product;

namespace CompLogic
{

    internal class CLogic : ILogicSearch, ILogicTrade, ILogicUpdate, ILogicWarning, ILogic
    {

        #region Fields
        private IData _iData;
        private IDataCon _iDataCon;
        private IDataDis _iDataDis;
        #endregion

        #region Properties         
        public ILogicSearch LogicSearch { get { return this; } }
        public ILogicTrade LogicTrade { get { return this; } }
        public ILogicUpdate LogicUpdate { get { return this; } }
        public ILogicWarning LogicWarning { get { return this; } }
        #endregion

        #region Ctor
        internal CLogic(IData iData)
        {
            _iData = iData;
            _iDataCon = iData.DataCon;
            _iDataDis = iData.DataDis;
        }
        #endregion

        #region Interface ILogicSearch Methods
        public void Init(ref int nCars, out object[] arrayMake)
        {
            _iDataCon.Init(ref nCars, out arrayMake);
        }

        public void InitCat(out object[] arrayCategory)
        {
            _iDataCon.InitCat(out arrayCategory);
        }

        public object[] GetModel(string make)
        {
            return _iDataCon.GetModel(make);
        }

        public void SelectProduct(ref DataTable datatable)
        {
            _iDataDis.SelectAllProducts(ref datatable);
            foreach (DataRow row in datatable.Rows)
            {
                if (row.IsNull(0))
                {
                    row.Delete();
                }
            }
        }

        public void SelectProductCategory(ref DataTable datatable) // Not needed
        {
            _iDataDis.SelectAllProductCategories(ref datatable);
        }
        #endregion

        #region Interface ILogicTrade Methods
        public void InsertProduct(IProduct iProduct)
        {
            _iDataDis.InsertProduct(iProduct);
        }
        public void InsertProductCategory(IProductCategory iProductCategory)
        {
            _iDataDis.InsertProductCategory(iProductCategory);
        }
        #endregion

        #region Interface ILogicUpdate Methods
        //Stockt ein Produkt mit einer guid um eine Menge auf
        public bool RestockProduct(string guid, int restockNumber)
        {
            DataTable dataTable = new DataTable();

            IProduct iProduct = new CFactoryCProduct().Create();
            iProduct.GUID = guid;
            _iDataDis.SelectProduct(iProduct, ref dataTable);
            int oldStock = (System.Int32)dataTable.Rows[0]["Lagerbestand"];
            iProduct.Stock = oldStock + restockNumber;
            if (iProduct.Stock >= 0)
            {
                _iDataDis.UpdateProduct(iProduct);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SellProduct(string guid, int restockNumber)
        {
            return RestockProduct(guid, restockNumber * -1);
        }
        #endregion

        #region Interface ILogicWarning Methods
        //Gibt eine Tabelle zurück (über ref), mit allen produkten, die weniger als die grenze an Lagerbestand haben
        //ref DataTable dataTable enthält eine Liste aller Produkte, die in der Funktion verändert wird
        public void Update(decimal grenze, ref DataTable dataTable)
        {
            //Wir gehen davon aus, dass die ref dataTable schon mir den aktuellen Werten gefüllt ist
            SelectProduct(ref dataTable);
            for (int i = dataTable.Rows.Count - 1; i >= 0; i--)
            {
                if (Utils.ParseInt(dataTable.Rows[i]["Lagerbestand"].ToString(), 0) > grenze)
                {
                    dataTable.Rows[i].Delete();
                }
            }
            dataTable.AcceptChanges();
        }

        public DataTable Format(DataTable toformat, decimal grenze)
        {
            toformat.Columns.Remove("GUID");
            toformat.Columns.Remove("Kategorie");
            toformat.Columns.Remove("Preis");
            toformat.Columns.Remove("Kategoriename");

            for (int row = toformat.Rows.Count - 1; row >= 0; row--)
            {
                if (((System.Int32)toformat.Rows[row]["Lagerbestand"]) > grenze)
                {
                    toformat.Rows[row].Delete();
                }
            }
            toformat.AcceptChanges();
            return toformat;
        }
        #endregion
    }
}
