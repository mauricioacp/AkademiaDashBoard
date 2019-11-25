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
    public class ColaboradoresController : Controller
    {
        private readonly IColaboradores _colaboradoresServices;

        public ColaboradoresController(IColaboradores colaboradoresServices)
        {
            _colaboradoresServices = colaboradoresServices;
        }

        // GET: Colaboradores
        public async Task<IActionResult> Index()
        {
            return View(await _colaboradoresServices.GetColaboradoresAsync());
        }

        public async Task<IActionResult> Profile(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var colaborador = await _colaboradoresServices.GetColaboradorByIdAsync(id);
            
            if (colaborador == null)
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // GET: Colaboradores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaborador = await _colaboradoresServices.GetColaboradorByIdAsync(id);
            if (colaborador== null)
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // GET: Colaboradores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colaboradores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellidos,Imagen,Email,Telefono,CartaMotivacional,FechaNacimiento,Comentarios,Edicion,TipoColaborador")] Colaboradores colaboradores)
        {
            if (ModelState.IsValid)
            {
                await _colaboradoresServices.CreateColaboradorAsync(colaboradores);
                return RedirectToAction(nameof(Index));
            }
            return View(colaboradores);
        }

        // GET: Colaboradores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradores = await _colaboradoresServices.GetColaboradorByIdAsync(id);
            if (colaboradores == null)
            {
                return NotFound();
            }
            return View(colaboradores);
        }

        // POST: Colaboradores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellidos,Imagen,Email,Telefono,CartaMotivacional,FechaNacimiento,Comentarios,Edicion,TipoColaborador")] Colaboradores colaboradores)
        {
            if (id != colaboradores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _colaboradoresServices.UpdateColaboradorAsync(colaboradores);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_colaboradoresServices.ColaboradorExist(colaboradores.Id))
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
            return View(colaboradores);
        }

        // GET: Colaboradores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradores = await _colaboradoresServices.GetColaboradorByIdAsync(id);
               
            if (colaboradores == null)
            {
                return NotFound();
            }

            return View(colaboradores);
        }

        // POST: Colaboradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colaboradores = await _colaboradoresServices.GetColaboradorByIdAsync(id);
            await _colaboradoresServices.DeleteColaboradorAsync(colaboradores);
            
            return RedirectToAction(nameof(Index));
        }
    }
}
