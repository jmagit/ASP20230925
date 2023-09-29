using DemoMVCCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoMVCCore.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            ViewBag.algo = "kk";
            return View();
        }

        public IActionResult Privacy() {
            ViewBag.algo = "kk";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}