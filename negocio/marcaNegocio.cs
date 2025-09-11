using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class marcaNegocio
    {
        List<Marca> lista = new List<Marca>();
        AccesoDatos datos = new AccesoDatos();

        public List<Marca> listar()
        {
            try
            {
                datos.setConsulta("SELECT Id, Descripcion FROM MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca auxMarca = new Marca();

                    auxMarca.IdMarca = (int)datos.Lector["Id"];
                    auxMarca.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(auxMarca);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
