using Biblioteca.Hexagonal.Core.Domain.Entities;
using Biblioteca.Hexagonal.Core.Domain.Ports;

namespace Biblioteca.Hexagonal.Core.Application.UseCases;

public class CadastrarLivroUseCase
{
    private readonly IRepositoryPort _repository;

    public CadastrarLivroUseCase(IRepositoryPort repository)
    {
        _repository = repository;
    }

    public async Task Execute(string titulo, string autor, string categoria)
    {
        var livro = new Livro(titulo, autor, categoria);
        await _repository.AdicionarAsync(livro);
    }
}