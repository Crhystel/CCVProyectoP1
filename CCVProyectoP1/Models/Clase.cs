using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CCVProyectoP1.Models;

namespace CCVProyecto1._1.Models
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
        public ICollection<Estudiante> Estudiante { get; set; } = new List<Estudiante>();

    }
}
