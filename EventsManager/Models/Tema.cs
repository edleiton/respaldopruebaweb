using System;
using System.Collections.Generic;

namespace EventsManager.Models
{
    public partial class Tema
    {
        public Tema()
        {
            Evento = new HashSet<Evento>();
        }

        public int Idtema { get; set; }
        public int? Idtipo { get; set; }
        public string Descripcion { get; set; }

        public TipoEvento IdtipoNavigation { get; set; }
        public ICollection<Evento> Evento { get; set; }
    }
}
