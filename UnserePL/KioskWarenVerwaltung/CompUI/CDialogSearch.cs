using System;
using System.Windows.Forms;
using CompLogic;
using CompLogic.Car;

namespace CompUI {
   internal partial class CDialogSearch : Form {

      #region Fields
      private ILogicSearch _iLogicSearch;
      private CDialogMain  _dialogMain;
      #endregion

      #region Ctor
      internal CDialogSearch( ILogic iLogic, CDialogMain dialogMain ) {
         InitializeComponent( );
         _iLogicSearch = iLogic.LogicSearch;
         _dialogMain   = dialogMain;
      }
      #endregion

      #region Eventhandler
      private void CDialogSearch_Load( object sender, EventArgs e ) {
         comboBoxKategorie.Items.Clear( );
         //comboBoxKategorie.Items.AddRange( _dialogMain.Make );
         comboBoxKategorie.Items.AddRange(_dialogMain.Kategorie);
         comboBoxKategorie.Items.Add( "Alle" );
         comboBoxKategorie.Text = comboBoxKategorie.Items [ 0 ].ToString( );
      }

        //private void buttonOK_Click( object sender, EventArgs e ) {
        //   ICar iCar = _dialogMain.Car;
        //   iCar.Make = this.comboBoxMake.Text;
        //   iCar.Model = this.comboBoxKategorie.Text;
        //   iCar.Price = Utils.ParseDouble( this.comboBoxPrice.Text, 999999 );
        //   iCar.Registration = Utils.ParseInt( this.comboBoxRegistration.Text, 1950 );
        //   iCar.Mileage = Utils.ParseInt( this.comboBoxMileage.Text, 999999 );
        //   this.DialogResult = DialogResult.OK;
        //      this.Close();
        //}

        private void buttonOK2_Click(object sender, EventArgs e)
        {
            IProduct iProduct = _dialogMain.Produkt;
            iProduct.Name = this.textBoxName.Text;
            iProduct.Category = Utils.ParseInt(this.comboBoxKategorie.Text, 1);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click( object sender, EventArgs e ) {
         this.DialogResult = DialogResult.Cancel;
         this.Close( );
      }
        #endregion
    }
}
