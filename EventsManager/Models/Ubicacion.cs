using System;
using System.Collections.Generic;

namespace EventsManager.Models
{
    public partial class Ubicacion
    {
        public Ubicacion()
        {
            Evento = new HashSet<Evento>();
        }

        public int Idubicacion { get; set; }
        public int? Idevento { get; set; }
        public int? Idprovincia { get; set; }
        public int? Idcanton { get; set; }
        public int? Iddistrito { get; set; }
        public string Lugar { get; set; }

        public Canton IdcantonNavigation { get; set; }
        public Distrito IddistritoNavigation { get; set; }
        public Provincia IdprovinciaNavigation { get; set; }
        public ICollection<Evento> Evento { get; set; }
    }
}
