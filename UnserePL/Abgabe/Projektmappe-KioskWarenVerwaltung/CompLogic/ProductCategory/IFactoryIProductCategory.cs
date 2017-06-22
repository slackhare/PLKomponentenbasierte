namespace CompLogic.ProductCategory
{
    public interface IFactoryIProductCategory {
        /// <summary>
        /// Create a new IProductCategory object
        /// </summary>
        /// <returns>A new IProductCategory object</returns>
        IProductCategory Create( );
    }
}
