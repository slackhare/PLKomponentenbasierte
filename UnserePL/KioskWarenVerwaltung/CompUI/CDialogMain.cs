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
        private DataTable _productCategoryDataTable;
        private double sumPrice = 0;
        #endregion

        #region Properties
        internal IProduct Produkt { get { return _iProduct; } }
        internal DataTable ProductCategoryDataTable { get { return _productCategoryDataTable; } }
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
            _productCategoryDataTable = new DataTable();

            loadCategoryTabelle();
        }
        #endregion

        #region Methods
        private void displayWarning()
        {
            this.dataGridViewWarning.DataSource =_productDataTable;

            // Unnötige Spalten Ausblenden
            foreach (DataGridViewColumn column in this.dataGridViewWarning.Columns)
            {
                if (column.Name== "GUID" || column.Name == "Kategorie" || (column.Name == "Preis") || column.Name == "Kategoriename")
                {
                    column.Visible = false;
                }
            }
            // Zeilen ausblenden, deren Lagerbestand über dem Grenzwert ist
            foreach (DataGridViewRow row in this.dataGridViewWarning.Rows)
            {
                if(decimal.Parse(row.Cells[2].Value.ToString()) < numericUpDownWarnungGrenze.Value)
                {
                    row.Visible = false;
                }
            }
        }

        private void loadCategoryTabelle()
        {
            _productCategoryDataTable.Clear();
            _iLogicSearch.SelectProductCategory(ref _productCategoryDataTable);
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
                //new System.EventHandler(this.numericUpDownInPanel_ValueChanged);
                Label col3 = new Label();

                // Setzt den Nötigen beschriftingstext
                col0name.Text = _productDataTable.Rows[i]["Produktname"].ToString();
                col1stock.Text = _productDataTable.Rows[i]["Lagerbestand"].ToString();
                double price = (double) _productDataTable.Rows[i]["Preis"];
                col3.Text = price.ToString();

                //redrawe lable 1 when changed
                col2tosell.ValueChanged += (sender, e) => this.numericUpDownInPanel_ValueChanged(sender, e, price);

                // Setzen von Zusatzinformationen

                col1stock.TextAlign = ContentAlignment.BottomCenter;
                col3.TextAlign = ContentAlignment.BottomCenter;

                // Füllt die Aktuelle Spalte des tableLayoutPanelRestock mit drei Control Objekten zur bearbeitung
                Control[] rowcontrols = new Control[4] { col0name, col1stock, col2tosell, col3};
                tableLayoutPanelVerkauf.Controls.AddRange(rowcontrols);
                tableLayoutPanelVerkauf.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            }
            redrawWarning();
            displayWarning();
        }

        private void redrawWarning()
        {
            //this.dataGridViewWarning.DataSource = null;
            //DataTable datatable = new DataTable();
            //_iLogicWarning.Update(numericUpDownWarnungGrenze.Value, ref datatable);
            //if (datatable.Rows.Count > 0)
            //{
            //    displayWarning(datatable);
            //}
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

        #region MenuItem_Click
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
        // Eventhandler Sortiment erweitern
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
            loadCategoryTabelle();
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
        #endregion

        // Eventhandler Verkaufen
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
        
        //Wieso eigentlich ein Timer? wär es nicht einfacher, die check-methode beim Verkauf aufzurufen? ist ja der einzige Fall, in dem sich der bestand reduziert
        private void timerWarning_Tick(object sender, EventArgs e)
        {
            /*
            this.dataGridViewWarning.DataSource = null;
            DataTable datatable = _productDataTable.Clone();
            _iLogicWarning.Update(numericUpDownWarnungGrenze.Value, ref datatable);
            if (datatable.Rows.Count > 0 )
            {
                displayWaring(datatable);
            }
            */
        }
        #endregion

        private void numericUpDownWarnungGrenze_ValueChanged(object sender, EventArgs e)
        {
            this.redrawWarning();
            this.displayWarning();
        }
        private void numericUpDownInPanel_ValueChanged(object sender, EventArgs e, double price)
        {
            NumericUpDown o = (NumericUpDown)sender;
            int thisValue = (int)o.Value;
            int lastValue = (o.Tag == null) ? 0 : (int)o.Tag;
            o.Tag = thisValue;

            this.sumPrice += ((thisValue - lastValue) * price);
            labelPrize.Text = sumPrice.ToString("F") + "€";
        }
    }

}
