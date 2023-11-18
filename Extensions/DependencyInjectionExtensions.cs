using MedControl.Data.Repositories;
using MedControl.Data.Repositories.Abstractions;

namespace MedControl.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void ConfigRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            services.AddScoped<IEstoqueRepository, EstoqueRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IMedicamentoRepository, MedicamentoRepository>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();
            services.AddScoped<IUnidadeTrabalhoRepository, UnidadeTrabalhoRepository>();
        }
    }
}
