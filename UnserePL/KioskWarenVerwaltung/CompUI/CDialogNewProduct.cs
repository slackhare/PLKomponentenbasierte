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
            // füllt die Combobox mit den Namen der Kategorien
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
        // Eventhandler für das Klicken des OK Buttons
        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Erstellt ein neues IProduct mit der Factory aus _dialogMain
            IProduct iProduct = _dialogMain.FactoryProduct.Create();
            bool allright = true;
            // Überprüft ob ein Productname eingegeben wurde
            if (this.textBoxName.Text.CompareTo("") == 0) {
                allright = false;
                MessageBox.Show("Bitte geben sie einen Produktnamen an!",
                            "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Überprüft ob ein Preis eingegeben Wurde
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
            // falls alles eingegeben ist wird das IProduct in die Logikschicht gegeben um es in die Datenbank einzufügen
            // danach wird der Dialog geschlossen
            if (allright)
            {
                iProduct.Name = this.textBoxName.Text;
                iProduct.Category = _dialogMain.CategoryList[this.comboBoxKategorie.SelectedIndex];
                iProduct.Stock = Convert.ToInt32(numericUpDownAnz.Value.ToString());

                this.DialogResult = DialogResult.OK;
                if (!_iLogicInsert.InsertProduct(iProduct))
                {
                    MessageBox.Show("Das Produkt existiert bereits!",
                            "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        #endregion
        // Eventhandler für das Klicken des Abbruch Buttons
        // schließt den Dialog
        private void buttonESC_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
