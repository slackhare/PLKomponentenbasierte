namespace CompLogic.ProductCategory
{
    public class CFactoryCProductCategory : IFactoryIProductCategory
    {
        // Erstellt ein Neues Konkretes CProductCategory Objekt
        public IProductCategory Create() {
            return new CProductCategory();
        }
    }
}
