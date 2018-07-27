using System;
using System.Collections.Generic;

namespace EventsManager.Models
{
    public partial class Evento
    {
        public Evento()
        {
            CalificacionNavigation = new HashSet<Calificacion>();
            Reserva = new HashSet<Reserva>();
        }

        public int Idevento { get; set; }
        public int? IdtipoEvento { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public int? Idexpositor { get; set; }
        public int? Idtema { get; set; }
        public int? Limite { get; set; }
        public int? Idubicacion { get; set; }
        public int? Estado { get; set; }
        public int? Calificacion { get; set; }

        public Usuario IdexpositorNavigation { get; set; }
        public Tema IdtemaNavigation { get; set; }
        public TipoEvento IdtipoEventoNavigation { get; set; }
        public Ubicacion IdubicacionNavigation { get; set; }
        public ICollection<Calificacion> CalificacionNavigation { get; set; }
        public ICollection<Reserva> Reserva { get; set; }
    }
}
