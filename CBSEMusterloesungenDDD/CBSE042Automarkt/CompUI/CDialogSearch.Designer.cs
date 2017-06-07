namespace CompUI {
    partial class CDialogSearch {
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
            this.labelMake = new System.Windows.Forms.Label();
            this.comboBoxMake = new System.Windows.Forms.ComboBox();
            this.labelModel = new System.Windows.Forms.Label();
            this.comboBoxModel = new System.Windows.Forms.ComboBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.comboBoxPrice = new System.Windows.Forms.ComboBox();
            this.comboBoxMileage = new System.Windows.Forms.ComboBox();
            this.labelkm = new System.Windows.Forms.Label();
            this.comboBoxRegistration = new System.Windows.Forms.ComboBox();
            this.labelReg = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelMake
            // 
            this.labelMake.AutoSize = true;
            this.labelMake.Location = new System.Drawing.Point(12, 9);
            this.labelMake.Name = "labelMake";
            this.labelMake.Size = new System.Drawing.Size(97, 36);
            this.labelMake.TabIndex = 0;
            this.labelMake.Text = "Marke";
            // 
            // comboBoxMake
            // 
            this.comboBoxMake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMake.FormattingEnabled = true;
            this.comboBoxMake.Items.AddRange(new object[] {
            "Ford",
            "Opel",
            "VW"});
            this.comboBoxMake.Location = new System.Drawing.Point(12, 48);
            this.comboBoxMake.Name = "comboBoxMake";
            this.comboBoxMake.Size = new System.Drawing.Size(345, 44);
            this.comboBoxMake.TabIndex = 1;
            this.comboBoxMake.SelectedIndexChanged += new System.EventHandler(this.comboBoxMake_SelectedIndexChanged);
            // 
            // labelModel
            // 
            this.labelModel.AutoSize = true;
            this.labelModel.Location = new System.Drawing.Point(420, 9);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(104, 36);
            this.labelModel.TabIndex = 2;
            this.labelModel.Text = "Modell";
            // 
            // comboBoxModel
            // 
            this.comboBoxModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModel.FormattingEnabled = true;
            this.comboBoxModel.Location = new System.Drawing.Point(419, 48);
            this.comboBoxModel.Name = "comboBoxModel";
            this.comboBoxModel.Size = new System.Drawing.Size(345, 44);
            this.comboBoxModel.TabIndex = 3;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(420, 105);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(83, 36);
            this.labelPrice.TabIndex = 4;
            this.labelPrice.Text = "Preis";
            // 
            // comboBoxPrice
            // 
            this.comboBoxPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrice.FormattingEnabled = true;
            this.comboBoxPrice.Items.AddRange(new object[] {
            "bis",
            "500",
            "1.000",
            "1.500",
            "2.000",
            "2.500",
            "3.000",
            "4.000",
            "5.000",
            "6.000",
            "7.000",
            "8.000",
            "9.000",
            "10.000",
            "12.500",
            "15.000",
            "17.500",
            "20.000",
            "25.000",
            "30.000",
            "40.000",
            "50.000",
            "100.000"});
            this.comboBoxPrice.Location = new System.Drawing.Point(419, 144);
            this.comboBoxPrice.Name = "comboBoxPrice";
            this.comboBoxPrice.Size = new System.Drawing.Size(345, 44);
            this.comboBoxPrice.TabIndex = 6;
            // 
            // comboBoxMileage
            // 
            this.comboBoxMileage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMileage.FormattingEnabled = true;
            this.comboBoxMileage.Items.AddRange(new object[] {
            "bis",
            "2.500",
            "5.000",
            "10.000",
            "20.000",
            "30.000",
            "40.000",
            "50.000",
            "100.000"});
            this.comboBoxMileage.Location = new System.Drawing.Point(12, 246);
            this.comboBoxMileage.Name = "comboBoxMileage";
            this.comboBoxMileage.Size = new System.Drawing.Size(345, 44);
            this.comboBoxMileage.TabIndex = 9;
            // 
            // labelkm
            // 
            this.labelkm.AutoSize = true;
            this.labelkm.Location = new System.Drawing.Point(12, 202);
            this.labelkm.Name = "labelkm";
            this.labelkm.Size = new System.Drawing.Size(131, 36);
            this.labelkm.TabIndex = 7;
            this.labelkm.Text = "kmStand";
            // 
            // comboBoxRegistration
            // 
            this.comboBoxRegistration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRegistration.FormattingEnabled = true;
            this.comboBoxRegistration.Items.AddRange(new object[] {
            "ab",
            "1980",
            "1985",
            "1990",
            "1995",
            "2000",
            "2002",
            "2004",
            "2002",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017"});
            this.comboBoxRegistration.Location = new System.Drawing.Point(13, 143);
            this.comboBoxRegistration.Name = "comboBoxRegistration";
            this.comboBoxRegistration.Size = new System.Drawing.Size(344, 44);
            this.comboBoxRegistration.TabIndex = 11;
            // 
            // labelReg
            // 
            this.labelReg.AutoSize = true;
            this.labelReg.Location = new System.Drawing.Point(12, 104);
            this.labelReg.Name = "labelReg";
            this.labelReg.Size = new System.Drawing.Size(154, 36);
            this.labelReg.TabIndex = 10;
            this.labelReg.Text = "Zulassung";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(410, 329);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(141, 44);
            this.buttonOK.TabIndex = 15;
            this.buttonOK.Text = "Senden";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(227, 329);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(141, 44);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "Abbruch";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // CDialogSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(776, 395);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.comboBoxRegistration);
            this.Controls.Add(this.labelReg);
            this.Controls.Add(this.comboBoxMileage);
            this.Controls.Add(this.labelkm);
            this.Controls.Add(this.comboBoxPrice);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.comboBoxModel);
            this.Controls.Add(this.labelModel);
            this.Controls.Add(this.comboBoxMake);
            this.Controls.Add(this.labelMake);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CDialogSearch";
            this.Text = "Suchen Sie ihr Traumauto";
            this.Load += new System.EventHandler(this.CDialogSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMake;
        private System.Windows.Forms.ComboBox comboBoxMake;
        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.ComboBox comboBoxModel;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.ComboBox comboBoxPrice;
        private System.Windows.Forms.ComboBox comboBoxMileage;
        private System.Windows.Forms.Label labelkm;
        private System.Windows.Forms.ComboBox comboBoxRegistration;
        private System.Windows.Forms.Label labelReg;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}