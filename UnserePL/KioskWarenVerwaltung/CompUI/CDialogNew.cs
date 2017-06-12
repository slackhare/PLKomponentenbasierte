using System;
using System.Windows.Forms;
using CompLogic;
using CompLogic.Car;
namespace CompUI
{
    internal partial class CDialogNew : Form
    {

        #region Fields
        private ILogicSearch _iLogicSearch;
        private ILogicTrade _iLogicTrade;
        private CDialogMain _dialogMain;
        #endregion

        #region Ctor
        internal CDialogNew(ILogic iLogic, CDialogMain dialogMain)
        {
            InitializeComponent();
            _iLogicSearch = iLogic.LogicSearch;
            _iLogicTrade = iLogic.LogicTrade;
            _dialogMain = dialogMain;
        }
        #endregion

        #region Method
        private void CDialogTrade_Load(object sender, EventArgs e)
        {
            comboBoxKategorie.Items.Clear();
            comboBoxKategorie.Items.AddRange(_dialogMain.Kategorie);
            comboBoxKategorie.Text = comboBoxKategorie.Items[0].ToString();
        }


        //private void buttonOK_Click( object sender, EventArgs e ) {
        //   ICar iCar = _dialogMain.Car;
        //   iCar.Make = this.comboBoxMake.Text;
        //   iCar.Model = this.comboBoxModel.Text;
        //   iCar.Price = Utils.ParseDouble( this.textBoxPrice.Text, 0 );
        //   iCar.Registration = Utils.ParseInt( this.textBox.Text, 0 );
        //   iCar.Mileage = Utils.ParseInt( this.textBoxMileage.Text, 0 );
        //   this.DialogResult = DialogResult.OK;
        //   this.Close( );
        //}

        private void buttonOK_Click(object sender, EventArgs e)
        {
            IProduct iProduct = _dialogMain.Produkt;
            iProduct.Name = this.textBoxName.Text;
            iProduct.Category = Utils.ParseInt(this.comboBoxKategorie.Text, 1);
            iProduct.Stock = Convert.ToInt32(numericUpDownAnz.Value.ToString());

            this.textBoxPreis.Text.Replace(",", ".");
            iProduct.Price = Convert.ToDouble(this.textBoxPreis.Text);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion
    }
}
