using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Models
{
    public class Colaboradores
    {
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Required]
        public string Nombre { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Apellidos { get; set; }
        public string Imagen { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefono { get; set; }
        public string CartaMotivacional { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Comentarios { get; set; }
        [Required(ErrorMessage = "Introduzca la Edición Actual de su Delegación")]
        public int Edicion { get; set; }
        public List<ColaboradoresTalleres> ColaboradoresTalleres { get; set; }
        public List<Sesiones> Sesiones { get; set; }
        public Akademia Akademia { get; set; }
        public string TipoColaborador { get; set; }
    }
}
