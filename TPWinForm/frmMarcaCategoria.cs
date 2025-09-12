using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;
using dominio;

namespace TPWinForm
{
    public partial class frmMarcaCategoria : Form
    {
        private bool marca = false;     // si se selecciona marca se pasa como true en el constructor.
        List<Marca> marcaLista = new List<Marca>();
        List<Categoria> categoriaLista = new List<Categoria>();
        public frmMarcaCategoria(bool marca)
        {
            InitializeComponent();
            this.marca = marca;
        }

        private void frmMarcaCategoria_Load(object sender, EventArgs e)
        {
            cargar();
        }
        private void cargar()
        {
            txtNombre.Text = string.Empty;
            if (marca)
            {
                marcaNegocio marNeg = new marcaNegocio();
                try
                {
                    marcaLista = marNeg.listar();
                    dgvMarCat.DataSource = marcaLista;

                    this.Text = " MARCA ";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                categoriaNegocio catNeg = new categoriaNegocio();
                try
                {
                    categoriaLista = catNeg.listar();
                    dgvMarCat.DataSource = categoriaLista;

                    this.Text = " CATEGORIA ";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))  //COMPRUEBA SI EL TXTBOX TIENE ALGO 
            {
                try
                {
                    if (marca)
                    {
                        marcaNegocio marcaNegocio = new marcaNegocio();
                        Marca aux = new Marca();
                        aux.Descripcion = txtNombre.Text;
                        marcaNegocio.agregar(aux);

                        MessageBox.Show(" MARCA AGREGADA ");

                    }
                    else
                    {
                        categoriaNegocio categoriaNegocio = new categoriaNegocio();
                        Categoria aux = new Categoria();
                        aux.Descripcion = txtNombre.Text;
                        categoriaNegocio.agregar(aux);

                        MessageBox.Show(" CATEGORIA AGREGADA ");
                    }
                    cargar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                MessageBox.Show(" AGREGAR UN NOMBRE ");
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Esta seguro que desea eliminar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    if (marca)
                    {
                        marcaNegocio marcaNegocio = new marcaNegocio();
                        Marca marca = (Marca)dgvMarCat.CurrentRow.DataBoundItem;

                        marcaNegocio.eliminar(marca.IdMarca);

                        MessageBox.Show(" MARCA ELIMINADA ");
                    }
                    else
                    {
                        categoriaNegocio categoriaNegocio = new categoriaNegocio();
                        Categoria cate = (Categoria)dgvMarCat.CurrentRow.DataBoundItem;

                        categoriaNegocio.eliminar(cate.IdCategoria);

                        MessageBox.Show(" CATEGORIA ELIMINADA ");

                    }
                    cargar();
                }
                else
                {
                    MessageBox.Show(" CANCELADO ");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))  //COMPRUEBA SI EL TXTBOX TIENE ALGO
            {
                if (marca)
                {
                    marcaNegocio marNegocio = new marcaNegocio();
                    Marca marca = (Marca)dgvMarCat.CurrentRow.DataBoundItem;
                    marca.Descripcion = txtNombre.Text;

                    marNegocio.modificar(marca);

                    MessageBox.Show(" MARCA MODIFICADA ");

                }
                else
                {
                    categoriaNegocio catNegocio = new categoriaNegocio();
                    Categoria categoria = (Categoria)dgvMarCat.CurrentRow.DataBoundItem;
                    categoria.Descripcion = txtNombre.Text;

                    catNegocio.modificar(categoria);

                    MessageBox.Show(" CATEGORIA MODIFICADA ");

                }
                cargar();
            }
        }
    }
}
