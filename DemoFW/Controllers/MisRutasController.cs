using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoFW.Controllers
{
    [RoutePrefix("informes")]
    public class MisRutasController : Controller
    {
        [Route("{idioma}/{año}/anual")]
        public ActionResult listados(string idioma, int año) {
            ViewData["tipo"] = "anual";
            ViewData["idioma"] = idioma;
            ViewData["año"] = año;
            return View();
        }
        [Route("{idioma}/{año}/trimestral")]
        public ActionResult listados2(string idioma, int año) {
            ViewData["tipo"] = "trimestral";
            ViewData["idioma"] = idioma;
            ViewData["año"] = año;
            return View("listados");
        }
    }
}