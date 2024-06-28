using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaSolicitud.DTO;

namespace SistemaSolicitud.BLL.Servicios.Contrato
{
    public interface ISolicitudesService
    {
        Task<List<SolicitudesDTO>> Lista();
        Task<SolicitudesDTO> Crear(SolicitudesDTO modelo);
        Task<bool> Editar(SolicitudesDTO modelo);
        Task<bool> Eliminar(int id);

    }
}
