using System;
using System.Collections.Generic;

#nullable disable

namespace Api_Bolsa_empleo.Entities
{
    public partial class Categoria
    {
        public Categoria()
        {
            Oferta = new HashSet<Ofertum>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Ofertum> Oferta { get; set; }
    }
}
