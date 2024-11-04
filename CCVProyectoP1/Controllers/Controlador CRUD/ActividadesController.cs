using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CCVProyectoP1.Data;
using CCVProyectoP1.Models;

namespace CCVProyectoP1.Controllers
{
    public class ActividadesController : Controller
    {
        private readonly CCVProyectoP1Context _context;

        public ActividadesController(CCVProyectoP1Context context)
        {
            _context = context;
        }

        // GET: Actividades
        public async Task<IActionResult> Index()
        {
            var cCVProyectoP1Context = _context.Actividad.Include(a => a.Clase);
            return View(await cCVProyectoP1Context.ToListAsync());
        }

        // GET: Actividades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividad = await _context.Actividad
                .Include(a => a.Clase)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actividad == null)
            {
                return NotFound();
            }

            return View(actividad);
        }

        // GET: Actividades/Create
        public IActionResult Create()
        {
            ViewData["ClaseId"] = new SelectList(_context.Clase, "Id", "Nombre");
            return View();
        }

        // POST: Actividades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descripcion,FechaCreacion,FechaEntrega,ClaseId")] Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actividad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClaseId"] = new SelectList(_context.Clase, "Id", "Nombre", actividad.ClaseId);
            return View(actividad);
        }

        // GET: Actividades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividad = await _context.Actividad.FindAsync(id);
            if (actividad == null)
            {
                return NotFound();
            }
            ViewData["ClaseId"] = new SelectList(_context.Clase, "Id", "Nombre", actividad.ClaseId);
            return View(actividad);
        }

        // POST: Actividades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descripcion,FechaCreacion,FechaEntrega,ClaseId")] Actividad actividad)
        {
            if (id != actividad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actividad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActividadExists(actividad.Id))
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
            ViewData["ClaseId"] = new SelectList(_context.Clase, "Id", "Nombre", actividad.ClaseId);
            return View(actividad);
        }

        // GET: Actividades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividad = await _context.Actividad
                .Include(a => a.Clase)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actividad == null)
            {
                return NotFound();
            }

            return View(actividad);
        }

        // POST: Actividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actividad = await _context.Actividad.FindAsync(id);
            if (actividad != null)
            {
                _context.Actividad.Remove(actividad);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActividadExists(int id)
        {
            return _context.Actividad.Any(e => e.Id == id);
        }
    }
}
