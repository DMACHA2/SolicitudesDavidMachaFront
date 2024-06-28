using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SistemaSolicitud.BLL.Servicios.Contrato;
using SistemaSolicitud.DTO;
using SistemaSolicitud.API.Utilidad;

namespace SistemaSolicitud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudesController : ControllerBase
    {
        private readonly ISolicitudesService _solicitudesService;

        public SolicitudesController(ISolicitudesService solicitudesService)
        {
            _solicitudesService = solicitudesService;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<SolicitudesDTO>>();
            try
            {
                rsp.status = true;
                rsp.Value = await _solicitudesService.Lista();
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> Crear([FromBody] SolicitudesDTO solicitud)
        {
            var rsp = new Response<SolicitudesDTO>();
            try
            {
                rsp.status = true;
                rsp.Value = await _solicitudesService.Crear(solicitud);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] SolicitudesDTO solicitud)
        {
            var rsp = new Response<bool>();
            try
            {
                rsp.status = true;
                rsp.Value = await _solicitudesService.Editar(solicitud);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var rsp = new Response<bool>();
            try
            {
                rsp.status = true;
                rsp.Value = await _solicitudesService.Eliminar(id);
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
