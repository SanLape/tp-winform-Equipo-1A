namespace TPWinForm
{
    partial class FmrModificarMarca
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
            this.txtMarcaModificar = new System.Windows.Forms.TextBox();
            this.lblMarcaModificar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMarcaModificar
            // 
            this.txtMarcaModificar.Location = new System.Drawing.Point(115, 41);
            this.txtMarcaModificar.Name = "txtMarcaModificar";
            this.txtMarcaModificar.Size = new System.Drawing.Size(100, 22);
            this.txtMarcaModificar.TabIndex = 0;
            // 
            // lblMarcaModificar
            // 
            this.lblMarcaModificar.AutoSize = true;
            this.lblMarcaModificar.Location = new System.Drawing.Point(36, 46);
            this.lblMarcaModificar.Name = "lblMarcaModificar";
            this.lblMarcaModificar.Size = new System.Drawing.Size(45, 16);
            this.lblMarcaModificar.TabIndex = 1;
            this.lblMarcaModificar.Text = "Marca";
            // 
            // FmrModificarMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblMarcaModificar);
            this.Controls.Add(this.txtMarcaModificar);
            this.Name = "FmrModificarMarca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modificar Marca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMarcaModificar;
        private System.Windows.Forms.Label lblMarcaModificar;
    }
}