﻿using System;
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
        private CDialogNew _dialogNew;
        private CDialogRestock _dialogRestock;
        // externe Komponenten
        private ILogic _iLogic;
        private ILogicSearch _iLogicSearch;
        private ILogicTrade _iLogicTrade;
        private ILogicWarning _iLogicWarning;
        private ILogicUpdate _iLogicUpdate;
        private ICar _iCar;
        private IProduct _iProduct;

        private DataTable _productDataTable;
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
            _iLogicWarning = iLogic.LogicWarning;
            _iLogicUpdate = iLogic.LogicUpdate;
            _iCar = new CFactoryCar().Create();
            _dialogSearch = new CDialogSearch(iLogic, this);
            _dialogSearchView = new CDialogSearchView(this);
            _dialogNew = new CDialogNew(iLogic, this);
            _dialogRestock = new CDialogRestock(iLogic, this);


            _iProduct = new CFactoryCProduct().Create();

            //hole produkte
            _productDataTable = new DataTable();
        }
        #endregion

        #region Methods
        //neu laden der produkte
        private void loadProducts()
        {
            _productDataTable.Clear();
            this.comboBoxVerkauf.Items.Clear();
            _iLogicSearch.SelectProduct(ref _productDataTable);
            foreach (DataRow row in _productDataTable.Rows)
            {
                this.comboBoxVerkauf.Items.Add(row["Produktname"].ToString() + " : " + row["Lagerbestand"].ToString());
            }
            //neu laden der box.. scheint nicht zu funktionieren?
            this.comboBoxVerkauf.Refresh();
        }

        private void displayWaring( DataTable datatable)
        {
            this.dataGridViewWarning.DataSource = datatable;

            // Unnötige Spalten Ausblenden
            foreach (DataGridViewColumn column in this.dataGridViewWarning.Columns)
            {
                if (column.Name== "GUID" || column.Name == "Kategorie" || (column.Name == "Preis") || column.Name == "Kategoriename")
                {
                    column.Visible = false;
                }
            }
        }
        #endregion

        #region Methods Interface IDialog
        public void Init()
        {
            _iLogicSearch.Init(ref _nCars, out _arrayMake);
            //TODO: die folgende Zeile macht keinen Sinn. Es wird die Anzahl der Autos geholt und in 
            _iLogicSearch.Init(ref _nCategorys, out _arrayCategory);
        }
        public void InitKat()
        {
            _iLogicSearch.InitCat(out _arrayCategory);
        }
        #endregion

        #region Events
        private void CDialogMain_Load(object sender, EventArgs e)
        {
            // Kategorienamen aus der Datenbank Holen
            this.InitKat();
            loadProducts();


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
            if (dialogResult == DialogResult.OK)
            {
                // Suchen ausführen
                loadProducts();
                // Ergebnis in DialogSearchView darstellen
                if (_dialogSearchView is CDialogSearchView)
                {
                    // Down Cast
                    (_dialogSearchView as CDialogSearchView).ResultTable = _productDataTable;
                }
                dialogResult = _dialogSearchView.ShowDialog();
            }
        }

        // Eventhandler Verkaufen
        private void newMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = _dialogNew.ShowDialog();
            DataTable dataTable = new DataTable();
            if (dialogResult == DialogResult.OK)
            {
                // Einfügen ausführen
                _iLogicTrade.InsertProduct(_iProduct);
            }
            loadProducts();
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

        //Wieso eigentlich ein Timer? wär es nicht einfacher, die check-methode beim Verkauf aufzurufen? ist ja der einzige Fall, in dem sich der bestand reduziert
        private void timerWarnung_Tick(object sender, EventArgs e)
        {
            this.dataGridViewWarning.DataSource = null;
            DataTable datatable = new DataTable();
            _iLogicWarning.Update(numericUpDownWarnungGrenze.Value, ref datatable);
            if (datatable.Rows.Count > 0 )
            {
                displayWaring(datatable);
            }
        }

        private void buttonVerkaufen_Click(object sender, EventArgs e)
        {
            string guid = _productDataTable.Rows[this.comboBoxVerkauf.SelectedIndex]["GUID"].ToString();
            _iLogicUpdate.SellProduct(guid, Convert.ToInt32(numericUpDownAnz.Value));
            loadProducts();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    #endregion
}
