using System;
using System.Windows.Forms;
using CompUI;
using CompLogic;
using CompData.Dbase.Access;

namespace TestApp {
   class Test {
      #region Fields
      // CompUI
      private IDialog _iDialog;
      // CompLogic
      private ILogic  _iLogic;
      // CompData
      private IData   _iDbase;
      #endregion

      void Run( ) {

         string pathDbAccess     = Properties.Settings.Default.PathDbAccess;
         string providerDbAccess = Properties.Settings.Default.ProviderDbAccess;
         string connectionString = providerDbAccess + pathDbAccess + ";";

         // Dependency Injection via Ctor
         _iDbase = new CFactoryDataAccess( ).Create( connectionString );
         _iLogic = new CFactoryCLogic( ).Create( _iDbase );
         _iDialog = new CFactoryCDialogMain( ).Create( _iLogic );

         // CDialogMain starten
         if( _iDialog is Form ) {
            Application.Run( _iDialog as Form );
         }
      }

      [STAThread]
      static void Main( string [ ] args ) {
         Application.EnableVisualStyles( );
         Application.SetCompatibleTextRenderingDefault( false );
         new Test( ).Run( );
         //  Console.ReadKey();
      }
   }
}
