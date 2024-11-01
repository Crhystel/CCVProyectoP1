using Microsoft.AspNetCore.Mvc;
using CCVProyectoP1.Models;
using CCVProyectoP1.Data;
using CCVProyecto1._1.Models;

namespace CCVProyectoP1.Controllers
{
    public class LoginController : Controller
    {
        private readonly Logica _logica;
        public LoginController(Logica logica)
        {
            _logica = logica;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index( Usuario _usuario)
        {
            var usuario= await _logica.GetProfesorsAsync();
            if(usuario != null)
            {
                return RedirectToAction("Index", "Administradores");
            }
            else
            {
                ViewBag.ErrorMessage = "El nombre de usuario o la contraseña son incorrectos.";
                return View();
            }
            
        }
    }
}
