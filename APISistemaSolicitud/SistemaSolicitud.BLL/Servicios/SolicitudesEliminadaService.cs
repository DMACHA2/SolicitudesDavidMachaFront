using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SistemaSolicitud.BLL.Servicios.Contrato;
using SistemaSolicitud.DAL.Repositorios.Contrato;
using SistemaSolicitud.DTO;
using SistemaSolicitud.Model;

namespace SistemaSolicitud.BLL.Servicios
{
    public class SolicitudesEliminadaService : ISolicitudesEliminadaService
    {
        private readonly IGenericRepository<SolicitudesEliminadas> _solicitudeliminadaRepositorio;
        private readonly IMapper _mapper;

        public SolicitudesEliminadaService(IGenericRepository<SolicitudesEliminadas> solicitudeliminadaRepositorio, IMapper mapper)
        {
            _solicitudeliminadaRepositorio = solicitudeliminadaRepositorio;
            _mapper = mapper;
        }

        public async Task<bool> AgregarSolicitudEliminada(SolicitudesEliminadasDTO solicitudEliminadaDTO)
        {
            var solicitudEliminadaEntity = _mapper.Map<SolicitudesEliminadas>(solicitudEliminadaDTO);
            var solicitudEliminadaCreada = await _solicitudeliminadaRepositorio.Crear(solicitudEliminadaEntity);
            return solicitudEliminadaCreada != null;
        }

        public async Task<List<SolicitudesEliminadasDTO>> Historial(string buscarPor, string idsolieliminada, string fechaEliminacion, string CodSolicitud)
        {
            var solicitudesEliminadas = await _solicitudeliminadaRepositorio.Consultar();
            var listaFiltrada = solicitudesEliminadas
                .Where(s =>
                    (string.IsNullOrEmpty(idsolieliminada) || s.SolicitudEliminadaId.ToString().Contains(idsolieliminada)) &&
                    (string.IsNullOrEmpty(fechaEliminacion) || (s.FechaEliminacion != null && s.FechaEliminacion.Value.Date.ToString("yyyy-MM-dd").Contains(fechaEliminacion))) &&
                    (string.IsNullOrEmpty(CodSolicitud) || s.CodigoSolicitud.Contains(CodSolicitud))
                )
                .ToList();

            return _mapper.Map<List<SolicitudesEliminadasDTO>>(listaFiltrada);
        }
    }
}
