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
using AkademiaV2.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace AkademiaV2.Controllers
{
    public class SesionesController : Controller
    {
        private readonly IAlumnos _alumnosServices;
        private readonly IColaboradores _colaboradoresServices;
        private readonly ISesiones _sesionesServices;
   

        public SesionesController(IAlumnos alumnosServices, IColaboradores colaboradoresServices,ISesiones sesionesServices )
        {
            _alumnosServices = alumnosServices;
            _colaboradoresServices = colaboradoresServices;
            _sesionesServices = sesionesServices;
        }

        // GET: Sesiones
        public async Task<IActionResult> Index()
        {
            return View(await _sesionesServices.GetSesionesAsync());
        }

        public async Task<IActionResult> RegistroSesiones()
        {
            Sesiones_Alumnos_Colab_VM sesiones_Alumnos_Colab_VM = new Sesiones_Alumnos_Colab_VM
            {
                EscogerAlumno = await _alumnosServices.GetAlumnos(),
              

            };

            return View(sesiones_Alumnos_Colab_VM);
        }


        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> CreateRegistro_Sesion(Sesiones_Alumnos_Colab_VM sesiones_Alumnos_Colab_VM, int[] alumnos_id)
        {

            var alumnos_registro_sesion = await _alumnosServices.GetSeveralAlumnosById(alumnos_id);
            


            foreach(Alumnos alumnos in alumnos_registro_sesion)
            {

                Sesiones sesiones= new Sesiones
                {
                    Alumno = await _alumnosServices.GetAlumnoByIdAsync(alumnos.Id),
                    Colaborador = await _colaboradoresServices.GetColaboradorByIdAsync(alumnos.Colaborador.Id),
                    FechaSesion= sesiones_Alumnos_Colab_VM.FechaSesion,
                    Comentario= sesiones_Alumnos_Colab_VM.Comentario,
                    Edicion= sesiones_Alumnos_Colab_VM.Edicion,
                    Evaluacion= sesiones_Alumnos_Colab_VM.Evaluacion,
                };

                if (ModelState.IsValid)
                {
                    await _sesionesServices.CreateSesionesAsync(sesiones);

                }
            }

            return RedirectToAction("Index", "Talleres");
        }


        // GET: Sesiones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesiones = await _sesionesServices.GetSesionesByIdAsync(id);

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
                await _sesionesServices.CreateSesionesAsync(sesiones);
              

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

            var sesiones = await _sesionesServices.GetSesionesByIdAsync(id);
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
                    await _sesionesServices.UpdateSesionesAsync(sesiones);
                  
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_sesionesServices.SesionesExists(sesiones.Id))
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

            var sesiones = await _sesionesServices.GetSesionesByIdAsync(id);
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
            var sesiones = await _sesionesServices.GetSesionesByIdAsync(id);
           await  _sesionesServices.DeleteSesionesAsync(sesiones);
           
            return RedirectToAction(nameof(Index));
        }

       
    }
}
