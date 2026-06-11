using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Abstraccion
{
    public interface IMarcaRepositorio
    {
        IEnumerable<Marca> Listar();

        Marca BuscarPorId(int id);

        bool Agregar(Marca marca);

        bool Actualizar(Marca marca);

        bool Eliminar(int id);

        IEnumerable<Marca> BuscarPorNombre(string texto);

    }
}
