using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataConnection {
    class Test {

        private IDataConnection _iDataConnection;
        private ADataConnection _aDataConnection;
        private CDataConnection _cDataConnection;

        void Run() {

            string path = @"C:\Users\rogallab\CBSE Autoverwaltung\CarDatabase.mdb";        
            // Connection String
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+path+";";

            // CDataConnection IS-A ADataConnection, ADataConnection IS-A IDataConnection
            _iDataConnection = _aDataConnection;
            _aDataConnection = _cDataConnection;

            Console.WriteLine("Interface IDataCollection");
            _iDataConnection = new CDataConnection( connectionString );
            _iDataConnection.Open();
            _iDataConnection.Close();

            Console.WriteLine("\nAbstrakte Klasse ADataCollection");
            _aDataConnection = _iDataConnection as ADataConnection;     // Dow Cast
            _aDataConnection = new CDataConnection( connectionString ); // geht auch
            _aDataConnection.Open();
            _aDataConnection.Close();
            _aDataConnection.OnStateChange();

            Console.WriteLine("\nKonkrete Klasse CDataCollection");
            _cDataConnection = _aDataConnection as CDataConnection;  // Down Cast
            _cDataConnection = new CDataConnection( connectionString ); // geht auch
            _cDataConnection.Open();
            _cDataConnection.Close();
            _cDataConnection.OnStateChange();

          

        }

        static void Main( string [ ] args ) {
            new Test().Run();
            Console.ReadKey();
        }
    }
}
