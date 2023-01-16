using Business.Notificacoes;
using Data.context;
using Data.repository;
using Domain.Interfaces;
using Treinamentos.Api.Extensions;
using Treinamentos.Domain.Interfaces;
using Treinamentos.Service.Services;

namespace Treinamentos.Api.Config
{
    public static class DepedencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();

            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IAlunoService, AlunoService>();

            services.AddScoped<IDocumentoRepository, DocumentoRepository>();
            services.AddScoped<IDocumentoService, DocumentoService>();

            services.AddScoped<INotificador, Notificador>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUser, AspNetUser>();

            return services;

        }
    }
}
