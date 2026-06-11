using Dominio.Abstraccion;
using Dominio.Entidades;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Negocio.Servicios
{
    public class CategoriaService
    {
        private readonly ICategoriaRepositorio _repo;

        public CategoriaService(ICategoriaRepositorio repo)
        {
            _repo = repo;
        }

        public IEnumerable<Categoria> Listar()
        {
            return _repo.Listar();
        }

        public Categoria BuscarPorId(int id)
        {
            return _repo.BuscarPorId(id);
        }

        public bool Agregar(Categoria categoria)
        {
            return _repo.Agregar(categoria);
        }

        public IEnumerable<Categoria> ListarActivas()
        {
            return _repo.ListarActivas();
        }

        public bool Actualizar(Categoria categoria)
        {
            return _repo.Actualizar(categoria);
        }

        public bool Eliminar(int id)
        {
            return _repo.Eliminar(id);
        }

        public IEnumerable<Categoria> BuscarPorNombre(string texto)
        {
            return _repo.BuscarPorNombre(texto);
        }
    }
}
