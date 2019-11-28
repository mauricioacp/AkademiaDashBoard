using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AkademiaV2.Data;
using AkademiaV2.Models;

namespace AkademiaV2.Controllers
{
    public class SesionesController : Controller
    {
        private readonly AkademiaSystem _context;

        public SesionesController(AkademiaSystem context)
        {
            _context = context;
        }

        // GET: Sesiones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sesiones.ToListAsync());
        }

        // GET: Sesiones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesiones = await _context.Sesiones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sesiones == null)
            {
                return NotFound();
            }

            return View(sesiones);
        }

        // GET: Sesiones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sesiones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaSesion,Evaluacion,Comentario,Edicion")] Sesiones sesiones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sesiones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sesiones);
        }

        // GET: Sesiones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesiones = await _context.Sesiones.FindAsync(id);
            if (sesiones == null)
            {
                return NotFound();
            }
            return View(sesiones);
        }

        // POST: Sesiones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaSesion,Evaluacion,Comentario,Edicion")] Sesiones sesiones)
        {
            if (id != sesiones.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sesiones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SesionesExists(sesiones.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sesiones);
        }

        // GET: Sesiones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesiones = await _context.Sesiones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sesiones == null)
            {
                return NotFound();
            }

            return View(sesiones);
        }

        // POST: Sesiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sesiones = await _context.Sesiones.FindAsync(id);
            _context.Sesiones.Remove(sesiones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SesionesExists(int id)
        {
            return _context.Sesiones.Any(e => e.Id == id);
        }
    }
}
