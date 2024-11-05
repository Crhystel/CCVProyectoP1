using System;
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
    public class EstudiantesController : Controller
    {
        private readonly CCVProyectoP1Context _context;

        public EstudiantesController(CCVProyectoP1Context context)
        {
            _context = context;
        }

        // GET: Estudiantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estudiante.ToListAsync());
        }
        public IActionResult Regresar()
        {
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Administrador");
        }

        // GET: Estudiantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // GET: Estudiantes/Create
        public IActionResult Create()
        {
            var rol = Enum.GetValues(typeof(RolEnum))
               .Cast<RolEnum>()
               .Where(r => r == RolEnum.Estudiante)
               .ToList();
            var grado = Enum.GetValues(typeof(GradoEnum))
                .Cast<GradoEnum>()
                .Select(c => new SelectListItem
                {
                    Value = c.ToString(),
                    Text = c.ToString()
                }).ToList();
            ViewBag.Grado = grado;
            ViewBag.Rol = rol;
            return View();
        }
            
        

        // POST: Estudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Grado,Id,Cedula,Nombre,NombreUsuario,Contrasenia,Edad,Rol")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var estudiante = await _context.Estudiante.FindAsync(id); 
            if (estudiante == null)
            {
                return NotFound();
            }
            var rol = new List<SelectListItem>
            {
                new SelectListItem{Value=RolEnum.Estudiante.ToString(),Text="Estudiante", Selected=true}
            };
            var grado = Enum.GetValues(typeof(GradoEnum))
                .Cast<GradoEnum>()
                .Select(c => new SelectListItem
                {
                    Value = c.ToString(),
                    Text=c.ToString(),
                    Selected=c==estudiante.Grado
                }).ToList();
            ViewBag.Rol = rol;
            ViewBag.Grado = grado;
            return View(estudiante);
        }

        // POST: Estudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Grado,Id,Cedula,Nombre,NombreUsuario,Contrasenia,Edad,Rol")] Estudiante estudiante)
        {
            if (id != estudiante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteExists(estudiante.Id))
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
            return View(estudiante);
        }

        // GET: Estudiantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }
        public async Task<IActionResult> ObtenerPorGrado(GradoEnum grado)
        {
            var estudinates = await _context.Estudiante
                .Where(c => c.Grado == grado)
                .Select(c => new { c.Id, c.Nombre }).ToListAsync();
            return Json(estudinates);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudiante = await _context.Estudiante.FindAsync(id);
            if (estudiante != null)
            {
                _context.Estudiante.Remove(estudiante);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteExists(int id)
        {
            return _context.Estudiante.Any(e => e.Id == id);
        }
    }
}
