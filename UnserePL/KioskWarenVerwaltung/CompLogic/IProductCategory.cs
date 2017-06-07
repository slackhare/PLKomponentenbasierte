using System.Data;
namespace CompLogic {

    public interface IProductCategory
    {
        string Name         { get; set; }
        void AddNewDataRow( DataTable dataTable );        
    }
}
