using System.Data;
namespace CompLogic
{
    public interface IData
    {
        IDataDis DataDis { get; }
        IDataCon DataCon { get; }
    }

    public interface IDataCon
    {
        void Init(ref int nCars, out object[] arrayMake);
        void InitCat(out object[] arrayKategorie);
        object[] GetModel(string make);

    }

    public interface IDataDis
    {
        void SelectAllProducts(ref DataTable dataTable);
        void SelectProduct(IProduct iProduct, ref DataTable dataTable);
        void InsertProduct(IProduct iProduct);
        void UpdateProduct(IProduct iProduct);
        void SelectAllProductCategories(ref DataTable dataTable);
        void SelectProductCategory(IProductCategory iProductCategory, ref DataTable dataTable);
        void InsertProductCategory(IProductCategory iProductCategor);
        //void RestockProduct(string guid, int restockNumber);
        //Unnötig, wird in der logic gemacht, braucht keinen eignen Datenbankzugriff
        //void WarningUpdate(decimal grenze, ref DataTable datatable);

    }
}
