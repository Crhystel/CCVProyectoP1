using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCVProyecto1._1.Models
{
    public class Estudiante : Usuario
    {
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Grado { get; set; }
        public List<Clase>? Clase { get; set; }

    }

    
}
