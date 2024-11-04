using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CCVProyectoP1.Data;
using CCVProyectoP1.Models;
using Microsoft.Extensions.Hosting.Internal;

namespace CCVProyectoP1.Controllers
{
    public class ActividadesController : Controller
    {
        private readonly CCVProyectoP1Context _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ActividadesController(CCVProyectoP1Context context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Actividades
        public async Task<IActionResult> Index()
        {
            // Recupera el profesor usando el nombre de usuario
            var profesor = await _context.Profesor.FirstOrDefaultAsync(p => p.NombreUsuario == User.Identity.Name);

            if (profesor == null)
            {
                return Unauthorized(); // maneja el caso de que el profesor no exista
            }

            int profesorId = profesor.Id;

            var actividadesFiltradas = _context.Actividad
                                                .Include(a => a.Clase)
                                                .Where(a => a.Clase.IdProfesor == profesorId);

            return View(await actividadesFiltradas.ToListAsync());

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
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descripcion,FechaCreacion,FechaEntrega,ClaseId")] Actividad actividad, IFormFile archivo)
        {
            if (ModelState.IsValid)
            {
                if (archivo != null && archivo.Length > 0)
                {
                    // Define la carpeta de destino para guardar el archivo
                    string rutaCarpeta = Path.Combine(_hostingEnvironment.WebRootPath, "archivos");

                    // Crea la carpeta si no existe
                    if (!Directory.Exists(rutaCarpeta))
                    {
                        Directory.CreateDirectory(rutaCarpeta);
                    }

                    // Genera un nombre único para el archivo
                    string nombreArchivo = Guid.NewGuid().ToString() + Path.GetExtension(archivo.FileName);
                    string rutaArchivo = Path.Combine(rutaCarpeta, nombreArchivo);

                    // Guarda el archivo en la carpeta definida
                    using (var fileStream = new FileStream(rutaArchivo, FileMode.Create))
                    {
                        await archivo.CopyToAsync(fileStream);
                    }

                    // Asigna la ruta y nombre de archivo en el modelo
                    actividad.NombreArchivo = archivo.FileName;
                    actividad.RutaArchivo = nombreArchivo; // Nombre único para recuperar después
                }
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

        public IActionResult DescargarArchivo(int id)
        {
            var actividad = _context.Actividad.Find(id);
            if (actividad == null || string.IsNullOrEmpty(actividad.RutaArchivo))
            {
                return NotFound();
            }

            var rutaCompleta = Path.Combine(_hostingEnvironment.WebRootPath, "archivos", actividad.RutaArchivo);
            var fileBytes = System.IO.File.ReadAllBytes(rutaCompleta);
            return File(fileBytes, "application/octet-stream", actividad.NombreArchivo);
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
