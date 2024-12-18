﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using CCVProyectoP1.Data;
using CCVProyectoP1.Models;
using Microsoft.AspNetCore.Authorization;

namespace CCVProyectoP1.Controllers
{
    [Authorize]
    public class ClasesController : Controller
    {
        private readonly CCVProyectoP1Context _context;

        public ClasesController(CCVProyectoP1Context context)
        {
            _context = context;
        }

        // GET: Clases
        public async Task<IActionResult> Index()
        {
            var cCVProyectoP1Context = _context.Clase.Include(c => c.Profesor);
            return View(await cCVProyectoP1Context.ToListAsync());
        }

        // GET: Clases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _context.Clase
                .Include(c => c.Profesor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clase == null)
            {
                return NotFound();
            }

            return View(clase);
        }

        // GET: Clases/Create
        public IActionResult Create()
        {
            var clases = Enum.GetValues(typeof(Clase.ClaseEnum))
                .Cast<Clase.ClaseEnum>()
                .Select(c => new SelectListItem
                {
                    Value = c.ToString(),
                    Text = c.ToString()

                }).ToList();
            var grado = Enum.GetValues(typeof(GradoEnum))
                .Cast<GradoEnum>()
                .Select(c => new SelectListItem
                {
                    Value = c.ToString(),
                    Text = c.ToString()
                }).ToList();
            ViewBag.Grado = grado;
            ViewBag.Clases = clases;
            ViewBag.IdProfesor = new SelectList(_context.Profesor, "Id", "Nombre");

            return View();
        }

        // POST: Clases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CNombre,IdProfesor,Grado")] Clase clase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.IdProfesor = new SelectList(_context.Profesor, "Id", "Nombre");

            return View(clase);
        }

        // GET: Clases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _context.Clase.FindAsync(id);
            if (clase == null)
            {
                return NotFound();
            }
            var clases = Enum.GetValues(typeof(Clase.ClaseEnum))
               .Cast<Clase.ClaseEnum>()
               .Select(c => new SelectListItem
               {
                   Value = c.ToString(),
                   Text = c.ToString(),
                   
               }).ToList();
            var grado = Enum.GetValues(typeof(GradoEnum))
                .Cast<GradoEnum>()
                .Select(c => new SelectListItem
                {
                    Value = c.ToString(),
                    Text = c.ToString()
                }).ToList();
            ViewBag.Grado = grado;
            ViewBag.Clases = clases;
            //ViewData["IdProfesor"] = new SelectList(_context.Profesor, "Id", "Contrasenia", clase.IdProfesor);
            return View(clase);
        }

        // POST: Clases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CNombre,IdProfesor,Grado")] Clase clase)
        {
            if (id != clase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaseExists(clase.Id))
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
            ViewData["IdProfesor"] = new SelectList(_context.Profesor, "Id", "Nombre", clase.IdProfesor);
            return View(clase);
        }

        // GET: Clases/UnirAlumnosAClases
        public IActionResult UnirAlumnosAClases(int? claseId)
        {
            
            var clasesConEstudiantes = _context.Clase.Include(c => c.ClaseEstudiantes).ThenInclude(e => e.Estudiante)
                .Select(c => new
                {
                    c.Id,
                    CNombre=c.CNombre,
                    Grado=c.Grado,
                    ClaseEstudiantes = c.ClaseEstudiantes,
                    DisplayText =$"{c.CNombre} - {c.Grado}"
                })
                .ToList();  
            var estudiantes = _context.Estudiante.ToList();
            var gradoClases = Enum.GetValues(typeof(GradoEnum))
                .Cast<GradoEnum>()
                .Select(c => new SelectListItem
                {
                    Value = c.ToString(),
                    Text = c.ToString()
                }).ToList();

            ViewBag.ClasesDropdown = new SelectList(clasesConEstudiantes, "Id", "DisplayText");

            ViewBag.Grado = gradoClases;
            ViewBag.Clases = clasesConEstudiantes;
            ViewBag.Estudiantes = new SelectList(estudiantes, "Id", "Nombre");

            
            if (claseId.HasValue)
            {
                var claseSeleccionada = clasesConEstudiantes.FirstOrDefault(c => c.Id == claseId);
                return View(claseSeleccionada);
            }

            return View();
        }

        // POST: Clases/UnirAlumnosAClases
        [HttpPost]
        public IActionResult UnirAlumnosAClases(int claseId, int estudianteId)
        {
           
            var existeRelacion = _context.ClaseEstudiante
                .Any(ce => ce.ClaseId == claseId && ce.EstudianteId == estudianteId);

            if (!existeRelacion)
            {
               
                var nuevaRelacion = new ClaseEstudiante
                {
                    ClaseId = claseId,
                    EstudianteId = estudianteId
                };

                _context.ClaseEstudiante.Add(nuevaRelacion);
                _context.SaveChanges();
            }

            return RedirectToAction("UnirAlumnosAClases");
        }

        // GET: Clases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _context.Clase
                .Include(c => c.Profesor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clase == null)
            {
                return NotFound();
            }

            return View(clase);
        }

        // POST: Clases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clase = await _context.Clase.FindAsync(id);
            if (clase != null)
            {
                _context.Clase.Remove(clase);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClaseExists(int id)
        {
            return _context.Clase.Any(e => e.Id == id);
        }


    }
}
