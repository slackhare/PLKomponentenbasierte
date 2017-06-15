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
            textBoxPrice.Text = "0,00";
            numericUpDownAnz.Value = 0;

            foreach (IProductCategory category in _dialogMain.CategoryList)
            {
                comboBoxKategorie.Items.Add(category.Name);
            }
            //foreach(DataRow row in _dialogMain.ProductCategoryDataTable.Rows)
            //{
            //    comboBoxKategorie.Items.Add(row["Kategoriename"].ToString());
            //}
            comboBoxKategorie.Text = comboBoxKategorie.Items[0].ToString();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            IProduct iProduct = _dialogMain.FactoryProduct.Create();
            bool allright = true;

            if (this.textBoxName.Text.CompareTo("") == 0) {
                allright = false;
                MessageBox.Show("Bitte geben sie einen Produktnamen an!",
                            "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                this.textBoxPrice.Text.Replace(",", ".");
                iProduct.Price = Convert.ToDouble(this.textBoxPrice.Text);
            }
            catch (System.FormatException)
            {
                allright = false;
                MessageBox.Show("Bitte geben sie einen Preis an!",
                            "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (allright)
            {
                iProduct.Name = this.textBoxName.Text;
                iProduct.Category = _dialogMain.CategoryList[this.comboBoxKategorie.SelectedIndex];
                iProduct.Stock = Convert.ToInt32(numericUpDownAnz.Value.ToString());

                _iLogicInsert.InsertProduct(iProduct);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        private void buttonESC_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
