using System;
using System.Collections.Generic;

namespace EventsManager.Models
{
    public partial class TipoEvento
    {
        public TipoEvento()
        {
            Evento = new HashSet<Evento>();
            Tema = new HashSet<Tema>();
        }

        public int IdtipoEvento { get; set; }
        public string Descripcion { get; set; }
        public int? Estado { get; set; }

        public ICollection<Evento> Evento { get; set; }
        public ICollection<Tema> Tema { get; set; }
    }
}
