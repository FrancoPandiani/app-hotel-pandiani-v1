
using Hotel_Pandiani.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Pandiani.Models
{
    public class HotelContext:DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Hotel_Pandiani.Models.Asistencia> Asistencia { get; set; }

    }
}
