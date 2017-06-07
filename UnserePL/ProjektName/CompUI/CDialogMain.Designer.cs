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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CDialogMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.searchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tradeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelCarsCount = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchMenuItem,
            this.tradeMenuItem,
            this.accountMenuItem,
            this.adminMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(13, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1099, 53);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // searchMenuItem
            // 
            this.searchMenuItem.Name = "searchMenuItem";
            this.searchMenuItem.Size = new System.Drawing.Size(127, 45);
            this.searchMenuItem.Text = "Suchen";
            this.searchMenuItem.Click += new System.EventHandler(this.searchMenuItem_Click);
            // 
            // tradeMenuItem
            // 
            this.tradeMenuItem.Name = "tradeMenuItem";
            this.tradeMenuItem.Size = new System.Drawing.Size(162, 45);
            this.tradeMenuItem.Text = "Verkaufen";
            this.tradeMenuItem.Click += new System.EventHandler(this.tradeMenuItem_Click);
            // 
            // accountMenuItem
            // 
            this.accountMenuItem.Name = "accountMenuItem";
            this.accountMenuItem.Size = new System.Drawing.Size(184, 45);
            this.accountMenuItem.Text = "Mein Konto";
            this.accountMenuItem.Click += new System.EventHandler(this.accountMenuItem_Click);
            // 
            // adminMenuItem
            // 
            this.adminMenuItem.Name = "adminMenuItem";
            this.adminMenuItem.Size = new System.Drawing.Size(117, 45);
            this.adminMenuItem.Text = "Admin";
            this.adminMenuItem.Click += new System.EventHandler(this.adminMenuItem_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Segoe Print", 20F, System.Drawing.FontStyle.Italic);
            this.labelTitle.Location = new System.Drawing.Point(1, 544);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(745, 105);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Suderburgs Automarkt";
            // 
            // labelCarsCount
            // 
            this.labelCarsCount.AutoSize = true;
            this.labelCarsCount.BackColor = System.Drawing.Color.Transparent;
            this.labelCarsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCarsCount.Location = new System.Drawing.Point(827, 586);
            this.labelCarsCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelCarsCount.Name = "labelCarsCount";
            this.labelCarsCount.Size = new System.Drawing.Size(153, 40);
            this.labelCarsCount.TabIndex = 3;
            this.labelCarsCount.Text = "0 Treffer";
            // 
            // CDialogMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(21F, 40F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1099, 658);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelCarsCount);
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
        private System.Windows.Forms.ToolStripMenuItem tradeMenuItem;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelCarsCount;
        private System.Windows.Forms.ToolStripMenuItem accountMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminMenuItem;
    }
}