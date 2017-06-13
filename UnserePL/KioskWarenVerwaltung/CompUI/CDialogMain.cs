using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

using CompLogic;
using CompLogic.Product;
using CompLogic.ProductCategory;
using System.Linq;

namespace CompUI
{

    internal partial class CDialogMain : Form, IDialog
    {

        #region Fields
        // Komposition 
        private CDialogSearch _dialogSearch;
        private CDialogSearchView _dialogSearchView;
        private CDialogNew _dialogNew;
        private CDialogRestock _dialogRestock;
        private CDialogNewCategory _dialogNewCategory;
        // externe Komponenten
        private ILogic _iLogic;
        private ILogicSearch _iLogicSearch;
        private ILogicInsert _iLogicTrade;
        private ILogicWarning _iLogicWarning;
        private ILogicUpdate _iLogicUpdate;
        private IProduct _iProduct;
        private IProductCategory _iProductCategory;

        private DataTable _productDataTable;
        private DataTable _productCategoryDataTable;
        private double sumPrice = 0;
        #endregion

        #region Properties
        internal IProduct Produkt { get { return _iProduct; } }
        internal IProductCategory ProductCategory { get { return _iProductCategory; } }
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
            _dialogNew = new CDialogNew(this);
            _dialogRestock = new CDialogRestock(iLogic, this);
            _dialogNewCategory = new CDialogNewCategory(this);


            _iProduct = new CFactoryCProduct().Create();
            _iProductCategory = new CFactoryCProductCategory().Create();

            //hole produkte
            _productDataTable = new DataTable();
            _productCategoryDataTable = new DataTable();

            loadSellingTabelle();
            loadCategoryTabelle();
        }
        #endregion

        #region Methods
        private void displayWarning()
        {
            this.dataGridViewWarning.Controls.Clear();
            this.dataGridViewWarning.DataSource = _iLogicWarning.Format(_productDataTable.Copy(), numericUpDownWarnungGrenze.Value);
            this.dataGridViewWarning.Refresh();
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
            this.tableLayoutPanelVerkauf.Visible = false;

            this.tableLayoutPanelVerkauf.Controls.Clear();
            this.tableLayoutPanelVerkauf.RowStyles.Clear();
            this.tableLayoutPanelVerkauf.Dock = System.Windows.Forms.DockStyle.Fill;

            tableLayoutPanelVerkauf.Controls.AddRange(new Control[5] { newHeaderLabel("Kategoriename"), newHeaderLabel("Produktname"), newHeaderLabel("Lagerbestand"), newHeaderLabel("Verkaufte Stückzahl"), newHeaderLabel("Preis") });
            tableLayoutPanelVerkauf.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));

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
                tableLayoutPanelVerkauf.Controls.AddRange(rowcontrols);
                tableLayoutPanelVerkauf.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            }
            this.tableLayoutPanelVerkauf.Visible = true;
        }
        #endregion

        #region Events
        private void CDialogMain_Load(object sender, EventArgs e)
        {
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
        // Eventhandler Sortiment erweitern
        private void newMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = _dialogNew.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                // Einfügen ausführen
                _iLogicTrade.InsertProduct(_iProduct);
            }
            loadSellingTabelle();
            loadCategoryTabelle();
        }
        private void newCategoryMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = _dialogNewCategory.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                _iLogicTrade.InsertProductCategory(_iProductCategory);
            }
        }
        #endregion

        // Eventhandler Verkaufen
        private void buttonSell_Click(object sender, EventArgs e)
        {
            NumericUpDown[] quantarray = tableLayoutPanelVerkauf.Controls.OfType<NumericUpDown>().ToArray();
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

            loadSellingTabelle();
            sumPrice = 0;
            labelPrize.Text = sumPrice.ToString("F") + "€";
        }

        #endregion

        private void numericUpDownWarnungGrenze_ValueChanged(object sender, EventArgs e)
        {
            this.displayWarning();
        }
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


    }

}
