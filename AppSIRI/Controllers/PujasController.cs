using AppSIRI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace AppSIRI.Controllers
{
    public class PujasController : Controller
    {
        // GET: Pujas
        public ActionResult PujasRemate(string Id)
        {
            Guid auxId = Guid.Parse(Id);

            using (ApplicationDbContext objContext = new ApplicationDbContext())
            {
                var pujas = (from p in objContext.Pujas
                             where p.RemateIdFk == auxId
                             select p).ToList();
                ViewBag.puja = pujas;
            }

            return View();
        }

        // GET: Pujas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pujas/Creat
        public ActionResult Create(string id)
        {
            Guid auxId = Guid.Parse(id);
            ViewBag.UserId = User.Identity.GetUserId();
            ViewBag.RemateId = auxId;
            return View();
        }

        // POST: Pujas/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "UserIdFk, RemateIdFk, valorPuja")]RematePorUsuarioModel pujas)
        {
            if (!ModelState.IsValid)
                return View(pujas);
            using (ApplicationDbContext objContext = new ApplicationDbContext())
            {
                try
                {
                    objContext.Pujas.Add(pujas);
                    objContext.SaveChanges();
                    return RedirectToAction("Remates", "Remates");
                }
                catch (Exception err)
                {
                    ModelState.AddModelError("", err.Message);
                    return View(pujas);
                }
            }
        }

        // GET: Pujas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pujas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pujas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pujas/Delete/5
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
