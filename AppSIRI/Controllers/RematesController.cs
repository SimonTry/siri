using AppSIRI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppSIRI.Controllers
{
    [Authorize]
    public class RematesController : Controller
    {
        // GET: Remates
        public ActionResult Remates()
        {
            List<RematesModel> remates = null;
            using (ApplicationDbContext objContext = new ApplicationDbContext())
            {
                remates = objContext.Remates.ToList();
                
            }
            return View(remates);
        }
        public ActionResult Create()
        {
            List<ProductosModel> productos = null;
            using(ApplicationDbContext context = new ApplicationDbContext())
            {
                productos = context.Productos.ToList();
            }
            ViewBag.productos = productos;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "productoId, fechaInicio, fechaFin, precioBase, descripcionRemate")] RematesModel remates)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                if (!ModelState.IsValid)
                    return View(remates);

                try
                {
                    context.Remates.Add(remates);
                    context.SaveChanges();
                    return RedirectToAction("Remates");
                }
                catch (Exception err)
                {
                    ModelState.AddModelError("", err.Message);
                    return View(remates);
                }
            }
        }
        public ActionResult EditRemate(string id)
        {
            List<ProductosModel> productos = null;
            RematesModel remates = null;
            ProductosModel productoSeleccionado = null;
            if (id == null)
                return RedirectToAction("Remates");
            else
            {
                Guid auxId = Guid.Parse(id);
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    remates = context.Remates.Find(auxId);
                    productoSeleccionado = context.Productos.Find(remates.productoId);
                    productos = context.Productos.ToList();
                }
                ViewBag.productos = productos;
                ViewBag.productoSeleccionado = productoSeleccionado;
                return View(remates);
            }
        }

        [HttpPost]
        public ActionResult EditRemate([Bind(Include = "RemateId, productoId, fechaInicio, fechaFin, precioBase, descripcionRemate")] RematesModel remates)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                if (!ModelState.IsValid)
                    return RedirectToAction("Remates");
                try
                {
                    context.Entry(remates).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Remates");
                }
                catch (Exception err)
                {
                    ModelState.AddModelError("", err.Message);
                    return View(remates);
                }
            }
        }
    }
}