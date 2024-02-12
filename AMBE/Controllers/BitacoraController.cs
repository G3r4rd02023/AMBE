using AMBE.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitacoraController : ControllerBase
    {
        private readonly TransportedbContext _context;

        public BitacoraController(TransportedbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bitacora>>> VerBitacora()
        {
            //valida que exista la tabla 
            if (_context.Bitacora == null)
            {
                return NotFound();
            }
            //obtiene los reigstros de bitacora 
            var bitacora = await _context.Bitacora.ToListAsync();
            //devuelve la lista de todos los registros
            return Ok(bitacora);
        }
    }
}
