using System.ComponentModel.DataAnnotations;

namespace CCVProyectoP1.Models
{
    public class Materia
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
