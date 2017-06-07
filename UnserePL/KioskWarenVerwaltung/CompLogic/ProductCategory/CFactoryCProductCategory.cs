namespace CompLogic.ProductCategory
{
    public class CFactoryCProductCategory : IFactoryIProductCategory
    {
        public IProductCategory Create() {
            return new CProductCategory();
        }
    }
}
