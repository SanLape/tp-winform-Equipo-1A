using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace negocio
{
    internal class AccesoDatos
    {
        private SqlConnection conexion; // Establece la coneccion
        private SqlCommand comando;     // Para realizar las acciones 
        private SqlDataReader lector;   // Son los datos, son los resultados
        public SqlDataReader Lector     // Con esta PROPERTY se tiene la posibilidad de leer del exterior el "lector".
        {
            get {  return lector; }
        }
        public AccesoDatos()
        {
            conexion = new SqlConnection("server =.\\SQLEXPRESS; database = CATALOGO_P3_DB ; integrated security = true");  // AGREGAR EL NOMBRE DE LA BASE DE DATOS **DATABASE**
            comando = new SqlCommand();
        }
        public void setConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text; // Forma de hacer la consutla 
            comando.CommandText = consulta;                     // Se manda la consutla en texto
        }
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void cerrarConexion()
        {
            if(lector != null)
                lector.Close();     //cierra el lector.
            conexion.Close();       //cierra la conexion.
        }
    }
}
