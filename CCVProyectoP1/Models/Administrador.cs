using System.ComponentModel.DataAnnotations;

namespace CCVProyectoP1.Models
{
    public class Administrador 
    {
        [Key]
        public int Id { get; set; }
        public string Usuario { get; set; }
        
        public string Contrasenia { get; set; }
        public Administrador() {
            Usuario = "admin";
            Contrasenia = "admin";
        }
    }
}
