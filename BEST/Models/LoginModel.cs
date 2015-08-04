using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BEST.Models
{
    public class RegistroModel
    {
        public string nombre_empresa { get; set; }
        public string usuario { get; set; }
        public string correo { get; set; }

        public string contraseña { get; set; }

        public string confirmarcontraseña { get; set; }

    }
}