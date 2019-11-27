using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Models
{
    public class AlumnosTalleres
    {
        public int Id { get; set; }
        public Alumnos Alumnos { get; set; }
        public int TallerId { get; set; }
        public Talleres Taller { get; set; }
       
    }
}
