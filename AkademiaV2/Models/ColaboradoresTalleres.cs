using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Models
{
    public class ColaboradoresTalleres
    {
        public int Id { get; set; }
        public Colaboradores Colaboradores { get; set; }
        public Talleres Taller { get; set; }
        public int TalleresId { get; set; }
    }
}
