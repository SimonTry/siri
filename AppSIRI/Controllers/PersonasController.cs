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
    public class PersonasController : Controller
    {
        // GET: Personas
        public ActionResult Personas()
        {
            List<PersonasModel> personas = null;
            using (ApplicationDbContext objContext = new ApplicationDbContext())
            {
                personas = objContext.Personas.ToList();
            }
            return View(personas);
        }

        // GET: Personas/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }


        public ActionResult Create()
        {
            List<ApplicationUser> usuarios = null;
            using(ApplicationDbContext context = new ApplicationDbContext())
            {
                usuarios = context.Users.ToList();
            }

            ViewBag.usuarios = usuarios;
            return View();
        }

        // POST: Personas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User, identification, firstName, secondName, firstLastName, secondLastName")] PersonasModel personas)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                if (!ModelState.IsValid)
                    return View(personas);

                try
                {
                    context.Personas.Add(personas);
                    context.SaveChanges();
                    return RedirectToAction("Personas");
                }
                catch (Exception err)
                {
                    ModelState.AddModelError("", err.Message);
                    return View(personas);
                }
            }

        }

        // GET: Personas/Edit/5
        public ActionResult EditPersona(string id)
        {
            PersonasModel persona = null;
            if (id == null)
                return RedirectToAction("Index");
            else
            {
                Guid auxId = Guid.Parse(id);
                List<ApplicationUser> usuarios = null;
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    usuarios = context.Users.ToList();
                    persona = context.Personas.Find(auxId);
                }

                ViewBag.usuarios = usuarios;
                return View(persona);
            }
            
        }

        // POST: Personas/Edit/5
        [HttpPost]
        public ActionResult EditPersona([Bind(Include = "Id, identification, firstName, secondName, firstLastName, secondLastName")] PersonasModel personas)
        {
            using(ApplicationDbContext context = new ApplicationDbContext())
            {
                if (!ModelState.IsValid)
                    return View(personas);

                try
                {
                    context.Entry(personas).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Personas");
                }
                catch (Exception err)
                {
                    ModelState.AddModelError("", err.Message);
                    return View(personas);
                }
            }
        }

        // GET: Personas/Delete/5
        public ActionResult changeStatus(string id)
        {
            return View();
        }

        // POST: Personas/Delete/5
        [HttpPost]
        public ActionResult changeStatus(Guid id)
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
