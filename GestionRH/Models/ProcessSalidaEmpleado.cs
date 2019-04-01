using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionRH.Models
{
    public partial class ProcessSalidaEmpleado
    {
        [Required(ErrorMessage = "Eliga un empleado")]
        public string Empleado { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string TipoDeSalida { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Motivo { get; set; }
        [Required(ErrorMessage = "Fecha obligatoria")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public int Id { get; set; }
    }
}
