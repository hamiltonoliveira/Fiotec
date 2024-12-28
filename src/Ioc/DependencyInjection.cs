using Application.Interfaces;
using Application.services;
using Infrastructure;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraStructure(this IServiceCollection service, IConfiguration Configuration)
        {
            service.AddScoped<Infrastructure.Interfaces.ISolicitante, SolicitanteRepository>();
            service.AddScoped<Infrastructure.Interfaces.IRelatorio, RelatorioRepository>();
            return service;
        }

        public static IServiceCollection AddServices(this IServiceCollection service, IConfiguration Configuration)
        {
            service.AddScoped<Application.Interfaces.ISolicitante, SolicitanteService>();
            service.AddScoped<Application.Interfaces.IRelatorioService, RelatorioService>();
            return service;
        }
    }
}
