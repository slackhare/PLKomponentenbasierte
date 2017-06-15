using System;
using System.Windows.Forms;
using CompLogic;
using System.Data;

namespace CompUI
{
    internal partial class CDialogNewProduct : Form
    {

        #region Fields
        private CDialogMain _dialogMain;
        private ILogicInsert _iLogicInsert;
        #endregion

        #region Ctor
        internal CDialogNewProduct(ILogicInsert iLogicInsert, CDialogMain dialogMain)
        {
            InitializeComponent();
            _dialogMain = dialogMain;
            _iLogicInsert = iLogicInsert;
        }
        #endregion

        #region Events
        private void CDialogTrade_Load(object sender, EventArgs e)
        {
            comboBoxKategorie.Items.Clear();
            textBoxName.Clear();
            textBoxPrice.Clear();
            numericUpDownAnz.ResetText();
            foreach(DataRow row in _dialogMain.ProductCategoryDataTable.Rows)
            {
                comboBoxKategorie.Items.Add(row["Kategoriename"].ToString());
            }
            comboBoxKategorie.Text = comboBoxKategorie.Items[0].ToString();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            IProduct iProduct = _dialogMain.FactoryProduct.Create();
            iProduct.Name = this.textBoxName.Text;
            iProduct.Category = _dialogMain.ProductCategoryDataTable.Rows[this.comboBoxKategorie.SelectedIndex]["GUID"].ToString();
            iProduct.Stock = Convert.ToInt32(numericUpDownAnz.Value.ToString());

            this.textBoxPrice.Text.Replace(",", ".");
            try
            {
                iProduct.Price = Convert.ToDouble(this.textBoxPrice.Text);
            }catch(System.FormatException)
            {
                iProduct.Price = 0;
            }
            _iLogicInsert.InsertProduct(iProduct);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        private void buttonESC_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
