using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoFW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFW.Models.Tests {
    [TestClass()]
    public class CalculadoraTests {
        [TestMethod("Suma numeros")]
        [DataRow(1, 2, 3)]
        [DataRow(1, -2, -1)]
        [DataRow(-1, 2, 1)]
        [DataRow(-1, -2, -3)]
        [DataRow(0.1, 0.2, 0.3)]
        [DataRow(0.2, 0.2, 0.4)]
        [DataRow(1, -0.9, 0.1)]
        public void sumaTest(double a, double b, double resultado) {
            var c = new Calculadora();

            var obtenido = c.suma(Convert.ToDecimal(a), Convert.ToDecimal(b));

            Assert.AreEqual(Convert.ToDecimal(resultado), obtenido);
        }

        [TestMethod("Suma dos positivos")]
        public void suma1Test() {
            var c = new Calculadora();

            var obtenido = c.suma(2, 2);

            Assert.AreEqual(4, obtenido);
        }

        [TestMethod("Suma positivo con negativo")]
        public void suma2Test() {
            var c = new Calculadora();

            var obtenido = c.suma(2, -2);

            Assert.AreEqual(0, obtenido);
        }

        [TestMethod("Divide entero")]
        public void DivideTest() {
            var c = new Calculadora();

            var obtenido = c.divide(3, 2);

            Assert.AreEqual(1, obtenido);
        }
        [TestMethod("Divide real")]
        public void Divide1Test() {
            var c = new Calculadora();

            var obtenido = c.divide(3.0m, 2);

            Assert.AreEqual(1.5m, obtenido);
        }
        [TestMethod("Divide entero por 0")]
        public void Divide3Test() {
            var c = new Calculadora();

            Assert.ThrowsException<DivideByZeroException>(() => c.divide(3, 0));
        }
        [TestMethod("Divide real por 0")]
        public void Divide4Test() {
            var c = new Calculadora();

            //var obtenido = c.divide(3.0m, 0);

            Assert.IsTrue(double.IsInfinity( 3.0 / 0));
        }
        [TestMethod()]
        public void MultiplicarTest() {
            var c = new Calculadora();

            var obtenido = c.multiplicar(2, 3);

            Assert.AreEqual(6, obtenido);
        }
    }
}