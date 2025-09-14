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
    public partial class FmrAgregarArticulo : Form
    {
        private Articulo articulo = null;

        public FmrAgregarArticulo()
        {
            InitializeComponent();
        }
        public FmrAgregarArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";
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



        private void FmrAgregarArticulo_Load(object sender, EventArgs e)
        {
            marcaNegocio marcaNegocio = new marcaNegocio();
            categoriaNegocio catNegocio = new categoriaNegocio();

            try
            {
                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.ValueMember = "IdMarca";
                cboMarca.DisplayMember = "Descripcion";
                cboCategoria.DataSource = catNegocio.listar();
                cboCategoria.ValueMember = "IdCategoria";
                cboCategoria.DisplayMember = "Descripcion";

                if (articulo != null)
                {
                    txtCodigo.Text = articulo.CodigoArticulo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString();
                    txtUrlImagen.Text = articulo.imagen.ImagenUrl;

                    cargrImgen(articulo.imagen.ImagenUrl);
                    cboMarca.SelectedValue = articulo.marca.IdMarca;
                    cboCategoria.SelectedValue = articulo.categoria.IdCategoria;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            articuloNegocio negocio = new articuloNegocio();
            try
            {
                if (articulo == null)
                    articulo = new Articulo();

                articulo.CodigoArticulo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = decimal.Parse(txtPrecio.Text);
                articulo.marca = new Marca();
                articulo.marca = (Marca)cboMarca.SelectedItem;
                articulo.categoria = new Categoria();
                articulo.categoria = (Categoria)cboCategoria.SelectedItem;
                // Actualizar la URL de la imagen principal si se cambió
                articulo.imagen.ImagenUrl = txtUrlImagen.Text;

                if (articulo.IdArticulo != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Artículo modificado correctamente");
                    
                }
                else
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("Artículo agregado correctamente");
                }
                this.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
