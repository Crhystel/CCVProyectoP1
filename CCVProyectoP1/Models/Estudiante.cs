using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCVProyectoP1.Models
{
    public enum GradoEnum
    {
        [Display(Name = "1ro Bachillerato BGU")]
        PrimerBachilleratoBGU,
        [Display(Name = "2do Bachillerato BGU")]
        SegundoBachilleratoBGU,
        [Display(Name = "3ro Bachillerato BGU")]
        TerceroBachilleratoBGU

    }
    public class Estudiante : Usuario
    {
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public GradoEnum Grado { get; set; }
        public ICollection<ClaseEstudiante> ClaseEstudiantes { get; set; } = new List<ClaseEstudiante>();



    }


}
