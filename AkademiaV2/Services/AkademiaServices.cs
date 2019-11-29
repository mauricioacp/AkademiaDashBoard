using AkademiaV2.Data;
using AkademiaV2.Models;
using AkademiaV2.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Services
{
    public class AkademiaServices:IAkademia
    {
        private readonly AkademiaSystem _context;

        public AkademiaServices(AkademiaSystem context)
        {
            _context = context;
        }

        public async Task CreateAkademiaAsync(Akademia akademia)
        {
            await _context.AddAsync(akademia);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAkademiaAsync(Akademia akademia)
        {
            _context.Akademia.Remove(akademia);
            await _context.SaveChangesAsync();
        }

        public async Task<Akademia> GetAkademiaByIdAsync(int? id)
        {
            return await _context.Akademia.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Akademia>> GetAkademiaAsync()
        {
            var akademia = await _context.Akademia.Include(o=>o.Alumnos)
                .Include(o => o.Talleres).Include(o => o.Colaboradores).ThenInclude(o=>o.Sesiones).ToListAsync();
            
            return akademia;
        }

        public async Task<AkademiaVM> GetAkademiaVM()
        {
           AkademiaVM akademia=new AkademiaVM
            {
                AlumnosTalleres = await _context.AlumnosTalleres.ToListAsync(),
                Facilitadores = await _context.ColaboradoresTalleres.ToListAsync(),
                Talleres = await _context.Talleres.ToListAsync(),
                Alumnos= await _context.Alumnos.ToListAsync(),
                
                Colaboradores= await _context.Colaboradores.ToListAsync(),
                Akademias= await _context.Akademia.ToListAsync()
                

            };

            return akademia;
        }

        public bool AkademiaExists(int id)
        {

            return _context.Akademia.Any(e => e.Id == id);
        }

        public async Task UpdateAkademiaAsync(Akademia akademia)
        {
            _context.Update(akademia);
            await _context.SaveChangesAsync();
        }
    }
}
