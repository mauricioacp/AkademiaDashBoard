using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AkademiaV2.Data;
using AkademiaV2.Models;
using Microsoft.EntityFrameworkCore;

namespace AkademiaV2.Services
{
    public class ColaboradoresTalleresServices : IColaboradoresTalleres
    {
        private readonly AkademiaSystem _context;

        public ColaboradoresTalleresServices(AkademiaSystem context)
        {
            _context = context;
        }
        public bool ColaboradoresTalleresExists(int id)
        {
            return _context.ColaboradoresTalleres.Any(e => e.Id == id);
        }

        public async Task CreateColaboradoresTalleres(ColaboradoresTalleres colaboradoresTalleress)
        {
            await _context.AddAsync(colaboradoresTalleress);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteColaboradoresTalleresAsync(ColaboradoresTalleres colaboradoresTalleress)
        {
            _context.ColaboradoresTalleres.Remove(colaboradoresTalleress);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ColaboradoresTalleres>> GetColaboradoresTalleres()
        {
            return await _context.ColaboradoresTalleres.Include(o=>o.Colaboradores).ToListAsync();
        }

        public async Task<ColaboradoresTalleres> GetColaboradoresTalleresByIdAsync(int? id)
        {
            return await _context.ColaboradoresTalleres.FindAsync(id);
        }

        public async Task<List<ColaboradoresTalleres>> GetColaboradoresTalleresByTallerId(int? id)
        {
            var colaboradorestalleres = await _context.ColaboradoresTalleres.Where(o => o.TalleresId == id).Include(o => o.Colaboradores).ToListAsync();

            return colaboradorestalleres;
        }

        public async Task UpdateColaboradoresTalleresAsync(ColaboradoresTalleres colaboradoresTalleress)
        {
            _context.Update(colaboradoresTalleress);
            await _context.SaveChangesAsync();
        }
    }
}
