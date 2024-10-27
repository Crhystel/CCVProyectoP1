using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCVProyectoP1.Models
{
    public class Clase
    {
        [Key]
        public int Id { get; set; }
        public Profesor? Profesor  { get; set; }
        [ForeignKey(nameof(Profesor))]
        public int IdProfesor { get; set; }
        public Estudiante? Estudiante { get; set; }
        [ForeignKey(nameof(Estudiante))]
        public int IdEstudiante { get; set; }
    }
}
