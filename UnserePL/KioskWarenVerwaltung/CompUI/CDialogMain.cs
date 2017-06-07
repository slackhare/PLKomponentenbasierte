using System;
using System.Data;
using System.Windows.Forms;

using CompLogic;
using CompLogic.Car;
using CompLogic.Product;

namespace CompUI
{

    internal partial class CDialogMain : Form, IDialog
    {

        #region Fields
        private int _nCars;
        private object[] _arrayMake;
        //Wieso braucht man die variablen?
        private int _nCategorys;
        private object[] _arrayCategory;
        // Komposition 
        private CDialogSearch _dialogSearch;
        private CDialogSearchView _dialogSearchView;
        private CDialogTrade _dialogTrade;
        private CDialogRestock _dialogRestock;
        // externe Komponenten
        private ILogic _iLogic;
        private ILogicSearch _iLogicSearch;
        private ILogicTrade _iLogicTrade;
        private ICar _iCar;
        private IProduct _iProduct;
        #endregion

        #region Properties
        internal IProduct Produkt { get { return _iProduct; } }
        internal ICar Car { get { return _iCar; } }
        internal object[] Make { get { return _arrayMake; } }
        internal object[] Kategorie { get { return _arrayCategory; } }
        #endregion

        #region Ctor
        internal CDialogMain(ILogic iLogic)
        {
            InitializeComponent();
            _iLogic = iLogic;
            _iLogicSearch = iLogic.LogicSearch;
            _iLogicTrade = iLogic.LogicTrade;
            _iCar = new CFactoryCar().Create();
            _dialogSearch = new CDialogSearch(iLogic, this);
            _dialogSearchView = new CDialogSearchView(this);
            _dialogTrade = new CDialogTrade(iLogic, this);
            _dialogRestock = new CDialogRestock(iLogic, this);


            _iProduct = new CFactoryCProduct().Create();
        }
        #endregion

        #region Methods Interface IDialog
        public void Init()
        {
            _iLogicSearch.Init(ref _nCars, out _arrayMake);
            //TODO: die folgende Zeile macht keinen Sinn. Es wird die Anzahl der Autos geholt und in 
            _iLogicSearch.Init(ref _nCategorys, out _arrayCategory);
        }
        //public void InitKat( ref)
        #endregion

        #region Events
        private void CDialogMain_Load(object sender, EventArgs e)
        {
            // Anzahl Autos in Datenbank abfragen
            //int nCars = _iLogicSearch.CountCars();
            this.Init();
        }

        // Eventhandler Suchen
        private void searchMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = _dialogSearch.ShowDialog();
            DataTable dataTable = new DataTable();
            if (dialogResult == DialogResult.OK)
            {
                // Suchen ausführen
                _iLogicSearch.SelectCar(_iCar, ref dataTable);
                // Ergebnis in DialogSearchView darstellen
                if (_dialogSearchView is CDialogSearchView)
                {
                    // Down Cast
                    (_dialogSearchView as CDialogSearchView).ResultTable = dataTable;
                }
                dialogResult = _dialogSearchView.ShowDialog();
            }
        }

        private void searchMenuItem2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = _dialogSearch.ShowDialog();
            DataTable dataTable = new DataTable();
            if (dialogResult == DialogResult.OK)
            {
                // Suchen ausführen
                _iLogicSearch.SelectProduct(ref dataTable);
                //_iLogicSearch.SelectCar(_iCar, ref dataTable);
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
        private void tradeMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = _dialogTrade.ShowDialog();
            DataTable dataTable = new DataTable();
            if (dialogResult == DialogResult.OK)
            {
                // Einfügen ausführen
                _iLogicTrade.InsertCar(_iCar);
            }
        }

        private void restockMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = _dialogRestock.ShowDialog();
            DataTable dataTable = new DataTable();
            if (dialogResult == DialogResult.OK)
            {
                // Einfügen ausführen
                //Kein insert hier, das würde ein neues Produkt anlegen. wir wollen auffüllen. :)
                //_iLogicTrade.InsertProduct(_iProduct);
            }
        }


        private void timerWarnung_Tick(object sender, EventArgs e)
        {

        }
        #endregion


    }
}
