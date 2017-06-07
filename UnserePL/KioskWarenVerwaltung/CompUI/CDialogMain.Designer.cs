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
            this.menuStrip1.SuspendLayout();
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
            this.lagerAuffüllenToolStripMenuItem.Click += new System.EventHandler(this.restockMenuItem_Click);
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
            // CDialogMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1099, 658);
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
    }
}