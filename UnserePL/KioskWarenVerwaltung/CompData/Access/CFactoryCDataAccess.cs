using CompLogic;
namespace CompData.Dbase.Access {    
    public class CFactoryDataAccess : IFactoryIData {
        public IData Create( string connectionString ) {
            return new CData ( connectionString );
        }
    }
}
