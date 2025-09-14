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

                //NUEVO Para las multiples imágenes
                Dictionary<int, Articulo> articulos = new Dictionary<int, Articulo>();

                while (datos.Lector.Read())
                {
                    int idArticulo = (int)datos.Lector["Id"];

                    if (!articulos.ContainsKey(idArticulo))
                    {
                        Articulo aux = new Articulo();

                        aux.IdArticulo = idArticulo;
                        aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                        aux.Nombre = (string)datos.Lector["Nombre"];
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                        aux.Precio = (decimal)datos.Lector["Precio"];

                        aux.marca = new Marca
                        {
                            IdMarca = (int)datos.Lector["marcID"],
                            Descripcion = (string)datos.Lector["marcDesc"]
                        };

                        aux.categoria = new Categoria
                        {
                            IdCategoria = (int)datos.Lector["catID"],
                            Descripcion = (string)datos.Lector["catDesc"]
                        };

                        // inicia la lista de imágenes
                        aux.Imagenes = new List<Imagen>();

                        articulos.Add(idArticulo, aux);
                    }

                    //  agrega mas imagens
                    if (!(datos.Lector["imgID"] is DBNull))
                    {
                        Imagen img = new Imagen
                        {
                            IdImagen = (int)datos.Lector["imgID"],
                            ImagenUrl = (string)datos.Lector["imgUrl"]
                        };

                        articulos[idArticulo].Imagenes.Add(img);

                        // compatibilidad con lo viejo:
                        if (articulos[idArticulo].imagen == null)
                            articulos[idArticulo].imagen = img;
                    }
                }

                lista = articulos.Values.ToList();

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
        public void agregar(Articulo nuevo)
        {
            string insertArticulo = "INSERT INTO ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio)" +
                                    " VALUES(@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)";

            try
            {
                datos.setConsulta(insertArticulo);
                datos.setearParametro("@Codigo", nuevo.CodigoArticulo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IdMarca", nuevo.marca.IdMarca);
                datos.setearParametro("@IdCategoria", nuevo.categoria.IdCategoria);
                datos.setearParametro("@Precio", nuevo.Precio);

                datos.ejecutarAccion();
                datos.cerrarConexion();

                //NUEVO Agregar la imagen al cargar
                // Obtengo el Id del artículo recién insertado
                datos.setConsulta("SELECT MAX(Id) AS IdArticulo FROM ARTICULOS");
                datos.ejecutarLectura();
                int idArticulo = 0;
                if (datos.Lector.Read())
                {
                    idArticulo = Convert.ToInt32(datos.Lector["IdArticulo"]);
                }
                datos.cerrarConexion();
                // Inserto la imagen
                string insertImagen = "INSERT INTO IMAGENES(IdArticulo, ImagenUrl) VALUES(@IdArticulo, @ImagenUrl)";
                datos.setConsulta(insertImagen);
                datos.setearParametro("@IdArticulo", idArticulo);
                datos.setearParametro("@ImagenUrl", nuevo.imagen.ImagenUrl);
                datos.ejecutarAccion();
                datos.cerrarConexion();
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



        // método para buscar un artículo por su código
        public Articulo buscarPorCodigo(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();
            Articulo aux = null;

            try
            {
                string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.Precio \n" +
                                  "FROM ARTICULOS A\n" +
                                  "INNER JOIN MARCAS M ON A.IdMarca = M.Id\n" +
                                  "INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id\n" +
                                  "WHERE A.Codigo = @Codigo\n";

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
                    aux.marca = new Marca();
                    aux.marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.categoria = new Categoria();
                    aux.categoria.Descripcion = (string)datos.Lector["Categoria"];
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

        // NUEVO Metodo para eliminar un artículo por su código
        public void eliminar(string codigo)
        {
            try
            {
                string consulta = "DELETE FROM ARTICULOS WHERE Codigo = @Codigo";
                datos.setConsulta(consulta);
                datos.Comando.Parameters.Clear();
                datos.setearParametro("@Codigo", codigo);

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

        //NUEVO Método para modificar un artículo existente
        public void modificar(Articulo art)
        {
            try
            {
                // Actualizar los datos del artículo
                string consultaArticulo = @"
            UPDATE ARTICULOS
            SET Codigo=@Codigo,
                Nombre=@Nombre,
                Descripcion=@Descripcion,
                Precio=@Precio,
                IdMarca=@IdMarca,
                IdCategoria=@IdCategoria
            WHERE Id=@Id";

                datos.setConsulta(consultaArticulo);

                datos.setearParametro("@Codigo", art.CodigoArticulo);
                datos.setearParametro("@Nombre", art.Nombre);
                datos.setearParametro("@Descripcion", art.Descripcion);
                datos.setearParametro("@Precio", art.Precio);
                datos.setearParametro("@IdMarca", art.marca.IdMarca);
                datos.setearParametro("@IdCategoria", art.categoria.IdCategoria);
                datos.setearParametro("@Id", art.IdArticulo);

                datos.ejecutarAccion();
                datos.cerrarConexion();

                // Actualizar la URL de la imagen principal si existe (tengo dudas como actualizar una url que no sea la principal)
                if (art.imagen != null && art.imagen.IdImagen > 0)
                {
                    string consultaImagen = @"
                UPDATE IMAGENES
                SET ImagenUrl=@ImagenUrl
                WHERE Id=@IdImagen AND IdArticulo=@IdArticulo";

                    datos.setConsulta(consultaImagen);
                    datos.setearParametro("@ImagenUrl", art.imagen.ImagenUrl);
                    datos.setearParametro("@IdImagen", art.imagen.IdImagen);
                    datos.setearParametro("@IdArticulo", art.IdArticulo);

                    datos.ejecutarAccion();
                    datos.cerrarConexion();
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



    }
}
