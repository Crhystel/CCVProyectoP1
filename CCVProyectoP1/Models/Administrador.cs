using System.ComponentModel.DataAnnotations;

namespace CCVProyecto1._1.Models
{
    public class Administrador
    {
        [Key]
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
    }
}
