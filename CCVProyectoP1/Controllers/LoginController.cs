using Microsoft.AspNetCore.Mvc;

using CCVProyectoP1.Data;
using CCVProyecto1._1.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;


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
            var usuario = await _logica.GetAdministradorsAsync(_usuario.NombreUsuario, _usuario.Contrasenia);
            if(usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,usuario.NombreUsuario),
                    new Claim("Contrasenia", usuario.Contrasenia),
                    new Claim(ClaimTypes.Role, usuario.Rol.ToString())
                    //new Claim("Usuario", usuario.Usuario)
                };
             
                var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Administrador");
            }
            else
            {
                ViewBag.ErrorMessage = "El nombre de usuario o la contraseña son incorrectos.";
                return View();
            }
            
            var usuario1= await _logica.GetProfesorAsync(_usuario.NombreUsuario, _usuario.Contrasenia);
            if (usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.NombreUsuario),
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
