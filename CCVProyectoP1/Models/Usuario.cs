﻿using System.ComponentModel.DataAnnotations;

namespace CCVProyecto1._1.Models
{
    public enum RolEnum
    {
        Administrador,
        Estudiante,
        Profesor
    }
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Range(1000000000, 9999999999, ErrorMessage = "Cédula inválida")]
        public long Cedula { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Display(Name = "Usuario")]
        [MaxLength(150)]
        public string NombreUsuario { get; set; }
        [Display(Name = "Contraseña")]
        [StringLength(10, ErrorMessage = "Formato de contraseña erronea")]
        public string Contrasenia { get; set; }
        [Range(0, 100)]
        public int Edad { get; set; }
        [Required]
        public RolEnum Rol {  get; set; }
    }
}
