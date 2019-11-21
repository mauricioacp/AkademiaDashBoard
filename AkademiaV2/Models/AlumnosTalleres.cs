using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Models
{
    public class AlumnosTalleres
    {
        public int Id { get; set; }
        public List<Alumnos> Alumnos { get; set; }
        public Talleres Talleres { get; set; }
        public int TalleresId { get; set; }
    }
}
