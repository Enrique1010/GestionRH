using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionRH.Models
{
    public partial class ProcessNominas
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}")]
        public DateTime Age { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM}")]
        public DateTime Mes { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:#.##RD$}", ApplyFormatInEditMode = false)]
        public double MontoTotal { get; set; }
    }
}
