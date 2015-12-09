using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tienda.Areas.Admin.Models;
using Tienda.Models;

namespace Tienda.Areas.Admin.Controllers
{
         
    public class AdminProductosController : Controller
    {
        private TiendaenlineaDbContext db = new TiendaenlineaDbContext();
        // GET: Admin/AdminProductos
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {

            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductoId,Descripcion,Nombre,Foto,Precio")] ProductoModels productoModels, HttpPostedFileBase foto)
        {
            if (foto != null && foto.ContentLength > 0)
            {
                if (foto.ContentType == "image/jpeg")
                {
                    var fileName = Path.GetFileName(foto.FileName);
                    var path = Path.Combine(Server.MapPath("~/uploads"), fileName);
                    foto.SaveAs(path);
                }
            }
            if (ModelState.IsValid)
            {
                productoModels.Foto = foto.FileName;
                db.Productos.Add(productoModels);
                db.SaveChanges();
                return RedirectToAction("Agregado");
            }
            return View(productoModels);
        }
        public ActionResult Agregado()
        {

            return View();
        }

    }
}