using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Models.ViewModels
{
    public class AkademiaVM
    {
        public List<AlumnosTalleres> AlumnosTalleres { get; set; }
        public List<Colaboradores> Colaboradores { get; set; }
        public List<Alumnos> Alumnos { get; set; }
        public List<Talleres> Talleres { get; set; }
        public List<ColaboradoresTalleres> Facilitadores { get; set; }
        public List<Akademia> Akademias { get; set; }
    }
}
