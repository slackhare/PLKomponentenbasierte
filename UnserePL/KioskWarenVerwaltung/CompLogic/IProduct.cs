﻿using System.Data;
namespace CompLogic {

    public interface IProduct {
        string GUID { get; }
        string Name         { get; set; }
        string Category        { get; set; }
        double Price        { get; set; }
        int    Stock { get; set; } 
        void AddNewDataRow( DataTable dataTable );        
    }
}
