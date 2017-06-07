using System;
using System.Data;
using System.Windows.Forms;

using CompLogic;
using CompLogic.Car;
namespace CompUI {

   internal partial class CDialogMain : Form, IDialog {

      #region Fields
      private int                 _nCars;
      private object[]            _arrayMake;
      // Komposition
      private CDialogSearch       _dialogSearch;
      private CDialogSearchView   _dialogSearchView;
      private CDialogTrade        _dialogTrade;
      // externe Komponenten
      private ILogic              _iLogic;
      private ILogicSearch        _iLogicSearch;
      private ILogicTrade         _iLogicTrade;
      private ICar                _iCar;
      #endregion

      #region Properties
      internal ICar       Car  { get { return _iCar;      } }
      internal object [ ] Make { get { return _arrayMake; } }
      #endregion

      #region Ctor
      internal CDialogMain( ILogic iLogic ) {
         InitializeComponent( );
         _iLogic = iLogic;
         _iLogicSearch = iLogic.LogicSearch;
         _iLogicTrade = iLogic.LogicTrade;
         _iCar = new CFactoryCar( ).Create( );
         _dialogSearch = new CDialogSearch( iLogic, this );
         _dialogSearchView = new CDialogSearchView( this );
         _dialogTrade = new CDialogTrade( iLogic, this );
      }
      #endregion

      #region Methods Interface IDialog
      public void Init( ) {
         _iLogicSearch.Init( ref _nCars, out _arrayMake );
      }
      #endregion

      #region Events
      private void CDialogMain_Load( object sender, EventArgs e ) {
         // Anzahl Autos in Datenbank abfragen
         //int nCars = _iLogicSearch.CountCars();
         this.Init( );
         this.labelCarsCount.Text = _nCars.ToString( ) + " Treffer";
      }

      // Eventhandler Suchen
      private void searchMenuItem_Click( object sender, EventArgs e ) {
         DialogResult dialogResult = _dialogSearch.ShowDialog();
         DataTable dataTable = new DataTable();
         if( dialogResult == DialogResult.OK ) {
            // Suchen ausführen
            _iLogicSearch.SelectCar( _iCar, ref dataTable );
            // Ergebnis in DialogSearchView darstellen
            if( _dialogSearchView is CDialogSearchView ) {
               // Down Cast
               ( _dialogSearchView as CDialogSearchView ).ResultTable = dataTable;
            }
            dialogResult = _dialogSearchView.ShowDialog( );
         }
      }

      // Eventhandler Verkaufen
      private void tradeMenuItem_Click( object sender, EventArgs e ) {
         DialogResult dialogResult = _dialogTrade.ShowDialog();
         DataTable dataTable = new DataTable();
         if( dialogResult == DialogResult.OK ) {
            // Einfügen ausführen
            _iLogicTrade.InsertCar( _iCar );
         }
      }
      #endregion

      // Eventhandler Konto
      private void accountMenuItem_Click( object sender, EventArgs e ) {

      }

      // Eventhandler Admin
      private void adminMenuItem_Click( object sender, EventArgs e ) {

      }
   }
}
