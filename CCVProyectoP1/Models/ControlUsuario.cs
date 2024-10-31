using System.ComponentModel.DataAnnotations;

namespace CCVProyecto1._1.Models
{
    public struct ControlUsuarios
    {
        public class Login
        {
            [Display(Name = "Nombre Usuario")]
            public string? NombreUsuario { get; set; }
            [Display(Name = "Contraseña")]
            public string? Contrasenia { get; set; }

        }
    }
}
