using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompLogic;
using System.Data.SqlClient;

namespace CompUI
{
    internal partial class CDialogRestock : Form
    {

        #region Fields
        private ILogicSearch _iLogicSearch;
        private ILogicUpdate _iLogicUpdate;
        private CDialogMain _dialogMain;
        private DataTable _productDataTable;
        
        #endregion

        #region Ctor
        internal CDialogRestock(ILogic iLogic, CDialogMain dialogMain)
        {
            InitializeComponent();
            _iLogicSearch = iLogic.LogicSearch;
            _iLogicUpdate = iLogic.LogicUpdate;
            _dialogMain = dialogMain;
            this.numericUpDown1.Minimum = 1;
            _productDataTable = new DataTable();
        }
        #endregion

        #region Methods
        //neu laden der produkte
        private void loadProducts()
        {
            _productDataTable.Clear();
            this.checkedListBoxProductsAndStock.Items.Clear();
            _iLogicSearch.SelectProduct(ref _productDataTable);
            foreach (DataRow row in _productDataTable.Rows)
            {
                this.checkedListBoxProductsAndStock.Items.Add(row["Produktname"].ToString() + " : " + row["Lagerbestand"].ToString());
            }
            //neu laden der box.. scheint nicht zu funktionieren?
            this.checkedListBoxProductsAndStock.Refresh();
        }
        private void loadProductsintoTableLayout()
        { 
            _iLogicSearch.SelectProduct(ref _productDataTable);
            DataColumn name = _productDataTable.Columns[1];
            DataColumn bestand = _productDataTable.Columns[2];
            for (int i = 0; i < _productDataTable.Rows.Count; i++)
            {
                CheckBox col0 = new CheckBox();
                Label col1 = new Label();
                NumericUpDown col2 = new NumericUpDown();
                col0.Text = _productDataTable.Rows[i][name, DataRowVersion.Current].ToString();
                col1.Text = _productDataTable.Rows[i][bestand, DataRowVersion.Current].ToString();
                col1.TextAlign = ContentAlignment.MiddleCenter;
                Control[] rowcontrols = new Control[3] { col0, col1, col2 };
                tableLayoutPanelRestock.Controls.AddRange(rowcontrols);
            }
            //neu laden der box.. scheint nicht zu funktionieren?
            this.checkedListBoxProductsAndStock.Refresh();
        }

        #region Events
        private void CDialogRestock_Load(object sender, EventArgs e)
        {
            loadProductsintoTableLayout();
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

            foreach (int indexChecked in checkedListBoxProductsAndStock.CheckedIndices)
            {
                // Hier jetzt den Bestand hochsetzen - läuft im moment nur mit einem index, muss ich noch mal gucken..
                foreach (int i in checkedListBoxProductsAndStock.SelectedIndices)
                {
                    string guid = _productDataTable.Rows[i]["GUID"].ToString();
                    _iLogicUpdate.RestockProduct(guid, Convert.ToInt32(this.numericUpDown1.Value));
                }
                loadProducts();
            }
        }
        #endregion
    }
}
