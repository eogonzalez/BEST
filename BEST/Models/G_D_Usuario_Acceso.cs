//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BEST.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class G_D_Usuario_Acceso
    {
        public long id_usuario_acceso { get; set; }
        public int id_empresa { get; set; }
        public int id_usuario { get; set; }
        public System.DateTime fecha_registro { get; set; }
        public string ip { get; set; }
    
        public virtual G_C_Usuario G_C_Usuario { get; set; }
    }
}
