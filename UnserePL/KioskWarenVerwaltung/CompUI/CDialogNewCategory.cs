using CompLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompUI
{
    internal partial class CDialogNewCategory : Form
    {
        #region Fields
        private CDialogMain _dialogMain;
        private List<string> Categories;
        #endregion

        #region Ctor
        internal CDialogNewCategory(CDialogMain dialogMain)
        {
            InitializeComponent();
            _dialogMain = dialogMain;
            Categories = new List<string>();
            textBoxNewCategory.Text = "";
        }
        #endregion

        #region Events
        private void CDialogNewCategory_Load(object sender, EventArgs e)
        {
            foreach (DataRow row in _dialogMain.ProductCategoryDataTable.Rows)
            {
                Categories.Add(row[1].ToString());
            }
        }
        private void buttonHinzufuegen_Click(object sender, EventArgs e)
        {
            IProductCategory iProductCategory = _dialogMain.ProductCategory;
            iProductCategory.Name = textBoxNewCategory.Text;
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
