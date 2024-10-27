using System.ComponentModel.DataAnnotations;

namespace CCVProyectoP1.Models
{
    public class Grado
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
    }
}
