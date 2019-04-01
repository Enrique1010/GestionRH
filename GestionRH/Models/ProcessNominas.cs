using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionRH.Models
{
    public partial class ProcessNominas
    {
        public int Id { get; set; }
        [Required]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public int Age { get; set; }
        [Required]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy}")]
        public int Mes { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:#.##RD$}", ApplyFormatInEditMode = false)]
        public double MontoTotal { get; set; }
    }
}
