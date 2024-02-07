using System;
using System.Collections.Generic;

namespace AMBE.Data;

public partial class Permisos
{
    public int IdPermiso { get; set; }

    public int IdRol { get; set; }

    public int IdObjeto { get; set; }

    public int IdInstituto { get; set; }

    public string? Permiso { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    //public virtual Institutos IdInstitutoNavigation { get; set; } = null!;

    //public virtual Objetos IdObjetoNavigation { get; set; } = null!;

    //public virtual Roles IdRolNavigation { get; set; } = null!;
}
