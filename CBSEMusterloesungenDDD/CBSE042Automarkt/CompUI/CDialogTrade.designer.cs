namespace CompUI {
    partial class CDialogTrade {
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelReg = new System.Windows.Forms.Label();
            this.labelkm = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.comboBoxModel = new System.Windows.Forms.ComboBox();
            this.labelModel = new System.Windows.Forms.Label();
            this.comboBoxMake = new System.Windows.Forms.ComboBox();
            this.labelMake = new System.Windows.Forms.Label();
            this.textBoxRegistration = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.textBoxMileage = new System.Windows.Forms.TextBox();
            this.buttonESC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Location = new System.Drawing.Point(395, 314);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(6);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(184, 54);
            this.buttonOK.TabIndex = 31;
            this.buttonOK.Text = "Ok";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelReg
            // 
            this.labelReg.AutoSize = true;
            this.labelReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReg.Location = new System.Drawing.Point(442, 9);
            this.labelReg.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelReg.Name = "labelReg";
            this.labelReg.Size = new System.Drawing.Size(158, 35);
            this.labelReg.TabIndex = 27;
            this.labelReg.Text = "Zulassung";
            // 
            // labelkm
            // 
            this.labelkm.AutoSize = true;
            this.labelkm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelkm.Location = new System.Drawing.Point(442, 208);
            this.labelkm.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelkm.Name = "labelkm";
            this.labelkm.Size = new System.Drawing.Size(137, 35);
            this.labelkm.TabIndex = 25;
            this.labelkm.Text = "kmStand";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrice.Location = new System.Drawing.Point(452, 107);
            this.labelPrice.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(86, 35);
            this.labelPrice.TabIndex = 23;
            this.labelPrice.Text = "Preis";
            // 
            // comboBoxModel
            // 
            this.comboBoxModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxModel.FormattingEnabled = true;
            this.comboBoxModel.Location = new System.Drawing.Point(16, 148);
            this.comboBoxModel.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxModel.Name = "comboBoxModel";
            this.comboBoxModel.Size = new System.Drawing.Size(338, 43);
            this.comboBoxModel.TabIndex = 22;
            // 
            // labelModel
            // 
            this.labelModel.AutoSize = true;
            this.labelModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelModel.Location = new System.Drawing.Point(11, 107);
            this.labelModel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(106, 35);
            this.labelModel.TabIndex = 21;
            this.labelModel.Text = "Modell";
            // 
            // comboBoxMake
            // 
            this.comboBoxMake.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMake.FormattingEnabled = true;
            this.comboBoxMake.Items.AddRange(new object[] {
            "Ford",
            "Opel",
            "VW"});
            this.comboBoxMake.Location = new System.Drawing.Point(15, 55);
            this.comboBoxMake.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxMake.Name = "comboBoxMake";
            this.comboBoxMake.Size = new System.Drawing.Size(331, 43);
            this.comboBoxMake.TabIndex = 20;
            this.comboBoxMake.SelectedIndexChanged += new System.EventHandler(this.comboBoxMake_SelectedIndexChanged);
            // 
            // labelMake
            // 
            this.labelMake.AutoSize = true;
            this.labelMake.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMake.Location = new System.Drawing.Point(15, 17);
            this.labelMake.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelMake.Name = "labelMake";
            this.labelMake.Size = new System.Drawing.Size(101, 35);
            this.labelMake.TabIndex = 19;
            this.labelMake.Text = "Marke";
            // 
            // textBoxRegistration
            // 
            this.textBoxRegistration.Location = new System.Drawing.Point(448, 56);
            this.textBoxRegistration.Name = "textBoxRegistration";
            this.textBoxRegistration.Size = new System.Drawing.Size(337, 41);
            this.textBoxRegistration.TabIndex = 37;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(448, 150);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(337, 41);
            this.textBoxPrice.TabIndex = 38;
            // 
            // textBoxMileage
            // 
            this.textBoxMileage.Location = new System.Drawing.Point(448, 246);
            this.textBoxMileage.Name = "textBoxMileage";
            this.textBoxMileage.Size = new System.Drawing.Size(337, 41);
            this.textBoxMileage.TabIndex = 39;
            // 
            // buttonESC
            // 
            this.buttonESC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonESC.Location = new System.Drawing.Point(186, 314);
            this.buttonESC.Margin = new System.Windows.Forms.Padding(6);
            this.buttonESC.Name = "buttonESC";
            this.buttonESC.Size = new System.Drawing.Size(184, 54);
            this.buttonESC.TabIndex = 40;
            this.buttonESC.Text = "Abbruch";
            this.buttonESC.UseVisualStyleBackColor = true;
            // 
            // CDialogTrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 383);
            this.Controls.Add(this.buttonESC);
            this.Controls.Add(this.textBoxMileage);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxRegistration);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelReg);
            this.Controls.Add(this.labelkm);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.comboBoxModel);
            this.Controls.Add(this.labelModel);
            this.Controls.Add(this.comboBoxMake);
            this.Controls.Add(this.labelMake);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "CDialogTrade";
            this.Text = "Bitte geben Sie ihre Daten ein";
            this.Load += new System.EventHandler(this.CDialogTrade_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelReg;
        private System.Windows.Forms.Label labelkm;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.ComboBox comboBoxModel;
        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.ComboBox comboBoxMake;
        private System.Windows.Forms.Label labelMake;
        private System.Windows.Forms.TextBox textBoxRegistration;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.TextBox textBoxMileage;
        private System.Windows.Forms.Button buttonESC;
    }
}