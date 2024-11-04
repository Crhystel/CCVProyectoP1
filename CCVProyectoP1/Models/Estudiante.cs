using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCVProyectoP1.Models
{
    public class Estudiante : Usuario
    {
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Grado { get; set; }
        public ICollection<ClaseEstudiante> ClaseEstudiantes { get; set; } = new List<ClaseEstudiante>();



    }


}
