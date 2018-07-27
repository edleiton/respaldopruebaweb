using System;
using System.Collections.Generic;

namespace EventsManager.Models
{
    public partial class Contacto
    {
        public int Idcontacto { get; set; }
        public int? TipoContacto { get; set; }
        public string Identificador { get; set; }
        public int? Idusuario { get; set; }

        public Usuario IdusuarioNavigation { get; set; }
    }
}
