using System;
using System.Collections.Generic;

namespace EventsManager.Models
{
    public partial class Calificacion
    {
        public int Idcalifiacion { get; set; }
        public int? Idevento { get; set; }
        public int? Idusuario { get; set; }
        public int? Calificacion1 { get; set; }
        public string Comentario { get; set; }

        public Evento IdeventoNavigation { get; set; }
        public Usuario IdusuarioNavigation { get; set; }
    }
}
