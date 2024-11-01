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
        public  async Task<List<Profesor>> GetProfesorsAsync() 
        {
            return await _context.Profesor.ToListAsync();
        }
    }
}
