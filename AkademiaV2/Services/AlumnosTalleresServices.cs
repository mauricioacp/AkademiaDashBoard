﻿using AkademiaV2.Data;
using AkademiaV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Services
{
    public class AlumnosTalleresServices:IAlumnosTalleres
    {
        private readonly AkademiaSystem _context;

        public AlumnosTalleresServices(AkademiaSystem context)
        {
            _context = context;
        }

        public bool AlumnosTalleresExists(int id)
        {
            return _context.AlumnosTalleres.Any(e => e.Id==id);
        }

        public async Task CreateAlumnosTalleres(AlumnosTalleres alumnosTalleres)
        {
            await _context.AddAsync(alumnosTalleres);
            await _context.SaveChangesAsync();
        }
        

        public async Task DeleteAlumnosTalleresAsync(AlumnosTalleres alumnosTalleres)
        {
            _context.AlumnosTalleres.Remove(alumnosTalleres);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AlumnosTalleres>> GetAlumnosTalleres()
        {
            return await _context.AlumnosTalleres.ToListAsync();
        }

        public async Task<AlumnosTalleres> GetAlumnosTalleresByIdAsync(int? id)
        {
            return await _context.AlumnosTalleres.FindAsync(id);
        }

        public async Task<List<AlumnosTalleres>> GetTallerAlumnosByTallerId(int? id)
        {
            var alumnostalleres = await _context.AlumnosTalleres.Where(o => o.TallerId == id).Include(o=>o.Alumnos.Colaborador).ToListAsync();
           
            return alumnostalleres;
        }

        public async Task UpdateAlumnosTalleresAsync(AlumnosTalleres alumnosTalleres)
        {
            _context.Update(alumnosTalleres);
            await _context.SaveChangesAsync();
        }
    }
}
