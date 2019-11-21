using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Models
{
    public class Sesiones
    {
        public int Id { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Evaluacion { get; set; }
        public string Comentario { get; set; }
        [Required(ErrorMessage = "Introduzca la Edición Actual de su Delegación")]
        public int Edicion { get; set; }
        public Colaboradores Colaborador { get; set; }
        public int ColaboradorId { get; set; }
        public Alumnos Alumno { get; set; }
        public int AlumnoId { get; set; }
    }
}
