namespace CCVProyectoP1.Models
{
    public class Actividad
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaEntrega { get; set; }
        public int ClaseId { get; set; }
        public Clase Clase { get; set; }

        public string NombreArchivo { get; set; } 
        public string RutaArchivo { get; set; }
    }
}
