using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CCVProyectoP1.Models;

namespace CCVProyectoP1.Models
{
    public class Clase
    {
        [Key]
   
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Nombre { get; set; }
        
        public Profesor Profesor { get; set; }
        [ForeignKey(nameof(Profesor))]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int IdProfesor { get; set; }
        public ICollection<ClaseEstudiante> ClaseEstudiantes { get; set; } = new List<ClaseEstudiante>();



    }
}
