using ApiPonto.Repositories.Repositorio;
using ApiPonto.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ApiPonto.Ioc
{
    public class ContainerDependencia
    {
        public static void RegistrarServicos(IServiceCollection services)
        {
            //repositorios
            services.AddScoped<CargoRepositorio, CargoRepositorio>();
            services.AddScoped<EquipeRepositorio, EquipeRepositorio>();
            services.AddScoped<FuncionarioRepositorio, FuncionarioRepositorio>();
            services.AddScoped<LiderancaRepositorio, LiderancaRepositorio>();
            services.AddScoped<PontoRepositorio, PontoRepositorio>();
            services.AddScoped<UsuarioRepositorio, UsuarioRepositorio>();

            //services
            services.AddScoped<CargoService, CargoService>();
            services.AddScoped<EquipeService, EquipeService>();
            services.AddScoped<FuncionarioService, FuncionarioService>();
            services.AddScoped<LiderancaService, LiderancaService>();
            services.AddScoped<PontoService, PontoService>();
            services.AddScoped<UsuarioService, UsuarioService>();
            services.AddScoped<AutorizacaoService, AutorizacaoService>();
        }
    }
}