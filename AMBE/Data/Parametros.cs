using System;
using System.Collections.Generic;

namespace AMBE.Data;

public partial class Parametros
{
    public int IdParametro { get; set; }

    public string? Parametro { get; set; }

    public string? Valor { get; set; }

    public int IdUsuario { get; set; }

    //public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
