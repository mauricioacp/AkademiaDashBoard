using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Models.ViewModels
{
    public class Sesiones_Alumnos_Colab_VM
    {
      
        public DateTime FechaSesion { get; set; }
        public string Evaluacion { get; set; }
        public string Comentario { get; set; }
        public int Edicion { get; set; }
        public int ColaboradorId { get; set; }
        public Colaboradores Colaborador { get; set; }
        public List<Colaboradores> EscogerColaborador { get; set; }
        public int AlumnoId { get; set; }
        public Alumnos Alumno { get; set; }
        public List<Alumnos> EscogerAlumno { get; set; }
    }
}
