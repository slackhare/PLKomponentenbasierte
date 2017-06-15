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
        private List<IProductCategory> _ListCategory;

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
        internal List<IProductCategory> CategoryList { get { return _ListCategory; } }
        internal IFactoryIProduct FactoryProduct { get { return _iFactoryProduct; } }
        internal IFactoryIProductCategory FactoryProductCategory { get { return _iFactoryProductCategory; } }
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
            _dialogNew = new CDialogNewProduct(_iLogicInsert, this);
            _dialogRestock = new CDialogRestock(_iLogicUpdate, this);
            _dialogNewCategory = new CDialogNewCategory(_iLogicInsert, this);

            _ListIProduct = new List<IProduct>();
            _ListCategory = new List<IProductCategory>();

            _iFactoryProduct = new CFactoryCProduct();
            _iFactoryProductCategory = new CFactoryCProductCategory();

            _productDataTable = new DataTable();
            _productCategoryDataTable = new DataTable();
        }
        #endregion

        #region Methods
        // Läd eine Neue formatierte Datenquelle in Die dataGridViewWaring um so die Aktuell nötigen Warnungen darzustellen
        private void redrawWarning()
        {
            this.dataGridViewWarning.Controls.Clear();
            this.dataGridViewWarning.DataSource = _iLogicWarning.Format(numericUpDownWarningLimit.Value);
            this.dataGridViewWarning.Refresh();
            dataGridViewWarning.ClearSelection();
        }
        //Läd die Aktuelle Liste der Produckte erneuert das Verkaufspanel und Aktualisiert die Warnungen
        private void loadProductTabelle()
        {
            _iLogicSearch.FillListProduct(ref _ListIProduct, _ListCategory);
            redrawPanel();
            redrawWarning();
        }

        // Erzeugt die Tabellenheader für Das Verkaufspanel
        internal Label newHeaderLabel(String text)
        {
            Label header = new Label();
            header.Text = text;
            header.TextAlign = ContentAlignment.BottomRight;
            header.AutoSize = true;
            header.Anchor = (AnchorStyles.Top | AnchorStyles.Right); ;
            return header;
        }

        // Erzeugt/Aktualisiert das Verkaufspanel neu
        private void redrawPanel()
        {
            List<IProductCategory> categoryList;
            if (comboBoxFilterCategory.SelectedIndex < 1)
            {
                categoryList = _ListCategory;
            }
            else
            {
                categoryList = new List<IProductCategory>();
                categoryList.Add(_ListCategory[comboBoxFilterCategory.SelectedIndex - 1]);
            }
            // Falls vorhanden wird das Verkaufspanel gelöscht um es zu Erstellen
            if (this.Controls.Find("tableLayoutPanelSelling", true).Length > 0)
            {
                this.Controls.Find("tableLayoutPanelSelling", true)[0].Dispose();
            }
            // Setzt die Eigenschaften des Verkaufspanels
            TableLayoutPanel newPanel = new TableLayoutPanel();
            newPanel.Name = "tableLayoutPanelSelling";
            newPanel.Location = new Point(12, 86);
            newPanel.Size = new Size(700, 453);
            newPanel.Anchor = AnchorStyles.Left;
            newPanel.AutoScroll = true;
            newPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            newPanel.ColumnCount = 5;
            for (int i = 0; i < 5; i++)
            {
                newPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            }
            newPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            newPanel.Controls.AddRange(new Control[5] { newHeaderLabel("Kategoriename"), newHeaderLabel("Produktname"), newHeaderLabel("Lagerbestand"), newHeaderLabel("Verkaufte Stückzahl"), newHeaderLabel("Preis") });

            // Fügt die nötigen Elemente wie Producktname KAtegorie Preis und einen regler für die Anzahl der zu Verkaufenden Produkte in das Verkaufspanel ein
            foreach (IProduct product in _ListIProduct)
            {
                if (categoryList.Contains(product.Category))
                {
                    double price = (double)product.Price;

                    Label col0cat = new Label();
                    col0cat.Text = product.Category.Name;
                    col0cat.TextAlign = ContentAlignment.BottomRight;
                    col0cat.AutoSize = true;
                    col0cat.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

                    Label col1name = new Label();
                    col1name.Text = product.Name.ToString();
                    col1name.TextAlign = ContentAlignment.BottomRight;
                    col1name.AutoSize = true;
                    col1name.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

                    Label col2stock = new Label();
                    col2stock.Text = product.Stock.ToString();
                    col2stock.TextAlign = ContentAlignment.BottomRight;
                    col2stock.AutoSize = true;
                    col2stock.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

                    NumericUpDown col3tosell = new NumericUpDown();
                    col3tosell.ValueChanged += (sender, e) => this.numericUpDownInPanel_ValueChanged(sender, e, price);
                    col3tosell.Value = 0;
                    col3tosell.Minimum = 0;
                    col3tosell.TextAlign = HorizontalAlignment.Right;
                    col3tosell.AutoSize = true;
                    col3tosell.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

                    Label col4price = new Label();
                    col4price.Text = price.ToString("F") + "€";
                    col4price.TextAlign = ContentAlignment.BottomRight;
                    col4price.AutoSize = true;
                    col4price.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

                    // Füllt die Aktuelle Spalte des tableLayoutPanelRestock mit drei Control Objekten zur bearbeitung
                    Control[] rowcontrols = new Control[5] { col0cat, col1name, col2stock, col3tosell, col4price };
                    newPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                    newPanel.Controls.AddRange(rowcontrols);
                }
            }
            newPanel.Visible = true;
            this.Controls.Add(newPanel);
        }
        // Füllt eine Combobox um das Verkaufspanel nach Kategorien zu filtern
        private void Fill_FilterCategory()
        {
            comboBoxFilterCategory.Items.Clear();
            comboBoxFilterCategory.Items.Add("Alle");
            foreach (IProductCategory category in _ListCategory)
            {
                comboBoxFilterCategory.Items.Add(category.Name);
            }
            comboBoxFilterCategory.Text = comboBoxFilterCategory.Items[0].ToString();
        }
        #endregion

        #region Events
        // Eventhandler für das Laden des Fensters
        private void CDialogMain_Load(object sender, EventArgs e)
        {
            // Hier werden alle nötigen Dynamisch erzuegten elemente geladen
            _iLogicSearch.FillListCategory(ref _ListCategory);
            loadProductTabelle();
            Fill_FilterCategory();
        }

        #region MenuItem_Click
        // Eventhandler lager auffüllen
        private void restockMenuItem_Click(object sender, EventArgs e)
        {
            _dialogRestock.ShowDialog();
            loadProductTabelle();
        }
        // Eventhandler Sortiment erweitern
        private void newMenuItem_Click(object sender, EventArgs e)
        {
            _dialogNew.ShowDialog();
            loadProductTabelle();
        }
        // Eventhandler neue Kategorie
        private void newCategoryMenuItem_Click(object sender, EventArgs e)
        {
            _dialogNewCategory.ShowDialog();
            _iLogicSearch.FillListCategory(ref _ListCategory);
            Fill_FilterCategory();
        }


        // Eventhandler Verkaufen
        private void buttonSell_Click(object sender, EventArgs e)
        {
            // Erstellt einen array mit allen Mengen von Allen produckten die man zu einem Zeitpunkt Verkaufen will
            NumericUpDown[] quantarray = ((TableLayoutPanel)this.Controls.Find("tableLayoutPanelSelling", true)[0]).Controls.OfType<NumericUpDown>().ToArray();
            double price = 0;
            // Iteriert durch den Array
            for (int row = 0; row < quantarray.Length; row++)
            {
                // falls der Wert des Panels größer null ist
                if (Convert.ToInt32(quantarray[row].Value) > 0)
                { 
                    //wird ein Datenbankupdate angestoßen das die zu Verkaufende Menge von der Vorhanden Menge des Produktes Abzieht
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
            this.redrawWarning();
        }
        //Eventhandler Anzahl verkauft geändert
        private void numericUpDownInPanel_ValueChanged(object sender, EventArgs e, double price)
        {
            //load and save old value
            NumericUpDown oldvalue = (NumericUpDown)sender;
            int thisValue = (int)oldvalue.Value;
            int lastValue = (oldvalue.Tag == null) ? 0 : (int)oldvalue.Tag;
            oldvalue.Tag = thisValue;

            //update price
            this.sumPrice += ((thisValue - lastValue) * price);
            labelPrize.Text = sumPrice.ToString("F") + "€";
        }
        // Eventhandler andere Kategorie zum Filtern ausgewält
        private void comboBoxSortCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            redrawPanel();
        }
        #endregion
    }
}
   