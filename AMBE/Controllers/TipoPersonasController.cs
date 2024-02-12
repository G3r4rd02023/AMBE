using AMBE.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPersonasController : ControllerBase
    {
        private readonly TransportedbContext _context;

        public TipoPersonasController(TransportedbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPersonas>>> ObtenerTipoPersonas()
        {
            //valida que exista la tabla tipoPersonas
            if (_context.TipoPersonas == null)
            {
                return NotFound();
            }
            //obtiene la lista de todos los tipoPersonas
            var tipoPersonas = await _context.TipoPersonas.ToListAsync();
            //devuelve la lista de todos los tipoPersonas
            return Ok(tipoPersonas);
        }

        [HttpPost]
        public async Task<ActionResult<TipoPersonas>> CrearTipoPersona(TipoPersonas tipoPersonas)
        {
            //agrega el nuevo tipo a la bd
            await _context.TipoPersonas.AddAsync(tipoPersonas);
            //guarda los cambios
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTipoPersona(int id)
        {
            //validar que la tabla exista
            if (_context.TipoPersonas == null)
            {
                return NotFound();
            }
            //buscar el tipo por id
            var tipoPersona = await _context.TipoPersonas.FindAsync(id);
            //si no existe devolver not found
            if (tipoPersona == null)
            {
                return NotFound();
            }
            //eiminar el instituto de la bd
            _context.TipoPersonas.Remove(tipoPersona);
            //guardar los cambios
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
