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


        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> ShowTaller_Alumnos(int? id)
        {

            Alumnos_en_TallerVM alumnos_en_Taller = new Alumnos_en_TallerVM
            {
              Taller= await _talleresServices.GetTallerByIdAsync(id),
              Escoger_Alumnos= await _alumnosServices.GetAlumnos(),
              

            };
            return View(alumnos_en_Taller);
        }

        // GET: AlumnosTalleres/Create
        //Creo registros con el mismo id taller y varios id alumnos a ese mismo taller.Se crean x id_alumnostaller
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> CreateTaller_Alumnos(Alumnos_en_TallerVM alumnos_En_TallerVM, int[] alumnos_id)
        {
            int Tallerid = alumnos_En_TallerVM.TallerId;
            
            foreach (int i in alumnos_id)
            {

            AlumnosTalleres alumnosTalleres = new AlumnosTalleres
            {
                Alumnos = await _alumnosServices.GetAlumnoByIdAsync(i),
                Taller = await _talleresServices.GetTallerByIdAsync(Tallerid),
            };
           
            if (ModelState.IsValid)
            {
                await _alumnosTalleresServices.CreateAlumnosTalleres(alumnosTalleres);
               
            }
            }

            return RedirectToAction("Index","Talleres");
        }

        //Muestra los alumnos para escoger cuales van a ese taller por su id.
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> ShowAlumnos_in_Taller(int? id)
        {
            var myAlumnoTallerObject = await _alumnosTalleresServices.GetTallerAlumnosByTallerId(id);

            List<Alumnos> alumnos_entaller = new List<Alumnos>();
            foreach (AlumnosTalleres alumnosTalleres in myAlumnoTallerObject)
            {
                alumnos_entaller.Add(alumnosTalleres.Alumnos);
            }
            Alumnos_en_TallerVM Showalumnos_en_Taller = new Alumnos_en_TallerVM
            {
                Taller = await _talleresServices.GetTallerByIdAsync(id),
                Escoger_Alumnos = alumnos_entaller,
            };
            return View(Showalumnos_en_Taller);
        }
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> ShowInfo_in_TallerAlumnos(int? id)
        {
            var myAlumnoTallerObject = await _alumnosTalleresServices.GetTallerAlumnosByTallerId(id);

            List<Alumnos> alumnos_entaller = new List<Alumnos>();
            foreach (AlumnosTalleres alumnosTalleres in myAlumnoTallerObject)
            {
                alumnos_entaller.Add(alumnosTalleres.Alumnos);
            }
            Alumnos_en_TallerVM Showalumnos_en_Taller = new Alumnos_en_TallerVM
            {
                Taller = await _talleresServices.GetTallerByIdAsync(id),
                Escoger_Alumnos = alumnos_entaller,
            };
            return View(Showalumnos_en_Taller);
        }


        //public async Task<IActionResult> ShowTaller_Alumnos(int? id)
        //{
        //    AlumnosTalleres alumnosTalleres = new AlumnosTalleres
        //    {
        //        //Alumnos = await _alumnosServices.GetAlumnos(),
        //        Taller = await _talleresServices.GetTallerByIdAsync(id),
        //    };

        //    return View(alumnosTalleres);
        //}



        // POST: AlumnosTalleres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] AlumnosTalleres alumnosTalleres)
        {
            if (ModelState.IsValid)
            {
                await _alumnosTalleresServices.CreateAlumnosTalleres(alumnosTalleres);
                return RedirectToAction(nameof(Index));
            }
            return View(alumnosTalleres);
        }

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
