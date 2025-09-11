using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace TPWinForm
{
    public partial class frmVentanaPrincipal : Form
    {
        private List<Articulo> listaArticulo;
        // Asegúrate de asociar el evento KeyDown en el constructor o en InitializeComponent
        public frmVentanaPrincipal()
        {
            InitializeComponent();
            txtBuscarArtículo.KeyDown += txtBuscarArtículo_KeyDown;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }
        public void cargar()
        {
            articuloNegocio artNegocio = new articuloNegocio();
            try
            {
                listaArticulo = artNegocio.listar();
                dgvArticulo.DataSource = listaArticulo;
                ocultarColumnas();  // este metodo oculta las columnas 
                cargrImgen(listaArticulo[0].imagen.ImagenUrl);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void ocultarColumnas()
        {
            dgvArticulo.Columns["imagen"].Visible = false;      //oculta las columnas
            dgvArticulo.Columns["idArticulo"].Visible = false;
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
        private void dgvArticulo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulo.CurrentRow != null) 
            {
                Articulo artSelec = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;
                cargrImgen(artSelec.imagen.ImagenUrl);
            }

        }
        private void mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmrModificarArticulo ventana = new FmrModificarArticulo(); 
            ventana.ShowDialog();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmrAgregarArticulo ventana = new FmrAgregarArticulo();  
            ventana.ShowDialog();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmrElimiarArticulo ventana = new FmrElimiarArticulo();
            ventana.ShowDialog();
        }

        private void detallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmrDetalles ventana = new FmrDetalles();
            ventana.ShowDialog();
        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          FmrAgregarMarca ventana = new FmrAgregarMarca();
            ventana.ShowDialog();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           FmrModificarMarca ventana = new FmrModificarMarca();
            ventana.ShowDialog();
        }

        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FmrEliminarMarca ventana = new FmrEliminarMarca();
            ventana.ShowDialog();
        }

        private void agregarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FmrAgregarCategoria ventana = new FmrAgregarCategoria();
            ventana.ShowDialog();
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FmrModificarCategoria ventana = new FmrModificarCategoria();
            ventana.ShowDialog();
        }

        private void eliminarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FmrEliminarCategoria ventana = new FmrEliminarCategoria();
            ventana.ShowDialog();
        }


        private void dgvArticulo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void lblBuscarArticulo_Click(object sender, EventArgs e)
        {

        }

        // Evento KeyDown para el TextBox de búsqueda de artículos por código
        private void txtBuscarArtículo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                articuloNegocio negocio = new articuloNegocio();
                Articulo art = negocio.buscarPorCodigo(txtBuscarArtículo.Text);

                if (art != null)
                {
                    List<Articulo> resultado = new List<Articulo> { art };
                    dataGridViewBuscarArticulo.DataSource = null; //limpio primero por si hay busquedas anteriores
                    dataGridViewBuscarArticulo.DataSource = resultado;
                }
                else
                {
                    MessageBox.Show("No se encontró un artículo con ese código.");
                    dataGridViewBuscarArticulo.DataSource = null;
                }

                e.SuppressKeyPress = true; // evita el beep del Enter
            }
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            frmMarcaCategoria marca = new frmMarcaCategoria(true);    // es true xq sale del boton de MARCA.
            marca.ShowDialog();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            frmMarcaCategoria categoria = new frmMarcaCategoria(false);    // es false xq sale del boton de CATEGORIA.
            categoria.ShowDialog();
        }
    }
}
