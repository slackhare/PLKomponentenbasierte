using System;
using System.Data;
using System.Windows.Forms;

using CompLogic;
using CompLogic.Car;
using CompLogic.Product;

namespace CompUI {

   internal partial class CDialogMain : Form, IDialog {

      #region Fields
      private int                 _nCars;
      private object[]            _arrayMake;
      private object[]            _arrayKategorie;
      // Komposition 
      private CDialogSearch       _dialogSearch;
      private CDialogSearchView   _dialogSearchView;
      private CDialogTrade        _dialogTrade;
      // externe Komponenten
      private ILogic              _iLogic;
      private ILogicSearch        _iLogicSearch;
      private ILogicTrade         _iLogicTrade;
        private ILogicUpdate _iLogicUpdate;
      private ICar                _iCar;
      private IProduct _iProduct;
      #endregion

      #region Properties
      internal IProduct Produkt { get { return _iProduct; } }
      internal ICar       Car  { get { return _iCar;      } }
      internal object [ ] Make { get { return _arrayMake; } }
      internal object [] Kategorie { get { return _arrayKategorie; } }
      #endregion

      #region Ctor
      internal CDialogMain( ILogic iLogic ) {
         InitializeComponent( );
         _iLogic = iLogic;
         _iLogicSearch = iLogic.LogicSearch;
         _iLogicTrade = iLogic.LogicTrade;
            _iLogicUpdate = iLogic.LogicUpdate;
         _iCar = new CFactoryCar( ).Create( );
         _dialogSearch = new CDialogSearch( iLogic, this );
         _dialogSearchView = new CDialogSearchView( this );
         _dialogTrade = new CDialogTrade( iLogic, this );


         _iProduct = new CFactoryCProduct().Create();
        }
      #endregion

      #region Methods Interface IDialog
      public void Init( ) {
         _iLogicSearch.Init( ref _nCars, out _arrayMake );
      }
      //public void InitKat( ref)
      #endregion

      #region Events
      private void CDialogMain_Load( object sender, EventArgs e ) {
         // Anzahl Autos in Datenbank abfragen
         //int nCars = _iLogicSearch.CountCars();
         this.Init( );
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

        private void searchMenuItem2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = _dialogSearch.ShowDialog();
            DataTable dataTable = new DataTable();
            if (dialogResult == DialogResult.OK)
            {
                // Suchen ausführen
                _iLogicSearch.SelectProduct(_iProduct, ref dataTable);
                // Ergebnis in DialogSearchView darstellen
                if (_dialogSearchView is CDialogSearchView)
                {
                    // Down Cast
                    (_dialogSearchView as CDialogSearchView).ResultTable = dataTable;
                }
                dialogResult = _dialogSearchView.ShowDialog();
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

        private void insertMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = _dialogTrade.ShowDialog();
            DataTable dataTable = new DataTable();
            if (dialogResult == DialogResult.OK)
            {
                // Einfügen ausführen
                _iLogicTrade.InsertProduct(_iProduct);
            }
        }


        private void timerWarnung_Tick(object sender, EventArgs e)
        {
            DataTable datatable = new DataTable();
            _iProduct.Stock = 10;
            _iLogicSearch.SelectProduct(_iProduct, ref datatable);
            // TODO Es Wird eine Methode benötigt das den Datatable mit allen Produckten Füllt die <= 10 Stück aujf lager haben

        }

        private void buttonVerkaufen_Click(object sender, EventArgs e)
        {
            _iProduct.Name = this.comboBoxVerkauf.Text;
            _iProduct.Stock = Utils.ParseInt(this.numericUpDownAnz.ToString(), 1);

            _iLogicUpdate.UpdateProduct(_iProduct);
        }
    }
    #endregion
}
