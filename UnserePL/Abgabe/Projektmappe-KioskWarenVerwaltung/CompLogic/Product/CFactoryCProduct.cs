namespace CompLogic.Product
{
    public class CFactoryCProduct : IFactoryIProduct {
        // Erstellt eine Neue Instanz von CPoduct
        public IProduct Create() {
            return new CProduct();
        }
        // Erstellt eine Neue Instanz von CProduct und setzt die Eigenschaften
        public IProduct Create(string GUID, string Name, IProductCategory Category, double Price, int Stock)
        {
            return new CProduct(GUID, Name, Category, Price, Stock);
        }
    }
}
