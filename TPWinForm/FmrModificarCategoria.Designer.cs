namespace TPWinForm
{
    partial class FmrModificarCategoria
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
            this.lblCategoriaModificar = new System.Windows.Forms.Label();
            this.txtCategoriaModificar = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCategoriaModificar
            // 
            this.lblCategoriaModificar.AutoSize = true;
            this.lblCategoriaModificar.Location = new System.Drawing.Point(22, 39);
            this.lblCategoriaModificar.Name = "lblCategoriaModificar";
            this.lblCategoriaModificar.Size = new System.Drawing.Size(66, 16);
            this.lblCategoriaModificar.TabIndex = 0;
            this.lblCategoriaModificar.Text = "Categoria";
            // 
            // txtCategoriaModificar
            // 
            this.txtCategoriaModificar.Location = new System.Drawing.Point(122, 39);
            this.txtCategoriaModificar.Name = "txtCategoriaModificar";
            this.txtCategoriaModificar.Size = new System.Drawing.Size(100, 22);
            this.txtCategoriaModificar.TabIndex = 1;
            // 
            // FmrModificarCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtCategoriaModificar);
            this.Controls.Add(this.lblCategoriaModificar);
            this.Name = "FmrModificarCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modificar Categoria";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategoriaModificar;
        private System.Windows.Forms.TextBox txtCategoriaModificar;
    }
}