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
            _productDataTable = new DataTable();
        }
        #endregion

        #region Methods
        //Füllt eine Andere Darstellung der Produkte
        private void loadProductsintoTableLayout()
        {
            tableLayoutPanelRestock.Controls.Clear();
            _productDataTable.Clear();
            _iLogicSearch.SelectProduct(ref _productDataTable);
            tableLayoutPanelRestock.RowStyles.Clear();

            for (int i = 0; i < _productDataTable.Rows.Count; i++)
            {
                // Erstellt für jede Spalte der Tabelle die Nötigen Objekte
                CheckBox col0 = new CheckBox();
                Label col1 = new Label();
                NumericUpDown col2 = new NumericUpDown();
                col0.Name = "CheckBoxRow" + i;
                col2.Name = "NumUpDownRow" + i;
                col2.Minimum = 1;

                // Setzt den Nötigen beschriftingstext
                col0.Text = _productDataTable.Rows[i]["Produktname"].ToString();
                col1.Text = _productDataTable.Rows[i]["Lagerbestand"].ToString();


                // Setzen von Zusatzinformationen

                col1.TextAlign = ContentAlignment.BottomCenter;

                // Füllt die Aktuelle Spalte des tableLayoutPanelRestock mit drei Control Objekten zur bearbeitung
                Control[] rowcontrols = new Control[3] { col0, col1, col2 };
                tableLayoutPanelRestock.Controls.AddRange(rowcontrols);
                tableLayoutPanelRestock.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            }
            //neu laden der box.. scheint nicht zu funktionieren?


            this.tableLayoutPanelRestock.Refresh();
        }

        #region Events
        private void CDialogRestock_Load(object sender, EventArgs e)
        {
            loadProductsintoTableLayout();
        }
        #endregion

        //private void button1_Click(object sender, EventArgs e)
        //{

        //    foreach (int indexChecked in checkedListBoxProductsAndStock.CheckedIndices)
        //    {
        //        // Hier jetzt den Bestand hochsetzen - läuft im moment nur mit einem index, muss ich noch mal gucken..
        //        foreach (int i in checkedListBoxProductsAndStock.SelectedIndices)
        //        {
        //            string guid = _productDataTable.Rows[i]["GUID"].ToString();
        //            _iLogicUpdate.RestockProduct(guid, Convert.ToInt32(this.numericUpDown1.Value));
        //        }
        //        loadProducts();
        //    }
        //}

        // Wird die Angaben aus der Tabelle für das Datenbankupdate Vorbereiten
        private void buttonAcc_ClicktTabelLayout(object sender, EventArgs e)
        {
            //foreach (CheckBox tocheck in tableLayoutPanelRestock.Controls.OfType<CheckBox>())
            //{
            //    foreach (NumericUpDown quant in tableLayoutPanelRestock.Controls.OfType<NumericUpDown>())
            //    {
            //        if(tocheck.Checked)
            //        {
            //            if (tableLayoutPanelRestock.GetRow(tocheck) == tableLayoutPanelRestock.GetRow(quant))
            //            {
            //                string guid = _productDataTable.Rows[tableLayoutPanelRestock.GetRow(tocheck)]["GUID"].ToString();
            //                _iLogicUpdate.RestockProduct(guid, Convert.ToInt32(quant.Value));
            //            }
            //        }
            //    }
            //}
            //loadProductsintoTableLayout();

            CheckBox[] tocheckarray = tableLayoutPanelRestock.Controls.OfType<CheckBox>().ToArray();
            NumericUpDown[] quantarray = tableLayoutPanelRestock.Controls.OfType<NumericUpDown>().ToArray();

            for(int row = 0; row < tableLayoutPanelRestock.RowCount; row++)
            {
                if(tocheckarray[row].Checked)
                {
                    string guid = _productDataTable.Rows[row]["GUID"].ToString();
                    _iLogicUpdate.RestockProduct(guid, Convert.ToInt32(quantarray[row].Value));
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion


    }
}
