using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;

using CompLogic;
using CompLogic.Product;
using CompLogic.ProductCategory;


namespace CompUI
{

    internal partial class CDialogMain : Form, IDialog
    {

        #region Fields
        // Komposition 
        private CDialogSearch _dialogSearch;
        private CDialogSearchView _dialogSearchView;
        private CDialogNewProduct _dialogNew;
        private CDialogRestock _dialogRestock;
        private CDialogNewCategory _dialogNewCategory;
        // externe Komponenten
        private ILogic _iLogic;
        private ILogicSearch _iLogicSearch;
        private ILogicInsert _iLogicInsert;
        private ILogicWarning _iLogicWarning;
        private ILogicUpdate _iLogicUpdate;

        private List<IProduct> _ListIProduct;

        private IFactoryIProduct _iFactoryProduct;
        private IFactoryIProductCategory _iFactoryProductCategory;
        // Tabellen
        private DataTable _productDataTable;
        private DataTable _productCategoryDataTable;
        private double sumPrice = 0;
        #endregion

        #region Properties
        internal DataTable ProductCategoryDataTable { get { return _productCategoryDataTable; } }
        internal List<IProduct> ProductList { get { return _ListIProduct; } }
        internal IFactoryIProduct FactoryProduct { get { return _iFactoryProduct; } }
        internal IFactoryIProduct FactoryProductCategory { get { return _iFactoryProduct; } }
        #endregion

        #region Ctor
        internal CDialogMain(ILogic iLogic)
        {
            InitializeComponent();

            _iLogic = iLogic;
            _iLogicSearch = iLogic.LogicSearch;
            _iLogicInsert = iLogic.LogicInsert;
            _iLogicWarning = iLogic.LogicWarning;
            _iLogicUpdate = iLogic.LogicUpdate;
            _dialogSearch = new CDialogSearch(iLogic, this);
            _dialogSearchView = new CDialogSearchView(this);
            _dialogNew = new CDialogNewProduct(_iLogicInsert, this);
            _dialogRestock = new CDialogRestock(iLogic, this);
            _dialogNewCategory = new CDialogNewCategory(_iLogicInsert, this);

            _ListIProduct = new List<IProduct>();
            _iFactoryProduct = new CFactoryCProduct();
            _productDataTable = new DataTable();
            _productCategoryDataTable = new DataTable();
        }
        #endregion

        #region Methods
        private void displayWarning()
        {
            this.dataGridViewWarning.Controls.Clear();
            this.dataGridViewWarning.DataSource = _iLogicWarning.Format(_productDataTable.Copy(), numericUpDownWarningLimit.Value);
            this.dataGridViewWarning.Refresh();
            dataGridViewWarning.ClearSelection();
        }

        private void loadCategoryTabelle()
        {
            _productCategoryDataTable.Clear();
            _iLogicSearch.SelectAllProductCategories(ref _productCategoryDataTable);
        }

        private void loadProductTabelle()
        {
            _productDataTable.Clear();
            _iLogicSearch.SelectAllProducts(ref _productDataTable);
            redrawPanel();
            displayWarning();
        }

        private Label newHeaderLabel(String text)
        {
            Label header = new Label();
            header.Text = text;
            header.TextAlign = ContentAlignment.TopRight;
            header.AutoSize = true;
            header.Anchor = (AnchorStyles.Top | AnchorStyles.Right); ;
            return header;
        }

        private void redrawPanel()
        {
            this.tableLayoutPanelSelling.Visible = false;

            this.tableLayoutPanelSelling.Controls.Clear();
            this.tableLayoutPanelSelling.RowStyles.Clear();
            this.tableLayoutPanelSelling.Dock = System.Windows.Forms.DockStyle.Fill;

            tableLayoutPanelSelling.Controls.AddRange(new Control[5] { newHeaderLabel("Kategoriename"), newHeaderLabel("Produktname"), newHeaderLabel("Lagerbestand"), newHeaderLabel("Verkaufte Stückzahl"), newHeaderLabel("Preis") });
            tableLayoutPanelSelling.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));

