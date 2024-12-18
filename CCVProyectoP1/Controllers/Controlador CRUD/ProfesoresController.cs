﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CCVProyectoP1.Data;
using CCVProyectoP1.Models;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace CCVProyectoP1.Controllers
{
    [Authorize]
    public class ProfesoresController : Controller
    {
        private readonly CCVProyectoP1Context _context;

        public ProfesoresController(CCVProyectoP1Context context)
        {
            _context = context;
        }

        // GET: Profesores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Profesor.ToListAsync());
        }

        public IActionResult Regresar()
        {
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Administrador");
        }

        // GET: Profesores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        // GET: Profesores/Create
        public IActionResult Create()
        {
            var rol = Enum.GetValues(typeof(RolEnum))
               .Cast<RolEnum>()
               .Where(r => r == RolEnum.Profesor )
               .ToList();
            var clases = Enum.GetValues(typeof(Clase.ClaseEnum))
                .Cast<Clase.ClaseEnum>()
                .Select(c => new SelectListItem
                {
                    Value = c.ToString(),
                    Text = c.ToString()
                }).ToList();
            ViewBag.Rol = rol;
            ViewBag.Clases = clases;
            
            return View();
        }

        // POST: Profesores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Clase,Id,Cedula,Nombre,NombreUsuario,Contrasenia,Edad,Rol")] Profesor profesor)
        {
            var rol = Enum.GetValues(typeof(RolEnum))
               .Cast<RolEnum>()
               .Where(r => r == RolEnum.Profesor)
               .ToList();
            var clases = Enum.GetValues(typeof(Clase.ClaseEnum))
                .Cast<Clase.ClaseEnum>()
                .Select(c => new SelectListItem
                {
                    Value = c.ToString(),
                    Text = c.ToString()
                }).ToList();
            ViewBag.Rol = rol;
            ViewBag.Clases = clases;
            var existeProfe = _context.Profesor.FirstOrDefault(c => c.Cedula == profesor.Cedula);
            if (existeProfe != null)
            {
                ViewBag.ErrorMessage = "Este usuario ya existe.";
                return View(profesor);
            }
            if (ModelState.IsValid)
            {
                _context.Add(profesor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profesor);
        }

        // GET: Profesores/Edit/55
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesor.FindAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }
            var rol = new List<SelectListItem>
            {
                new SelectListItem{Value=RolEnum.Profesor.ToString(),Text="Profesor", Selected=true}
            };
            var clases = Enum.GetValues(typeof(Clase.ClaseEnum))
                .Cast<Clase.ClaseEnum>()
                .Select(c => new SelectListItem
                {
                    Value=c.ToString(),
                    Text=c.ToString(),
                    Selected=c==profesor.Clase
                }).ToList();
            ViewBag.Rol = rol;
            ViewBag.Clases = clases;
            //ViewBag.Rol = new SelectList(Enum.GetValues(typeof(RolEnum)), profesor.Rol);
            return View(profesor);
        }

        // POST: Profesores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind tofrfrrrr.  
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Clase,Id,Cedula,Nombre,NombreUsuario,Contrasenia,Edad,Rol")] Profesor profesor)
        {
            if (id != profesor.Id)
            {
                return NotFound();
            }
            var existeProfe = _context.Profesor.FirstOrDefault(c => c.Cedula == profesor.Cedula && c.Id != id);
            if (existeProfe != null)
            {
              
                ViewBag.ErrorMessage = "Este usuario ya existe.";

                
                var rol = new List<SelectListItem>
                {
                    new SelectListItem{ Value = RolEnum.Profesor.ToString(), Text = "Profesor", Selected = true }
                };
                var clases = Enum.GetValues(typeof(Clase.ClaseEnum))
                    .Cast<Clase.ClaseEnum>()
                    .Select(c => new SelectListItem
                    {
                        Value = c.ToString(),
                        Text = c.ToString(),
                        Selected = c == profesor.Clase
                    }).ToList();

                ViewBag.Rol = rol;
                ViewBag.Clases = clases;

                return View(profesor);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesorExists(profesor.Id))
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
            return View(profesor);
        }

        // GET: Profesores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }
        public async Task<IActionResult> ObtenerPorClase(Clase.ClaseEnum clase)
        {
            var profesores= await _context.Profesor
                .Where(c=> c.Clase==clase)
                .Select(c=> new {c.Id, c.Nombre}).ToListAsync();
            return Json(profesores);
        }

        // POST: Profesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profesor = await _context.Profesor.FindAsync(id);
            if (profesor != null)
            {
                _context.Profesor.Remove(profesor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesorExists(int id)
        {
            return _context.Profesor.Any(e => e.Id == id);
        }
    }
}
