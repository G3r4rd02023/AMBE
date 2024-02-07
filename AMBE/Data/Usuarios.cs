using System;
using System.Collections.Generic;

namespace AMBE.Data;

public partial class Usuarios
{
    public int IdUsuario { get; set; }

    public int? IdPersona { get; set; }

    public string? Usuario { get; set; }

    public int? IdInstituto { get; set; }

    public string? NombreUsuario { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Contraseña { get; set; }

    public string? Estado { get; set; }

    public int? IdRol { get; set; }

    public DateTime? FechaUltimaConexion { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    //public virtual ICollection<Bitacora> Bitacora { get; set; } = new List<Bitacora>();

    //public virtual Institutos? IdInstituto1 { get; set; }

    //public virtual Personas? IdPersonaNavigation { get; set; }

    //public virtual Roles? IdRolNavigation { get; set; }

    //public virtual ICollection<Parametros> Parametros { get; set; } = new List<Parametros>();

    //public virtual ICollection<Institutos> IdInstitutoNavigation { get; set; } = new List<Institutos>();
}
