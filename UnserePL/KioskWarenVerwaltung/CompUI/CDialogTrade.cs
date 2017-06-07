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
         checkedListBoxKategorie.Items.Clear( );
         checkedListBoxKategorie.Items.AddRange( _dialogMain.Kategorie );
         checkedListBoxKategorie.Text = checkedListBoxKategorie.Items [ 0 ].ToString( );
      }

      private void comboBoxMake_SelectedIndexChanged( object sender, EventArgs e ) {
         if( this.checkedListBoxKategorie.Items.Count <= 0 ) return;
         this.checkedListBoxKategorie.Text = this.checkedListBoxKategorie.SelectedItem.ToString( );
         string kategorie =  this.checkedListBoxKategorie.Text;
         if( kategorie == "Alle" ) return;

            // Alle Modelle des Herstellers aus der Datenbank lesen
            checkedListBoxKategorie.Items.Clear();
            checkedListBoxKategorie.Items.AddRange(_dialogMain.Kategorie);
            checkedListBoxKategorie.Text = checkedListBoxKategorie.Items[0].ToString();
        }

      private void buttonOK_Click( object sender, EventArgs e ) {
            /* Kompiliert nicht, erstmal auskommentiert
         ICar iCar = _dialogMain.Car;
         iCar.Make = this.comboBoxMake.Text;
         iCar.Model = this.comboBoxModel.Text;
         iCar.Price = Utils.ParseDouble( this.textBoxPrice.Text, 0 );
         iCar.Registration = Utils.ParseInt( this.textBox.Text, 0 );
         iCar.Mileage = Utils.ParseInt( this.textBoxMileage.Text, 0 );
         */

         this.DialogResult = DialogResult.OK;
         this.Close( );
      }

        private void buttonOK2_Click(object sender, EventArgs e)
        {
            IProduct iProduct = _dialogMain.Produkt;
            iProduct.Name = this.textBoxName.Text;
            iProduct.Category = Utils.ParseInt(this.checkedListBoxKategorie.Text, 1);
            iProduct.Stock = Utils.ParseInt(numericUpDownAnz.Value.ToString(), 10);
            iProduct.Price = Utils.ParseDouble(this.textBoxPreis.Text, 10);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        private void checkedListBoxKategorie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
