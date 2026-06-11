using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Abstraccion
{
    public interface IUsuarioRepositorio
    {
        Usuario Login(string usuarioLogin, string clave);
    }
}
