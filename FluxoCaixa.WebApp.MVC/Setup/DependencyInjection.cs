using FluxoCaixa.Lancamentos.Application.Services;
using FluxoCaixa.Lancamentos.Data.Repository;
using FluxoCaixa.Lancamentos.Domain;

namespace FluxoCaixa.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();
            services.AddScoped<ILancamentoAppService, LancamentoAppService>();
        }
    }
}