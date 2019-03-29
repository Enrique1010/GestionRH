using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionRH.Models
{
    public partial class MantenimientoEmpleado
    {
      

        public int Id { get; set; }
        [Required(ErrorMessage = "El codigo del Empleado es Requerido")]
        [DataType(DataType.Text)]
        public int CodigoEmpleado { get; set; }
        [Required(ErrorMessage = "El Nombre del Empleado es Requerido")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Apellido del Empleado es Requerido")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "EL Numero de telefono es requerio")]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El Departamento al que pertenece el Empleado es Requerido")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Departamento { get; set; }
        [Required(ErrorMessage = "La Fecha de Ingreso del Empleado es Requerida")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime FechaIngreso { get; set; }
        [Required(ErrorMessage = "El Sueldo a Ganar del Empleado es Requerido")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:#.##RD$}", ApplyFormatInEditMode = false)]
        public double Salario { get; set; }
        [Required(ErrorMessage = "El Estatus debe estar seleccionado")]
        public bool Estatus { get; set; }
        [Required(ErrorMessage = "El cargo del Empleado es Requerido")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Cargo { get; set; }

 
    }

}
