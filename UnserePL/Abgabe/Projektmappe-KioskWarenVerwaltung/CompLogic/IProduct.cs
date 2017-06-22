using System.Data;
namespace CompLogic {

    public interface IProduct {
        string GUID { get; set; }
        string Name         { get; set; }
        IProductCategory Category        { get; set; }
        double? Price        { get; set; }
        int?    Stock { get; set; } 
        /// <summary>
        /// Adds a new DataRow to the dattable Parameter 
        /// </summary>
        /// <param name="dataTable">the Datatable in witch you wish to insert the product</param>
        void AddNewDataRow( DataTable dataTable );        
    }
}
