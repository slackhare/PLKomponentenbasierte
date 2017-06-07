using System.Data;
namespace CompLogic {

    public interface ICar {
        string Make         { get; set; }
        string Model        { get; set; }
        double Price        { get; set; }
        int    Registration { get; set; } 
        int    Mileage      { get; set; }
        void AddNewDataRow( DataTable dataTable );        
    }
}
