using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Models
{
    public class BusquedaFacilitadores
    {
        public int Id { get; set; }

        public Colaboradores Colaboradores { get; set; }
        public string Nombre { get; set; }
        public string RutaDrive { get; set; }
    }
}
