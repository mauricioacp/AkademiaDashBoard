using AkademiaV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Services
{
    public interface IColaboradores
    {
        public Task<List<Colaboradores>> GetColaboradoresAsync();
        public Task<List<Colaboradores>> GetFacilitadoresAsync();
        public Task<Colaboradores> GetColaboradorByIdAsync(int? id);
        public Task CreateColaboradorAsync(Colaboradores colaboradores);
        public Task UpdateColaboradorAsync(Colaboradores colaboradores);
        public Task DeleteColaboradorAsync(Colaboradores colaboradores);
        public bool ColaboradorExist(int id);
    
    }
}
