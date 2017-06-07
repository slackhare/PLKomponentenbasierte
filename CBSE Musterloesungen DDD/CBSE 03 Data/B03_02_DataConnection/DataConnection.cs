using System;
using System.Collections.Generic;

using System.Data;

namespace DataConnection {

    public interface IDataConnection {
        // Properties
        string          ConnectionString {get; set; }
        ConnectionState State            {get; set; }
        // Methods
        void Open();
        void Close();
    }

    public abstract class ADataConnection : IDataConnection {
        
        // Properties - keine Implemntierung
        public abstract string          ConnectionString {get; set; }
        public abstract ConnectionState State            {get; set;}

        // Ctor
        public ADataConnection() {
            State = ConnectionState.Closed;  
            Console.WriteLine( "ADataConnection() State=ConnectionState.Closed");                    
        }

        // Interface Methoden - keine Implementierung
        public abstract void Open();
        public abstract void Close();

        // Zusätzliche abstrakte Methoden
        public abstract void ChangeDatabase();

        // Zusätzliche konkrete Methoden
        public void OnStateChange() {
            Console.WriteLine( "ADataConnection.OnStateChange()");
        }

    }

    public class CDataConnection: ADataConnection, IDataConnection {

        // Properties - Implemntierung
        public override string          ConnectionString {get; set; }
        public override ConnectionState State            {get; set;}

        // Ctor
        public CDataConnection( string connectionString ) : base() {
            ConnectionString = connectionString;
        }
 
        // Abstrakte Methoden werden überschrieben
        public override void Open() {            
            // To Do
            State = ConnectionState.Open;
            Console.WriteLine( "CDataConnection.Open()  State=Open");
        }
        public override void Close( ) {
            // To Do
            State = ConnectionState.Open;
            Console.WriteLine( "CDataConnection.Close()  State=Closed");
        }
        public override void ChangeDatabase() {
            Console.WriteLine( "CDataConnection.ChangeDataBase()");
        }
    }
}
