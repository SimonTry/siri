using AppSIRI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace AppSIRI.Controllers
{
    [Authorize]
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Productos()
        {
            List<ProductosModel> productos = null;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                productos = context.Productos.ToList();
            }
            return View(productos);
        }

        // GET: Productos/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            List<PersonasModel> personas = null;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                personas = context.Personas.ToList();
            }
            ViewBag.personas = personas;
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombreProducto, descripcionProducto")] ProductosModel productos)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                if (!ModelState.IsValid)
                    return View(productos);

                try
                {
                    context.Productos.Add(productos);
                    context.SaveChanges();
                    return RedirectToAction("Productos");
                }
                catch (Exception err)
                {
                    ModelState.AddModelError("", err.Message);
                    return View(productos);
                }
            }
        }

        // GET: Productos/Edit/5
        public ActionResult EditProductos(string id)
        {
            ProductosModel productos = null;
            if (id == null)
                return RedirectToAction("Productos");
            else
            {
                Guid auxId = Guid.Parse(id);
                List<PersonasModel> personas = null;
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    personas = context.Personas.ToList();
                    productos = context.Productos.Find(auxId);
                }
                ViewBag.personas = personas;
                return View(productos);
            }
        }

        // POST: Productos/Edit/5
        [HttpPost]
        public ActionResult EditProductos([Bind(Include = "productoId, nombreProducto, descripcionProducto")] ProductosModel productos)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                if (!ModelState.IsValid)
                    return RedirectToAction("Productos");
                try
                {
                    context.Entry(productos).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Productos");
                }
                catch (Exception err)
                {
                    ModelState.AddModelError("", err.Message);
                    return View(productos);
                }
            }
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Productos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
