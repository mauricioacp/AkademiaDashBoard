using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Models.ViewModels
{
    public class Colab_Taller_AsistentesVM
    {
        public int Id { get; set; }
        public Colaboradores Facilitador { get; set; }
        public int TallerId { get; set; }
        public Talleres Taller { get; set; }
        public List<Colaboradores> Escoger_Facilitadores { get; set; }
      
    }
}
