﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CCVProyectoP1.Models;
using CCVProyecto1._1.Models;

namespace CCVProyectoP1.Data
{
    public class CCVProyectoP1Context : DbContext
    {
        public CCVProyectoP1Context (DbContextOptions<CCVProyectoP1Context> options)
            : base(options)
        {
        }
        public DbSet<CCVProyecto1._1.Models.Administrador> Administrador { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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
        
            

        
        public DbSet<CCVProyectoP1.Models.Profesor> Profesor { get; set; } = default!;
        public DbSet<CCVProyecto1._1.Models.Estudiante> Estudiante { get; set; } = default!;
        //public DbSet<CCVProyectoP1.Models.Profesor> Profesor { get; set; } = default!;
        //public DbSet<CCVProyectoP1.Models.Usuario> Usuarios { get; set; } = default!;
    }
}
