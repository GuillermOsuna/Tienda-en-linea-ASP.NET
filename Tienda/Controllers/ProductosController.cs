using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tienda.Areas.Admin.Models;
using Tienda.Models;

namespace Tienda.Controllers
{
    public class ProductosController : Controller
    {
        private TiendaenlineaDbContext db = new TiendaenlineaDbContext();

        // GET: Productos
        public ActionResult Index()
        {
            return View(db.Productos.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoModels productoModels = db.Productos.Find(id);
            if (productoModels == null)
            {
                return HttpNotFound();
            }
            return View(productoModels);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            var prod = new AdminProductoModels();
            return View(prod);
        }

        // POST: Productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductoId,Descripcion,Nombre,Foto,Precio")]ProductoModels productoModels, HttpPostedFile foto)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(productoModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productoModels);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoModels productoModels = db.Productos.Find(id);
            if (productoModels == null)
            {
                return HttpNotFound();
            }
            return View(productoModels);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductoId,Descripcion,Nombre,Foto,Precio")] ProductoModels productoModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productoModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productoModels);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoModels productoModels = db.Productos.Find(id);
            if (productoModels == null)
            {
                return HttpNotFound();
            }
            return View(productoModels);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductoModels productoModels = db.Productos.Find(id);
            db.Productos.Remove(productoModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
