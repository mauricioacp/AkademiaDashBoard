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

namespace AkademiaV2.Controllers
{
    public class TalleresController : Controller
    {
        private readonly ITalleres _talleresServices;

        public TalleresController(ITalleres talleresServices)
        {
            _talleresServices = talleresServices;
        }

        // GET: Talleres
        public async Task<IActionResult> Index()
        {
            return View(await _talleresServices.GetTalleresAsync());
        }

        // GET: Talleres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talleres = await _talleresServices.GetTallerByIdAsync(id);
            
            if (talleres == null)
            {
                return NotFound();
            }

            return View(talleres);
        }

        // GET: Talleres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Talleres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,FechaTaller,Imagen,Karrusel,Edicion,Evaluaciones,CarpetaPrincipal")] Talleres talleres)
        {
            if (ModelState.IsValid)
            {
                await _talleresServices.CreateTallerAsync(talleres);
                return RedirectToAction(nameof(Index));
            }
            return View(talleres);
        }

        // GET: Talleres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talleres = await _talleresServices.GetTallerByIdAsync(id);
            if (talleres == null)
            {
                return NotFound();
            }
            return View(talleres);
        }

        // POST: Talleres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,FechaTaller,Imagen,Karrusel,Edicion,Evaluaciones,CarpetaPrincipal")] Talleres talleres)
        {
            if (id != talleres.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _talleresServices.UpdateTallerAsync(talleres);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_talleresServices.TallerExists(talleres.Id))
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
            return View(talleres);
        }

        // GET: Talleres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talleres = await _talleresServices.GetTallerByIdAsync(id);
            if (talleres == null)
            {
                return NotFound();
            }

            return View(talleres);
        }

        // POST: Talleres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var talleres = await _talleresServices.GetTallerByIdAsync(id);

            await _talleresServices.DeleteTallerAsync(talleres);
            return RedirectToAction(nameof(Index));
        }
    }
}
