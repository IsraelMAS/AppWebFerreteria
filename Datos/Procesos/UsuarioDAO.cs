using Dominio.Abstraccion;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Datos.Procesos
{
        public class UsuarioDAO : Conexion, IUsuarioRepositorio
        {
            public Usuario Login(string usuario, string clave)
            {
                Usuario user = null;
                using (SqlConnection cn = ObtenerConexion())
                {
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("usp_login", cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@clave", clave);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        user = new Usuario
                        {
                            IdUsuario = (int)dr["IdUsuario"],
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            UsuarioLogin = dr["Usuario"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Estado = (bool)dr["Estado"],
                            FechaRegistro = (DateTime)dr["FechaRegistro"],
                            IdRol = (int)dr["IdRol"]
                        };
                    }
                }

                return user;
            }
        }
}

