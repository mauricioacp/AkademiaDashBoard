using AkademiaV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Services
{
    public interface IColaboradoresTalleres
    {
        public Task<List<ColaboradoresTalleres>> GetColaboradoresTalleres();
        public Task<ColaboradoresTalleres> GetColaboradoresTalleresByIdAsync(int? id);
        public Task CreateColaboradoresTalleres(ColaboradoresTalleres colaboradoresTalleres);
        public Task UpdateColaboradoresTalleresAsync(ColaboradoresTalleres colaboradoresTalleress);
        public Task DeleteColaboradoresTalleresAsync(ColaboradoresTalleres colaboradoresTalleress);
        public bool ColaboradoresTalleresExists(int id);
        public Task<List<ColaboradoresTalleres>> GetColaboradoresTalleresByTallerId(int? id);
    }
}
