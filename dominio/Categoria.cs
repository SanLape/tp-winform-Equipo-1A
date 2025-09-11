using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Categoria
    {
        [DisplayName("NUMERO")]
        public int IdCategoria { get; set; }
        [DisplayName("NOMBRE")]
        public string Descripcion { get; set; }
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
