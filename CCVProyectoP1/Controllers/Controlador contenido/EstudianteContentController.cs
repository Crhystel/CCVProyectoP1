using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CCVProyectoP1.Data;
using Microsoft.EntityFrameworkCore;

namespace CCVProyectoP1.Controllers
{
    [Authorize]
    public class EstudianteContentController : Controller
    {
        private readonly CCVProyectoP1Context _context;
        public EstudianteContentController(CCVProyectoP1Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var estudianteId = int.Parse(User.FindFirst("UserId")?.Value ?? "0");
            var clases = _context.Clase.Where(c => c.ClaseEstudiantes.Any(e => e.EstudianteId == estudianteId)).ToList();


            ViewData["MostrarSalir"] = true;
            return View(clases);
        }

        public async Task<IActionResult> ActividadesPorClase(int claseId)
        {
            var actividades = await _context.Actividad
                .Where(a => a.ClaseId == claseId)
                .ToListAsync();
            return View(actividades);
        }


        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
