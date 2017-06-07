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
            this.labelKategorie = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonESC = new System.Windows.Forms.Button();
            this.checkedListBoxKategorie = new System.Windows.Forms.CheckedListBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelAnz = new System.Windows.Forms.Label();
            this.labelPreis = new System.Windows.Forms.Label();
            this.textBoxPreis = new System.Windows.Forms.TextBox();
            this.numericUpDownAnz = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAnz)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Location = new System.Drawing.Point(18, 208);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(6);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(184, 54);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "Ok";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK2_Click);
            // 
            // labelKategorie
            // 
            this.labelKategorie.AutoSize = true;
            this.labelKategorie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKategorie.Location = new System.Drawing.Point(15, 63);
            this.labelKategorie.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelKategorie.Name = "labelKategorie";
            this.labelKategorie.Size = new System.Drawing.Size(81, 17);
            this.labelKategorie.TabIndex = 27;
            this.labelKategorie.Text = "Kategorien:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(15, 17);
            this.labelName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(96, 17);
            this.labelName.TabIndex = 19;
            this.labelName.Text = "Produktname:";
            // 
            // buttonESC
            // 
            this.buttonESC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonESC.Location = new System.Drawing.Point(214, 208);
            this.buttonESC.Margin = new System.Windows.Forms.Padding(6);
            this.buttonESC.Name = "buttonESC";
            this.buttonESC.Size = new System.Drawing.Size(184, 54);
            this.buttonESC.TabIndex = 6;
            this.buttonESC.Text = "Abbruch";
            this.buttonESC.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxKategorie
            // 
            this.checkedListBoxKategorie.FormattingEnabled = true;
            this.checkedListBoxKategorie.Location = new System.Drawing.Point(18, 83);
            this.checkedListBoxKategorie.Name = "checkedListBoxKategorie";
            this.checkedListBoxKategorie.Size = new System.Drawing.Size(306, 112);
            this.checkedListBoxKategorie.TabIndex = 2;
            this.checkedListBoxKategorie.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxKategorie_SelectedIndexChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(18, 37);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(306, 23);
            this.textBoxName.TabIndex = 1;
            // 
            // labelAnz
            // 
            this.labelAnz.AutoSize = true;
            this.labelAnz.Location = new System.Drawing.Point(330, 18);
            this.labelAnz.Name = "labelAnz";
            this.labelAnz.Size = new System.Drawing.Size(55, 17);
            this.labelAnz.TabIndex = 43;
            this.labelAnz.Text = "Anzahl:";
            // 
            // labelPreis
            // 
            this.labelPreis.AutoSize = true;
            this.labelPreis.Location = new System.Drawing.Point(330, 64);
            this.labelPreis.Name = "labelPreis";
            this.labelPreis.Size = new System.Drawing.Size(71, 17);
            this.labelPreis.TabIndex = 44;
            this.labelPreis.Text = "Preis in €:";
            // 
            // textBoxPreis
            // 
            this.textBoxPreis.Location = new System.Drawing.Point(333, 83);
            this.textBoxPreis.Name = "textBoxPreis";
            this.textBoxPreis.Size = new System.Drawing.Size(100, 23);
            this.textBoxPreis.TabIndex = 4;
            // 
            // numericUpDownAnz
            // 
            this.numericUpDownAnz.Location = new System.Drawing.Point(333, 37);
            this.numericUpDownAnz.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownAnz.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownAnz.Name = "numericUpDownAnz";
            this.numericUpDownAnz.Size = new System.Drawing.Size(100, 23);
            this.numericUpDownAnz.TabIndex = 45;
            this.numericUpDownAnz.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CDialogTrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 277);
            this.Controls.Add(this.numericUpDownAnz);
            this.Controls.Add(this.textBoxPreis);
            this.Controls.Add(this.labelPreis);
            this.Controls.Add(this.labelAnz);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.checkedListBoxKategorie);
            this.Controls.Add(this.buttonESC);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelKategorie);
            this.Controls.Add(this.labelName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "CDialogTrade";
            this.Text = "Bitte geben Sie ihre Daten ein";
            this.Load += new System.EventHandler(this.CDialogTrade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAnz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelKategorie;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonESC;
        private System.Windows.Forms.CheckedListBox checkedListBoxKategorie;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelAnz;
        private System.Windows.Forms.Label labelPreis;
        private System.Windows.Forms.TextBox textBoxPreis;
        private System.Windows.Forms.NumericUpDown numericUpDownAnz;
    }
}