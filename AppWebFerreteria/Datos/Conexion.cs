using System.Configuration;
using System.Data.SqlClient;


namespace Datos
{
    public class Conexion
    {
        private readonly string cadena;

        public Conexion()
        {
            cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        }

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }

    }
    /*Tip de clase: “Antes poníamos la conexión en cada clase… ahora la centralizamos.
Esto se llama reutilización y desacoplamiento básico.”*/
}
