using Biblioteca.Hexagonal.Core.Domain.Entities;
using Biblioteca.Hexagonal.Core.Domain.Ports;

namespace Biblioteca.Hexagonal.Core.Application.UseCases;

public class ConsultarLivroUseCase
{
    private readonly IRepositoryPort _repository;

    public ConsultarLivroUseCase(IRepositoryPort repository)
    {
        _repository = repository;
    }

    public async Task<Livro> Execute(Guid id)
    {
        return await _repository.ObterPorIdAsync(id);
    }
}