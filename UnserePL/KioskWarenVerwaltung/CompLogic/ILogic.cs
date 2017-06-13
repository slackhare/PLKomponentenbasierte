using System.Data;
namespace CompLogic
{
    public interface ILogic
    {
        ILogicSearch LogicSearch { get; }
        ILogicInsert LogicTrade { get; }
        ILogicUpdate LogicUpdate { get; }
        ILogicWarning LogicWarning { get; }
    }

    public interface ILogicSearch
    {
        void Init(ref int nCars, out object[] arrayMake);
        void InitCat(out object[] arrayKategorie);
        object[] GetModel(string make);
        void SelectAllProducts(ref DataTable dataTable);
        void SelectAllProductCategories(ref DataTable dataTable);
    }

    public interface ILogicInsert
    {
        void InsertProduct(IProduct iProduct);

        void InsertProductCategory(IProductCategory iProductCategory);
    }

    public interface ILogicUpdate
    {
        //sauberer, logik nicht in der Oberfläche
        bool RestockProduct(string guid, int restockNumber);
        void RestockProduct(IProduct iProduct);
        bool SellProduct(string guid, int restockNumber);
    }

    public interface ILogicWarning
    {
        DataTable Format(DataTable toformat, decimal grenze);
    }



}
