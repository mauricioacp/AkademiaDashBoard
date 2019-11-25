using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Models
{
    public class BusquedaAcompañantes
    {
        public int Id { get; set; }
        public Colaboradores Colaborador { get; set; }
        public string Nombre { get; set; }
        public string RutaDrive { get; set; }
    }
}
