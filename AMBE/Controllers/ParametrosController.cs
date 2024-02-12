using AMBE.Data;
using AMBE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametrosController : ControllerBase
    {
        private readonly TransportedbContext _context;
        private readonly IServicioBitacora _bitacora;

        public ParametrosController(TransportedbContext context, IServicioBitacora bitacora)
        {
            _context = context;
            _bitacora = bitacora;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parametros>>> ObtenerParametros()
        {
            //valida que exista la tabla 
            if (_context.Parametros == null)
            {
                return NotFound();
            }
            //obtiene la lista 
            var parametro = await _context.Parametros.ToListAsync();
            await _bitacora.AgregarRegistro("Consultó", "Parametros");
            //devuelve la lista 
            return Ok(parametro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarParametro(int id, Parametros parametro)
        {
            if (id != parametro.IdParametro)
            {
                return BadRequest();
            }
            //actualiza el parametro
            _context.Entry(parametro).State = EntityState.Modified;
            //guarda los cambios en bd           
            await _context.SaveChangesAsync();
            await _bitacora.AgregarRegistro("Actualizó", "Parametros");
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Parametros>> CrearParametro(Parametros parametro)
        {
            //agrega el nuevo parametro a la bd
            await _context.Parametros.AddAsync(parametro);
            //guarda los cambios
            await _context.SaveChangesAsync();
            await _bitacora.AgregarRegistro("Creó", "Parametros");
            return Ok();
        }
    }
}
