namespace CompUI
{
    partial class CDialogRestock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanelRestock = new System.Windows.Forms.TableLayoutPanel();
            this.checkedListBoxProductsAndStock = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(388, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "Auffüllen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(388, 12);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 6;
            // 
            // tableLayoutPanelRestock
            // 
            this.tableLayoutPanelRestock.ColumnCount = 3;
            this.tableLayoutPanelRestock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRestock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRestock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanelRestock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanelRestock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelRestock.Location = new System.Drawing.Point(12, 127);
            this.tableLayoutPanelRestock.Name = "tableLayoutPanelRestock";
            this.tableLayoutPanelRestock.RowCount = 1;
            this.tableLayoutPanelRestock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.18033F));
            this.tableLayoutPanelRestock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.81967F));
            this.tableLayoutPanelRestock.Size = new System.Drawing.Size(306, 122);
            this.tableLayoutPanelRestock.TabIndex = 7;
            // 
            // checkedListBoxProductsAndStock
            // 
            this.checkedListBoxProductsAndStock.FormattingEnabled = true;
            this.checkedListBoxProductsAndStock.Location = new System.Drawing.Point(12, 12);
            this.checkedListBoxProductsAndStock.Name = "checkedListBoxProductsAndStock";
            this.checkedListBoxProductsAndStock.Size = new System.Drawing.Size(306, 109);
            this.checkedListBoxProductsAndStock.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(419, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // CDialogRestock
            // 
            this.ClientSize = new System.Drawing.Size(589, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanelRestock);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkedListBoxProductsAndStock);
            this.Name = "CDialogRestock";
            this.Load += new System.EventHandler(this.CDialogRestock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownAnz;
        private System.Windows.Forms.CheckedListBox checkedListBoxProduct;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRestock;
        private System.Windows.Forms.CheckedListBox checkedListBoxProductsAndStock;
        private System.Windows.Forms.Label label1;
    }
}