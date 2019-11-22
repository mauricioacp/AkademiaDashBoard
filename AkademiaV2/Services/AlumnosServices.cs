using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AkademiaV2.Data;
using AkademiaV2.Models;
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

        public async Task CreateAlumnoAsync(Alumnos alumnos)
        {
            await _context.AddAsync(alumnos);
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
             return await _context.Alumnos.ToListAsync();
        }

        public async Task UpdateAlumnoAsync(Alumnos alumnos)
        {
            _context.Update(alumnos);
            await _context.SaveChangesAsync();
        }
    }
}
