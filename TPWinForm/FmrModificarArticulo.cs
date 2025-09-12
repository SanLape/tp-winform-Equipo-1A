using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPWinForm
{
    public partial class FmrModificarArticulo : Form
    {
        public FmrModificarArticulo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tbModificarArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                articuloNegocio negocio = new articuloNegocio();
                Articulo art = negocio.buscarPorCodigo(tbModificarArticulo.Text);

                if (art != null)
                {
                    List<Articulo> resultado = new List<Articulo> { art };
                    dgvModificarArticulo.DataSource = null; 
                    dgvModificarArticulo.DataSource = resultado;
                    ocultar_Columnas(dgvModificarArticulo);

                    // Segundo datagridview / modificando articulo

                    Articulo modificado = new Articulo();
                    modificado.CodigoArticulo = resultado[0].CodigoArticulo;
                    List<Articulo> modificados = new List<Articulo>{modificado};
                    dgvParaModificar.DataSource = null;
                    dgvParaModificar.DataSource = modificados;
                    ocultar_Columnas(dgvModificarArticulo);

                }
                else
                {
                    MessageBox.Show("No se encontró un artículo con ese código.");
                    dgvModificarArticulo.DataSource = null;
                }

                e.SuppressKeyPress = true;

            }
            
        }

        private void ocultar_Columnas(DataGridView dataGridView) 
        {
            dataGridView.Columns["imagen"].Visible = false;
            dataGridView.Columns["IdArticulo"].Visible = false;
        }
    }
}
