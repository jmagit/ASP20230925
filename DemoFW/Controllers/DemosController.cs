using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoFW.Controllers
{
    public class DemosController : Controller
    {
        // GET: Demos
        public ActionResult Index(int? id, string nom = "mundo")
        {
            ViewData["nombre"] = nom;
            ViewBag.despide = id > 0;
            ViewBag.lista = new string[] { "uno", "dos", "tres" };
            if(ViewBag.despide) {
                //return View("Adios");
                // return this.HttpNotFound();
                return this.Json(ViewData);
            }
            return View();
        }
    }
}