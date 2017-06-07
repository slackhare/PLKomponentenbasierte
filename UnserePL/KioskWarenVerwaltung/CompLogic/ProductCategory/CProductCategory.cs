using System;
using System.Data;

namespace CompLogic.ProductCategory
{
    internal class CProductCategory : IProductCategory
    {
        public string Name { get; set; }
        public CProductCategory() {
        }

        public void AddNewDataRow( DataTable dataTable ) {

            DataRow dataRow = dataTable.NewRow();
            dataRow["GUID"]                 = Utils.CreateGUID();
            dataRow["Kategoriename"]        = Name;
 
            dataTable.Rows.Add( dataRow ); // DataRow der Tabelle hinzufügen
                                           // RowState steht auf RowState.Added
        }
    }
}
