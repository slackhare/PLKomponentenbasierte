using System.Data;
namespace CompLogic
{
    public interface ILogic
    {
        ILogicSearch LogicSearch { get; }
        ILogicTrade LogicTrade { get; }
        ILogicUpdate LogicUpdate { get; }
        ILogicWarning LogicWarning { get; }
    }

    public interface ILogicSearch
    {
        void Init(ref int nCars, out object[] arrayMake);
        void InitCat(out object[] arrayKategorie);
        object[] GetModel(string make);
        void SelectProduct(ref DataTable dataTable);
        void SelectProductCategory(ref DataTable dataTable);
    }

    public interface ILogicTrade
    {
        void InsertProduct(IProduct iProduct);

        void InsertProductCategory(IProductCategory iProductCategory);
    }

    public interface ILogicUpdate
    {
        //sauberer, logik nicht in der Oberfläche
        bool RestockProduct(string guid, int restockNumber);

        bool SellProduct(string guid, int restockNumber);
    }

    public interface ILogicWarning
    {
        DataTable Format(DataTable toformat, decimal grenze);
    }



}
