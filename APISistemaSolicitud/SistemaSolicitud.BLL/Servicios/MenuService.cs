using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using SistemaSolicitud.BLL.Servicios.Contrato;
using SistemaSolicitud.DAL.Repositorios.Contrato;
using SistemaSolicitud.DTO;
using SistemaSolicitud.Model;

namespace SistemaSolicitud.BLL.Servicios
{
    public class MenuService:IMenuService
    {
        private readonly IGenericRepository<Usuario> _usuariolRepositorio;
        private readonly IGenericRepository<MenuRol> _menurolRepositorio;
        private readonly IGenericRepository<Menu> _menuRepositorio;
        private readonly IMapper _mapper;

        public MenuService(IGenericRepository<Usuario> usuariolRepositorio, IGenericRepository<MenuRol> menurolRepositorio, IGenericRepository<Menu> menuRepositorio, IMapper mapper)
        {
            _usuariolRepositorio = usuariolRepositorio;
            _menurolRepositorio = menurolRepositorio;
            _menuRepositorio = menuRepositorio;
            _mapper = mapper;
        }

        public async Task<List<MenuDTO>> Lista(int idUsuario)
        {
            IQueryable<Usuario> tbUsuario = await _usuariolRepositorio.Consultar(u => u.IdUsuario == idUsuario);
            IQueryable<MenuRol> tbMenuRol = await _menurolRepositorio.Consultar();
            IQueryable<Menu> tbMenu =await _menuRepositorio.Consultar();

            try
            {
                IQueryable<Menu>tbResultado =(from u in tbUsuario
                                              join mr in tbMenuRol on u.IdRol equals mr.IdRol
                                              join m in tbMenu on mr.IdMenu equals m.IdMenu
                                              select m).AsQueryable();

                var listaMenus = tbResultado.ToList();
                return _mapper.Map<List<MenuDTO>>(listaMenus);  
                    
            }
            catch
            {
                throw;
            }

        }
    }
}
