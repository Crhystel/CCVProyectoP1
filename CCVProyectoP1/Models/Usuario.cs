using System.ComponentModel.DataAnnotations;

namespace CCVProyectoP1.Models
{
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
        [StringLength(15, MinimumLength =8, ErrorMessage ="La contraseña debe tener mínimo 8 caracteres")]
        public string Contrasenia { get; set; }
        [Range(0,100)]
        public int Edad {  get; set; }
    }
}
