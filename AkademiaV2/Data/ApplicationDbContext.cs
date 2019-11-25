using System;
using System.Collections.Generic;
using System.Text;
using AkademiaV2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AkademiaV2.Models.ViewModels;

namespace AkademiaV2.Data
{
    public class AkademiaSystem : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public AkademiaSystem(DbContextOptions<AkademiaSystem> options)
            : base(options)
        {
        }
        public DbSet<AkademiaV2.Models.Alumnos> Alumnos { get; set; }
        public DbSet<AkademiaV2.Models.AlumnosTalleres> AlumnosTalleres { get; set; }
        public DbSet<AkademiaV2.Models.BusquedaAcompañantes> BusquedaAcompañantes { get; set; }
        public DbSet<AkademiaV2.Models.BusquedaAlumnos> BusquedaAlumnos { get; set; }
        public DbSet<AkademiaV2.Models.BusquedaFacilitadores> BusquedaFacilitadores { get; set; }
        public DbSet<AkademiaV2.Models.Colaboradores> Colaboradores { get; set; }
        public DbSet<AkademiaV2.Models.ColaboradoresTalleres> ColaboradoresTalleres { get; set; }
        public DbSet<AkademiaV2.Models.RegistroActividad> RegistroActividades { get; set; }
        public DbSet<AkademiaV2.Models.Sesiones> Sesiones { get; set; }
        public DbSet<AkademiaV2.Models.Talleres> Talleres { get; set; }
        public DbSet<AkademiaV2.Models.Akademia> Akademia { get; set; }
  
    }
}
