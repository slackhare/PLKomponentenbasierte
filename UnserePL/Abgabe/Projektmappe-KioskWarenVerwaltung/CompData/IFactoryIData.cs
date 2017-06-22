using CompLogic;
namespace CompData {
    public interface IFactoryIData {
        IData Create( string connectionString );
    }
}
