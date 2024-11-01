using CCVProyecto1._1.Models;
using CCVProyectoP1.Models;
using Microsoft.EntityFrameworkCore;
namespace CCVProyectoP1.Data
{
    public class Logica
    {
        private readonly CCVProyectoP1Context _context;
        public Logica(CCVProyectoP1Context context)
        {
            _context = context;
        }
        public async Task<Administrador?> GetAdministradorsAsync(string nombreUsuario, string contrasenia)
        {
            return await _context.Administrador
                .FirstOrDefaultAsync(a => a.NombreUsuario == nombreUsuario && a.Contrasenia == contrasenia);
        }

    }
}
