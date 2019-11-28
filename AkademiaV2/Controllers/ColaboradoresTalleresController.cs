using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AkademiaV2.Data;
using AkademiaV2.Models;
using AkademiaV2.Services;
using Microsoft.AspNetCore.Authorization;
using AkademiaV2.Models.ViewModels;

namespace AkademiaV2.Controllers
{
    public class ColaboradoresTalleresController : Controller
    {
        private readonly IColaboradores _colaboradoresServices;
        private readonly ITalleres _talleresServices;
        private readonly IColaboradoresTalleres _colaboradoresTalleresServices;

        public ColaboradoresTalleresController(IColaboradores colaboradoresServices, ITalleres talleresServices, IColaboradoresTalleres colaboradoresTalleresServices)
        {

            _talleresServices = talleresServices;
            _colaboradoresTalleresServices = colaboradoresTalleresServices;
            _colaboradoresServices = colaboradoresServices;

        }

        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> ShowTaller_Colaboradores(int? id)
        {

            Colab_Taller_AsistentesVM colab_Taller_AsistentesVM = new Colab_Taller_AsistentesVM
            {
                Taller = await _talleresServices.GetTallerByIdAsync(id),
                Escoger_Facilitadores = await _colaboradoresServices.GetFacilitadoresAsync(),
            };
            return View(colab_Taller_AsistentesVM);
        }

        //Creo registros con el mismo id taller y varios id Facilitadores a ese mismo taller.Se crean x id_colaboradorestaller
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> CreateTaller_Colaboradores(Colab_Taller_AsistentesVM colab_Taller_AsistentesVM, int[] facilitadores_id)
        {
            int Tallerid = colab_Taller_AsistentesVM.TallerId;

            foreach (int i in facilitadores_id)
            {

                ColaboradoresTalleres colaboradoresTalleres = new ColaboradoresTalleres
                {
                    Colaboradores = await _colaboradoresServices.GetColaboradorByIdAsync(i),
                    Taller = await _talleresServices.GetTallerByIdAsync(Tallerid),

                };

                if (ModelState.IsValid)
                {
                    await _colaboradoresTalleresServices.CreateColaboradoresTalleres(colaboradoresTalleres);

                }
            }

            return RedirectToAction("ListaTalleres", "Talleres");
        }


        //// GET: ColaboradoresTalleres
        //public async Task<IActionResult> Index()
        //{
        //    var akademiaSystem = _context.ColaboradoresTalleres.Include(c => c.Taller);
        //    return View(await akademiaSystem.ToListAsync());
        //}

        //// GET: ColaboradoresTalleres/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var colaboradoresTalleres = await _context.ColaboradoresTalleres
        //        .Include(c => c.Taller)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (colaboradoresTalleres == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(colaboradoresTalleres);
        //}

        //// GET: ColaboradoresTalleres/Create
        //public IActionResult Create()
        //{
        //    ViewData["TalleresId"] = new SelectList(_context.Talleres, "Id", "Descripcion");
        //    return View();
        //}

        //// POST: ColaboradoresTalleres/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,TalleresId")] ColaboradoresTalleres colaboradoresTalleres)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(colaboradoresTalleres);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["TalleresId"] = new SelectList(_context.Talleres, "Id", "Descripcion", colaboradoresTalleres.TalleresId);
        //    return View(colaboradoresTalleres);
        //}

        //// GET: ColaboradoresTalleres/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var colaboradoresTalleres = await _context.ColaboradoresTalleres.FindAsync(id);
        //    if (colaboradoresTalleres == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["TalleresId"] = new SelectList(_context.Talleres, "Id", "Descripcion", colaboradoresTalleres.TalleresId);
        //    return View(colaboradoresTalleres);
        //}

        //// POST: ColaboradoresTalleres/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,TalleresId")] ColaboradoresTalleres colaboradoresTalleres)
        //{
        //    if (id != colaboradoresTalleres.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(colaboradoresTalleres);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ColaboradoresTalleresExists(colaboradoresTalleres.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["TalleresId"] = new SelectList(_context.Talleres, "Id", "Descripcion", colaboradoresTalleres.TalleresId);
        //    return View(colaboradoresTalleres);
        //}

        //// GET: ColaboradoresTalleres/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var colaboradoresTalleres = await _context.ColaboradoresTalleres
        //        .Include(c => c.Taller)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (colaboradoresTalleres == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(colaboradoresTalleres);
        //}

        //// POST: ColaboradoresTalleres/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var colaboradoresTalleres = await _context.ColaboradoresTalleres.FindAsync(id);
        //    _context.ColaboradoresTalleres.Remove(colaboradoresTalleres);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ColaboradoresTalleresExists(int id)
        //{
        //    return _context.ColaboradoresTalleres.Any(e => e.Id == id);
        //}
    }
}
