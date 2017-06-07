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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.searchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lagerAuffüllenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerWarnung = new System.Windows.Forms.Timer(this.components);
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.labelVerkauf = new System.Windows.Forms.Label();
            this.comboBoxVerkauf = new System.Windows.Forms.ComboBox();
            this.numericUpDownAnz = new System.Windows.Forms.NumericUpDown();
            this.labelAnz = new System.Windows.Forms.Label();
            this.buttonVerkaufen = new System.Windows.Forms.Button();
            this.labelWarnung = new System.Windows.Forms.Label();
            this.labelWarnungGrenze = new System.Windows.Forms.Label();
            this.numericUpDownWarnungGrenze = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAnz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWarnungGrenze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchMenuItem,
            this.lagerAuffüllenToolStripMenuItem});
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
            this.searchMenuItem.Click += new System.EventHandler(this.searchMenuItem2_Click);
            // 
            // lagerAuffüllenToolStripMenuItem
            // 
            this.lagerAuffüllenToolStripMenuItem.Name = "lagerAuffüllenToolStripMenuItem";
            this.lagerAuffüllenToolStripMenuItem.Size = new System.Drawing.Size(111, 23);
            this.lagerAuffüllenToolStripMenuItem.Text = "Lager auffüllen";
            this.lagerAuffüllenToolStripMenuItem.Click += new System.EventHandler(this.insertMenuItem_Click);
            // 
            // timerWarnung
            // 
            this.timerWarnung.Tick += new System.EventHandler(this.timerWarnung_Tick);
            // 
            // labelVerkauf
            // 
            this.labelVerkauf.AutoSize = true;
            this.labelVerkauf.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVerkauf.Location = new System.Drawing.Point(32, 101);
            this.labelVerkauf.Name = "labelVerkauf";
            this.labelVerkauf.Size = new System.Drawing.Size(128, 37);
            this.labelVerkauf.TabIndex = 1;
            this.labelVerkauf.Text = "Verkauf";
            // 
            // comboBoxVerkauf
            // 
            this.comboBoxVerkauf.FormattingEnabled = true;
            this.comboBoxVerkauf.Location = new System.Drawing.Point(39, 141);
            this.comboBoxVerkauf.Name = "comboBoxVerkauf";
            this.comboBoxVerkauf.Size = new System.Drawing.Size(327, 28);
            this.comboBoxVerkauf.TabIndex = 2;
            // 
            // numericUpDownAnz
            // 
            this.numericUpDownAnz.Location = new System.Drawing.Point(103, 175);
            this.numericUpDownAnz.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownAnz.Name = "numericUpDownAnz";
            this.numericUpDownAnz.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownAnz.TabIndex = 3;
            this.numericUpDownAnz.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelAnz
            // 
            this.labelAnz.AutoSize = true;
            this.labelAnz.Location = new System.Drawing.Point(35, 177);
            this.labelAnz.Name = "labelAnz";
            this.labelAnz.Size = new System.Drawing.Size(62, 20);
            this.labelAnz.TabIndex = 4;
            this.labelAnz.Text = "Anzahl:";
            // 
            // buttonVerkaufen
            // 
            this.buttonVerkaufen.Location = new System.Drawing.Point(39, 207);
            this.buttonVerkaufen.Name = "buttonVerkaufen";
            this.buttonVerkaufen.Size = new System.Drawing.Size(110, 49);
            this.buttonVerkaufen.TabIndex = 5;
            this.buttonVerkaufen.Text = "Verkaufen";
            this.buttonVerkaufen.UseVisualStyleBackColor = true;
            this.buttonVerkaufen.Click += new System.EventHandler(this.buttonVerkaufen_Click);
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
            this.labelWarnungGrenze.Location = new System.Drawing.Point(35, 285);
            this.labelWarnungGrenze.Name = "labelWarnungGrenze";
            this.labelWarnungGrenze.Size = new System.Drawing.Size(169, 20);
            this.labelWarnungGrenze.TabIndex = 9;
            this.labelWarnungGrenze.Text = "Warnung anzeigen ab:";
            // 
            // numericUpDownWarnungGrenze
            // 
            this.numericUpDownWarnungGrenze.Location = new System.Drawing.Point(210, 283);
            this.numericUpDownWarnungGrenze.Name = "numericUpDownWarnungGrenze";
            this.numericUpDownWarnungGrenze.Size = new System.Drawing.Size(61, 26);
            this.numericUpDownWarnungGrenze.TabIndex = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(621, 172);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(359, 190);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // CDialogMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1099, 658);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.numericUpDownWarnungGrenze);
            this.Controls.Add(this.labelWarnungGrenze);
            this.Controls.Add(this.labelWarnung);
            this.Controls.Add(this.buttonVerkaufen);
            this.Controls.Add(this.labelAnz);
            this.Controls.Add(this.numericUpDownAnz);
            this.Controls.Add(this.comboBoxVerkauf);
            this.Controls.Add(this.labelVerkauf);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CDialogMain";
            this.Text = "Automarkt";
            this.Load += new System.EventHandler(this.CDialogMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAnz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWarnungGrenze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem searchMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lagerAuffüllenToolStripMenuItem;
        private System.Windows.Forms.Timer timerWarnung;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.Label labelVerkauf;
        private System.Windows.Forms.ComboBox comboBoxVerkauf;
        private System.Windows.Forms.NumericUpDown numericUpDownAnz;
        private System.Windows.Forms.Label labelAnz;
        private System.Windows.Forms.Button buttonVerkaufen;
        private System.Windows.Forms.Label labelWarnung;
        private System.Windows.Forms.Label labelWarnungGrenze;
        private System.Windows.Forms.NumericUpDown numericUpDownWarnungGrenze;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}