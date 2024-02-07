using System;
using System.Collections.Generic;

namespace AMBE.Data;

public partial class Objetos
{
    public int IdObjeto { get; set; }

    public int? IdInstituto { get; set; }

    public string? Objeto { get; set; }

    public string? Descripcion { get; set; }

    public string? TipoObjeto { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? FechaDeCreacion { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? FechaDeModificacion { get; set; }

    //public virtual Institutos? IdInstitutoNavigation { get; set; }

    //public virtual ICollection<Permisos> Permisos { get; set; } = new List<Permisos>();
}
