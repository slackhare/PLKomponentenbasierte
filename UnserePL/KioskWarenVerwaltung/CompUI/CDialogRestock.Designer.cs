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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CDialogRestock));
            this.buttonAcc = new System.Windows.Forms.Button();
            this.tableLayoutPanelRestock = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAcc
            // 
            this.buttonAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAcc.Location = new System.Drawing.Point(12, 403);
            this.buttonAcc.Name = "buttonAcc";
            this.buttonAcc.Size = new System.Drawing.Size(137, 56);
            this.buttonAcc.TabIndex = 4;
            this.buttonAcc.Text = "Auffüllen";
            this.buttonAcc.UseVisualStyleBackColor = true;
            this.buttonAcc.Click += new System.EventHandler(this.buttonAcc_ClicktTabelLayout);
            // 
            // tableLayoutPanelRestock
            // 
            this.tableLayoutPanelRestock.AutoScroll = true;
            this.tableLayoutPanelRestock.AutoSize = true;
            this.tableLayoutPanelRestock.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelRestock.ColumnCount = 3;
            this.tableLayoutPanelRestock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRestock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRestock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRestock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tableLayoutPanelRestock.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanelRestock.MaximumSize = new System.Drawing.Size(743, 385);
            this.tableLayoutPanelRestock.Name = "tableLayoutPanelRestock";
            this.tableLayoutPanelRestock.RowCount = 1;
            this.tableLayoutPanelRestock.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRestock.Size = new System.Drawing.Size(35, 29);
            this.tableLayoutPanelRestock.TabIndex = 7;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(618, 403);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(137, 56);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Abbrechen";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // CDialogRestock
            // 
            this.ClientSize = new System.Drawing.Size(767, 471);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.tableLayoutPanelRestock);
            this.Controls.Add(this.buttonAcc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CDialogRestock";
            this.Text = "Lager Auffüllen";
            this.Load += new System.EventHandler(this.CDialogRestock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAcc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRestock;
        private System.Windows.Forms.Button buttonCancel;
    }
}