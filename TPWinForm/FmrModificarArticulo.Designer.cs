namespace TPWinForm
{
    partial class FmrModificarArticulo
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
            this.tbModificarArticulo = new System.Windows.Forms.TextBox();
            this.lblArticuloModificar = new System.Windows.Forms.Label();
            this.dgvModificarArticulo = new System.Windows.Forms.DataGridView();
            this.dgvParaModificar = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModificarArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParaModificar)).BeginInit();
            this.SuspendLayout();
            // 
            // tbModificarArticulo
            // 
            this.tbModificarArticulo.Location = new System.Drawing.Point(76, 33);
            this.tbModificarArticulo.Margin = new System.Windows.Forms.Padding(2);
            this.tbModificarArticulo.Name = "tbModificarArticulo";
            this.tbModificarArticulo.Size = new System.Drawing.Size(76, 20);
            this.tbModificarArticulo.TabIndex = 0;
            this.tbModificarArticulo.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.tbModificarArticulo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbModificarArticulo_KeyDown);
            // 
            // lblArticuloModificar
            // 
            this.lblArticuloModificar.AutoSize = true;
            this.lblArticuloModificar.Location = new System.Drawing.Point(20, 33);
            this.lblArticuloModificar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblArticuloModificar.Name = "lblArticuloModificar";
            this.lblArticuloModificar.Size = new System.Drawing.Size(42, 13);
            this.lblArticuloModificar.TabIndex = 1;
            this.lblArticuloModificar.Text = "Articulo";
            this.lblArticuloModificar.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvModificarArticulo
            // 
            this.dgvModificarArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModificarArticulo.Location = new System.Drawing.Point(113, 83);
            this.dgvModificarArticulo.Name = "dgvModificarArticulo";
            this.dgvModificarArticulo.Size = new System.Drawing.Size(497, 150);
            this.dgvModificarArticulo.TabIndex = 2;
            // 
            // dgvParaModificar
            // 
            this.dgvParaModificar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParaModificar.Location = new System.Drawing.Point(113, 271);
            this.dgvParaModificar.Name = "dgvParaModificar";
            this.dgvParaModificar.Size = new System.Drawing.Size(497, 150);
            this.dgvParaModificar.TabIndex = 3;
            // 
            // FmrModificarArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 532);
            this.Controls.Add(this.dgvParaModificar);
            this.Controls.Add(this.dgvModificarArticulo);
            this.Controls.Add(this.lblArticuloModificar);
            this.Controls.Add(this.tbModificarArticulo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FmrModificarArticulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modificar Articulo";
            ((System.ComponentModel.ISupportInitialize)(this.dgvModificarArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParaModificar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbModificarArticulo;
        private System.Windows.Forms.Label lblArticuloModificar;
        private System.Windows.Forms.DataGridView dgvModificarArticulo;
        private System.Windows.Forms.DataGridView dgvParaModificar;
    }
}