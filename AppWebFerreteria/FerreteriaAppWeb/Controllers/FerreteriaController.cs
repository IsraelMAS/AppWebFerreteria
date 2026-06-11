using Datos.Procesos;
using Negocio.Servicios;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FerreteriaAppWeb.Controllers
{
    public class FerreteriaController : Controller
    {
        //SERVICES
        private readonly CategoriaService _categoriaService;
        private readonly MarcaService _marcaService;


        public FerreteriaController()
        {
            _categoriaService = new CategoriaService(new CategoriaDAO());
            _marcaService = new MarcaService(new MarcaDAO());
        }


        // Dashboard
        public ActionResult Index()
        {
            return View();
        }

        // Productos
        public ActionResult Productos()
        {
            return View();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Categorías
        public ActionResult Categorias()
        {
            return View(_categoriaService.Listar());
        }

        // GET: Nueva Categoría
        public ActionResult NuevaCategoria()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevaCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _categoriaService.Agregar(categoria);

                return RedirectToAction("Categorias");
            }

            return View(categoria);
        }

        // GET: Editar Categoría
        public ActionResult EditarCategoria(int id)
        {
            return View(
                _categoriaService.BuscarPorId(id)
            );
        }

        [HttpPost]
        public ActionResult EditarCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _categoriaService.Actualizar(categoria);

                return RedirectToAction("Categorias");
            }

            return View(categoria);
        }

        // Eliminar Categoría
        public ActionResult EliminarCategoria(int id)
        {
            _categoriaService.Eliminar(id);

            return RedirectToAction("Categorias");
        }

        // Buscar Categoría
        public ActionResult BuscarCategoria(string texto)
        {
            return View(
                "Categorias",
                _categoriaService.BuscarPorNombre(texto)
            );
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //  **** M     A     R     C      A      S ******

        public ActionResult Marcas()
        {
            return View(_marcaService.Listar());
        }

        // GET Nueva Marca
        public ActionResult NuevaMarca()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevaMarca(Marca marca)
        {
            if (ModelState.IsValid)
            {
                _marcaService.Agregar(marca);

                return RedirectToAction("Marcas");
            }

            return View(marca);
        }

        // GET Editar Marca
        public ActionResult EditarMarca(int id)
        {
            Marca marca = _marcaService.BuscarPorId(id);

            return View(marca);
        }

        [HttpPost]
        public ActionResult EditarMarca(Marca marca)
        {
            if (ModelState.IsValid)
            {
                _marcaService.Actualizar(marca);

                return RedirectToAction("Marcas");
            }

            return View(marca);
        }

        // Eliminar Marca
        public ActionResult EliminarMarca(int id)
        {
            _marcaService.Eliminar(id);

            return RedirectToAction("Marcas");
        }

        // Buscar por Marca
        public ActionResult BuscarMarca(string texto)
        {
            return View(
                "Marcas",
                _marcaService.BuscarPorNombre(texto)
            );
        }


 
        ///////////////////////////////////////////////////////////////////////////////////////////////
       

        // Unidades de Medida
        public ActionResult Unidades()
        {
            return View();
        }

        // Proveedores
        public ActionResult Proveedores()
        {
            return View();
        }

        // Entradas
        public ActionResult Entradas()
        {
            return View();
        }

        // Salidas
        public ActionResult Salidas()
        {
            return View();
        }

        // Kardex
        public ActionResult Kardex()
        {
            return View();
        }

        // Bitácora
        public ActionResult Bitacora()
        {
            return View();
        }
    }
}