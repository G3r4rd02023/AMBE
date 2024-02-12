using AMBE.Data;
using AMBE.Models;

namespace AMBE.Services
{
    public interface IServicioUsuario
    {
        Task<Usuarios> CrearUsuario(PersonaViewModel model);

    }
}
