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
            return View();
        }
        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home"); 
        }
       
    }


}
