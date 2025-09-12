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
            
        }
    }
}
