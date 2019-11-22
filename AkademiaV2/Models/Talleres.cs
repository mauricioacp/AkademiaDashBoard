using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Models
{
    public class Talleres
    {
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Introduzca el nombre del Taller")]
        public string Nombre { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Introduzca la Descripción del Taller")]
        public string Descripcion { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FechaTaller { get; set; }
        [Display(Name = "Cloud link: Media")]
        public string Imagen { get; set; }
        [Display(Name = "Cloud link: Karrusel")]
        public string Karrusel { get; set; }
        [Required(ErrorMessage = "Introduzca la Edición Actual de su Delegación")]
        public int Edicion { get; set; }
        public string Evaluaciones { get; set; }
        [Display(Name = "Cloud Link: Carpeta Principal")]
        public string CarpetaPrincipal { get; set; }
        public List<ColaboradoresTalleres> ColaboradoresTalleres { get; set; }
        public List<AlumnosTalleres> AlumnosTalleres { get; set; }
        public Akademia Akademia { get; set; }
    }
}
