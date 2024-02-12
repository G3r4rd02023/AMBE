using AMBE.Data;
using AMBE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetosController : ControllerBase
    {
        private readonly TransportedbContext _context;
        private readonly IServicioBitacora _bitacora;

        public ObjetosController(TransportedbContext context, IServicioBitacora bitacora)
        {
            _context = context;
            _bitacora = bitacora;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Objetos>>> ObtenerObjetos()
        {
            //valida que exista la tabla 
            if (_context.Objetos == null)
            {
                return NotFound();
            }
            //obtiene la lista 
            var objeto = await _context.Objetos.ToListAsync();
            await _bitacora.AgregarRegistro("Consultó", "Objetos");
            //devuelve la lista 
            return Ok(objeto);
        }

        [HttpPost]
        public async Task<ActionResult<Objetos>> CrearObjetos(Objetos objeto)
        {
            //agrega el nuevo objeto a la bd
            await _context.Objetos.AddAsync(objeto);
            //guarda los cambios
            await _context.SaveChangesAsync();
            await _bitacora.AgregarRegistro("Creó", "Objetos");
            return Ok();
        }
    }
}
