using CompLogic;
using CompLogic.ProductCategory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CompUI
{
    internal partial class CDialogNewCategory : Form
    {
        #region Fields
        private CDialogMain _dialogMain;
        private List<string> Categories;
        private ILogicInsert _iLogicInsert;
        #endregion

        #region Ctor
        internal CDialogNewCategory(ILogicInsert iLogicInsert, CDialogMain dialogMain)
        {
            InitializeComponent();
            _dialogMain = dialogMain;
            Categories = new List<string>();
            textBoxNewCategory.Text = "";
            _iLogicInsert = iLogicInsert;
        }
        #endregion

        #region Events
        private void CDialogNewCategory_Load(object sender, EventArgs e)
        {
            textBoxNewCategory.Clear();
            foreach (DataRow row in _dialogMain.ProductCategoryDataTable.Rows)
            {
                Categories.Add(row[1].ToString());
            }
        }
        private void buttonHinzufuegen_Click(object sender, EventArgs e)
        {
            IProductCategory iProductCategory = new CFactoryCProductCategory().Create();
            iProductCategory.Name = textBoxNewCategory.Text;
            _iLogicInsert.InsertProductCategory(iProductCategory);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonAbbrechen_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion
    }
}
