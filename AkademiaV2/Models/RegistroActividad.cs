using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Models
{
    public class RegistroActividad
    {
        public int Id { get; set; }
        public int ColaboradoresId{ get; set; }
        public AppUser AppUser{ get; set; }
    }
}
