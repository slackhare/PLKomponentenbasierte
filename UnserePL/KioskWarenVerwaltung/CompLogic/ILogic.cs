using System.Data;
namespace CompLogic {

   public interface ILogic {
      ILogicSearch LogicSearch { get; }
      ILogicTrade LogicTrade { get; }
   }

   public interface ILogicSearch {
      void Init( ref int nCars, out object [ ] arrayMake );
      object [ ] GetModel( string make );
      void SelectCar( ICar iCar, ref DataTable dataTable );
      void SelectProduct(IProduct iProduct, ref DataTable dataTable);
      void SelectProductCategory(IProductCategory iProductCategory, ref DataTable dataTable);
    }

   public interface ILogicTrade {
      void InsertCar( ICar iCar );
   }
}
