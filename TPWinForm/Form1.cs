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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listadoDeArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmrListadoArticulos ventana = new FmrListadoArticulos();
            ventana.ShowDialog();
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

        private void busquedaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmrBuscar ventana = new FmrBuscar();
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
    }
}
