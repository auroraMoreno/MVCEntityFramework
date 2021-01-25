using Microsoft.EntityFrameworkCore;
using MVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEntityFramework.Data
{
    public class EmpleadoContext : DbContext
    {
        public EmpleadoContext(DbContextOptions<EmpleadoContext> options):base(options)
        {

        }

        public DbSet<Empleado> Empleados { get; set; }
    }
}
