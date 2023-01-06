using Business.Notificacoes;
using Domain.Interfaces;
using Treinamentos.Api.Extensions;

namespace Treinamentos.Api.Config
{
    public static class DepedencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            //services.AddScoped<MeuDbContext>();

            //services.AddScoped<IProdutoRepository, ProdutoRepository>();
            //services.AddScoped<IProdutoService, ProdutoService>();

           // services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            //services.AddScoped<ICategoriaService, CategoriaService>();

            services.AddScoped<INotificador, Notificador>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUser, AspNetUser>();

            return services;

        }
    }
}
