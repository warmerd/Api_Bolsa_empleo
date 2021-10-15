using System;
using System.Collections.Generic;

#nullable disable

namespace Api_Bolsa_empleo.Entities
{
    public partial class Ofertum
    {
        public int Id { get; set; }
        public string Compania { get; set; }
        public string Tipo { get; set; }
        public string Logo { get; set; }
        public string Url { get; set; }
        public string Posicion { get; set; }
        public string Ubicacion { get; set; }
        public int? IdCategorias { get; set; }
        public string Email { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Categoria IdCategoriasNavigation { get; set; }
    }
}
