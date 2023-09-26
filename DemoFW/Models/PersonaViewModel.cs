using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoFW.Models {
    public class PersonaViewModel {
        public Persona model;
        public string[] lista { get { return new string[] { "uno", "dos", "tres" }; } }
}
}