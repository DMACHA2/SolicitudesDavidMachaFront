using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaSolicitud.DTO;

namespace SistemaSolicitud.BLL.Servicios.Contrato
{
    public interface ISolicitudesEliminadaService
    {
        Task<bool> AgregarSolicitudEliminada(SolicitudesEliminadasDTO solicitudEliminada);
        Task<List<SolicitudesEliminadasDTO>> Historial(string buscarPor, string idsolieliminada, string fechaEliminacion, string CodSolicitud);
    }
}
