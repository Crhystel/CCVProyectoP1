using CCVProyecto1._1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCVProyectoP1.Models
{
    public class Profesor: Usuario
    {
        public string Materia {  get; set; }    
    }
}
