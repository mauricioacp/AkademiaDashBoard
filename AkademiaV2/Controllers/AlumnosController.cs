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
    public class AlumnosController : Controller
    {
        private readonly IAlumnos _alumnosServices;
        private readonly IColaboradores _colaboradoresServices;

        public AlumnosController(IAlumnos alumnosServices, IColaboradores colaboradoresServices)
        {
            _alumnosServices = alumnosServices;
            _colaboradoresServices = colaboradoresServices;
        }

        // GET: Alumnos
        public async Task<IActionResult> Index()
        {
            return View(await _alumnosServices.GetAlumnos());
        }

        // GET: Alumnos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnos = await _alumnosServices.GetAlumnoByIdAsync(id);
               
            if (alumnos == null)
            {
                return NotFound();
            }

            return View(alumnos);
        }

        // GET: Alumnos/Create
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Create()
        {

            AlumnoColaborador alumnoColaborador = new AlumnoColaborador
            {
                Colaboradores = await _colaboradoresServices.GetColaboradoresAsync(),

            };
            return View(alumnoColaborador);
        }

        // POST: Alumnos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> EleccionColaborador(AlumnoColaborador alumnoColaborador)
        {
         
                 Alumnos alumno =new Alumnos
                {
                    Nombre = alumnoColaborador.Alumnos.Nombre,
                    Apellidos =alumnoColaborador.Alumnos.Apellidos,
                    CartaMotivacional = alumnoColaborador.Alumnos.CartaMotivacional,
                    Akademia = alumnoColaborador.Alumnos.Akademia,
                    Colaborador = alumnoColaborador.Alumnos.Colaborador,
                    Comentarios = alumnoColaborador.Alumnos.Comentarios,
                    Edicion = alumnoColaborador.Alumnos.Edicion,
                    Email = alumnoColaborador.Alumnos.Email,
                    Entrevista = alumnoColaborador.Alumnos.Entrevista,
                    FechaNacimiento = alumnoColaborador.Alumnos.FechaNacimiento,
                    Id = alumnoColaborador.Alumnos.Id,
                    Imagen = alumnoColaborador.Alumnos.Imagen,
                    Telefono = alumnoColaborador.Alumnos.Telefono
                };
               
                 return View( alumno);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmarAlumno(Alumnos alumnos)
        {
            await _alumnosServices.CreateAlumnoAsync(alumnos);
           
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Create(Alumnos alumnos)
        {
            if (ModelState.IsValid)
            {
               
                await _alumnosServices.CreateAlumnoAsync(alumnos);
                return RedirectToAction(nameof(Index));

               
            }
            return View(alumnos);
        }

        // GET: Alumnos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnos = await _alumnosServices.GetAlumnoByIdAsync(id);
            if (alumnos == null)
            {
                return NotFound();
            }
            return View(alumnos);
        }

        // POST: Alumnos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellidos,Imagen,Email,Telefono,CartaMotivacional,FechaNacimiento,Comentarios,Edicion")] Alumnos alumnos)
        {
            if (id != alumnos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _alumnosServices.UpdateAlumnoAsync(alumnos);
                  
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_alumnosServices.AlumnoExist(alumnos.Id))
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
            return View(alumnos);
        }

        // GET: Alumnos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnos = await _alumnosServices.GetAlumnoByIdAsync(id);
               
            if (alumnos == null)
            {
                return NotFound();
            }

            return View(alumnos);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alumnos = await _alumnosServices.GetAlumnoByIdAsync(id);
            await _alumnosServices.DeleteAlumnoAsync(alumnos);
          
            return RedirectToAction(nameof(Index));
        }
    }
}
