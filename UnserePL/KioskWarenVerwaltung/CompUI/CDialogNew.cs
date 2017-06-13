using System;
using System.Windows.Forms;
using CompLogic;
using System.Data;

namespace CompUI
{
    internal partial class CDialogNew : Form
    {

        #region Fields
        private CDialogMain _dialogMain;
        #endregion

        #region Ctor
        internal CDialogNew(CDialogMain dialogMain)
        {
            InitializeComponent();
            _dialogMain = dialogMain;
        }
        #endregion

        #region Events
        private void CDialogTrade_Load(object sender, EventArgs e)
        {
            comboBoxKategorie.Items.Clear();
            foreach(DataRow row in _dialogMain.ProductCategoryDataTable.Rows)
            {
                comboBoxKategorie.Items.Add(row["Kategoriename"].ToString());
            }
            comboBoxKategorie.Text = comboBoxKategorie.Items[0].ToString();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            IProduct iProduct = _dialogMain.Produkt;
            iProduct.Name = this.textBoxName.Text;
            iProduct.Category = _dialogMain.ProductCategoryDataTable.Rows[this.comboBoxKategorie.SelectedIndex]["GUID"].ToString();
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
