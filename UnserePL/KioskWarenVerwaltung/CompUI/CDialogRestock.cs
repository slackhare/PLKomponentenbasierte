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
    public partial class CDialogRestock : Form
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

        #region Method
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


        private void CDialogRestock_Load(object sender, EventArgs e)
        {
            loadProducts();
        }
        #endregion

        private void checkedListBoxProductsAndStock_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

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

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
