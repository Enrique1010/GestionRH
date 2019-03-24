using System;
using System.Collections.Generic;

namespace GestionRH.Models
{
    public partial class ProcessSalidaEmpleado
    {
        public string Empleado { get; set; }
        public string TipoDeSalida { get; set; }
        public string Motivo { get; set; }
        public DateTime Fecha { get; set; }
        public int Id { get; set; }
    }
}
