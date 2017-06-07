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
         comboBoxMake.Items.Clear( );
         comboBoxMake.Items.AddRange( _dialogMain.Make );
         comboBoxMake.Items.Add( "Alle" );
         comboBoxMake.Text = comboBoxMake.Items [ 0 ].ToString( );

         if( comboBoxRegistration.Items.Count >= 1 )
            comboBoxRegistration.Text = comboBoxRegistration.Items [ 0 ].ToString( );

         if( comboBoxPrice.Items.Count >= 1 )
            comboBoxPrice.Text = comboBoxPrice.Items [ 0 ].ToString( );

         if( comboBoxMileage.Items.Count >= 1 )
            comboBoxMileage.Text = comboBoxMileage.Items [ 0 ].ToString( );
      }

      private void comboBoxMake_SelectedIndexChanged( object sender, EventArgs e ) {
         if( this.comboBoxMake.Items.Count <= 0 ) return;
         this.comboBoxMake.Text = this.comboBoxMake.SelectedItem.ToString( );
         string make =  this.comboBoxMake.Text;
         if( make == "Alle" ) return;

         // Alle Modelle des Herstellers aus der Datenbank lesen
         comboBoxModel.Items.Clear( );
         comboBoxModel.Items.AddRange( _iLogicSearch.GetModel( make ) );
         comboBoxModel.Items.Add( "Alle" );
         comboBoxModel.Text = comboBoxModel.Items [ 0 ].ToString( );
      }

      private void buttonOK_Click( object sender, EventArgs e ) {
         ICar iCar = _dialogMain.Car;
         iCar.Make = this.comboBoxMake.Text;
         iCar.Model = this.comboBoxModel.Text;
         iCar.Price = Utils.ParseDouble( this.comboBoxPrice.Text, 999999 );
         iCar.Registration = Utils.ParseInt( this.comboBoxRegistration.Text, 1950 );
         iCar.Mileage = Utils.ParseInt( this.comboBoxMileage.Text, 999999 );

         this.DialogResult = DialogResult.OK;
         this.Close( );
      }

      private void buttonCancel_Click( object sender, EventArgs e ) {
         this.DialogResult = DialogResult.Cancel;
         this.Close( );
      }
      #endregion
   }
}
