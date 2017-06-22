namespace CompUI
{
    partial class CDialogNewCategory
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
            this.textBoxNewCategory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonHinzufuegen = new System.Windows.Forms.Button();
            this.buttonAbbrechen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxNewCategory
            // 
            this.textBoxNewCategory.Location = new System.Drawing.Point(12, 28);
            this.textBoxNewCategory.Name = "textBoxNewCategory";
            this.textBoxNewCategory.Size = new System.Drawing.Size(324, 20);
            this.textBoxNewCategory.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name der Neuen Kategorie:";
            // 
            // buttonHinzufuegen
            // 
            this.buttonHinzufuegen.Location = new System.Drawing.Point(12, 57);
            this.buttonHinzufuegen.Name = "buttonHinzufuegen";
            this.buttonHinzufuegen.Size = new System.Drawing.Size(75, 23);
            this.buttonHinzufuegen.TabIndex = 2;
            this.buttonHinzufuegen.Text = "Hinzufügen";
            this.buttonHinzufuegen.UseVisualStyleBackColor = true;
            this.buttonHinzufuegen.Click += new System.EventHandler(this.buttonHinzufuegen_Click);
            // 
            // buttonAbbrechen
            // 
            this.buttonAbbrechen.Location = new System.Drawing.Point(261, 57);
            this.buttonAbbrechen.Name = "buttonAbbrechen";
            this.buttonAbbrechen.Size = new System.Drawing.Size(75, 23);
            this.buttonAbbrechen.TabIndex = 3;
            this.buttonAbbrechen.Text = "Abbrechen";
            this.buttonAbbrechen.UseVisualStyleBackColor = true;
            this.buttonAbbrechen.Click += new System.EventHandler(this.buttonAbbrechen_Click);
            // 
            // CDialogNewCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 92);
            this.Controls.Add(this.buttonAbbrechen);
            this.Controls.Add(this.buttonHinzufuegen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNewCategory);
            this.Name = "CDialogNewCategory";
            this.Text = "EIne neue Produktkategorie hinzufügen";
            this.Load += new System.EventHandler(this.CDialogNewCategory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNewCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonHinzufuegen;
        private System.Windows.Forms.Button buttonAbbrechen;
    }
}