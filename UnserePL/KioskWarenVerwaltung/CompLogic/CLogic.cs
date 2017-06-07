using System.Data;
namespace CompLogic {

    internal class CLogic : ILogicSearch, ILogicTrade, ILogic {

        #region Fields
        private IData     _iData;
        private IDataCon  _iDataCon;
        private IDataDis  _iDataDis;
        private ICar      _iCar;
        #endregion

        #region Properties         
        public ILogicSearch LogicSearch { get { return this; } }
        public ILogicTrade  LogicTrade  { get { return this; } }
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

        public  object[] GetModel( string make ) {
            return _iDataCon.GetModel( make );
        }

        public void SelectCar( ICar iCar, ref DataTable datatable ) {
            _iDataDis.SelectCar( iCar, ref datatable );
        }

        public void SelectProduct(ref DataTable datatable)
        {
            _iDataDis.SelectProduct(ref datatable);
        }

        public void SelectProductCategory(ref DataTable datatable) // Not needed
        {
            _iDataDis.SelectProductCategory(ref datatable);
        }
        #endregion

        #region Interface ILogicTrade Methods
        public void InsertCar( ICar iCar ) {
            _iDataDis.InsertCar( iCar );
        }
        public void InsertProduct(IProduct iProduct)
        {
            _iDataDis.InsertProduct(iProduct);
        }
        public void InsertProductCategory(IProductCategory iProductCategory)
        {
            _iDataDis.InsertProductCategory(iProductCategory);
        }
        #endregion

    }
}
