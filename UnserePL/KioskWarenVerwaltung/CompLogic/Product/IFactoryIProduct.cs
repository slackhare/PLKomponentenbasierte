namespace CompLogic.Product {
    public interface IFactoryIProduct {
        IProduct Create( );
        IProduct Create(string GUID, string Name, IProductCategory Category, double Price, int Stock);
    }
}
