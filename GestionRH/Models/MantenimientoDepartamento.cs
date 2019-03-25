using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionRH.Models
{
    public partial class MantenimientoDepartamento
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El codigo del Departamento es Requerido")]
        [DataType(DataType.Text)]
        public int CodigoDepartamento { get; set; }
        [Required(ErrorMessage = "El nombre del Departamento es Requerido")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
    }
}
