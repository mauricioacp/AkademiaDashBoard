using AkademiaV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Services
{
    public interface ISesiones
    {
        public Task<List<Sesiones>> GetSesionesAsync();  
        public Task<Sesiones> GetSesionesByIdAsync(int? id);
        public Task CreateSesionesAsync(Sesiones sesiones);
        public Task UpdateSesionesAsync(Sesiones sesiones);
        public Task DeleteSesionesAsync(Sesiones sesiones);
        public bool SesionesExists(int id);
        public Task<List<Sesiones>> GetSesionesByIdColaborador(int? id);
    }
}
