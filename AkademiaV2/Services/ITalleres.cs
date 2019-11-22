using AkademiaV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Services
{
    public interface ITalleres
    {
        public Task<List<Talleres>> GetTalleresAsync();
        public Task<Talleres> GetTallerByIdAsync(int? id);
        public Task CreateTallerAsync(Talleres talleres);
        public Task UpdateTallerAsync(Talleres talleres);
        public Task DeleteTallerAsync(Talleres talleres);
        public bool TallerExists(int id);
    }
}
