using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSolicitud.DTO
{
    public class SolicitudesEliminadasDTO
    {
        public int? SolicitudEliminadaId { get; set; }

        public DateTime? FechaEliminacion { get; set; }

        public string? MotivoEliminacion { get; set; } = null!;

        public string? CodigoSolicitud { get; set; } = null!;

        public int? UsuarioSolicitanteId { get; set; }

        public int? UsuarioEliminadorId { get; set; }


        
    }
}
