using AkademiaV2.Data;
using AkademiaV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Services
{
    public class SesionesServices:ISesiones
    {
        private readonly AkademiaSystem _context;

        public SesionesServices(AkademiaSystem context)
        {
            _context = context;
        }

        public async Task CreateSesionesAsync(Sesiones sesiones)
        {
            await _context.AddAsync(sesiones);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSesionesAsync(Sesiones sesiones)
        {
            _context.Sesiones.Remove(sesiones);
            await _context.SaveChangesAsync();
        }

        public async Task<Sesiones> GetSesionesByIdAsync(int? id)
        {
            return await _context.Sesiones.Include(o => o.Colaborador).Include(o => o.Alumno).FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<List<Sesiones>> GetSesionesByIdColaborador(int? id)
        {
            var Sesiones_Colaborador= await _context.Sesiones.Where(o => o.Colaborador.Id == id).Include(o => o.Colaborador).Include(o=>o.Alumno).ToListAsync();
            return Sesiones_Colaborador;
        }
        //var colaboradorestalleres = await _context.ColaboradoresTalleres.Where(o => o.TalleresId == id).Include(o => o.Colaboradores).ToListAsync();

        public async Task<List<Sesiones>> GetSesionesAsync()
        {
            var sesiones = await _context.Sesiones.Include(o => o.Colaborador).Include(o=>o.Alumno).ToListAsync();

            return sesiones;
        }

        public bool SesionesExists(int id)
        {

            return _context.Sesiones.Any(e => e.Id == id);
        }

        public async Task UpdateSesionesAsync(Sesiones sesiones)
        {
            _context.Update(sesiones);
            await _context.SaveChangesAsync();
        }
    }
}
