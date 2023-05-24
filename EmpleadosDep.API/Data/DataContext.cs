using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmpleadosDep.Modelos;

    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<EmpleadosDep.Modelos.Departamento> Departamentos { get; set; } = default!;

        public DbSet<EmpleadosDep.Modelos.Empleado>? Empleados { get; set; }
    }
