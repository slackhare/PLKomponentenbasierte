using CompLogic;
namespace CompData.Dbase.Access {

    //Wird von CFactoryCData erzeugt und füllt _iDataDis mit einem CDataDisAccess Objekt
    internal class CDataAccess : AData {

        #region ctor
        internal CDataAccess( string connectionString ) 
            : base( ) {
             _connectionString = connectionString;
            _providerString   = "System.Data.OleDb";
            this.Setup( );

            _iDataDis = new CDataDisAccess( this );           
        }
        #endregion        
    }
}
