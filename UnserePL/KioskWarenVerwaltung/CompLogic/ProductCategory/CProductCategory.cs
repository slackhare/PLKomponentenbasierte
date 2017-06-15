﻿using System;
using System.Data;

namespace CompLogic.ProductCategory
{
    internal class CProductCategory : IProductCategory
    {
        #region Properties
        public string GUID { get; }
        public string Name { get; set; }
        #endregion

        #region Ctor
        public CProductCategory()
        {
        }
        public CProductCategory(string guid, string name)
        {
            this.GUID = guid;
            this.Name = name;
        }
        #endregion

        #region Methods
        public void AddNewDataRow(DataTable dataTable)
        {

            DataRow dataRow = dataTable.NewRow();
            dataRow["GUID"] = Utils.CreateGUID();
            dataRow["Kategoriename"] = Name;

            dataTable.Rows.Add(dataRow); // DataRow der Tabelle hinzufügen
                                         // RowState steht auf RowState.Added
        }
        #endregion

    }
}