            for (int i = 0; i < _productDataTable.Rows.Count; i++)
            {
                double price = (double)_productDataTable.Rows[i]["Preis"];

                Label col0cat = new Label();
                col0cat.Text = _productDataTable.Rows[i]["Kategoriename"].ToString();
                col0cat.TextAlign = ContentAlignment.BottomRight;
                col0cat.AutoSize = true;
                col0cat.Anchor = (AnchorStyles.Top | AnchorStyles.Right); ;

                Label col1name = new Label();
                col1name.Text = _productDataTable.Rows[i]["Produktname"].ToString();
                col1name.TextAlign = ContentAlignment.BottomRight;
                col1name.AutoSize = true;
                col1name.Anchor = (AnchorStyles.Top | AnchorStyles.Right); ;

                Label col2stock = new Label();
                col2stock.Text = _productDataTable.Rows[i]["Lagerbestand"].ToString();
                col2stock.TextAlign = ContentAlignment.BottomRight;
                col2stock.AutoSize = true;
                col2stock.Anchor = (AnchorStyles.Top | AnchorStyles.Right); ;

                NumericUpDown col3tosell = new NumericUpDown();
                col3tosell.ValueChanged += (sender, e) => this.numericUpDownInPanel_ValueChanged(sender, e, price);
                col3tosell.Value = 0;
                col3tosell.Minimum = 0;
                col3tosell.TextAlign = HorizontalAlignment.Right;
                col3tosell.AutoSize = true;
                col3tosell.Anchor = (AnchorStyles.Top | AnchorStyles.Right); ;

                Label col4price = new Label();
                col4price.Text = price.ToString("F") + "€";
                col4price.TextAlign = ContentAlignment.BottomRight;
                col4price.AutoSize = true;
                col4price.Anchor = (AnchorStyles.Top | AnchorStyles.Right); ;

                // Füllt die Aktuelle Spalte des tableLayoutPanelRestock mit drei Control Objekten zur bearbeitung
                Control[] rowcontrols = new Control[5] { col0cat, col1name, col2stock, col3tosell, col4price };
                tableLayoutPanelSelling.Controls.AddRange(rowcontrols);
                tableLayoutPanelSelling.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            }
            this.tableLayoutPanelSelling.Visible = true;
        }

        private void FillProductList()
        {
            this._ListIProduct.Clear();
            foreach (DataRow row in _productDataTable.Rows)
            {
                _ListIProduct.Add(_iFactoryProduct.Create(row["GUID"].ToString(), row["Produktname"].ToString(), row["Kategorie"].ToString(), double.Parse(row["Preis"].ToString()), int.Parse(row["Lagerbestand"].ToString())));
            }
        }
        #endregion

        #region Events
        private void CDialogMain_Load(object sender, EventArgs e)
        {
            loadProductTabelle();
            loadCategoryTabelle();
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
                _iLogicSearch.SelectAllProducts(ref _productDataTable);
                // Ergebnis in DialogSearchView darstellen
                if (_dialogSearchView is CDialogSearchView)
                {
                    // Down Cast
                    (_dialogSearchView as CDialogSearchView).ResultTable = _productDataTable;
                }
                dialogResult = _dialogSearchView.ShowDialog();
            }
        }
        // Eventhandler lager auffüllen
        private void restockMenuItem_Click(object sender, EventArgs e)
        {
            this.FillProductList();
            loadProductTabelle();
        }
        // Eventhandler Sortiment erweitern
        private void newMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = _dialogNew.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                // Einfügen ausführen
                //_iLogicTrade.InsertProduct(_iProduct);
            }
            loadProductTabelle();
        }
        private void newCategoryMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = _dialogNewCategory.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                //_iLogicInsert.InsertProductCategory(_iProductCategory);
            }
            loadCategoryTabelle();
        }
        

        // Eventhandler Verkaufen
        private void buttonSell_Click(object sender, EventArgs e)
        {
            NumericUpDown[] quantarray = tableLayoutPanelSelling.Controls.OfType<NumericUpDown>().ToArray();
            double price = 0;
            for (int row = 0; row < quantarray.Length; row++)
            {
                if (Convert.ToInt32(quantarray[row].Value) > 0)
                {
                    string guid = _productDataTable.Rows[row]["GUID"].ToString();
                    if (!_iLogicUpdate.SellProduct(guid, Convert.ToInt32(quantarray[row].Value)))
                    {
                        MessageBox.Show("Das Produkt "
                            + _productDataTable.Rows[row]["Produktname"].ToString()
                            + " ist nicht mehr oft genug vorrätig und konnte nicht verkauft werden!",
                            "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        price += Convert.ToInt32(quantarray[row].Value) * ((double)_productDataTable.Rows[row]["Preis"]);
                    }
                }
            }
            if (price > 0)
            {
                MessageBox.Show("Der Kunde muss: " + Environment.NewLine + price.ToString("F") + "€" + Environment.NewLine + "bezahlen!",
                                "Rechung", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            loadProductTabelle();
            sumPrice = 0;
            labelPrize.Text = sumPrice.ToString("F") + "€";
        }
        #endregion

        //Eventhandler Grenze geändert
        private void numericUpDownWarningLimit_ValueChanged(object sender, EventArgs e)
        {
            this.displayWarning();
        }
        //Eventhandler Anzahl verkauft geändert
        private void numericUpDownInPanel_ValueChanged(object sender, EventArgs e, double price)
        {
            //load and save old value
            NumericUpDown o = (NumericUpDown)sender;
            int thisValue = (int)o.Value;
            int lastValue = (o.Tag == null) ? 0 : (int)o.Tag;
            o.Tag = thisValue;

            //update price
            this.sumPrice += ((thisValue - lastValue) * price);
            labelPrize.Text = sumPrice.ToString("F") + "€";
        }
        #endregion
    }

}
