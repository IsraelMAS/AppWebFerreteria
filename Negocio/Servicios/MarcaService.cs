using Dominio.Abstraccion;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Servicios
{
    public class MarcaService
    {
        private readonly IMarcaRepositorio _repo;

        public MarcaService(IMarcaRepositorio repo)
        {
            _repo = repo;
        }

        public IEnumerable<Marca> Listar()
        {
            return _repo.Listar();
        }

        public Marca BuscarPorId(int id)
        {
            return _repo.BuscarPorId(id);
        }

        public bool Agregar(Marca entidad)
        {
            return _repo.Agregar(entidad);
        }

        public bool Actualizar(Marca entidad)
        {
            return _repo.Actualizar(entidad);
        }

        public bool Eliminar(int id)
        {
            return _repo.Eliminar(id);
        }

        public IEnumerable<Marca> BuscarPorNombre(string texto)
        {
            return _repo.BuscarPorNombre(texto);
        }
    }
}

