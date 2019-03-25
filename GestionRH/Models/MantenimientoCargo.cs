using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionRH.Models
{
    public partial class MantenimientoCargo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El codigo del Empleado es Requerido")]
        [DataType(DataType.Text)]
        public int CodigoCargo { get; set; }
        [Required(ErrorMessage = "El codigo del Empleado es Requerido")]
        [DataType(DataType.Text)]
        public string NombreCargo { get; set; }
    }
}
