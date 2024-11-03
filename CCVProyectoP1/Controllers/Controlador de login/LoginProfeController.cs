using CCVProyecto1._1.Models;
using CCVProyectoP1.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CCVProyectoP1.Controllers
{
    public class LoginProfeController : Controller
    {
        private readonly Logica _logica;
        public LoginProfeController(Logica logica)
        {
            _logica = logica;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Usuario _usuario)
        {
            var usuario = await _logica.GetProfesorAsync(_usuario.NombreUsuario, _usuario.Contrasenia);
            if (usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                    new Claim("UserId", usuario.Id.ToString()),
                    new Claim("Contrasenia", usuario.Contrasenia),
                    new Claim(ClaimTypes.Role, usuario.Rol.ToString())
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Index", "ProfesorContent");
            }
            else
            {
                ViewBag.ErrorMessage = "El nombre de usuario o la contraseña son incorrectos.";
                return View();
            }

        }
    }
}
