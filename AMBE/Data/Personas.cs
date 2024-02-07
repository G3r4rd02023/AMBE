using System;
using System.Collections.Generic;

namespace AMBE.Data;

public partial class Personas
{
    public int IdPersona { get; set; }

    public int IdTipoPersona { get; set; }

    public int IdInstituto { get; set; }

    public string? PrimerNombre { get; set; }

    public string? SegundoNombre { get; set; }

    public string? PrimerApellido { get; set; }

    public string? SegundoApellido { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Genero { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? Estado { get; set; }

    //public virtual Institutos IdInstitutoNavigation { get; set; } = null!;

    //public virtual TipoPersonas IdTipoPersonaNavigation { get; set; } = null!;

    //public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
}
