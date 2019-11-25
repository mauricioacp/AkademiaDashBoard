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

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime FechaNacimiento { get; set; }
        [Display(Name = "Cloud: Carpeta Principal")]
        public string CloudCarpetaPrincipal { get; set; }//Carpeta Principal
        [Required(ErrorMessage = "Introduzca la Edición Actual de su Delegación")]
        public int Edicion { get; set; }
        public ColaboradoresTalleres ColaboradoresTalleres { get; set; }
        public List<Sesiones> Sesiones { get; set; }
        public Akademia Akademia { get; set; }
        [Display(Name = "Tipo:" +
            "\n-Facilitador"+
            "\n-Acompañante"+
            "\n-Ambos")]
        public string TipoColaborador { get; set; }
        public string Entrevista { get; set; }
        public List<BusquedaAcompañantes> BusquedaAcompañantes { get; set; }
        public List<BusquedaFacilitadores> BusquedaFacilitadores { get; set; }
    }
}
