using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoFW.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DemoFW.Controllers.Tests {
    [TestClass()]
    public class HomeControllerTests {
        [TestMethod()]
        public void IndexTest() {
            Assert.Fail();
        }

        [TestMethod()]
        public void AboutTest() {
            //var c = new HomeController();

            //ViewResult rslt = c.About() as ViewResult;

            //Assert.AreEqual("Your application description page.", rslt.ViewBag.Message);
            //Assert.AreEqual("About", rslt.ViewName);
        }

        [TestMethod()]
        public void ContactTest() {
            Assert.Fail();
        }
    }
}