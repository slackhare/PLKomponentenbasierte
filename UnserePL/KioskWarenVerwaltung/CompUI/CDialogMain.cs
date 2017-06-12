using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

using CompLogic;
using CompLogic.Car;
using CompLogic.Product;
using System.Linq;

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

        private void loadVerkaufTabelle()
        {
            _iLogicSearch.SelectProduct(ref _productDataTable);
            tableLayoutPanelVerkauf.RowStyles.Clear();
            for (int i = 0; i < _productDataTable.Rows.Count; i++)
            {
                // Erstellt für jede Spalte der Tabelle die Nötigen Objekte
                CheckBox col0 = new CheckBox();
                Label col1 = new Label();
                NumericUpDown col2 = new NumericUpDown();
                Label col3 = new Label();

                col2.Minimum = 1;

                // Setzt den Nötigen beschriftingstext
                col0.Text = _productDataTable.Rows[i]["Produktname"].ToString();
                col1.Text = _productDataTable.Rows[i]["Lagerbestand"].ToString();
                col3.Text = _productDataTable.Rows[i]["Preis"].ToString();


                // Setzen von Zusatzinformationen

                col1.TextAlign = ContentAlignment.BottomCenter;
                col3.TextAlign = ContentAlignment.BottomCenter;

                // Füllt die Aktuelle Spalte des tableLayoutPanelRestock mit drei Control Objekten zur bearbeitung
                Control[] rowcontrols = new Control[4] { col0, col1, col2, col3};
                tableLayoutPanelVerkauf.Controls.AddRange(rowcontrols);
                tableLayoutPanelVerkauf.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            }
            this.tableLayoutPanelVerkauf.Refresh();
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
            this.loadVerkaufTabelle();

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
                _iLogicSearch.SelectProduct(ref _productDataTable);
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
            loadVerkaufTabelle();
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
            loadVerkaufTabelle();
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
            CheckBox[] tocheckarray = tableLayoutPanelVerkauf.Controls.OfType<CheckBox>().ToArray();
            NumericUpDown[] quantarray = tableLayoutPanelVerkauf.Controls.OfType<NumericUpDown>().ToArray();

            for (int row = 0; row < tableLayoutPanelVerkauf.RowCount; row++)
            {
                if (tocheckarray[row].Checked)
                {
                    string guid = _productDataTable.Rows[row]["GUID"].ToString();
                    _iLogicUpdate.SellProduct(guid, Convert.ToInt32(quantarray[row].Value));
                }
            }
            loadVerkaufTabelle();
        }
        #endregion
    }

}
