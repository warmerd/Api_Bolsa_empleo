using System;
using System.Collections.Generic;

#nullable disable

namespace Api_Bolsa_empleo.Entities
{
    public partial class Operacione
    {
        public Operacione()
        {
            Permisos = new HashSet<Permiso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? IdAcceso { get; set; }

        public virtual Acceso IdAccesoNavigation { get; set; }
        public virtual ICollection<Permiso> Permisos { get; set; }
    }
}
