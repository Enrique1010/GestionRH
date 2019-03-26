using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionRH.Models
{
    public partial class ProcessLicencias
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre del Empleado es Requerido")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Empleado { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Desde { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Hasta { get; set; }
        [Required(ErrorMessage = "El Comentario es Requerido")]
        public string Comentario { get; set; }
        [Required(ErrorMessage = "El Motivo es Requerido")]
        public string Motivo { get; set; }
        
    }
}
