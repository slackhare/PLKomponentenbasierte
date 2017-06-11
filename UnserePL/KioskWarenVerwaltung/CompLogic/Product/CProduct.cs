using System;
using System.Data;

namespace CompLogic.Product
{
    internal class CProduct : IProduct
    {
        public string GUID { get; }
        public string Name { get; set; }
        public int Category { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public CProduct() {
        }

        public void AddNewDataRow( DataTable dataTable ) {

            DataRow dataRow = dataTable.NewRow();
            dataRow["GUID"]                 = Utils.CreateGUID();
            dataRow["Produktname"]          = Name;
            dataRow["Kategorie"]     = Category;
            dataRow["Lagerbestand"]         = Stock;
            dataRow["Preis"]                = Price;
 
            dataTable.Rows.Add( dataRow ); // DataRow der Tabelle hinzufügen
                                           // RowState steht auf RowState.Added
        }
    }
}
