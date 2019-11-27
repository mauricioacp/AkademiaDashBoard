using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AkademiaV2.Data;
using AkademiaV2.Models;
using AkademiaV2.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AkademiaV2.Services
{
    public class AlumnosServices : IAlumnos
    {
        private readonly AkademiaSystem _context;

        public AlumnosServices(AkademiaSystem context)
        {
            _context = context;
        }
        public bool AlumnoExist(int id)
        {
            return _context.Alumnos.Any(e => e.Id == id);
        }

        public async Task CreateAlumnoAsync(Alumnos alumno)
        {
         
            await _context.Alumnos.AddAsync(alumno);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAlumnoAsync(Alumnos alumnos)
        {
            _context.Alumnos.Remove(alumnos);
            await _context.SaveChangesAsync();
        }

        public async Task<Alumnos> GetAlumnoByIdAsync(int? id)
        {
            return await _context.Alumnos.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Alumnos>> GetAlumnos()
        {
            var alumnos = await _context.Alumnos.OrderBy(x => x.Nombre).ToListAsync();
            alumnos = await _context.Alumnos.Include(o => o.Colaborador).ThenInclude(o=>o.Akademia).ToListAsync();
            return alumnos;
          
        }

        public async Task UpdateAlumnoAsync(Alumnos alumnos)
        {
            _context.Update(alumnos);
            await _context.SaveChangesAsync();
        }
    }
}
