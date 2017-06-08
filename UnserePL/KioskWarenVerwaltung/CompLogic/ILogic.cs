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
        object[] GetModel(string make);
        void SelectCar(ICar iCar, ref DataTable dataTable);
        void SelectProduct(ref DataTable dataTable);
        void SelectProductCategory(ref DataTable dataTable);
    }

    public interface ILogicTrade
    {
        void InsertCar(ICar iCar);

        void InsertProduct(IProduct iProduct);

        void InsertProductCategory(IProductCategory iProductCategory);
    }

    public interface ILogicUpdate
    {
        //sauberer, logik nicht in der Oberfläche
        void RestockProduct(string guid, int restockNumber);

        void SellProduct(string guid, int restockNumber);
    }

    public interface ILogicWarning
    {
        void Update(decimal grenze, ref DataTable datatable);
    }



}
