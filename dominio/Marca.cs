using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Marca
    {
        [DisplayName("NUMERO")]
        public int IdMarca { get; set; }
        [DisplayName("NOMBRE")]
        public string Descripcion { get; set; }
        public override string ToString()
        {
            return Descripcion;
        }

    }
}
