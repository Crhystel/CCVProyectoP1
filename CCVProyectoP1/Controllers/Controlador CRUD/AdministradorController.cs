using CCVProyecto1._1.Models;
using CCVProyectoP1.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CCVProyectoP1.Controllers
{
    [Authorize]
    public class AdministradorController : Controller
    {
        
        public IActionResult Index()
        {
            ViewData["MostrarSalir"] = true;
            var clases = _context.Clase.ToList();
            var profesores = _context.Profesor.ToList();
            var estudiantes = _context.Estudiante.ToList();

            ViewBag.Clases = clases;
            ViewBag.Profesores = profesores;
            ViewBag.Estudiantes = estudiantes;
            return View();
        }
        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home"); 
        }
        private readonly CCVProyectoP1Context _context;

        public AdministradorController(CCVProyectoP1Context context)
        {
            _context = context;
        }
        public IActionResult ListaClases()
        {
            var clases = _context.Clase.ToList();
            return View(clases);
        }
        public IActionResult CrearClase()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearClase(Clase clase)
        {
            if (ModelState.IsValid)
            {
                _context.Clase.Add(clase);
                await _context.SaveChangesAsync();
                return RedirectToAction("ListaClases");
            }
            return View(clase);
        }

        public IActionResult EditarClase(int id)
        {
            var clase = _context.Clase.Find(id);
            if (clase == null)
            {
                return NotFound();
            }
            return View(clase);
        }

        [HttpPost]
        public IActionResult EditarClase(Clase clase)
        {
            if (ModelState.IsValid)
            {
                _context.Clase.Update(clase);
                _context.SaveChanges();
                return RedirectToAction("ListaClases");
            }
            return View(clase);
        }

        public IActionResult EliminarClase(int id)
        {
            var clase = _context.Clase.Find(id);
            if (clase == null)
            {
                return NotFound();
            }
            return View(clase);
        }

        [HttpPost, ActionName("EliminarClase")]
        public IActionResult ConfirmarEliminarClase(int id)
        {
            var clase = _context.Clase.Find(id);
            if (clase != null)
            {
                _context.Clase.Remove(clase);
                _context.SaveChanges();
            }
            return RedirectToAction("ListaClases");
        }

        public IActionResult AsignarProfesorAClase(int claseId, int profesorId)
        {
            var clase = _context.Clase.Find(claseId);
            clase.IdProfesor = profesorId;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult AsignarEstudiantesAClase(int claseId, List<int> estudianteIds)
        {
            var clase = _context.Clase.Include(c => c.Estudiante).FirstOrDefault(c => c.Id == claseId);
            clase.Estudiante = _context.Estudiante.Where(e => estudianteIds.Contains(e.Id)).ToList();
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }


}
