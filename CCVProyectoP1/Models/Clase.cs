﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CCVProyectoP1.Models;

namespace CCVProyecto1._1.Models
{
    public class Clase
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public Profesor? Profesor { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [ForeignKey(nameof(Profesor))]
        public int? IdProfesor { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public List<Estudiante>? Estudiante { get; set; }
        
    }
}
