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
    
    public partial class G_C_Roles
    {
        public G_C_Roles()
        {
            this.G_D_Empresa_Roles = new HashSet<G_D_Empresa_Roles>();
            this.G_D_Usuario_Roles = new HashSet<G_D_Usuario_Roles>();
        }
    
        public int id_rol { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public System.DateTime fecha_registro { get; set; }
        public bool rol_del_sistema { get; set; }
        public string estado { get; set; }
    
        public virtual ICollection<G_D_Empresa_Roles> G_D_Empresa_Roles { get; set; }
        public virtual ICollection<G_D_Usuario_Roles> G_D_Usuario_Roles { get; set; }
    }
}
