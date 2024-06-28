using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSolicitud.DTO
{
    public class MenuDTO
    {
        public int IdMenu { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Icono { get; set; }

        public string? Url { get; set; }
    }
}
