using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CCVProyectoP1.Models;

namespace CCVProyectoP1.Models
{
    public class Clase
    {
        public enum ClaseEnum
        {
            Biologia,
            Fisica,
            Matematicas,
            Historia,
            Ciudadania,
            Filosofia,
            Quimica
        }
        [Key]
   
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name ="Clase")]
        public ClaseEnum CNombre { get; set; }
        
        public Profesor Profesor { get; set; }
        [ForeignKey(nameof(Profesor))]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Profesor")]
        public int IdProfesor { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        

        public GradoEnum Grado { get; set; }
        public ICollection<ClaseEstudiante> ClaseEstudiantes { get; set; } = new List<ClaseEstudiante>();

        public ICollection<Actividad> Actividades { get; set; } = new List<Actividad>();


    }
}
