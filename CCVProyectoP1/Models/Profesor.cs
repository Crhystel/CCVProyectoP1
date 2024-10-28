using System.ComponentModel.DataAnnotations.Schema;

namespace CCVProyectoP1.Models
{
    public class Profesor
    {
        public Usuario? Usuario { get; set; }
        public int IdUsuario { get; set; }
        public string Materia {  get; set; }    
    }
}
