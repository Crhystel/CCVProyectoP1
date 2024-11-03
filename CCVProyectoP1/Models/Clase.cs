using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CCVProyectoP1.Models;

namespace CCVProyecto1._1.Models
{
    public class Clase
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Profesor? Profesor { get; set; }
        [ForeignKey(nameof(Profesor))]
        public int? IdProfesor { get; set; }
        public List<Estudiante>? Estudiante { get; set; }
        
    }
}
