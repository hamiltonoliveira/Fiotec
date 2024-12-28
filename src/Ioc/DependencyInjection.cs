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
            service.AddScoped<IRelatorioRepository, RelatorioRepository>();
            service.AddScoped<ISolicitante, SolicitanteRepository>();
            return service;
        }

        public static IServiceCollection AddServices(this IServiceCollection service, IConfiguration Configuration)
        {
            service.AddScoped<IRelatorioService, RelatorioService>();
            service.AddScoped<ISolicitanteService, SolicitanteService>();
            return service;
        }
    }
}
