using RRP.Repositories.Repositorie;
using RRP.Services;
using Microsoft.Extensions.DependencyInjection;

namespace RRP.Ioc
{
    public class ContainerDependencia
    {
        public static void RegistrarServicos(IServiceCollection services)
        {
            //repositorios
            services.AddScoped<UsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<ProdutoRepositorio, ProdutoRepositorio>();

            //services
            services.AddScoped<UsuarioService, UsuarioService>();
            services.AddScoped<AutorizacaoService, AutorizacaoService>();
            services.AddScoped<ProdutoService, ProdutoService>();
        }
    }
}