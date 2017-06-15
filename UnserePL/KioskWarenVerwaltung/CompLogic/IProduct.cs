using System.Data;
namespace CompLogic {

    public interface IProduct {
        string GUID { get; set; }
        string Name         { get; set; }
        IProductCategory Category        { get; set; }
        double? Price        { get; set; }
        int?    Stock { get; set; } 
        void AddNewDataRow( DataTable dataTable );        
    }
}
