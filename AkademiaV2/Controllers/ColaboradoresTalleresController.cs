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
    public class ColaboradoresTalleresController : Controller
    {
        private readonly AkademiaSystem _context;

        public ColaboradoresTalleresController(AkademiaSystem context)
        {
            _context = context;
        }

        // GET: ColaboradoresTalleres
        public async Task<IActionResult> Index()
        {
            var akademiaSystem = _context.ColaboradoresTalleres.Include(c => c.Taller);
            return View(await akademiaSystem.ToListAsync());
        }

        // GET: ColaboradoresTalleres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradoresTalleres = await _context.ColaboradoresTalleres
                .Include(c => c.Taller)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colaboradoresTalleres == null)
            {
                return NotFound();
            }

            return View(colaboradoresTalleres);
        }

        // GET: ColaboradoresTalleres/Create
        public IActionResult Create()
        {
            ViewData["TalleresId"] = new SelectList(_context.Talleres, "Id", "Descripcion");
            return View();
        }

        // POST: ColaboradoresTalleres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TalleresId")] ColaboradoresTalleres colaboradoresTalleres)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colaboradoresTalleres);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TalleresId"] = new SelectList(_context.Talleres, "Id", "Descripcion", colaboradoresTalleres.TalleresId);
            return View(colaboradoresTalleres);
        }

        // GET: ColaboradoresTalleres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradoresTalleres = await _context.ColaboradoresTalleres.FindAsync(id);
            if (colaboradoresTalleres == null)
            {
                return NotFound();
            }
            ViewData["TalleresId"] = new SelectList(_context.Talleres, "Id", "Descripcion", colaboradoresTalleres.TalleresId);
            return View(colaboradoresTalleres);
        }

        // POST: ColaboradoresTalleres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TalleresId")] ColaboradoresTalleres colaboradoresTalleres)
        {
            if (id != colaboradoresTalleres.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaboradoresTalleres);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboradoresTalleresExists(colaboradoresTalleres.Id))
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
            ViewData["TalleresId"] = new SelectList(_context.Talleres, "Id", "Descripcion", colaboradoresTalleres.TalleresId);
            return View(colaboradoresTalleres);
        }

        // GET: ColaboradoresTalleres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradoresTalleres = await _context.ColaboradoresTalleres
                .Include(c => c.Taller)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colaboradoresTalleres == null)
            {
                return NotFound();
            }

            return View(colaboradoresTalleres);
        }

        // POST: ColaboradoresTalleres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colaboradoresTalleres = await _context.ColaboradoresTalleres.FindAsync(id);
            _context.ColaboradoresTalleres.Remove(colaboradoresTalleres);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColaboradoresTalleresExists(int id)
        {
            return _context.ColaboradoresTalleres.Any(e => e.Id == id);
        }
    }
}
