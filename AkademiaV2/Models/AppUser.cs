using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Models
{
    public class AppUser:IdentityUser
    {
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(30)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese sus Apellidos")]
        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Indica sólo el número actual de tu Edición, Ej= 1")]
        public int Edicion { get; set; }
    }
}
