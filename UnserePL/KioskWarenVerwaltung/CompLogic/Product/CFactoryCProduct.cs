namespace CompLogic.Product
{
    public class CFactoryCProduct : IFactoryIProduct {
        public IProduct Create() {
            return new CProduct();
        }
        public IProduct Create(string GUID, string Name, IProductCategory Category, double Price, int Stock)
        {
            return new CProduct(GUID, Name, Category, Price, Stock);
        }
    }
}
