using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaSolicitud.DAL.DBContext;

using SistemaSolicitud.DAL.Repositorios.Contrato;
using SistemaSolicitud.DAL.Repositorios;

using SistemaSolicitud.Utility;
using SistemaSolicitud.BLL.Servicios.Contrato;
using SistemaSolicitud.BLL.Servicios;
using System.ComponentModel.Design;
namespace SistemaSolicitud.IOC
{
    public static class Dependencia
    {

        public static void InyectarDependencias(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<DbSolicitudesContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("cadenaSQL"));
            });


            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddAutoMapper(typeof(AutoMapperProfile));



            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ISolicitudesService, SolicitudesService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<ISolicitudesEliminadaService, SolicitudesEliminadaService>();





        }

    }
}
