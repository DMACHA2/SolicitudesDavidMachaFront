using System;
using System.Collections.Generic;

namespace SistemaSolicitud.Model;

public partial class SolicitudesEliminadas
{
    public int SolicitudEliminadaId { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public string? MotivoEliminacion { get; set; } = null!;

    public string? CodigoSolicitud { get; set; } = null!;

    public int? UsuarioSolicitanteId { get; set; }

    public int? UsuarioEliminadorId { get; set; }

    public string? DetalleSolicitud { get; set; }

    public virtual Usuario UsuarioEliminador { get; set; } = null!;

    public virtual Usuario UsuarioSolicitante { get; set; } = null!;
}
