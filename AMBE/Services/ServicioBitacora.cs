using AMBE.Data;
using System;

namespace AMBE.Services
{
    public class ServicioBitacora : IServicioBitacora
    {
        private readonly TransportedbContext _context;

        public ServicioBitacora(TransportedbContext context)
        {
            _context = context;
        }

        public async Task<Bitacora> AgregarRegistro( string tipoAccion, string tabla)
        {
            Bitacora bitacora = new()
            {
                IdInstituto = 1,
                TipoAccion = tipoAccion,
                Tabla = tabla,
                IdUsuario = 1,
                Fecha = DateTime.Now,
            };
            _context.Bitacora.Add(bitacora);
            await _context.SaveChangesAsync();
            return bitacora;
        }
    }
}
