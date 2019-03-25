using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionRH.Models
{
    public partial class ProcessVacaciones
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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Correspondiente { get; set; }
        [Required(ErrorMessage ="El Comentario es Requerido")]
        public string Comentario { get; set; } 
    }
}
