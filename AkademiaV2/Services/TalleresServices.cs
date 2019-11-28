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
        //Obtengo el taller y su asistencia.
            return await _context.Talleres.Include(o=>o.AlumnosTalleres).Include(o=>o.ColaboradoresTalleres).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Talleres>> GetTalleresAsync()
        {
             var talleres = await _context.Talleres.OrderBy(x => x.FechaTaller).Include(o=>o.ColaboradoresTalleres).ToListAsync();
            return talleres;
        }

        public async Task<Alumno_Talleres_Facilitador_Asistencia_VM> GetVM()
        {
            Alumno_Talleres_Facilitador_Asistencia_VM alumno_taller_facilitadorVM = new Alumno_Talleres_Facilitador_Asistencia_VM()
            {
                AlumnosTalleres = await _context.AlumnosTalleres.ToListAsync(),
                Facilitadores = await _context.ColaboradoresTalleres.Include(O=>O.Colaboradores).ToListAsync(),
                Talleres = await _context.Talleres.ToListAsync(),


            };

            return alumno_taller_facilitadorVM;
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
