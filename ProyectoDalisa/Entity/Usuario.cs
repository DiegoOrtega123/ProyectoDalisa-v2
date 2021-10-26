using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoDalisa.Entity
{
    public class Usuario
    {
        public string idUsuario { get; set; }
        public string Pais { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string FechaNac { get; set; }
        public string EstadoCiv { get; set; }
        public string sexo { get; set; }
        public string Dni { get; set; }
        public string Direccion { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string Celuar { get; set; }
        public string Correo { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Cuenta { get; set; }
        public Banco Banc { get; set; }
        public string foto { get; set; }
        public string fechaReg { get; set; }

    }
}