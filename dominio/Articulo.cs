using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public string CodigoArticulo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio{ get; set; }
        public Marca marca { get; set; }
        public Categoria categoria { get; set; }
        public Imagen imagen { get; set; }

        /// Ya cuando tengamos imagenes bien hecho sumamos una lista de imagenes;
        // List<Imagen> imagenes = new List<Imagen>();
    }
}
