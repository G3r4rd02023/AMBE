using AMBE.Data;

namespace AMBE.Services
{
    public interface IServicioBitacora
    {
        Task<Bitacora> AgregarRegistro(string tipoAccion, string tabla);
    }
}
