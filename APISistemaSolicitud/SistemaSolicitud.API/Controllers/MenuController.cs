using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SistemaSolicitud.BLL.Servicios.Contrato;
using SistemaSolicitud.DTO;
using SistemaSolicitud.API.Utilidad;
using SistemaSolicitud.BLL.Servicios;

namespace SistemaSolicitud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista(int idUsuario)
        {
            var rsp = new Response<List<MenuDTO>>();
            try
            {
                rsp.status = true;
                rsp.Value = await _menuService.Lista(idUsuario);
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
