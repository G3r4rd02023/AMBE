using System;
using System.Collections.Generic;

namespace AMBE.Data;

public partial class TipoPersonas
{
    public int IdTipoPersona { get; set; }

    public int IdInstituto { get; set; }

    public string? TipoPersona { get; set; }

    public string? Descripcion { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? Estado { get; set; }

    //public virtual Institutos IdInstitutoNavigation { get; set; } = null!;

    //public virtual ICollection<Personas> Personas { get; set; } = new List<Personas>();
}
