using System.Data;
namespace CompLogic {
    public interface IData {
        IDataDis DataDis { get; }
        IDataCon DataCon { get; }             
    }

    public interface IDataCon {
        void Init( ref int nCars, out object[] arrayMake);
        object[] GetModel( string make );

    }

    public interface IDataDis {
        void     SelectCar( ICar iCar, ref DataTable dataTable);
        void     InsertCar( ICar iCar );
        void     SelectProduct(IProduct iProduct, ref DataTable dataTable);
        void     InsertProduct(IProduct iProduct);
        void     SelectProductCategory(IProductCategory iProductCategor, ref DataTable dataTable);
        void     InsertProductCategory(IProductCategory iProductCategor);
        void UpdateProduct(IProduct iProduct);

    }
}
