using System;
using System.Collections.Generic;

namespace GestionRH.Models
{
    public partial class MantenimientoDepartamento
    {
        public int Id { get; set; }
        public int CodigoDepartamento { get; set; }
        public string Nombre { get; set; }
    }
}
