using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoFW.Models {
    public class Calculadora {
        public decimal suma(decimal x, decimal y) {
            return x + y;
        }
        public int divide(int x, int y) { return x / y; }
        public decimal divide(decimal x, decimal y) { return x / y; }

        public int multiplicar(int a, int b) {
            return a * b;
        }
    }
}