namespace oplan
{
    partial class frmPostrojbe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPostrojbe));
            this.dgvDivizije = new System.Windows.Forms.DataGridView();
            this.btnIzbrisiPostrojbu = new System.Windows.Forms.Button();
            this.btnDodajPostrojbu = new System.Windows.Forms.Button();
            this.btnIzmijeniPostrojbu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDivizije)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDivizije
            // 
            this.dgvDivizije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDivizije.Location = new System.Drawing.Point(13, 13);
            this.dgvDivizije.Name = "dgvDivizije";
            this.dgvDivizije.Size = new System.Drawing.Size(600, 360);
            this.dgvDivizije.TabIndex = 0;
            // 
            // btnIzbrisiPostrojbu
            // 
            this.btnIzbrisiPostrojbu.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnIzbrisiPostrojbu.Location = new System.Drawing.Point(488, 391);
            this.btnIzbrisiPostrojbu.Name = "btnIzbrisiPostrojbu";
            this.btnIzbrisiPostrojbu.Size = new System.Drawing.Size(125, 32);
            this.btnIzbrisiPostrojbu.TabIndex = 2;
            this.btnIzbrisiPostrojbu.Text = "Izbriši postrojbu";
            this.btnIzbrisiPostrojbu.UseVisualStyleBackColor = true;
            // 
            // btnDodajPostrojbu
            // 
            this.btnDodajPostrojbu.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnDodajPostrojbu.Location = new System.Drawing.Point(226, 391);
            this.btnDodajPostrojbu.Name = "btnDodajPostrojbu";
            this.btnDodajPostrojbu.Size = new System.Drawing.Size(125, 32);
            this.btnDodajPostrojbu.TabIndex = 3;
            this.btnDodajPostrojbu.Text = "Dodaj postrojbu";
            this.btnDodajPostrojbu.UseVisualStyleBackColor = true;
            // 
            // btnIzmijeniPostrojbu
            // 
            this.btnIzmijeniPostrojbu.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnIzmijeniPostrojbu.Location = new System.Drawing.Point(357, 391);
            this.btnIzmijeniPostrojbu.Name = "btnIzmijeniPostrojbu";
            this.btnIzmijeniPostrojbu.Size = new System.Drawing.Size(125, 32);
            this.btnIzmijeniPostrojbu.TabIndex = 4;
            this.btnIzmijeniPostrojbu.Text = "Izmijeni postrojbu";
            this.btnIzmijeniPostrojbu.UseVisualStyleBackColor = true;
            // 
            // frmPostrojbe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.btnIzmijeniPostrojbu);
            this.Controls.Add(this.btnDodajPostrojbu);
            this.Controls.Add(this.btnIzbrisiPostrojbu);
            this.Controls.Add(this.dgvDivizije);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPostrojbe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rad s postrojbama";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDivizije)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDivizije;
        private System.Windows.Forms.Button btnIzbrisiPostrojbu;
        private System.Windows.Forms.Button btnDodajPostrojbu;
        private System.Windows.Forms.Button btnIzmijeniPostrojbu;
    }
}