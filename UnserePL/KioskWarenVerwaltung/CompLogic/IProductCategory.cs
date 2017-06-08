using System.Data;
namespace CompLogic {

    public interface IProductCategory
    {
        string GUID { get; }
        string Name         { get; set; }
        void AddNewDataRow( DataTable dataTable );        
    }
}
