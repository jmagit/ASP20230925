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

        public ActionResult Listados(string idioma = "es", int año = 2000) {
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
        public ActionResult About() {
            ViewBag.Message = "Desde demos.";

            return View("../Home/About");
        }

        [ChildActionOnly]
        public ActionResult ParteDeLaVista() {
            ViewBag.Message = "Desde la parte de la vista.";

            return PartialView("_parte");
        }

        protected override void OnException(ExceptionContext filterContext) {
            filterContext.Result = new ViewResult() {
                ViewName = "Error"
            };
            filterContext.ExceptionHandled = true;
            //base.OnException(filterContext);
        }
    }
}