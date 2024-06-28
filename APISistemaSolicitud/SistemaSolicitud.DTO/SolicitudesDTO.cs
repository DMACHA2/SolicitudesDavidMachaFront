using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSolicitud.DTO
{
    public class SolicitudesDTO
    {
        public int SolicitudId { get; set; }

        public string? FechaRegistro { get; set; }

        public int? UsuarioId { get; set; }

        public string? CodigoSolicitud { get; set; } = null!;

        public string? DetalleSolicitud { get; set; }

        public int? Modificada { get; set; } 


    }
}
