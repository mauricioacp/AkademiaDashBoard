using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AkademiaV2.Data;
using AkademiaV2.Models;
using Microsoft.EntityFrameworkCore;

namespace AkademiaV2.Services
{
    public class ColaboradoresServices : IColaboradores
    {
        private readonly AkademiaSystem _context;

        public ColaboradoresServices(AkademiaSystem context)
        {
            _context = context;
        }
        public bool ColaboradorExist(int id)
        {
            return _context.Colaboradores.Any(e => e.Id == id);
        }

        public async Task CreateColaboradorAsync(Colaboradores colaboradores)
        {
            await _context.AddAsync(colaboradores);
          

            await _context.SaveChangesAsync();
        }

        public async Task DeleteColaboradorAsync(Colaboradores colaboradores)
        {
            _context.Colaboradores.Remove(colaboradores);
            await _context.SaveChangesAsync();
        }
        public async Task<Colaboradores> GetColaboradorByIdAsync(int? id)
        {

            _context.Colaboradores.Include(o => o.Akademia);
                return await _context.Colaboradores.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Colaboradores>> GetColaboradoresAsync()
        {
            _context.Colaboradores.Include(o => o.Akademia);
            var colaboradores= await _context.Colaboradores.OrderBy(x => x.Nombre).ToListAsync();
            return colaboradores;
        }

        public async Task<List<Colaboradores>> GetFacilitadoresAsync()
        {
            _context.Colaboradores.Include(o => o.Akademia);
            var colaboradores = await _context.Colaboradores.OrderBy(o=>o.Nombre).Where(o=>o.TipoColaborador=="Facilitador"||o.TipoColaborador=="Ambos")
                .Include(o=>o.BusquedaFacilitadores).ToListAsync();
            return colaboradores;
        }

        public async Task UpdateColaboradorAsync(Colaboradores colaboradores)
        {
            _context.Update(colaboradores);
            await _context.SaveChangesAsync();
        }
    }
}
