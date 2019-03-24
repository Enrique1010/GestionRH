using System;
using System.Collections.Generic;

namespace GestionRH.Models
{
    public partial class ProcessNominas
    {
        public int Id { get; set; }
        public DateTime Age { get; set; }
        public DateTime Mes { get; set; }
        public double MontoTotal { get; set; }
    }
}
