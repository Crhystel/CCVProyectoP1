using System.ComponentModel.DataAnnotations.Schema;

namespace CCVProyectoP1.Models
{
    public class Profesor
    {
        public Usuario? Usuario { get; set; }
        public int IdUsuario { get; set; }
        public Materia? Materia { get; set; }
        [ForeignKey(nameof(Materia))]
        public int IdMateria { get; set; }
    }
}
