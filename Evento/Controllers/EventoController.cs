using Evento.Repositories.Interfaces;
using Evento.Services.Cadastro;
using Microsoft.AspNetCore.Mvc;

namespace Evento.Controllers;

[ApiController]
[Route("eventos")]
public class EventoController : ControllerBase
{
    private readonly IEventoCadastroService _eventoCadastroService;
    private readonly IEVENTOS_REPOSITORY _eventos_repository;

    public EventoController(IEventoCadastroService eventoCadastroService, IEVENTOS_REPOSITORY eventos_repository)
    {
        _eventoCadastroService = eventoCadastroService;
        _eventos_repository = eventos_repository;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(EventoCadastroDTO dto)
    {
        var result = await _eventoCadastroService.CadastrarAsync(dto);

        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _eventos_repository.GetAllAsync();
        return Ok(result);
    }

    [HttpDelete]
    public async Task <IActionResult> Deletar(int id)
    {
        await _eventos_repository.DeleteAsync(id);
        return Ok();
    }
}
