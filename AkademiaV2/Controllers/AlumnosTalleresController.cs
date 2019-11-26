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
    public class AlumnosTalleresController : Controller
    {
        private readonly IAlumnos _alumnosServices;
        private readonly ITalleres _talleresServices;
        private readonly IAlumnosTalleres _alumnosTalleresServices;

        public AlumnosTalleresController(ITalleres talleresServices, IAlumnos alumnosServices,IAlumnosTalleres alumnosTalleres)
        {
            _alumnosServices = alumnosServices;
            _talleresServices = talleresServices;
            _alumnosTalleresServices = alumnosTalleres;

        }
        // GET: AlumnosTalleres
        public async Task<IActionResult> Index()
        {
            return View(await _alumnosTalleresServices.GetAlumnosTalleres());
        }

        // GET: AlumnosTalleres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnosTalleres = await _alumnosTalleresServices.GetAlumnosTalleresByIdAsync(id);
               
            if (alumnosTalleres == null)
            {
                return NotFound();
            }

            return View(alumnosTalleres);
        }

        // GET: AlumnosTalleres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlumnosTalleres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] AlumnosTalleres alumnosTalleres)
        {
            if (ModelState.IsValid)
            {
                await _alumnosTalleresServices.CreateAlumnosTalleresAsync(alumnosTalleres);
                return RedirectToAction(nameof(Index));
            }
            return View(alumnosTalleres);
        }

        // GET: AlumnosTalleres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnosTalleres = await _alumnosTalleresServices.GetAlumnosTalleresByIdAsync(id);
            if (alumnosTalleres == null)
            {
                return NotFound();
            }
            return View(alumnosTalleres);
        }

        // POST: AlumnosTalleres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] AlumnosTalleres alumnosTalleres)
        {
            if (id != alumnosTalleres.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _alumnosTalleresServices.UpdateAlumnosTalleresAsync(alumnosTalleres);
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                    if (!_alumnosTalleresServices.AlumnosTalleresExists(alumnosTalleres.Id))
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
            return View(alumnosTalleres);
        }

        // GET: AlumnosTalleres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnosTalleres = await _alumnosTalleresServices.GetAlumnosTalleresByIdAsync(id);
            if (alumnosTalleres == null)
            {
                return NotFound();
            }

            return View(alumnosTalleres);
        }

        // POST: AlumnosTalleres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alumnosTalleres = await _alumnosTalleresServices.GetAlumnosTalleresByIdAsync(id);
            await _alumnosTalleresServices.DeleteAlumnosTalleresAsync(alumnosTalleres);
            return RedirectToAction(nameof(Index));
        }

    }
}
