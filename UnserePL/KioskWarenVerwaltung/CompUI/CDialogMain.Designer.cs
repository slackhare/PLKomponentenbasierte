namespace CompUI {
    partial class CDialogMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && (components != null) ) {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( ) {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CDialogMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.searchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restockMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProductMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCategoryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerWarnung = new System.Windows.Forms.Timer(this.components);
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.labelVerkauf = new System.Windows.Forms.Label();
            this.buttonVerkaufen = new System.Windows.Forms.Button();
            this.labelWarnung = new System.Windows.Forms.Label();
            this.labelWarnungGrenze = new System.Windows.Forms.Label();
            this.numericUpDownWarnungGrenze = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewWarning = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelVerkauf = new System.Windows.Forms.TableLayoutPanel();
            this.labelPrize = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWarnungGrenze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarning)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchMenuItem,
            this.restockMenuItem,
            this.newProductMenuItem,
            this.newCategoryMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(13, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1099, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // searchMenuItem
            // 
            this.searchMenuItem.Name = "searchMenuItem";
            this.searchMenuItem.Size = new System.Drawing.Size(65, 23);
            this.searchMenuItem.Text = "Suchen";
            this.searchMenuItem.Click += new System.EventHandler(this.searchMenuItem_Click);
            // 
            // restockMenuItem
            // 
            this.restockMenuItem.Name = "restockMenuItem";
            this.restockMenuItem.Size = new System.Drawing.Size(111, 23);
            this.restockMenuItem.Text = "Lager auffüllen";
            this.restockMenuItem.Click += new System.EventHandler(this.restockMenuItem_Click);
            // 
            // newProductMenuItem
            // 
            this.newProductMenuItem.Name = "newProductMenuItem";
            this.newProductMenuItem.Size = new System.Drawing.Size(142, 23);
            this.newProductMenuItem.Text = "Sortiment erweitern";
            this.newProductMenuItem.Click += new System.EventHandler(this.newMenuItem_Click);
            // 
            // newCategoryMenuItem
            // 
            this.newCategoryMenuItem.Name = "newCategoryMenuItem";
            this.newCategoryMenuItem.Size = new System.Drawing.Size(201, 23);
            this.newCategoryMenuItem.Text = "Produktkategorie Hinzufügen";
            this.newCategoryMenuItem.Click += new System.EventHandler(this.newCategoryMenuItem_Click);
            // 
            // labelVerkauf
            // 
            this.labelVerkauf.AutoSize = true;
            this.labelVerkauf.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVerkauf.Location = new System.Drawing.Point(12, 46);
            this.labelVerkauf.Name = "labelVerkauf";
            this.labelVerkauf.Size = new System.Drawing.Size(128, 37);
            this.labelVerkauf.TabIndex = 1;
            this.labelVerkauf.Text = "Verkauf";
            // 
            // buttonVerkaufen
            // 
            this.buttonVerkaufen.Location = new System.Drawing.Point(408, 545);
            this.buttonVerkaufen.Name = "buttonVerkaufen";
            this.buttonVerkaufen.Size = new System.Drawing.Size(110, 49);
            this.buttonVerkaufen.TabIndex = 5;
            this.buttonVerkaufen.Text = "Verkaufen";
            this.buttonVerkaufen.UseVisualStyleBackColor = true;
            this.buttonVerkaufen.Click += new System.EventHandler(this.buttonSell_Click);
            // 
            // labelWarnung
            // 
            this.labelWarnung.AutoSize = true;
            this.labelWarnung.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarnung.ForeColor = System.Drawing.Color.Red;
            this.labelWarnung.Location = new System.Drawing.Point(611, 114);
            this.labelWarnung.Name = "labelWarnung";
            this.labelWarnung.Size = new System.Drawing.Size(369, 55);
            this.labelWarnung.TabIndex = 6;
            this.labelWarnung.Text = "!!!WARNUNG!!!";
            // 
            // labelWarnungGrenze
            // 
            this.labelWarnungGrenze.AutoSize = true;
            this.labelWarnungGrenze.Location = new System.Drawing.Point(524, 574);
            this.labelWarnungGrenze.Name = "labelWarnungGrenze";
            this.labelWarnungGrenze.Size = new System.Drawing.Size(169, 20);
            this.labelWarnungGrenze.TabIndex = 9;
            this.labelWarnungGrenze.Text = "Warnung anzeigen ab:";
            // 
            // numericUpDownWarnungGrenze
            // 
            this.numericUpDownWarnungGrenze.Location = new System.Drawing.Point(699, 572);
            this.numericUpDownWarnungGrenze.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownWarnungGrenze.Name = "numericUpDownWarnungGrenze";
            this.numericUpDownWarnungGrenze.Size = new System.Drawing.Size(61, 26);
            this.numericUpDownWarnungGrenze.TabIndex = 10;
            this.numericUpDownWarnungGrenze.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownWarnungGrenze.ValueChanged += new System.EventHandler(this.numericUpDownWarnungGrenze_ValueChanged);
            // 
            // dataGridViewWarning
            // 
            this.dataGridViewWarning.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewWarning.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewWarning.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewWarning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWarning.ColumnHeadersVisible = false;
            this.dataGridViewWarning.EnableHeadersVisualStyles = false;
            this.dataGridViewWarning.GridColor = System.Drawing.SystemColors.Info;
            this.dataGridViewWarning.Location = new System.Drawing.Point(621, 172);
            this.dataGridViewWarning.Margin = new System.Windows.Forms.Padding(10);
            this.dataGridViewWarning.Name = "dataGridViewWarning";
            this.dataGridViewWarning.RowHeadersVisible = false;
            this.dataGridViewWarning.RowTemplate.Height = 24;
            this.dataGridViewWarning.Size = new System.Drawing.Size(359, 190);
            this.dataGridViewWarning.TabIndex = 11;
            // 
            // tableLayoutPanelVerkauf
            // 
            this.tableLayoutPanelVerkauf.AutoScroll = true;
            this.tableLayoutPanelVerkauf.AutoSize = true;
            this.tableLayoutPanelVerkauf.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelVerkauf.ColumnCount = 5;
            this.tableLayoutPanelVerkauf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelVerkauf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelVerkauf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelVerkauf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelVerkauf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelVerkauf.Location = new System.Drawing.Point(12, 86);
            this.tableLayoutPanelVerkauf.MaximumSize = new System.Drawing.Size(593, 453);
            this.tableLayoutPanelVerkauf.Name = "tableLayoutPanelVerkauf";
            this.tableLayoutPanelVerkauf.RowCount = 1;
            this.tableLayoutPanelVerkauf.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelVerkauf.Size = new System.Drawing.Size(10, 10);
            this.tableLayoutPanelVerkauf.TabIndex = 12;
            // 
            // labelPrize
            // 
            this.labelPrize.AutoSize = true;
            this.labelPrize.Location = new System.Drawing.Point(695, 545);
            this.labelPrize.Name = "labelPrize";
            this.labelPrize.Size = new System.Drawing.Size(49, 20);
            this.labelPrize.TabIndex = 13;
            this.labelPrize.Text = "0,00€";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(524, 545);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Preis insgesamt:";
            // 
            // CDialogMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1099, 658);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelPrize);
            this.Controls.Add(this.tableLayoutPanelVerkauf);
            this.Controls.Add(this.dataGridViewWarning);
            this.Controls.Add(this.numericUpDownWarnungGrenze);
            this.Controls.Add(this.labelWarnungGrenze);
            this.Controls.Add(this.labelWarnung);
            this.Controls.Add(this.buttonVerkaufen);
            this.Controls.Add(this.labelVerkauf);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CDialogMain";
            this.Text = "Lagerverwaltung";
            this.Load += new System.EventHandler(this.CDialogMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWarnungGrenze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarning)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem searchMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restockMenuItem;
        private System.Windows.Forms.Timer timerWarnung;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.Label labelVerkauf;
        private System.Windows.Forms.Button buttonVerkaufen;
        private System.Windows.Forms.Label labelWarnung;
        private System.Windows.Forms.Label labelWarnungGrenze;
        private System.Windows.Forms.NumericUpDown numericUpDownWarnungGrenze;
        private System.Windows.Forms.DataGridView dataGridViewWarning;
        private System.Windows.Forms.ToolStripMenuItem newProductMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelVerkauf;
        private System.Windows.Forms.Label labelPrize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem newCategoryMenuItem;
    }
}