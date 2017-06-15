using CompLogic;
namespace CompData.Dbase.Access {

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
