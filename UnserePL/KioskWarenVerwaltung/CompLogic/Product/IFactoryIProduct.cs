namespace CompLogic.Product {
    public interface IFactoryIProduct {
        IProduct Create( );
        IProduct Create(string GUID, string Name, string Category, double Price, int Stock);
    }
}
