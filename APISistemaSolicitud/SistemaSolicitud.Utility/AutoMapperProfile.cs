using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AutoMapper;
using SistemaSolicitud.DTO;
using SistemaSolicitud.Model;

namespace SistemaSolicitud.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Solicitudes, SolicitudesEliminadasDTO>();
            CreateMap<SolicitudesEliminadasDTO, SolicitudesEliminadas>();

            #region Rol
            CreateMap<Rol,RolDTO>().ReverseMap();
            #endregion Rol

            #region Menu
            CreateMap<Menu, MenuDTO>().ReverseMap();
            #endregion Menu

            #region Usuario
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(destino =>
                destino.RolDescripcion,
                opt => opt.MapFrom(origen => origen.IdRolNavigation.Nombre)
                )
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0)
                );

            CreateMap<Usuario, SesionDTO>()
                .ForMember(destino =>
                destino.RolDescripcion,
                opt => opt.MapFrom(origen => origen.IdRolNavigation.Nombre)
                );

            CreateMap<UsuarioDTO,Usuario>()
                .ForMember(destino =>
                destino.IdRolNavigation,
                opt=>opt.Ignore()
                )
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == 1 ? true : false)
                );

            #endregion Usuario

            #region Solicitudes

            CreateMap<Solicitudes, SolicitudesDTO>()


            .ForMember(destino =>
                destino.Modificada,
                opt => opt.MapFrom(origen => origen.Modificada == true ? 1 : 0)
                )

             .ForMember(destino => destino.FechaRegistro,
             opt => opt.MapFrom(origen => origen.FechaRegistro.Value.ToString("dd/MM/yyyy")));

            CreateMap<SolicitudesDTO,Solicitudes>()
                .ForMember(destino =>
                destino.Modificada,
                opt => opt.MapFrom(origen => origen.Modificada == 1 ? true : false)
                );
            #endregion Solicitudes


            #region SolicitudesEliminadas
            CreateMap<SolicitudesEliminadas, SolicitudesEliminadasDTO>()

             .ForMember(destino => destino.FechaEliminacion,
             opt => opt.MapFrom(origen => origen.FechaEliminacion.Value.ToString("dd/MM/yyyy")));

            #endregion SolicitudesEliminadas

        }
    }
}
