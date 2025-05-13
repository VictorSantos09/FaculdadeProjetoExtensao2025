using Evento.Services.Cadastro;
using Microsoft.AspNetCore.Mvc;

namespace Evento.Controllers;

[ApiController]
[Route("eventos")]
public class EventoController : ControllerBase
{
    private readonly IEventoCadastroService _eventoCadastroService;

    public EventoController(IEventoCadastroService eventoCadastroService)
    {
        _eventoCadastroService = eventoCadastroService;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(EventoCadastroDTO dto)
    {
        var result = await _eventoCadastroService.CadastrarAsync(dto);

        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
