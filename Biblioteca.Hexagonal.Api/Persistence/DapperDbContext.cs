using System.Data;
using Microsoft.Data.SqlClient;

namespace Biblioteca.Hexagonal.Api.Persistence;

public class DapperDbContext
{
    private readonly string _connectionString;

    public DapperDbContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}