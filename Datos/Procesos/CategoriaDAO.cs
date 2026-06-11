using Dominio.Abstraccion;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos.Procesos
{
    public class CategoriaDAO : Conexion, ICategoriaRepositorio
    {
        public IEnumerable<Categoria> Listar()
        {
            List<Categoria> lista = new List<Categoria>();

            using (SqlConnection cn = ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("usp_listar_categorias", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Categoria
                    {
                        IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                        NombreCategoria = dr["NombreCategoria"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        Estado = Convert.ToBoolean(dr["Estado"])
                    });
                }
            }

            return lista;
        }

        public Categoria BuscarPorId(int id)
        {
            Categoria categoria = null;

            using (SqlConnection cn = ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("usp_buscar_categoria", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = id;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    categoria = new Categoria
                    {
                        IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                        NombreCategoria = dr["NombreCategoria"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        Estado = Convert.ToBoolean(dr["Estado"])
                    };
                }
            }

            return categoria;
        }

        public bool Agregar(Categoria categoria)
        {
            bool respuesta = false;

            using (SqlConnection cn = ObtenerConexion())
            {
                cn.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("usp_agregar_categoria", cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add("@NombreCategoria", SqlDbType.VarChar, 100)
                        .Value = categoria.NombreCategoria;

                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 250)
                        .Value = categoria.Descripcion;

                    cmd.Parameters.Add("@Estado", SqlDbType.Bit)
                        .Value = categoria.Estado;

                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
                catch
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public bool Actualizar(Categoria categoria)
        {
            bool respuesta = false;

            using (SqlConnection cn = ObtenerConexion())
            {
                cn.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("usp_actualizar_categoria", cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add("@IdCategoria", SqlDbType.Int)
                        .Value = categoria.IdCategoria;

                    cmd.Parameters.Add("@NombreCategoria", SqlDbType.VarChar, 100)
                        .Value = categoria.NombreCategoria;

                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 250)
                        .Value = categoria.Descripcion;

                    cmd.Parameters.Add("@Estado", SqlDbType.Bit)
                        .Value = categoria.Estado;

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
                    SqlCommand cmd = new SqlCommand("usp_eliminar_categoria", cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add("@IdCategoria", SqlDbType.Int)
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

        public IEnumerable<Categoria> BuscarPorNombre(string texto)
        {
            List<Categoria> lista = new List<Categoria>();

            using (SqlConnection cn = ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("usp_busqueda_categoria", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add("@texto", SqlDbType.VarChar, 100)
                    .Value = texto;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Categoria
                    {
                        IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                        NombreCategoria = dr["NombreCategoria"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        Estado = Convert.ToBoolean(dr["Estado"])
                    });
                }
            }

            return lista;
        }

        public IEnumerable<Categoria> ListarActivas()
        {
            List<Categoria> lista = new List<Categoria>();

            using (SqlConnection cn = ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand(
                    @"SELECT IdCategoria, NombreCategoria FROM Categorias WHERE Estado = 1 ORDER BY NombreCategoria", cn);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Categoria()
                    {
                        IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                        NombreCategoria = dr["NombreCategoria"].ToString()
                    });
                }
            }

            return lista;
        }
    }
}