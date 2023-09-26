using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoFW.Controllers {
    public class DemosController : Controller {
        // GET: Demos
        public ActionResult Index(int? id, string nom = "<b>mundo</b>") {
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
        // GET: Demos/class
        [ActionName("class")]
        public ActionResult clase(int? id, string nom = "mundo") {
            return privado();
        }

        [NonAction]
        public ActionResult privado() {
            return View("Adios");
        }
        [HttpPost]
        public ActionResult json(int? id, string nom = "mundo") {
            ViewData["nombre"] = nom;
            ViewBag.despide = id > 0;
            ViewBag.lista = new string[] { "uno", "dos", "tres" };
            return this.Json(ViewData);
        }

        public ActionResult listados(string idioma, int año) {
            //try {
            //int i = año / 0;
            //} catch {
            //    //return new HttpStatusCodeResult(400, "Fuera de rango");
            //}
            if(año < 2000)
                throw new InvalidDataException("Fuera de rango");
            ViewData["idioma"] = idioma;
            ViewData["año"] = año;
            return View();
        }

        protected override void OnException(ExceptionContext filterContext) {
            base.OnException(filterContext);
        }
    }
}