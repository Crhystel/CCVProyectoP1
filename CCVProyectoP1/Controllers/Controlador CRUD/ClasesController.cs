using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CCVProyecto1._1.Models;
using CCVProyectoP1.Data;

namespace CCVProyectoP1.Controllers
{
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
            ViewData["IdProfesor"] = new SelectList(_context.Profesor, "Id", "Nombre");
            return View();
        }

        // POST: Clases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,IdProfesor")] Clase clase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProfesor"] = new SelectList(_context.Profesor, "Id", "Contrasenia", clase.IdProfesor);
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
            ViewData["IdProfesor"] = new SelectList(_context.Profesor, "Id", "Contrasenia", clase.IdProfesor);
            return View(clase);
        }

        // POST: Clases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,IdProfesor")] Clase clase)
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
            ViewData["IdProfesor"] = new SelectList(_context.Profesor, "Id", "Contrasenia", clase.IdProfesor);
            return View(clase);
        }

        // GET: Clases/UnirAlumnosAClases
        public IActionResult UnirAlumnosAClases()
        {
            // Cargar listas de clases y estudiantes para el formulario
            var clases = _context.Clase.ToList();
            var estudiantes = _context.Estudiante.ToList();

            // Pasar las listas a la vista mediante ViewBag
            ViewBag.Clases = new SelectList(clases, "Id", "Nombre");
            ViewBag.Estudiantes = new SelectList(estudiantes, "Id", "Nombre");

            return View();
        }

        // POST: Clases/UnirAlumnosAClases
        [HttpPost]
        public IActionResult UnirAlumnosAClases(int claseId, int estudianteId)
        {
            // Buscar la clase y el estudiante seleccionados
            var clase = _context.Clase.Include(c => c.Estudiante).FirstOrDefault(c => c.Id == claseId);
            var estudiante = _context.Estudiante.Find(estudianteId);

            // Agregar el estudiante a la clase y guardar los cambios
            if (clase != null && estudiante != null && !clase.Estudiante.Contains(estudiante))
            {
                clase.Estudiante.Add(estudiante);
                _context.SaveChanges();
            }

            // Redirigir de vuelta al índice de Clases
            return RedirectToAction("Index");
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
