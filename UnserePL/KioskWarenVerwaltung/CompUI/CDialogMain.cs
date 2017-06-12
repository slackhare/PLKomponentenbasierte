using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

using CompLogic;
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
        private IProduct _iProduct;

        private DataTable _productDataTable;
        #endregion

        #region Properties
        internal IProduct Produkt { get { return _iProduct; } }
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

        private void loadSellingTabelle()
        {
            _productDataTable.Clear();
            _iLogicSearch.SelectProduct(ref _productDataTable);
            this.tableLayoutPanelVerkauf.Controls.Clear();
            this.tableLayoutPanelVerkauf.RowStyles.Clear();
            for (int i = 0; i < _productDataTable.Rows.Count; i++)
            {
                // Erstellt für jede Spalte der Tabelle die Nötigen Objekte
                Label col0name = new Label();
                Label col1stock = new Label();
                NumericUpDown col2tosell = new NumericUpDown();
                col2tosell.Value = 0;
                col2tosell.Minimum = 0;
                //redrawe lable 1 when changed
                col2tosell.Click += new System.EventHandler(this.labelPrize_Update);
                Label col3 = new Label();

                // Setzt den Nötigen beschriftingstext
                col0name.Text = _productDataTable.Rows[i]["Produktname"].ToString();
                col1stock.Text = _productDataTable.Rows[i]["Lagerbestand"].ToString();
                col3.Text = _productDataTable.Rows[i]["Preis"].ToString();


                // Setzen von Zusatzinformationen

                col1stock.TextAlign = ContentAlignment.BottomCenter;
                col3.TextAlign = ContentAlignment.BottomCenter;

                // Füllt die Aktuelle Spalte des tableLayoutPanelRestock mit drei Control Objekten zur bearbeitung
                Control[] rowcontrols = new Control[4] { col0name, col1stock, col2tosell, col3};
                tableLayoutPanelVerkauf.Controls.AddRange(rowcontrols);
                tableLayoutPanelVerkauf.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            }
        }
        #endregion

        #region Methods Interface IDialog
        public void InitCat()
        {
            _iLogicSearch.InitCat(out _arrayCategory);
        }
        #endregion

        #region Events
        private void CDialogMain_Load(object sender, EventArgs e)
        {
            // Kategorienamen aus der Datenbank Holen
            this.InitCat();     
            this.loadSellingTabelle();
        }
        // Eventhandler Suchen
        private void searchMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = _dialogSearch.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                // Suchen ausführen
                _productDataTable.Clear();
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
            loadSellingTabelle();
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
            loadSellingTabelle();
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

        private void buttonSell_Click(object sender, EventArgs e)
        {
            NumericUpDown[] quantarray = tableLayoutPanelVerkauf.Controls.OfType<NumericUpDown>().ToArray();

            for (int row = 0; row < quantarray.Length; row++)
                {
                if (Convert.ToInt32(quantarray[row].Value) > 0)
                {
                    string guid = _productDataTable.Rows[row]["GUID"].ToString();
                    _iLogicUpdate.SellProduct(guid, Convert.ToInt32(quantarray[row].Value));
                }
            }
            loadSellingTabelle();
        }
        #endregion

        private void labelPrize_Update(object sender, EventArgs e)
        {
            this.labelPrize.Text = "Preis ingesamt: ";
            int sumPrice = 0;
            int numberToSell = 0;
            int price = 0;
            int column = 0;
            foreach (Control c in this.tableLayoutPanelVerkauf.Controls)
            {
                switch (column)
                {
                    case 0:
                        //this.label1.Text += "Name:";
                        break;
                    case 1:
                        //this.label1.Text += "Lagerbestand:";
                        break;
                    case 2:
                        //this.label1.Text += "Verkaufen:";
                        numberToSell = Int32.Parse(c.Text);
                        break;
                    case 3:
                        //this.label1.Text += "Preis:";
                        price = Int32.Parse(c.Text);
                        break;
                }
                //this.label1.Text += c.Text;
                if (column >= 3)
                {
                    sumPrice += (numberToSell * price);
                    numberToSell = 0;
                    price = 0;
                    //this.label1.Text += Environment.NewLine;
                    column = 0;
                }
                else
                {
                    //this.label1.Text += " ";
                    column++;
                }
            }
            this.labelPrize.Text += sumPrice.ToString();
            this.labelPrize.Text += " €";
        }
    }

}
