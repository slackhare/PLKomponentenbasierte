using System;
using System.Windows.Forms;
using CompLogic;
using System.Data;

namespace CompUI {
    internal partial class CDialogSearch : Form
    {

        #region Fields
        private ILogicSearch _iLogicSearch;
        private CDialogMain _dialogMain;
        #endregion

        #region Ctor
        internal CDialogSearch(ILogic iLogic, CDialogMain dialogMain)
        {
            InitializeComponent();
            _iLogicSearch = iLogic.LogicSearch;
            _dialogMain = dialogMain;
        }
        #endregion

        #region Events
        private void CDialogSearch_Load(object sender, EventArgs e)
        {
            textBoxName.Clear();
            comboBoxKategorie.Items.Clear();
            comboBoxKategorie.Items.Add("Alle");
            foreach (DataRow row in _dialogMain.ProductCategoryDataTable.Rows)
            {
                comboBoxKategorie.Items.Add(row["Kategoriename"]);
            }
            comboBoxKategorie.Text = comboBoxKategorie.Items[0].ToString();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            IProduct iProduct = _dialogMain.Produkt;
            iProduct.Name = this.textBoxName.Text;
            iProduct.Category = this.comboBoxKategorie.Text;

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
