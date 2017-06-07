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
            this.labelName = new System.Windows.Forms.Label();
            this.labelKategorie = new System.Windows.Forms.Label();
            this.comboBoxKategorie = new System.Windows.Forms.ComboBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextErgebnisse = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(92, 17);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Produktname";
            // 
            // labelKategorie
            // 
            this.labelKategorie.AutoSize = true;
            this.labelKategorie.Location = new System.Drawing.Point(420, 9);
            this.labelKategorie.Name = "labelKategorie";
            this.labelKategorie.Size = new System.Drawing.Size(69, 17);
            this.labelKategorie.TabIndex = 2;
            this.labelKategorie.Text = "Kategorie";
            // 
            // comboBoxKategorie
            // 
            this.comboBoxKategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKategorie.FormattingEnabled = true;
            this.comboBoxKategorie.Location = new System.Drawing.Point(419, 48);
            this.comboBoxKategorie.Name = "comboBoxKategorie";
            this.comboBoxKategorie.Size = new System.Drawing.Size(345, 24);
            this.comboBoxKategorie.TabIndex = 3;
            this.comboBoxKategorie.SelectedIndexChanged += new System.EventHandler(this.comboBoxKategorie_SelectedIndexChanged);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(353, 23);
            this.textBox1.TabIndex = 17;
            // 
            // richTextErgebnisse
            // 
            this.richTextErgebnisse.AcceptsTab = true;
            this.richTextErgebnisse.Location = new System.Drawing.Point(15, 78);
            this.richTextErgebnisse.Name = "richTextErgebnisse";
            this.richTextErgebnisse.Size = new System.Drawing.Size(749, 245);
            this.richTextErgebnisse.TabIndex = 18;
            this.richTextErgebnisse.Text = "";
            // 
            // CDialogSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(776, 395);
            this.Controls.Add(this.richTextErgebnisse);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.comboBoxKategorie);
            this.Controls.Add(this.labelKategorie);
            this.Controls.Add(this.labelName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CDialogSearch";
            this.Text = "Suche nach Lagerbestand";
            this.Load += new System.EventHandler(this.CDialogSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelKategorie;
        private System.Windows.Forms.ComboBox comboBoxKategorie;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextErgebnisse;
    }
}