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
        public void agregar(Marca nuevo)
        {
            string insert = "INSERT INTO MARCAS (Descripcion) VALUES (@nombre)";
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

            if (marcaEnUso(id))
            {
                return false;
            }

            string consulta = "DELETE FROM MARCAS WHERE Id = @ID";
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
        public bool marcaEnUso(int idMarca)
        {
            try
            {
                string consulta = "SELECT COUNT(*) FROM ARTICULOS WHERE IdMarca = @IdMarca";
                datos.setConsulta(consulta);
                datos.setearParametro("@IdMarca", idMarca);
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
        public void modificar(Marca modificar)
        {
            string consulta = "UPDATE MARCAS SET Descripcion = @DESCRIPCION WHERE ID = @ID";
            try
            {
                datos.setConsulta(consulta);
                datos.setearParametro("@ID", modificar.IdMarca);
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
