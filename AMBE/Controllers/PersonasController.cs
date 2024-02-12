using AMBE.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly TransportedbContext _context;

        public PersonasController(TransportedbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personas>>> ObtenerPersonas()
        {
            //valida que exista la tabla personas
            if (_context.Personas == null)
            {
                return NotFound();
            }
            //obtiene la lista de todos los personas
            var personas = await _context.Personas.ToListAsync();
            //devuelve la lista de todos los institutos
            return Ok(personas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personas>> BuscarPersona(int id)
        {
            //valida que exista la tabla personas
            if (_context.Personas == null)
            {
                return NotFound();
            }
            //buscar el persona en la bd, de acuerdo al Id
            var persona = await _context.Personas.FindAsync(id);

            //si no encuentra con ese id, devuelve not found 
            if (persona == null)
            {
                return NotFound();
            }
            //devuelve el encontrado
            return Ok(persona);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarPersonas(int id, Personas persona)
        {
            if (id != persona.IdPersona)
            {
                return BadRequest();
            }
            //actualizar
            _context.Entry(persona).State = EntityState.Modified;
            //guarda los cambios en bd           
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
