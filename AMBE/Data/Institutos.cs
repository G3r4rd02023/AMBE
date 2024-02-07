using System;
using System.Collections.Generic;

namespace AMBE.Data;

public partial class Institutos
{
    public int IdInstituto { get; set; }

    public string? NombreInstituto { get; set; }

    public string? Rtn { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? Email { get; set; }

    public string? Descripcion { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    //public virtual ICollection<Bitacora> Bitacora { get; set; } = new List<Bitacora>();

    //public virtual ICollection<Objetos> Objetos { get; set; } = new List<Objetos>();

    //public virtual ICollection<Permisos> Permisos { get; set; } = new List<Permisos>();

    //public virtual ICollection<Personas> Personas { get; set; } = new List<Personas>();

    //public virtual ICollection<Roles> Roles { get; set; } = new List<Roles>();

    //public virtual ICollection<TipoPersonas> TipoPersonas { get; set; } = new List<TipoPersonas>();

    //public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();

    //public virtual ICollection<Roles> IdRol { get; set; } = new List<Roles>();

    //public virtual ICollection<Usuarios> IdUsuario { get; set; } = new List<Usuarios>();
}
