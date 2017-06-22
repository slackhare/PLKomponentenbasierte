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
        private ILogicUpdate _iLogicUpdate;
        private CDialogMain _dialogMain;
        
        #endregion

        #region Ctor
        internal CDialogRestock(ILogicUpdate iLogicUpdate, CDialogMain dialogMain)
        {
            InitializeComponent();
            _iLogicUpdate = iLogicUpdate;
            _dialogMain = dialogMain;
        }
        #endregion

        #region Methods
        //Füllt eine Andere Darstellung der Produkte
        private void loadProductsintoTableLayout()
        {
            tableLayoutPanelRestock.Controls.Clear();
            tableLayoutPanelRestock.RowStyles.Clear();
            tableLayoutPanelRestock.Dock = System.Windows.Forms.DockStyle.Fill;

            tableLayoutPanelRestock.Controls.AddRange(new Control[3] { _dialogMain.newHeaderLabel("Produktname"), _dialogMain.newHeaderLabel("Lagerbestand"), _dialogMain.newHeaderLabel("Auffüllen")});
            tableLayoutPanelRestock.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));

            foreach (IProduct product in _dialogMain.ProductList)
            {
                // Erstellt für jede Spalte der Tabelle die Nötigen Objekte
                Label col0 = new Label();
                col0.Name = "Label" + product.GUID;
                col0.Text = product.Name;
                col0.AutoSize = true;
                col0.TextAlign = ContentAlignment.BottomRight;
                col0.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

                Label col1 = new Label();
                col1.Text = product.Stock.ToString();
                // Setzen von Zusatzinformationen
                col1.TextAlign = ContentAlignment.BottomCenter;
                col1.AutoSize = true;
                col1.TextAlign = ContentAlignment.BottomRight;
                col1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

                NumericUpDown col2 = new NumericUpDown();
                col2.Name = "NumUpDownRow"+product.GUID;
                col2.Minimum = 0;
                col2.AutoSize = true;
                col2.TextAlign = HorizontalAlignment.Right;
                col2.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
                // Setzt den Nötigen beschriftingstext
                //col0.Text = _productDataTable.Rows[i]["Produktname"].ToString();
                //col1.Text = _productDataTable.Rows[i]["Lagerbestand"].ToString();
                //col0.Text = _dialogMain.ProductList[i].Name;
                //col1.Text = _dialogMain.ProductList[i].Stock.ToString();


                // Füllt die Aktuelle Spalte des tableLayoutPanelRestock mit drei Control Objekten zur bearbeitung
                Control[] rowcontrols = new Control[3] { col0, col1, col2 };
                tableLayoutPanelRestock.Controls.AddRange(rowcontrols);
                tableLayoutPanelRestock.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            }
            this.tableLayoutPanelRestock.Refresh();
        }
        #endregion
        #region Events
        private void CDialogRestock_Load(object sender, EventArgs e)
        {
            loadProductsintoTableLayout();
        }
        // Wird die Angaben aus der Tabelle für das Datenbankupdate Vorbereiten
        private void buttonAcc_ClicktTabelLayout(object sender, EventArgs e)
        {
            NumericUpDown[] quantarray = tableLayoutPanelRestock.Controls.OfType<NumericUpDown>().ToArray();
            for(int row = 0; row < quantarray.Length; row++)
            {
                if(Convert.ToInt32(quantarray[row].Value) > 0)
                {
                    string GUID = _dialogMain.ProductList[row].GUID;
                    _iLogicUpdate.RestockProduct(GUID, int.Parse(quantarray[row].Value.ToString()));
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
