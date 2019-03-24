using System;
using System.Collections.Generic;

namespace GestionRH.Models
{
    public partial class ProcessVacaciones
    {
        public string Empleado { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public DateTime Correspondiente { get; set; }
        public string Comentario { get; set; }
        public int Id { get; set; }
    }
}
