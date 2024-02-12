using AMBE.Data;
using AMBE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosController : ControllerBase
    {
        private readonly TransportedbContext _context;
        private readonly IServicioBitacora _bitacora;

        public PermisosController(TransportedbContext context, IServicioBitacora bitacora)
        {
            _context = context;
            _bitacora = bitacora;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Permisos>>> ObtenerPermisos()
        {
            //valida que exista la tabla 
            if (_context.Permisos == null)
            {
                return NotFound();
            }
            //obtiene la lista 
            var permisos = await _context.Permisos.ToListAsync();
            await _bitacora.AgregarRegistro("Consultó", "Permisos");
            //devuelve la lista 
            return Ok(permisos);
        }

        [HttpPost]
        public async Task<ActionResult<Permisos>> CrearPermisos(Permisos permiso)
        {
            //agrega el nuevo permiso a la bd
            await _context.Permisos.AddAsync(permiso);
            //guarda los cambios
            await _context.SaveChangesAsync();
            await _bitacora.AgregarRegistro("Creó", "Permisos");
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarPermiso(int id, Permisos permiso)
        {
            if (id != permiso.IdPermiso)
            {
                return BadRequest();
            }
            //actualiza el permiso
            _context.Entry(permiso).State = EntityState.Modified;
            //guarda los cambios en bd           
            await _context.SaveChangesAsync();
            await _bitacora.AgregarRegistro("Actualizó", "Permisos");
            return Ok();
        }
    }
}
