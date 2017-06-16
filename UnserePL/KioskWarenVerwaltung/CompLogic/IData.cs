using System.Data;
namespace CompLogic
{
    public interface IData
    {
        IDataDis DataDis { get; }
    }

    //Interface für den Datenbankzugriff für die Logik-Komponente
    public interface IDataDis
    {
        void SelectAllProducts(ref DataTable dataTable);
        void SelectProduct(IProduct iProduct, ref DataTable dataTable);
        void InsertProduct(IProduct iProduct);
        void UpdateProduct(IProduct iProduct);
        void SelectAllProductCategories(ref DataTable dataTable);
        void SelectProductCategory(IProductCategory iProductCategory, ref DataTable dataTable);
        void InsertProductCategory(IProductCategory iProductCategor);
    }
}
