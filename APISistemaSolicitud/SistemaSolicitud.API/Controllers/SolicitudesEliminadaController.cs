using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaSolicitud.BLL.Servicios.Contrato;
using SistemaSolicitud.DTO;

using SistemaSolicitud.BLL.Servicios.Contrato;
using SistemaSolicitud.DTO;
using SistemaSolicitud.API.Utilidad;

namespace SistemaSolicitud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudesEliminadaController : ControllerBase
    {

        private readonly ISolicitudesEliminadaService _solicitudesEliminadaService;

        public SolicitudesEliminadaController(ISolicitudesEliminadaService solicitudesEliminadaService)
        {
            _solicitudesEliminadaService = solicitudesEliminadaService;
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] SolicitudesEliminadasDTO solicitudEliminada)
        {
            var rsp = new Response<bool>();
            try
            {
                rsp.status = true;
                rsp.Value = await _solicitudesEliminadaService.AgregarSolicitudEliminada(solicitudEliminada);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpGet]
        [Route("Historial")]
        public async Task<IActionResult> Historial(string buscarPor, string idsolieliminada, string fechaEliminacion, string CodSolicitud)
        {
            var rsp = new Response<List<SolicitudesEliminadasDTO>>();
            try
            {
                rsp.status = true;
                rsp.Value = await _solicitudesEliminadaService.Historial(buscarPor, idsolieliminada, fechaEliminacion, CodSolicitud);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }
    }
}
