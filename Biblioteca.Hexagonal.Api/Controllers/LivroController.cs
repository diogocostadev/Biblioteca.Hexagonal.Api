using Biblioteca.Hexagonal.Core.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Hexagonal.Api.Controllers;

[ApiController]
[Route("api/livros")]
public class LivroController : ControllerBase
{
    private readonly CadastrarLivroUseCase _cadastrarUseCase;
    private readonly ConsultarLivroUseCase _consultarUseCase;

    public LivroController(CadastrarLivroUseCase cadastrarUseCase, ConsultarLivroUseCase consultarUseCase)
    {
        _cadastrarUseCase = cadastrarUseCase;
        _consultarUseCase = consultarUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarLivro([FromBody] LivroDto dto)
    {
        await _cadastrarUseCase.Execute(dto.Titulo, dto.Autor, dto.Categoria);
        return Ok(new { Mensagem = "Livro cadastrado com sucesso." });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> ConsultarLivro(Guid id)
    {
        var livro = await _consultarUseCase.Execute(id);
        if (livro == null)
        {
            return NotFound(new { Mensagem = "Livro não encontrado." });
        }

        return Ok(livro);
    }
}