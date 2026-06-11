using Dominio.Entidades;
using System.Collections.Generic;

namespace Dominio.Abstraccion
{
    public interface ICategoriaRepositorio
    {
        IEnumerable<Categoria> Listar();

        Categoria BuscarPorId(int id);

        bool Agregar(Categoria categoria);
        IEnumerable<Categoria> ListarActivas();

        bool Actualizar(Categoria categoria);

        bool Eliminar(int id);

        IEnumerable<Categoria> BuscarPorNombre(string texto);
    }
}