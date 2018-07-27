using System;
using System.Collections.Generic;

namespace EventsManager.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
            Ubicacion = new HashSet<Ubicacion>();
        }

        public int Idprovincia { get; set; }
        public string Nombre { get; set; }

        public ICollection<Ubicacion> Ubicacion { get; set; }
    }
}
