using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    internal class Articulo
    {
        public int IdArticulo { get; set; }
        public int CodigoArticulo { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }
        public decimal Precio{ get; set; }

        /// Ya cuando tengamos imagenes bien hecho sumamos una lista de imagenes;
        // List<Imagen> imagenes = new List<Imagen>();
    }
}
