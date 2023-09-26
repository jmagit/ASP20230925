using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoFW.Models {
    public class Persona {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime? fechaNacimiento { get; set; }
        public Boolean activo { get; set; } = true;
        public DateTime? fechaBaja { get; set; }

        public string DameNombre() { return $"{Apellidos}, {Nombre}"; }

        public void Jubilate() {
            activo = false;
            fechaBaja = DateTime.Now;
        }


    }
}