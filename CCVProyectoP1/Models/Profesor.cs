
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCVProyectoP1.Models
{
    public class Profesor: Usuario
    {
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Materia {  get; set; }    
    }
}
