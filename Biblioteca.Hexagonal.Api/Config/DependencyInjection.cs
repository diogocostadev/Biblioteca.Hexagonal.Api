
using Biblioteca.Hexagonal.Api.Persistence;
using Biblioteca.Hexagonal.Core.Application.UseCases;
using Biblioteca.Hexagonal.Core.Domain.Ports;

namespace Biblioteca.Hexagonal.Api.Config;

public static class DependencyInjection
{
    public static IServiceCollection AddHexagonalDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // Adicionar o DapperDbContext
        services.AddSingleton<DapperDbContext>();
        
        // Registrar os adaptadores
        services.AddScoped<IRepositoryPort, LivroRepositoryAdapter>();

        // Registrar os casos de uso
        services.AddScoped<CadastrarLivroUseCase>();
        services.AddScoped<ConsultarLivroUseCase>();

        return services;
    }
}