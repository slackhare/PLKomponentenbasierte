using System;
using System.Windows.Forms;
using CompLogic;
using CompLogic.Car;
namespace CompUI {
   internal partial class CDialogTrade : Form {

      #region Fields
      private ILogicSearch    _iLogicSearch;
      private ILogicTrade     _iLogicTrade;
      private CDialogMain     _dialogMain;
      #endregion
      
      #region Ctor
      internal CDialogTrade( ILogic iLogic, CDialogMain dialogMain ) {
         InitializeComponent( );
         _iLogicSearch = iLogic.LogicSearch;
         _iLogicTrade = iLogic.LogicTrade;
         _dialogMain = dialogMain;
      }
      #endregion

      #region Method
      private void CDialogTrade_Load( object sender, EventArgs e ) {
         comboBoxMake.Items.Clear( );
         comboBoxMake.Items.AddRange( _dialogMain.Make );
         comboBoxMake.Items.Add( "Alle" );
         comboBoxMake.Text = comboBoxMake.Items [ 0 ].ToString( );
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
         iCar.Price = Utils.ParseDouble( this.textBoxPrice.Text, 0 );
         iCar.Registration = Utils.ParseInt( this.textBoxRegistration.Text, 0 );
         iCar.Mileage = Utils.ParseInt( this.textBoxMileage.Text, 0 );

         this.DialogResult = DialogResult.OK;
         this.Close( );
      }
      #endregion
   }
}
