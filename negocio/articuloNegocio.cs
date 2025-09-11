using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class articuloNegocio
    {
        List<Articulo> lista = new List<Articulo> ();
        AccesoDatos datos = new AccesoDatos ();
        
        public List<Articulo> listar()
        {
            string select = "SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Id marcID, M.Descripcion marcDesc, C.Id catID, C.Descripcion catDesc, Precio, I.Id imgID, I.ImagenUrl imgUrl";
            string from = " FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id LEFT JOIN IMAGENES AS I ON I.IdArticulo = A.Id";
            string consulta = select + from;

            try
            {
                datos.setConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.IdArticulo = (int)datos.Lector["Id"];
                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    
                    aux.marca = new Marca();
                    aux.marca.IdMarca = (int)datos.Lector["marcID"];
                    aux.marca.Descripcion = (string)datos.Lector["marcDesc"];

                    aux.categoria = new Categoria();
                    aux.categoria.IdCategoria = (int)datos.Lector["catID"];
                    aux.categoria.Descripcion = (string)datos.Lector["catDesc"];

                    aux.imagen = new Imagen();
                    if (!(datos.Lector["imgID"] is DBNull))
                    {
                        aux.imagen.IdImagen = (int)datos.Lector["imgID"];
                        aux.imagen.ImagenUrl = (string)datos.Lector["imgUrl"];
                    }

                    lista.Add(aux);
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



        // Nuevo método para buscar un artículo por su código
        public Articulo buscarPorCodigo(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();
            Articulo aux = null;

            try
            {
                string consulta = "SELECT Id, Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio " +
                                  "FROM ARTICULOS WHERE Codigo = @Codigo";

                datos.setConsulta(consulta);
                datos.Comando.Parameters.Clear();
                datos.Comando.Parameters.AddWithValue("@Codigo", codigo);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    aux = new Articulo();
                    aux.IdArticulo = (int)datos.Lector["Id"];
                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    //aux.IdMarca = (int)datos.Lector["IdMarca"];
                    //aux.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                }

                return aux;
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
