using CompLogic;
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
        private ILogicInsert _iLogicInsert;
        #endregion

        #region Ctor
        internal CDialogNewCategory(ILogicInsert iLogicInsert, CDialogMain dialogMain)
        {
            InitializeComponent();
            _dialogMain = dialogMain;
            textBoxNewCategory.Text = "";
            _iLogicInsert = iLogicInsert;
        }
        #endregion

        #region Events
        // Eventhandler für das Laden des Dialogs
        private void CDialogNewCategory_Load(object sender, EventArgs e)
        {
            // um alte Texte zu Löschen
            textBoxNewCategory.Clear();
        }
        // Eventhandler für das Klicken des Hinzufügen Buttons
        private void buttonHinzufuegen_Click(object sender, EventArgs e)
        {
            // Überprüfung ob die eingegbene Kategorie bereits Existiert
            if (_dialogMain.CategoryList.Exists(X => X.Name.ToUpper() == textBoxNewCategory.Text.ToUpper()))
            {
                MessageBox.Show("Diese Kategorie ist bereits Vorhanden", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Falls nicht wird eine neue Kategorie angelegt
            else
            {
                IProductCategory iProductCategory = _dialogMain.FactoryProductCategory.Create();
                iProductCategory.Name = textBoxNewCategory.Text;
                _iLogicInsert.InsertProductCategory(iProductCategory);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        // Eventhander für das Klicken des Abbrehen Buttons
        private void buttonAbbrechen_Click(object sender, EventArgs e)
        {
            // Schließt den Dialog
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion
    }
}
