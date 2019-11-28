using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Models.ViewModels
{
    public class Alumno_Talleres_Facilitador_Asistencia_VM
    {
        public List<AlumnosTalleres> AlumnosTalleres { get; set; }
        public List<Talleres> Talleres { get; set; }
        public List<ColaboradoresTalleres>Facilitadores{get;set;}
        public List<Akademia> Akademias { get; set; }
    }
}
