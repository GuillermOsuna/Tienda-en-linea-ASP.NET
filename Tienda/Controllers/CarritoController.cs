using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tienda.Models;

namespace Tienda.Controllers
{
    public class CarritoController : Controller
    {
        private CarritoModel carrito;
        public CarritoController() 
        {
           
        }
        private CarritoModel Carrito 
        {
            get 
            {
                var s = Session["Carrito"] as CarritoModel;
                if (s == null)
                {

                    s = new CarritoModel();
                    Session["Carrito"] = s;
                }
                return s;
            }
        }
        // GET: Carrito
        public ActionResult Index()
        {
            var carrito = Carrito;
            return View(carrito);
        }

        [HttpPost]
        public ActionResult Agregar(PartidaCarritoModel partida)
        {
            var carrito = Carrito;
            carrito.AgregarArticulo(partida);
            return RedirectToAction("Index","Productos");
        }

        [HttpPost]
        public ActionResult Quitar(PartidaCarritoModel partida)
        {
            var carrito = Carrito;
            carrito.QuitarArticulo(partida);
            return RedirectToAction("Index");
        }
        public ActionResult Comprar()
        {
            var carrito = Carrito;
            if (carrito.EstaVacio)
            {
                return RedirectToAction("Index");
            }
            //si no estoy logueado
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Register", "Account");
            }
            //si estoy logueado
           

            return View(carrito);
        }
        [HttpPost]
        public ActionResult Finalizar(bool Acepto) 
        {
            if (!Acepto) 
            {
               return RedirectToAction("Comprar");
            }
            //guardar en bd que si se hizo la compra
            //Descontar inventarios


            //Limpiar el carrito
            carrito = Carrito;
            carrito.vaciar();
            return RedirectToAction("Index", "Home");
        }
    }
}