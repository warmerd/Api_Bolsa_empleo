using System;
using System.Collections.Generic;

#nullable disable

namespace Api_Bolsa_empleo.Entities
{
    public partial class Acceso
    {
        public Acceso()
        {
            Operaciones = new HashSet<Operacione>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Operacione> Operaciones { get; set; }
    }
}
