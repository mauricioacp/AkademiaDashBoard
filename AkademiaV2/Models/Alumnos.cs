using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Models
{
    public class Alumnos
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Apellidos { get; set; }
        public string Imagen { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Telefono { get; set; }
        public string CartaMotivacional { get; set; }
        [Display(Name = "Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        public string Comentarios { get; set; }
        [Required(ErrorMessage = "Introduzca la Edición Actual de su Delegación")]
        public int Edicion { get; set; }
        public List<AlumnosTalleres> AlumnosTalleres { get; set; }
        public List<Sesiones> Sesiones { get; set; }
        public int AkademiaId { get; set; }
        public Akademia Akademia { get; set; }
        [Display(Name = "Cloud Link: Entrevista")]
        public string Entrevista { get; set; }
        public int ColaboradorId { get; set; }
        public Colaboradores Colaborador { get; set; }
    }
}
