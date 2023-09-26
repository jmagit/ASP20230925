using DemoFW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoFW.Controllers
{
    public class PersonasController : Controller
    {
        // GET: Personas
        public ActionResult Index(string modo = "corto")
        {
            ViewData["operacion"] = TempData.ContainsKey("operacion") ? TempData["operacion"] : "ninguna";
            List<Persona> list = new List<Persona>();
            list.Add(new Persona { Id = 1, Nombre = "Pepito", Apellidos = "Grillo" });
            list.Add(new Persona { Id = 2, Nombre = "Carmelo", Apellidos = "Coton" });
            if(modo == "corto")
                return View(list);
            else 
                return View("List", list);
        }

        // GET: Personas/Details/5
        public ActionResult Details(int id)
        {
            return View(new Persona { Id = id, Nombre = "Pepito", Apellidos = "Grillo" });
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
        [HttpPost]
        public ActionResult Create(Persona item)
        {
            try
            {
                // TODO: Add insert logic here
                TempData["operacion"] = "Create";

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Personas/Edit/5
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

        // GET: Personas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Personas/Delete/5
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
