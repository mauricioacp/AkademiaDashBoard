using AkademiaV2.Data;
using AkademiaV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Services
{
    public class TalleresServices:ITalleres
    {
        private readonly AkademiaSystem _context;

        public TalleresServices(AkademiaSystem context)
        {
            _context = context;
        }

        public async Task CreateTallerAsync(Talleres talleres)
        {
            await _context.AddAsync(talleres);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTallerAsync(Talleres talleres)
        {
            _context.Talleres.Remove(talleres);
            await _context.SaveChangesAsync();
        }

        public async Task<Talleres> GetTallerByIdAsync(int? id)
        {
            return await _context.Talleres.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Talleres>> GetTalleresAsync()
        {
            return await _context.Talleres.ToListAsync();
        }

        public bool TallerExists(int id)
        {

            return _context.Talleres.Any(e => e.Id == id);
        }

        public async Task UpdateTallerAsync(Talleres talleres)
        {
            _context.Update(talleres);
            await _context.SaveChangesAsync();
        }
    }
}
