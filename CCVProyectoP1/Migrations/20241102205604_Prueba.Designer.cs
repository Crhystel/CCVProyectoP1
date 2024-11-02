﻿// <auto-generated />
using CCVProyectoP1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CCVProyectoP1.Migrations
{
    [DbContext(typeof(CCVProyectoP1Context))]
    [Migration("20241102205604_Prueba")]
    partial class Prueba
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CCVProyecto1._1.Models.Administrador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("Cedula")
                        .HasColumnType("bigint");

                    b.Property<string>("Contrasenia")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NombreUsuario")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Administrador");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cedula = 1234567890L,
                            Contrasenia = "admin",
                            Edad = 30,
                            Nombre = "Roberto",
                            NombreUsuario = "admin",
                            Rol = 0
                        });
                });

            modelBuilder.Entity("CCVProyecto1._1.Models.Clase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdProfesor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdProfesor");

                    b.ToTable("Clase");
                });

            modelBuilder.Entity("CCVProyecto1._1.Models.Estudiante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("Cedula")
                        .HasColumnType("bigint");

                    b.Property<int>("ClaseId")
                        .HasColumnType("int");

                    b.Property<string>("Contrasenia")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Grado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NombreUsuario")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClaseId");

                    b.ToTable("Estudiante");
                });

            modelBuilder.Entity("CCVProyectoP1.Models.Profesor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("Cedula")
                        .HasColumnType("bigint");

                    b.Property<string>("Contrasenia")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Materia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NombreUsuario")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Profesor");
                });

            modelBuilder.Entity("CCVProyecto1._1.Models.Clase", b =>
                {
                    b.HasOne("CCVProyectoP1.Models.Profesor", "Profesor")
                        .WithMany()
                        .HasForeignKey("IdProfesor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("CCVProyecto1._1.Models.Estudiante", b =>
                {
                    b.HasOne("CCVProyecto1._1.Models.Clase", "Clase")
                        .WithMany("Estudiante")
                        .HasForeignKey("ClaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clase");
                });

            modelBuilder.Entity("CCVProyecto1._1.Models.Clase", b =>
                {
                    b.Navigation("Estudiante");
                });
#pragma warning restore 612, 618
        }
    }
}
