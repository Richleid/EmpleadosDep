using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmpleadosDep.Modelos;

namespace EmpleadosDep.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BLController : ControllerBase
    {
        private readonly DataContext _context;

        public BLController(DataContext context)
        {
            _context = context;
        }

        // GET: api/BL/SumaSalarios
        [Route("/SumaSalarios")]
        [HttpGet]
        public ActionResult<int> SumaSalarios()
        {
            if (_context.Empleados == null)
            {
                return NotFound();
            }
            return _context.Empleados.Sum(e => e.Salario);
        }

        // GET: api/BL/promedio
        [Route("/PromedioSalarios")]
        [HttpGet]
        public ActionResult<double> PromedioSalarios()
        {
            if (_context.Empleados == null)
            {
                return NotFound();
            }
            return _context.Empleados.Average(e => e.Salario);
        }

        // GET: api/BL/NumeroEmpleadosPorDepartamento
        [Route("/NumeroEmpleadosPorDepartamento")]
        [HttpGet]
        public ActionResult<Dictionary<string, int>> NumeroEmpleadosPorDepartamento()
        {
            if (_context.Departamentos == null || _context.Empleados == null)
            {
                return NotFound();
            }

            Dictionary<string, int> empleadosPorDepartamento = new Dictionary<string, int>();

            foreach (var departamento in _context.Departamentos)
            {
                int count = _context.Empleados.Count(d => d.DepartamentoId == departamento.DepartamentoId);
                empleadosPorDepartamento.Add(departamento.Nombre, count);
            }

            return empleadosPorDepartamento;
        }

    }
}
