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
                ocultar_Columnas(dgvArticulo);  // este metodo oculta las columnas 
                cargrImgen(listaArticulo[0].imagen.ImagenUrl);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void ocultar_Columnas(DataGridView dataGridView)
        {
            dataGridView.Columns["imagen"].Visible = false;
            dataGridView.Columns["IdArticulo"].Visible = false;
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
                Articulo artSelec = dgvArticulo.CurrentRow.DataBoundItem as Articulo;

                if (artSelec != null)
                {
                    string url = "https://media.istockphoto.com/id/1385481764/es/vector/fotograf%C3%ADa-prohibida-signo.jpg?s=612x612&w=0&k=20&c=086e9bSgllT8QdK1TmlXy0Rn-i7-L0EwLCOb-OnLIrg="; // imagen por defecto

                    if (artSelec.imagen != null && !string.IsNullOrEmpty(artSelec.imagen.ImagenUrl))
                        url = artSelec.imagen.ImagenUrl;

                    cargrImgen(url);
                }
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
                    ocultar_Columnas(dataGridViewBuscarArticulo);
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FmrAgregarArticulo articulo = new FmrAgregarArticulo();
            articulo.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo articuloSeleccionado;
            articuloSeleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;

            FmrModificarArticulo ventanaModificar = new FmrModificarArticulo(articuloSeleccionado);
            ventanaModificar.ShowDialog();

            
        }

        private void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = txtBuscarArtículo.Text.Trim();

                if (string.IsNullOrEmpty(codigo))
                {
                    MessageBox.Show("Por favor, ingrese un código de artículo.");
                    return;
                }

                articuloNegocio negocio = new articuloNegocio();

                // Verificar si el artículo existe
                Articulo articulo = negocio.buscarPorCodigo(codigo);

                if (articulo == null)
                {
                    MessageBox.Show("No se encontró un artículo con el código: " + codigo);
                    return;
                }

                // Confirmación
                DialogResult confirmacion = MessageBox.Show(
                    "¿Está seguro de que desea eliminar el artículo con código: " + codigo + "?",
                    "Eliminar artículo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacion == DialogResult.Yes)
                {
                    negocio.eliminar(codigo);
                    MessageBox.Show("Artículo eliminado correctamente.");

                    // Refrescar el DataGridView
                    dataGridViewBuscarArticulo.DataSource = null;
                    dgvArticulo.DataSource = null;
                    dgvArticulo.DataSource = negocio.listar();
                    ocultar_Columnas(dgvArticulo);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }
    }
}
