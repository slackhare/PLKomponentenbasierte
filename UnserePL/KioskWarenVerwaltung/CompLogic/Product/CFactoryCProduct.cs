namespace CompLogic.Product
{
    public class CFactoryCProduct : IFactoryIProduct {
        public IProduct Create() {
            return new CProduct();
        }
    }
}
