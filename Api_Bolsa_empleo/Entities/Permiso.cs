using System;
using System.Collections.Generic;

#nullable disable

namespace Api_Bolsa_empleo.Entities
{
    public partial class Permiso
    {
        public int Id { get; set; }
        public int? IdRol { get; set; }
        public int? IdOperaciones { get; set; }

        public virtual Operacione IdOperacionesNavigation { get; set; }
        public virtual Rol IdRolNavigation { get; set; }
    }
}
