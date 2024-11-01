using Microsoft.AspNetCore.Mvc;
using CCVProyectoP1.Models;
using CCVProyectoP1.Data;

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
        public async Task<IActionResult> Index()
        {
            var usuario= await _logica.GetProfesorsAsync();
            return View();
        }
    }
}
