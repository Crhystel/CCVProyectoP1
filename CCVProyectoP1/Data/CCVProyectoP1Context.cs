using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CCVProyectoP1.Models;

namespace CCVProyectoP1.Data
{
    public class CCVProyectoP1Context : DbContext
    {
        public CCVProyectoP1Context (DbContextOptions<CCVProyectoP1Context> options)
            : base(options)
        {
        }

        public DbSet<CCVProyectoP1.Models.Administrador> Administrador { get; set; } = default!;
        public DbSet<CCVProyectoP1.Models.Estudiante> Estudiante { get; set; } = default!;
        public DbSet<CCVProyectoP1.Models.Profesor> Profesor { get; set; } = default!;
        public DbSet<CCVProyectoP1.Models.Usuario> Usuarios { get; set; } = default!;
    }
}
