using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Models
{
    public class Akademia
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Introduzca la Edición Actual de su Delegación")]
        public int Edicion { get; set; }
        [Required(ErrorMessage = "Porfavor Indtroduzca Una Ciudad"), MaxLength(40)]
        [DataType(DataType.Text)]
        public string Ciudad { get; set; }
        [Required(ErrorMessage = "Por favor, Introduzca la dirección de su delegación"), MaxLength(250)]
        [DataType(DataType.Text)]
        public string Direccion { get; set; }
        public string Imagen { get; set; }
        [Required]
        public string Email { get; set; }
        public List<Colaboradores> Colaboradores { get; set; }
        public List<Alumnos> Alumnos { get; set; }
        public List<Talleres> Talleres { get; set; }
    }
}
