using Dominio.Abstraccion;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Servicios
{
    public class UsuarioService
    {
        private readonly IUsuarioRepositorio _repo;

        public UsuarioService(IUsuarioRepositorio repo)
        {
            _repo = repo;
        }

        public Usuario Login(string usuario, string clave)
        {
            return _repo.Login(usuario, clave);
        }
    }
}