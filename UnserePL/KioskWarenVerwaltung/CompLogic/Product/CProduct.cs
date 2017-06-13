using System;
using System.Data;

namespace CompLogic.Product
{
    internal class CProduct : IProduct
    {
        public string GUID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double? Price { get; set; }
        public int? Stock { get; set; }
        public CProduct()
        {
            GUID = null;
            Name = null;
            Category = null;
            Price = null;
            Stock = null;
        }

        public CProduct(string GUID, string Name, string Category, double Price, int Stock)
        {
            this.GUID = GUID;
            this.Name = Name;
            this.Category = Category;
            this.Price = Price;
            this.Stock = Stock;
        }

        public void AddNewDataRow(DataTable dataTable)
        {

            DataRow dataRow = dataTable.NewRow();
            
            dataRow["GUID"] = Utils.CreateGUID().ToString();
            dataRow["Produktname"] = Name;
            dataRow["Kategorie"] = Category;
            dataRow["Lagerbestand"] = Stock;
            dataRow["Preis"] = Price;

            dataTable.Rows.Add(dataRow); // DataRow der Tabelle hinzufügen
                                         // RowState steht auf RowState.Added
        }
    }
}
