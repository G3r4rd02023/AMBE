using AMBE.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutosController : ControllerBase
    {
        private readonly TransportedbContext _context;

        public InstitutosController(TransportedbContext context)
        {
            _context = context;
        }

        // GET: api/Institutos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Institutos>>> GetInstitutos()
        {
            if (_context.Institutos == null)
            {
                return NotFound();
            }
            return await _context.Institutos.ToListAsync();
        }

        // GET: api/Institutos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Institutos>> GetInstitutos(int id)
        {
            if (_context.Institutos == null)
            {
                return NotFound();
            }
            var institutos = await _context.Institutos.FindAsync(id);

            if (institutos == null)
            {
                return NotFound();
            }

            return institutos;
        }

        // PUT: api/Institutos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstitutos(int id, Institutos institutos)
        {
            if (id != institutos.IdInstituto)
            {
                return BadRequest();
            }

            _context.Entry(institutos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstitutosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Institutos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Institutos>> PostInstitutos(Institutos institutos)
        {
            if (_context.Institutos == null)
            {
                return Problem("Entity set 'TransportedbContext.Institutos'  is null.");
            }
            _context.Institutos.Add(institutos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstitutos", new { id = institutos.IdInstituto }, institutos);
        }

        // DELETE: api/Institutos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstitutos(int id)
        {
            if (_context.Institutos == null)
            {
                return NotFound();
            }
            var institutos = await _context.Institutos.FindAsync(id);
            if (institutos == null)
            {
                return NotFound();
            }

            _context.Institutos.Remove(institutos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstitutosExists(int id)
        {
            return (_context.Institutos?.Any(e => e.IdInstituto == id)).GetValueOrDefault();
        }
    }
}
