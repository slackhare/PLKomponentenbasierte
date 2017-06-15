namespace CompLogic.Product {
    public interface IFactoryIProduct {

        /// <summary>
        /// Creates a new IProduct instance
        /// </summary>
        /// <returns>an instance of IProduct</returns>
        IProduct Create( );

        /// <summary>
        /// Creates a new IProduct with filled properties
        /// </summary>
        /// <param name="GUID">GUID of the Product in the Database</param>
        /// <param name="Name">Name of the Product</param>
        /// <param name="Category">IProductCategory the assined category of the Product</param>
        /// <param name="Price">The Prize of the Product</param>
        /// <param name="Stock">The Stock of the Product in the warehouse/database</param>
        /// <returns>An instance of IProduct filled with properties</returns>
        IProduct Create(string GUID, string Name, IProductCategory Category, double Price, int Stock);
    }
}
