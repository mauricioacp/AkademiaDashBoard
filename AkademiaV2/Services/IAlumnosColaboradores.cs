using AkademiaV2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Services
{
    public interface IAlumnosColaboradores
    {
        public Task<List<AlumnoColaborador>> GetAlumnoColaboradorAsync();
       
        public Task CreateAlumnoColaboradorAsync(AlumnoColaborador alumnoColaborador);
        public Task UpdateAlumnoColaboradorAsync(AlumnoColaborador alumnoColaborador);
        public Task DeleteAlumnoColaboradorAsync(AlumnoColaborador alumnoColaborador);
       
    }
}
