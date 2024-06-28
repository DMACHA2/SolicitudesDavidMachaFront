using System;
using System.Collections.Generic;

namespace SistemaSolicitud.Model;

public partial class Solicitudes
{
    public int SolicitudId { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public int? UsuarioId { get; set; }

    public string? CodigoSolicitud { get; set; } = null!;

    public string? DetalleSolicitud { get; set; }

    public bool? Modificada { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
