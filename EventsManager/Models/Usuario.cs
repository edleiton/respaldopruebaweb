using System;
using System.Collections.Generic;

namespace EventsManager.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Calificacion = new HashSet<Calificacion>();
            Contacto = new HashSet<Contacto>();
            Evento = new HashSet<Evento>();
            Reserva = new HashSet<Reserva>();
        }

        public int Idusuario { get; set; }
        public int? Idtipo { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Usuario1 { get; set; }
        public string Clave { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? Estado { get; set; }
        public int? Idinstitucion { get; set; }
        public int? Idnivel { get; set; }

        public Institucion IdinstitucionNavigation { get; set; }
        public NivelAcademico IdnivelNavigation { get; set; }
        public TipoUsuario IdtipoNavigation { get; set; }
        public ICollection<Calificacion> Calificacion { get; set; }
        public ICollection<Contacto> Contacto { get; set; }
        public ICollection<Evento> Evento { get; set; }
        public ICollection<Reserva> Reserva { get; set; }
    }
}
