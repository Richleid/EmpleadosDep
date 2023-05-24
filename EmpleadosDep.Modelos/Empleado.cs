using System.ComponentModel.DataAnnotations;

namespace EmpleadosDep.Modelos
{
    public class Empleado
    {
        [Key]
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Salario { get; set; }

        //Relación 
        public int DepartamentoId { get; set; } //Fk
        public Departamento? Departamento { get; set; }
    }
}