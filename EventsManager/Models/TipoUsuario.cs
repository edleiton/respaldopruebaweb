using System;
using System.Collections.Generic;

namespace EventsManager.Models
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int Idtipo { get; set; }
        public string Descripcion { get; set; }
        public int? Estado { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
