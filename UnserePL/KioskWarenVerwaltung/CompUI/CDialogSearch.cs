using System;
using System.Windows.Forms;
using CompLogic;

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

        #region Eventhandler
        private void CDialogSearch_Load(object sender, EventArgs e)
        {
            comboBoxKategorie.Items.Clear();
            comboBoxKategorie.Items.Add("Alle");
            comboBoxKategorie.Items.AddRange(_dialogMain.Kategorie);
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
