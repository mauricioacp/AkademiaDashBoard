using AkademiaV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Services
{
    public interface IAlumnosTalleres
    {
        public Task<List<AlumnosTalleres>> GetAlumnosTalleres();
        public Task<AlumnosTalleres> GetAlumnosTalleresByIdAsync(int? id);
        public Task CreateAlumnosTalleres(AlumnosTalleres alumnosTalleres);        
        public Task UpdateAlumnosTalleresAsync(AlumnosTalleres alumnosTalleres);
        public Task DeleteAlumnosTalleresAsync(AlumnosTalleres alumnosTalleres);
        public bool AlumnosTalleresExists(int id);
        public Task<List<AlumnosTalleres>> GetTallerAlumnosByTallerId(int? id);
    }
}
