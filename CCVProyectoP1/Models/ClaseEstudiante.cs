
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CCVProyectoP1.Models
{
    public class ClaseEstudiante
    {
    
        
        public int ClaseId { get; set; }
        
        public Clase Clase { get; set; }
        public int EstudianteId { get; set; }
      
        public Estudiante Estudiante { get; set; }
      
    }
   
}
