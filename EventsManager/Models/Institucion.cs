using System;
using System.Collections.Generic;

namespace EventsManager.Models
{
    public partial class Institucion
    {
        public Institucion()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int Idinstitucion { get; set; }
        public string Descripcion { get; set; }
        public int? Estado { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
