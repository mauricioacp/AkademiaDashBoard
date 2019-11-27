using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Models.ViewModels
{
    public class Alumnos_en_TallerVM
    {
        public int Id { get; set; }
        public Alumnos Alumnos { get; set; }
        public int TallerId { get; set; }
        public Talleres Taller { get; set; }             
        public List<Alumnos> Escoger_Alumnos { get; set; }
    }
}
