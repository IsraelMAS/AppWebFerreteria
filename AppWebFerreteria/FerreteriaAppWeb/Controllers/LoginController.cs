using Datos.Procesos;
using Dominio.Abstraccion;
using Dominio.Entidades;
using Negocios.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FerreteriaAppWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly UsuarioService _service;

        public LoginController()
        {
            _service = new UsuarioService(new UsuarioDAO());
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string usuario, string clave)
        {
            Usuario user = _service.Login(usuario, clave);

            if (user != null)
            {
                Session["usuario"] = user;
                Session["nombre"] = user.Nombre;

                return RedirectToAction("Index", "Ferreteria");
            }

            ViewBag.Error = "Usuario o contraseña incorrectos";

            return View();
        }

        public ActionResult CerrarSesion()
        {
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Login");
        }
    }
}