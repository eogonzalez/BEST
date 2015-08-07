using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BEST.Models
{
    public class LoginModel
    {
        public G_C_Empresa M_empresa { get; set; }

        public G_C_Usuario M_usuario { get; set; }

        public G_D_Usuario_Password M_usuario_password { get; set; }
        
        [DisplayName("Confirmar Contraseña")]
        [DataType(DataType.Password)]
        public string confirmarcontraseña { get; set; }

        //public G_D_Usuario_Roles M_usuario_roles { get; set; }
        //public G_D_Usuario_Acceso M_usuario_acceso { get; set; }
    }
}