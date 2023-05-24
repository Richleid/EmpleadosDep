using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadosDep.Modelos
{
    public class Departamento
    {
        [Key]
        public int DepartamentoId { get; set; } //pk
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }

        //relación
        public List<Empleado>? Empleados { get; set; }

    }
}
