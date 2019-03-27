using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRH.Models.ViewModel
{
    public class DepEmp
    {
        public MantenimientoEmpleado Empleado { get; set; }

        public IEnumerable<MantenimientoDepartamento> Departamento { get; set; }
    }
}
