using System.Data;
namespace CompLogic {

    public interface ILogic {
        ILogicSearch LogicSearch { get; }
        ILogicTrade LogicTrade { get; }
        ILogicUpdate LogicUpdate { get; }
        ILogicWarning LogicWarning { get; }
    }

    public interface ILogicSearch {
        void Init(ref int nCars, out object[] arrayMake);
        object[] GetModel(string make);
        void SelectCar(ICar iCar, ref DataTable dataTable);
        void SelectProduct(IProduct iProduct, ref DataTable dataTable);
        void SelectProductCategory(IProductCategory iProductCategory, ref DataTable dataTable); //Not needed
    }

    public interface ILogicTrade {
        void InsertCar(ICar iCar);

        void InsertProduct(IProduct iProduct);

        void InsertProductCategory(IProductCategory iProductCategory);
    }

    public interface ILogicUpdate
    {
        void UpdateProduct(IProduct iProduct);
    }

    public interface ILogicWarning
    {
        void Warning(int grenze, ref DataTable datatable);
    }



}
