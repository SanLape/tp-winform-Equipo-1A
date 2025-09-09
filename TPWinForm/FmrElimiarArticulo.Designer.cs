namespace TPWinForm
{
    partial class FmrElimiarArticulo
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
            this.lblArticuloEliminar = new System.Windows.Forms.Label();
            this.txtArticulo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblArticuloEliminar
            // 
            this.lblArticuloEliminar.AutoSize = true;
            this.lblArticuloEliminar.BackColor = System.Drawing.SystemColors.Control;
            this.lblArticuloEliminar.Location = new System.Drawing.Point(35, 32);
            this.lblArticuloEliminar.Name = "lblArticuloEliminar";
            this.lblArticuloEliminar.Size = new System.Drawing.Size(51, 16);
            this.lblArticuloEliminar.TabIndex = 0;
            this.lblArticuloEliminar.Text = "Articulo";
            this.lblArticuloEliminar.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtArticulo
            // 
            this.txtArticulo.Location = new System.Drawing.Point(92, 29);
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Size = new System.Drawing.Size(100, 22);
            this.txtArticulo.TabIndex = 1;
            // 
            // FmrElimiarArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtArticulo);
            this.Controls.Add(this.lblArticuloEliminar);
            this.Name = "FmrElimiarArticulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Elimiar Articulo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblArticuloEliminar;
        private System.Windows.Forms.TextBox txtArticulo;
    }
}