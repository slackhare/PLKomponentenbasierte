using CompLogic;
namespace CompData.Dbase.Access {

    //Wird von CFactoryCData erzeugt und füllt _iDataDis mit einem CDataDisAccess Objekt
    internal class CData : AData {

        #region ctor
        internal CData( string connectionString ) 
            : base( ) {
             _connectionString = connectionString;
            _providerString   = "System.Data.OleDb";
            this.Setup( );

            _iDataAccess = new CDataAccess( this );           
        }
        #endregion        
    }
}
