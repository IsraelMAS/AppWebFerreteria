using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> Listar();

        T BuscarPorId(int id);

        bool Agregar(T entidad);

        bool Actualizar(T entidad);

        bool Eliminar(int id);
    }
}