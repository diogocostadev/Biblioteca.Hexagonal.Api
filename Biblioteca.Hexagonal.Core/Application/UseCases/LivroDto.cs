namespace Biblioteca.Hexagonal.Core.Application.UseCases;

public class LivroDto
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Categoria { get; set; }
    public bool Disponivel { get; set; }
}