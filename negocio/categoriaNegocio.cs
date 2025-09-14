using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public bool eliminar(int id)
        {

            if (categoriaEnUso(id))
            {
                return false;
            }

            string consulta = "DELETE FROM CATEGORIAS WHERE Id = @ID";
            try
            {
                datos.setConsulta(consulta);
                datos.setearParametro("@ID", id);
                datos.ejecutarAccion();
                return true;
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
        public bool categoriaEnUso(int idCategoria)
        {
            try
            {
                string consulta = "SELECT COUNT(*) FROM ARTICULOS WHERE IdCategoria = @IdCategoria";
                datos.setConsulta(consulta);
                datos.setearParametro("@IdCategoria", idCategoria);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return (int)datos.Lector[0] > 0;
                }
                else
                {
                    return false;
                }
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
        public void modificar(Categoria modificar)
        {
            string consulta = "UPDATE CATEGORIAS SET Descripcion = @DESCRIPCION WHERE ID = @ID";
            try
            {
                datos.setConsulta(consulta);
                datos.setearParametro("@ID", modificar.IdCategoria);
                datos.setearParametro("@DESCRIPCION", modificar.Descripcion);

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

