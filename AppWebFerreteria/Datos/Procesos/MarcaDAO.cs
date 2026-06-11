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
    public class MarcaDAO : Conexion, IMarcaRepositorio
    {
        public IEnumerable<Marca> Listar()
        {
            List<Marca> lista = new List<Marca>();

            using (SqlConnection cn = ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("usp_listar_marcas", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Marca
                    {
                        IdMarca = Convert.ToInt32(dr["IdMarca"]),
                        NombreMarca = dr["NombreMarca"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        Estado = Convert.ToBoolean(dr["Estado"])
                    });
                }
            }

            return lista;
        }

        public Marca BuscarPorId(int id)
        {
            Marca marca = null;

            using (SqlConnection cn = ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("usp_buscar_marca", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add("@IdMarca", SqlDbType.Int).Value = id;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    marca = new Marca
                    {
                        IdMarca = Convert.ToInt32(dr["IdMarca"]),
                        NombreMarca = dr["NombreMarca"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        Estado = Convert.ToBoolean(dr["Estado"])
                    };
                }
            }

            return marca;
        }

        public bool Agregar(Marca marca)
        {
            bool respuesta = false;

            using (SqlConnection cn = ObtenerConexion())
            {
                cn.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("usp_agregar_marca", cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add("@NombreMarca", SqlDbType.VarChar, 100)
                        .Value = marca.NombreMarca;

                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 250)
                        .Value = marca.Descripcion;

                    cmd.Parameters.Add("@Estado", SqlDbType.Bit)
                        .Value = marca.Estado;

                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
                catch
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public bool Actualizar(Marca marca)
        {
            bool respuesta = false;

            using (SqlConnection cn = ObtenerConexion())
            {
                cn.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("usp_actualizar_marca", cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add("@IdMarca", SqlDbType.Int)
                        .Value = marca.IdMarca;

                    cmd.Parameters.Add("@NombreMarca", SqlDbType.VarChar, 100)
                        .Value = marca.NombreMarca;

                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 250)
                        .Value = marca.Descripcion;

                    cmd.Parameters.Add("@Estado", SqlDbType.Bit)
                        .Value = marca.Estado;

                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
                catch
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public bool Eliminar(int id)
        {
            bool respuesta = false;

            using (SqlConnection cn = ObtenerConexion())
            {
                cn.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("usp_eliminar_marca", cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add("@IdMarca", SqlDbType.Int)
                        .Value = id;

                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
                catch
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public IEnumerable<Marca> BuscarPorNombre(string texto)
        {
            List<Marca> lista = new List<Marca>();

            using (SqlConnection cn = ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("usp_busqueda_marca", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add("@Texto", SqlDbType.VarChar, 100)
                    .Value = texto;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Marca
                    {
                        IdMarca = Convert.ToInt32(dr["IdMarca"]),
                        NombreMarca = dr["NombreMarca"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        Estado = Convert.ToBoolean(dr["Estado"])
                    });
                }
            }

            return lista;
        }
    }
}
