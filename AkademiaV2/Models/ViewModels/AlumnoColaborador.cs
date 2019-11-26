using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Models.ViewModels
{
    public class AlumnoColaborador
    {
        
        public Alumnos Alumnos { get; set; }
        public List<Colaboradores> Colaboradores { get; set; }
        public AlumnoColaborador AlumnoColaboradores { get; set; }
       
    }
}
