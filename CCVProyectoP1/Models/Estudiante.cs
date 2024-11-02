using System.ComponentModel.DataAnnotations.Schema;

namespace CCVProyecto1._1.Models
{
    public class Estudiante : Usuario
    {
        public string Grado { get; set; }
        public int? ClaseId { get; set; }
        [ForeignKey("ClaseId")]
        public Clase? Clase { get; set; }
        
    }

    
}
