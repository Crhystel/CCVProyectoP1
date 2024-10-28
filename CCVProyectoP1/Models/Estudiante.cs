using System.ComponentModel.DataAnnotations.Schema;

namespace CCVProyectoP1.Models
{
    public class Estudiante
    {
        public Usuario? Usuario { get; set; }
        [ForeignKey(nameof(Usuario))]
        public int IdUsuario { get; set; }
        public string Grado { get; set; }
    }
}
