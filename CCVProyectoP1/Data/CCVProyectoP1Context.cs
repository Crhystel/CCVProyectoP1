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

        public DbSet<CCVProyectoP1.Models.Profesor> Profesor { get; set; } 
        public DbSet<CCVProyectoP1.Models.Estudiante>Estudiante { get; set; }

        public DbSet<CCVProyectoP1.Models.Clase> Clase { get; set; }
        public DbSet<CCVProyectoP1.Models.ClaseEstudiante> ClaseEstudiante { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ClaseEstudiante>()
                .HasKey(c => new { c.ClaseId, c.EstudianteId });
            //Tabla intermedia para hacer la relacion muchos a muchos

            modelBuilder.Entity<ClaseEstudiante>()
                .HasOne(c => c.Clase)
                .WithMany(c => c.ClaseEstudiantes)
                .HasForeignKey(c => c.ClaseId);
            modelBuilder.Entity<ClaseEstudiante>()
                .HasOne(c => c.Estudiante)
                .WithMany(c => c.ClaseEstudiantes)
                .HasForeignKey(c => c.EstudianteId);
          


            modelBuilder.Entity<Administrador>().HasData(new Administrador
            {
                Id = 1,
                Cedula = 1234567890,
                Nombre = "Roberto",
                NombreUsuario = "admin",
                Contrasenia = "admin",
                Edad = 30,
                Rol = RolEnum.Administrador,
            });




        }
    }
}
