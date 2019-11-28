using AkademiaV2.Models;
using AkademiaV2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Services
{
    public interface IAkademia
    {
        public Task<List<Akademia>> GetAkademiaAsync();
        public Task<Akademia> GetAkademiaByIdAsync(int? id);
        public Task CreateAkademiaAsync(Akademia akademia);
        public Task UpdateAkademiaAsync(Akademia akademia);
        public Task DeleteAkademiaAsync(Akademia akademia);
        public bool AkademiaExists(int id);
        public Task<AkademiaVM> GetAkademiaVM();
    }
}
