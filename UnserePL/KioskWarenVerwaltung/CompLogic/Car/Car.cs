using System;
using System.Data;

namespace CompLogic.Car {
    internal class Car : ICar {
        public string Make         { get; set; }
        public string Model        { get; set; }
        public double Price        { get; set; }
        public int    Registration { get; set; } 
        public int    Mileage      { get; set; }
        public Car() {
            DateTime dateTime = DateTime.Today;
            Registration = dateTime.Year; 
        }

        public void AddNewDataRow( DataTable dataTable ) {

            DataRow dataRow = dataTable.NewRow();
            dataRow["pkGUID"]       = Utils.CreateGUID();
            dataRow["Make"]         = Make;
            dataRow["Model"]        = Model;
            dataRow["Price"]        = Price;
            dataRow["Registration"] = Registration;
            dataRow["Mileage"]      = Mileage;
            dataRow["fkSeller"]     = -1;
 
            dataTable.Rows.Add( dataRow ); // DataRow der Tabelle hinzufügen
                                           // RowState steht auf RowState.Added
        }
    }
}
