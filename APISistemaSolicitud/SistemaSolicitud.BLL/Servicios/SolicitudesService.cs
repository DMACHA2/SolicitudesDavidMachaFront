using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaSolicitud.BLL.Servicios.Contrato;
using SistemaSolicitud.DAL.Repositorios.Contrato;
using SistemaSolicitud.DTO;
using SistemaSolicitud.Model;

namespace SistemaSolicitud.BLL.Servicios
{
    public class SolicitudesService : ISolicitudesService
    {
        private readonly IGenericRepository<Solicitudes> _solicitudRepositorio;
        private readonly IMapper _mapper;
        private readonly ISolicitudesEliminadaService _solicitudEliminadaService;

        public SolicitudesService(IGenericRepository<Solicitudes> solicitudRepositorio, IMapper mapper, ISolicitudesEliminadaService solicitudEliminadaService)
        {
            _solicitudRepositorio = solicitudRepositorio;
            _mapper = mapper;
            _solicitudEliminadaService = solicitudEliminadaService;
        }

        public async Task<List<SolicitudesDTO>> Lista()
        {
            try
            {
                var querySolicitud = await _solicitudRepositorio.Consultar();

                var listaSolicitud = querySolicitud.Include(Usuario => Usuario.Usuario).ToList();

                return _mapper.Map<List<SolicitudesDTO>>(listaSolicitud.ToList());
            }
            catch
            {
                throw;
            }
        }

        public async Task<SolicitudesDTO> Crear(SolicitudesDTO modelo)
        {
            try
            {
                var solicitudCreado = await _solicitudRepositorio.Crear(_mapper.Map<Solicitudes>(modelo));

                if (solicitudCreado.SolicitudId == 0)
                    throw new TaskCanceledException("No se pudo crear");

                return _mapper.Map<SolicitudesDTO>(solicitudCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(SolicitudesDTO modelo)
        {
            try
            {
                var solicitudModelo = _mapper.Map<Solicitudes>(modelo);
                var solicitudEncontrado = await _solicitudRepositorio.Obtener(u =>
                    u.SolicitudId == solicitudModelo.SolicitudId
                );

                if (solicitudEncontrado == null)
                    throw new TaskCanceledException("La solicitud no existe");

                solicitudEncontrado.SolicitudId = solicitudModelo.SolicitudId;
                solicitudEncontrado.FechaRegistro = solicitudModelo.FechaRegistro;
                solicitudEncontrado.UsuarioId = solicitudModelo.UsuarioId;
                solicitudEncontrado.CodigoSolicitud = solicitudModelo.CodigoSolicitud;
                solicitudEncontrado.Modificada = solicitudModelo.Modificada;

                bool respuesta = await _solicitudRepositorio.Editar(solicitudEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo editar");

                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var solicitudEncontrado = await _solicitudRepositorio.Obtener(p => p.SolicitudId == id);

                if (solicitudEncontrado == null)
                    throw new TaskCanceledException("La solicitud no existe");


                bool respuesta = await _solicitudRepositorio.Eliminar(solicitudEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo eliminar");

                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        
    }
}
