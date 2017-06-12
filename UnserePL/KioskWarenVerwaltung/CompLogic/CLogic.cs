using System.Data;
using CompLogic.Product;

namespace CompLogic {

    internal class CLogic : ILogicSearch, ILogicTrade, ILogicUpdate, ILogicWarning, ILogic {

        #region Fields
        private IData     _iData;
        private IDataCon  _iDataCon;
        private IDataDis  _iDataDis;
        #endregion

        #region Properties         
        public ILogicSearch LogicSearch { get { return this; } }
        public ILogicTrade  LogicTrade  { get { return this; } }
        public ILogicUpdate LogicUpdate { get { return this; } }
        public ILogicWarning LogicWarning { get { return this; } }
        #endregion

        #region Ctor
        internal CLogic( IData iData ) {
            _iData    = iData;
            _iDataCon = iData.DataCon;
            _iDataDis = iData.DataDis;
        }
        #endregion      
                
        #region Interface ILogicSearch Methods
        public void Init( ref int nCars, out object [ ] arrayMake ) {
            _iDataCon.Init( ref nCars, out arrayMake );
        }

        public void InitCat(out object[] arrayCategory)
        {
            _iDataCon.InitCat(out arrayCategory);
        }

        public  object[] GetModel( string make ) {
            return _iDataCon.GetModel( make );
        }

        public void SelectProduct(ref DataTable datatable)
        {
            _iDataDis.SelectProduct(ref datatable);
            foreach(DataRow row in datatable.Rows)
            {
                if(row.IsNull(0))
                {
                    row.Delete();
                }
            }
        }

        public void SelectProductCategory(ref DataTable datatable) // Not needed
        {
            _iDataDis.SelectProductCategory(ref datatable);
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
        public void RestockProduct(string guid, int restockNumber)
        {
            _iDataDis.RestockProduct(guid, restockNumber);
        }

        public void SellProduct(string guid, int restockNumber)
        {
            _iDataDis.RestockProduct(guid, restockNumber*-1);
        }
        #endregion

        #region Interface ILogicWarning Methods
        //Gibt eine Tabelle zurück (über ref), mit allen produkten, die weniger als die grenze an Lagerbestand haben
        public void Update(decimal grenze, ref DataTable dataTable)
        {
            SelectProduct(ref dataTable);
            for (int i = dataTable.Rows.Count - 1; i >= 0; i--)
            {
                if (Utils.ParseInt(dataTable.Rows[i]["Lagerbestand"].ToString(), 0) >= grenze)
                {
                    dataTable.Rows[i].Delete();
                }
            }
            dataTable.AcceptChanges();
        }
        #endregion
    }
}
