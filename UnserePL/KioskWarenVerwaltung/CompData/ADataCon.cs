using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using CompLogic;
namespace CompData {
    internal abstract class ADataCon {

        #region Fields        
        private    AData            _aData;
        protected  DbConnection     _dbConnection;
        protected  DbCommand        _dbCommand;
        #endregion

        #region Ctor
        public ADataCon( AData aData ) {
            _aData                  = aData;
            _dbConnection           = aData.Connection;
            _dbCommand              = aData.ProviderFactory.CreateCommand();
            _dbCommand.Connection   = aData.Connection;
            _dbCommand.CommandType  = CommandType.Text;
        }
        #endregion
    }
}