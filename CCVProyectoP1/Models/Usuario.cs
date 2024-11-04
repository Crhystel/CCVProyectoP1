using System.ComponentModel.DataAnnotations;

namespace CCVProyectoP1.Models
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
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Range(1000000000, 9999999999, ErrorMessage = "Cédula inválida")]
        public long Cedula { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Usuario")]
        [MaxLength(150)]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Contraseña")]
        [StringLength(10)]
        public string Contrasenia { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Range(10, 100, ErrorMessage ="La edad debe estar entre 10 y 100.")]
        public int Edad { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public RolEnum Rol {  get; set; }
    }
}
