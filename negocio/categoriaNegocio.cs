using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class categoriaNegocio
    {
        List<Categoria> lista = new List<Categoria>();
        AccesoDatos datos = new AccesoDatos();

        public List<Categoria> listar()
        {
            try
            {
                datos.setConsulta("SELECT Id, Descripcion FROM CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria auxCategoria = new Categoria();

                    auxCategoria.IdCategoria = (int)datos.Lector["Id"];
                    auxCategoria.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(auxCategoria);
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
        public void agregar(Categoria nuevo)
        {
            string insert = "INSERT INTO CATEGORIAS (Descripcion) VALUES (@nombre)";
            try
            {
                datos.setConsulta(insert);
                datos.setearParametro("@nombre", nuevo.Descripcion);

                datos.ejecutarAccion();
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

