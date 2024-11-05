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
        [StringLength(10, MinimumLength = 10, ErrorMessage = "La cédula debe tener exactamente 10 dígitos.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "La cédula debe contener solo números.")]
        public string Cedula { get; set; }
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
