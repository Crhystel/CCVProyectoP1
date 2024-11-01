using Microsoft.AspNetCore.Mvc;

namespace CCVProyectoP1.Controllers
{
    public class AdministradorController : Controller
    {
        public IActionResult Index()
        {
            ViewData["MostrarSalir"] = true; 
            return View();
        }
        public IActionResult Salir()
        {
            return RedirectToAction("Index", "Home"); 
        }

    }
}
