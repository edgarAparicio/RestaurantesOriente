using EdgarAparicio.Restaurantes.Data.Models;
using EdgarAparicio.Restaurantes.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantesOriente.Controllers
{
    public class RestaurantesController : Controller
    {
        private readonly IRestaurante restauranteRepostorio;

        
        public Restaurante Restaurante { get; set; }

        // GET: Restaurantes

        public RestaurantesController(IRestaurante restaurante)
        {
            this.restauranteRepostorio = restaurante;
        }
        public ActionResult Index()
        {
            var listaRestaurantes = restauranteRepostorio.ObtenerListaRestaurantes();
            return View(listaRestaurantes);
        }

        public ActionResult Detalles(int idRestaurante) //El id debe llamarse igual que el item del actionlink detallles
        {
            var restaurante = restauranteRepostorio.ObtenerRestaurantePorId(idRestaurante);
            if (restaurante == null)
            {
                return HttpNotFound();
            }

            return View(restaurante);

        }
        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Crear(Restaurante restaurante)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            restauranteRepostorio.CrearRestaurante(restaurante);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var restaurante = restauranteRepostorio.ObtenerRestaurantePorId(id);
            return View(restaurante);
        }

        [HttpPost]

        public ActionResult Editar(Restaurante restauranteEditado)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            restauranteRepostorio.EditarRestaurante(restauranteEditado);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Eliminar(int? id)
        {
            if (id.HasValue)
            {

                //Cualquiera de las dos formas funciona
                //Si lo hacemos de esta forma tenemos que declarar la propeidad REstaurante para poder usarla 
                //De lo contrario se haria como todo lo comentado


                Restaurante = restauranteRepostorio.ObtenerRestaurantePorId(id.Value);
                //var restaurante = restauranteRepostorio.ObtenerRestaurantePorId(id.Value);
                //return View(restaurante);

            }
            else
            {
               Restaurante = new Restaurante();
               //Restaurante restaurante = new Restaurante();
               //return View(restaurante);
            }
            
            return View(Restaurante);
        }

        [HttpPost]

        public ActionResult Eliminar(int id)
        {
            //Restaurante restaurante = restauranteRepostorio.EliminarRestaurante(id);
            Restaurante = restauranteRepostorio.EliminarRestaurante(id);
            return RedirectToAction("Index");
        }




    }
}