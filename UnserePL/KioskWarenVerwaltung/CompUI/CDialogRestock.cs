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
        private ILogicTrade _iLogicTrade;
        private CDialogMain _dialogMain;
        #endregion

        #region Ctor
        internal CDialogRestock(ILogic iLogic, CDialogMain dialogMain)
        {
            InitializeComponent();
            _iLogicSearch = iLogic.LogicSearch;
            _iLogicTrade = iLogic.LogicTrade;
            _dialogMain = dialogMain;
            this.numericUpDown1.Minimum = 1;
        }
        #endregion

        #region Method
        private void CDialogRestock_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            _iLogicSearch.SelectProduct(ref dataTable);
            foreach (DataRow row in dataTable.Rows)
            {
                this.checkedListBoxProductsAndStock.Items.Add(row["Produktname"].ToString() + " : " + row["Lagerbestand"].ToString());
            }
        }
        #endregion

        private void checkedListBoxProductsAndStock_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            foreach (int indexChecked in checkedListBoxProductsAndStock.CheckedIndices)
            {
                // Hier jetzt den Bestand hochsetzen
                this.checkedListBox1.Items.Add(checkedListBoxProductsAndStock.Items[indexChecked].ToString()
                    + this.numericUpDown1.Value.ToString());
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
