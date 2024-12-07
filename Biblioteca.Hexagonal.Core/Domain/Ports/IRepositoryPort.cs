using Biblioteca.Hexagonal.Core.Domain.Entities;

namespace Biblioteca.Hexagonal.Core.Domain.Ports;

public interface IRepositoryPort
{
    Task AdicionarAsync(Livro livro);
    Task<Livro> ObterPorIdAsync(Guid id);
}