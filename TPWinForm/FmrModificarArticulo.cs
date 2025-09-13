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
        private Articulo articulo = null;
        public FmrModificarArticulo()
        {
            InitializeComponent();
        }
        public FmrModificarArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tbModificarArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            
            
        }

        private void ocultar_Columnas(DataGridView dataGridView) 
        {
            dataGridView.Columns["imagen"].Visible = false;
            dataGridView.Columns["IdArticulo"].Visible = false;
        }

        private void FmrModificarArticulo_Load(object sender, EventArgs e)
        {
            marcaNegocio marcaNegocio = new marcaNegocio();
            categoriaNegocio catNegocio = new categoriaNegocio();

            try
            {
                cboMarca.DataSource = marcaNegocio.listar();
                cboCategoria.DataSource = catNegocio.listar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


            if (articulo != null)
            {
                txtCodigo.Text = articulo.CodigoArticulo;
                txtNombre.Text = articulo.Nombre;
                txtDescripcion.Text = articulo.Descripcion;
                txtPrecio.Text = articulo.Precio.ToString();
                txtUrlImagen.Text = articulo.imagen.ImagenUrl;
                
                cargrImgen(articulo.imagen.ImagenUrl);
            }
        }
        private void cargrImgen(string imgen)
        {
            try
            {
                pbxArticulo.Load(imgen);
            }
            catch (Exception)
            {
                pbxArticulo.Load("https://mrchava.es/wp-content/uploads/2021/09/placeholder.png");
            }
        }



    }
}
