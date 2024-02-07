using System;
using System.Collections.Generic;

namespace AMBE.Data;

public partial class Bitacora
{
    public int IdBitacora { get; set; }

    public int IdUsuario { get; set; }

    public int IdInstituto { get; set; }

    public string? TipoAccion { get; set; }

    public string? Tabla { get; set; }

    public DateTime? Fecha { get; set; }

    //public virtual Institutos IdInstitutoNavigation { get; set; } = null!;

    //public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
