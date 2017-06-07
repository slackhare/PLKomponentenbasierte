using System;
using System.Data;
using System.Windows.Forms;
using CompLogic;
namespace CompUI {

   internal partial class CDialogSearchView : Form {

      #region fields
      private CDialogMain  _dialogMain;
      private DataTable    _dataTable;
      #endregion

      #region Properties Interface Implementierung IDialogSearch
      public DataTable ResultTable {
         get { return _dataTable; }
         set { _dataTable = value; }
      }
      #endregion

      #region Ctor
      internal CDialogSearchView( CDialogMain dialogMain ) {
         InitializeComponent( );
         _dialogMain = dialogMain;
      }
      #endregion

      #region Methods
      private void CDialogSearchView_Load( object sender, EventArgs e ) {

         // set datasource
         this.dataGridView1.DataSource = ResultTable;

         // set primary key and foreign keys columns invisible
         foreach( DataGridViewColumn column in this.dataGridView1.Columns ) {
            if( column.Name.Substring( 0, 2 ) == "pk" ||
                column.Name.Substring( 0, 2 ) == "fk" )
               column.Visible = false;
         }

         // column width auto
         foreach( DataGridViewColumn dataGridViewColumn in this.dataGridView1.Columns ) {
            dataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
         }
      }      
      #endregion
   }
}
