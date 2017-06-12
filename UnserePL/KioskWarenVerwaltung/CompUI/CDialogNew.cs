using System;
using System.Windows.Forms;
using CompLogic;

namespace CompUI
{
    internal partial class CDialogNew : Form
    {

        #region Fields
        private ILogicSearch _iLogicSearch;
        private ILogicTrade _iLogicTrade;
        private CDialogMain _dialogMain;
        #endregion

        #region Ctor
        internal CDialogNew(ILogic iLogic, CDialogMain dialogMain)
        {
            InitializeComponent();
            _iLogicSearch = iLogic.LogicSearch;
            _iLogicTrade = iLogic.LogicTrade;
            _dialogMain = dialogMain;
        }
        #endregion

        #region Methods
        private void CDialogTrade_Load(object sender, EventArgs e)
        {
            comboBoxKategorie.Items.Clear();
            comboBoxKategorie.Items.AddRange(_dialogMain.Kategorie);
            comboBoxKategorie.Text = comboBoxKategorie.Items[0].ToString();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            IProduct iProduct = _dialogMain.Produkt;
            iProduct.Name = this.textBoxName.Text;
            iProduct.Category = this.comboBoxKategorie.Text;
            iProduct.Stock = Convert.ToInt32(numericUpDownAnz.Value.ToString());

            this.textBoxPreis.Text.Replace(",", ".");
            try
            {
                iProduct.Price = Convert.ToDouble(this.textBoxPreis.Text);
            }catch(System.FormatException)
            {
                iProduct.Price = 0;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion
    }
}
