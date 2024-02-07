using System;
using System.Collections.Generic;

namespace AMBE.Data;

public partial class Roles
{
    public int IdRol { get; set; }

    public int? IdInstituto { get; set; }

    public string? Descripcion { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    //public virtual Institutos? IdInstituto1 { get; set; }

    //public virtual ICollection<Permisos> Permisos { get; set; } = new List<Permisos>();

    //public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();

    //public virtual ICollection<Institutos> IdInstitutoNavigation { get; set; } = new List<Institutos>();
}
