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

namespace AkademiaV2.Controllers
{
    public class AkademiasController : Controller
    {
        private readonly IAkademia _akademiaServices;

        public AkademiasController(IAkademia akademiaServices)
        {
            _akademiaServices = akademiaServices;
        }

        // GET: Alumnos
        public async Task<IActionResult> Index()
        {
            return View(await _akademiaServices.GetAkademiaAsync());
        }

        // GET: Alumnos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var akademia = await _akademiaServices.GetAkademiaByIdAsync(id);

            if (akademia == null)
            {
                return NotFound();
            }

            return View(akademia);
        }

        // GET: Alumnos/Create
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alumnos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellidos,Imagen,Email,Telefono,CartaMotivacional,FechaNacimiento,Comentarios,Edicion")]Akademia akademia)
        {
            if (ModelState.IsValid)
            {
                await _akademiaServices.CreateAkademiaAsync(akademia);

                return RedirectToAction(nameof(Index));
            }
            return View(akademia);
        }

        // GET: Alumnos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var akademia = await _akademiaServices.GetAkademiaByIdAsync(id);
            if (akademia == null)
            {
                return NotFound();
            }
            return View(akademia);
        }

        // POST: Alumnos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellidos,Imagen,Email,Telefono,CartaMotivacional,FechaNacimiento,Comentarios,Edicion")] Akademia akademia)
        {
            if (id != akademia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _akademiaServices.UpdateAkademiaAsync(akademia);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_akademiaServices.AkademiaExists(akademia.Id))
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
            return View(akademia);
        }

        // GET: Alumnos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var akademia = await _akademiaServices.GetAkademiaByIdAsync(id);

            if (akademia == null)
            {
                return NotFound();
            }

            return View(akademia);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var akademia = await _akademiaServices.GetAkademiaByIdAsync(id);
            await _akademiaServices.DeleteAkademiaAsync(akademia);

            return RedirectToAction(nameof(Index));
        }
    }
}
