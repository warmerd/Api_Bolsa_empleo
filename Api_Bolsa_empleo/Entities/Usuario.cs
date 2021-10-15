using System;
using System.Collections.Generic;

#nullable disable

namespace Api_Bolsa_empleo.Entities
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public int? IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
    }
}
