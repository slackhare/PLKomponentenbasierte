using System;
using System.Data;
using System.Data.Common;
using CompLogic;

namespace CompData {

    internal abstract class AData : IData {

        #region Fields
        // Objektvariable        
        protected  string             _connectionString;
        protected  string             _providerString;       
        protected  DbProviderFactory  _dbProviderFactory;
        protected  DbConnection       _dbConnection;
        // Assoziationen
        protected  IDataCon           _iDataCon;
        protected  IDataDis           _iDataDis;     
        #endregion

        #region Properties
        public     IDataCon           DataCon          { get { return _iDataCon;         } }
        public     IDataDis           DataDis          { get { return _iDataDis;         } }
        #endregion

        internal   DbProviderFactory  ProviderFactory  { get { return _dbProviderFactory; } }
        internal   DbConnection       Connection       { get { return _dbConnection;      } }

        #region ctor
        internal AData( ) {        
        }
        #endregion

            
        #region interne Methoden
        internal virtual void Setup( ) {            
            // preconditions
            if( _connectionString == string.Empty )
                throw new NullReferenceException( "ADbase.Create() ConnectionString is null" );
            if( _providerString == string.Empty )
                throw new NullReferenceException( "ADbase.Create() ProviderString is null" );

            try {
                // Create Provider Factory 
                _dbProviderFactory = DbProviderFactories.GetFactory( _providerString ); // Provider
                // postcondition
                if( _dbProviderFactory == null )
                    throw new NullReferenceException( "ADbase.Create() fails _dbProviderFactory is null" );
                // Create Connection
                _dbConnection = _dbProviderFactory.CreateConnection( );
                // postcondition
                if( _dbConnection == null )
                    throw new NullReferenceException( "ADbase.Create() fails _dbConnection is null" );
                _dbConnection.ConnectionString = _connectionString;
                
                // Test Connection
                if( _dbConnection.State != ConnectionState.Open ) 
                    _dbConnection.Open( );
                if( _dbConnection.State == ConnectionState.Open )
                    _dbConnection.Close( );
                else
                    throw new Exception("ADbase.TestConnection() Opening Database failed" );                
            }
            catch( Exception exception ) {
                throw new DataException(
                    string.Format( "ADbase.Create() fails\nConnectionString:{0}\nProviderString:{1}\n{2}",
                    _connectionString, _providerString, exception ) );
            }
        }
        #endregion
    }
}
