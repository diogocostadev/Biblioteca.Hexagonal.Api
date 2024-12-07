using Biblioteca.Hexagonal.Core.Domain.Entities;
using Biblioteca.Hexagonal.Core.Domain.Ports;
using Dapper;

namespace Biblioteca.Hexagonal.Api.Persistence;


public class LivroRepositoryAdapter : IRepositoryPort
{
    private readonly Api.Persistence.DapperDbContext _dbContext;

    public LivroRepositoryAdapter(Api.Persistence.DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AdicionarAsync(Livro livro)
    {
        var query = "INSERT INTO Livros (Id, Titulo, Autor, Categoria, Disponivel) VALUES (@Id, @Titulo, @Autor, @Categoria, @Disponivel)";
        using var connection = _dbContext.CreateConnection();
        await connection.ExecuteAsync(query, livro);
    }

    public async Task<Livro> ObterPorIdAsync(Guid id)
    {
        var query = "SELECT * FROM Livros WHERE Id = @Id";
        using var connection = _dbContext.CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<Livro>(query, new { Id = id });
    }
}