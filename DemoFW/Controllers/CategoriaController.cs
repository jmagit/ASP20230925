﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace DemoFW.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            ViewBag.page = 0;
            ViewBag.size = 3;
            ViewBag.numPages = 2;
            return View();
        }
    }
}